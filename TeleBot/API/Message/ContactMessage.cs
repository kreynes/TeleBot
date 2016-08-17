using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ContactMessage
    {
        public ContactMessage(string chatId, string phoneNumber, string firstName)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Null or whitespace", nameof(phoneNumber));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Null or whitespace", nameof(firstName));
            ChatId = chatId;
        }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public string ChatId { get; set; }

        [JsonProperty(PropertyName = "phone_number", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "first_name", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "disable_notification", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableNotification { get; set; } = false;

        [JsonProperty(PropertyName = "reply_to_message_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ReplyToMessageId { get; set; } = 0;

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; } = null;
    }
}