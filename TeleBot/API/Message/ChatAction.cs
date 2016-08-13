using System;
using Newtonsoft.Json;

namespace TeleBot
{
    public class ChatAction
    {
        public ChatAction(string chatId, string action)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentNullException(nameof(chatId));
            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException(nameof(action));

            ChatIdString = chatId;
            Action = action;
        }
        public ChatAction(int chatId, string action)
        {
            if (chatId == default(int))
                throw new ArgumentNullException(nameof(chatId));
            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentNullException(nameof(chatId));

            ChatIdInt = chatId;
            Action = action;
        }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ChatIdString { get; set; }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ChatIdInt { get; set; }

        [JsonProperty(PropertyName = "action", Required = Required.Always)]
        public string Action { get; set; }
    }
}

