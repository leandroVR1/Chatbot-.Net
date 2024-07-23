namespace apiwebhook.Models{
   public class IncomingMessage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string WaId { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
}
}