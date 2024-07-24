using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiwebhook.Data;
using apiwebhook.Models;

namespace apiwebhook.Controllers
{
    [ApiController]
    [Route("/webhook")]
    public class Apiweb : ControllerBase
    {
        private readonly BaseContext _context;

        public Apiweb(BaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] WebhookPayload jsoncontent)
        {
            try
            {
                var entry = jsoncontent.Entries?[0];
                var change = entry?.Changes?[0];
                var value = change?.Value;
                var message = value?.Messages?[0];

                if (message == null)
                {
                    return BadRequest("Message content is missing");
                }

                string messageText = null;
                string buttonId = null;

                if (message.Type == "text" && message.Text != null)
                {
                    messageText = message.Text.Body;
                }
                else if (message.Type == "interactive" && message.Interactive?.Type == "button_reply")
                {
                    buttonId = message.Interactive.ButtonReply?.Id;
                    messageText = "[Interactive Message]"; 
                }
                else
                {
                    return BadRequest("Unsupported message type or missing fields");
                }

                var incomingMessage = new IncomingMessage
                {
                    Name = value?.Contacts?[0].Profile?.Name,
                    WaId = value?.Contacts?[0].WaId,
                    Message = messageText,
                    ButtonId = buttonId,
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(message.Timestamp)).DateTime
                };

                _context.IncomingMessages.Add(incomingMessage);
                await _context.SaveChangesAsync();

                return "Message saved to database!";
            }
            catch (Exception ex)
            {
                return BadRequest($"Error processing webhook: {ex.Message}");
            }
        }
    }
}
