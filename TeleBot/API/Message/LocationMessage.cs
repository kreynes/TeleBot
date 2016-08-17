using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class LocationMessage
    {
        public LocationMessage(string chatId, float latitude, float longitude)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            ChatId = chatId;
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public string ChatId { get; set; }

        [JsonProperty(PropertyName = "latitude", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public float Longitude { get; set; }

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