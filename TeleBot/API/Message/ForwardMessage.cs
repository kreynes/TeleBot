using System;
using Newtonsoft.Json;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ForwardMessage : IMessage
    {
        public ForwardMessage(string chatId, string fromChatId, int messageId)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (string.IsNullOrWhiteSpace(fromChatId))
                throw new ArgumentException("Null or whitespace.", nameof(fromChatId));
            ChatId = chatId;
            FromChatId = fromChatId;
            MessageId = messageId;
        }
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public string ChatId { get; set; }

        [JsonProperty(PropertyName = "from_chat_id", Required = Required.Always)]
        public string FromChatId { get; set; }

        [JsonProperty(PropertyName = "disable_notification", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableNotification { get; set; } = false;

        [JsonProperty(PropertyName = "message_id", Required = Required.Always)]
        public int MessageId { get; set; }
    }
}

