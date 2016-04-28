using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class Message
    {
        public int ID { get; set; }
        public User From { get; set; }
        public int Date { get; set; }
        public Chat Chat { get; set; }
        public User ForwardedFrom { get; set; }
        public int ForwardDate { get; set; }
        public Message ReplyToMessage { get; set; }
        public string Text { get; set; }
        public MessageEntity[] Entities { get; set }

    }
}

