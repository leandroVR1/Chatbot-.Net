using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace apiwebhook.Models
{

public class WebhookPayload
{
    [JsonPropertyName("entry")]
    public List<Entry> Entries { get; set; }
}

public class Entry
{
    [JsonPropertyName("changes")]
    public List<Change> Changes { get; set; }
}

public class Change
{
    [JsonPropertyName("value")]
    public Value Value { get; set; }
}

public class Value
{
    [JsonPropertyName("messages")]
    public List<Message> Messages { get; set; }
    
    [JsonPropertyName("contacts")]
    public List<Contact> Contacts { get; set; }
}

public class Message
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("text")]
    public Text? Text { get; set; }

    [JsonPropertyName("interactive")]
    public Interactive? Interactive { get; set; }

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }

    [JsonPropertyName("from")]
    public string From { get; set; }
}

public class Text
{
    [JsonPropertyName("body")]
    public string Body { get; set; }
}

public class Interactive
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("button_reply")]
    public ButtonReply ButtonReply { get; set; }
    
}

public class ButtonReply
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
}

public class Contact
{
    [JsonPropertyName("profile")]
    public Profile Profile { get; set; }

    [JsonPropertyName("wa_id")]
    public string WaId { get; set; }
}

public class Profile
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

    
}
