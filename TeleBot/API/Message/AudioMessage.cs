using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AudioMessage : IMessageWithReply
    {
        public AudioMessage(string chatId, InputFile audio)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (audio == null)
                throw new ArgumentNullException(nameof(audio));
            ChatId = chatId;
            Audio = audio;
        }

        public AudioMessage(string chatId, string fileId)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (string.IsNullOrWhiteSpace(fileId))
                throw new ArgumentNullException(nameof(fileId));
            ChatId = chatId;
            FileId = fileId;
        }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public string ChatId { get; set; }

        [JsonProperty(PropertyName = "audio", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InputFile Audio { get; set; }

        [JsonProperty(PropertyName = "audio", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "duration", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Duration { get; set; } = 0;

        [JsonProperty(PropertyName = "performer", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Performer { get; set; } = "";

        [JsonProperty(PropertyName = "title", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Title { get; set; } = "";

        [JsonProperty(PropertyName = "disable_notification", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableNotification { get; set; } = false;

        [JsonProperty(PropertyName = "reply_to_message_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ReplyToMessageId { get; set; } = 0;

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; } = null;
    }
}
