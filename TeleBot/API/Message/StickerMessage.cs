using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class StickerMessage : IMediaMessage
    {
        public StickerMessage(string chatId, InputFile sticker)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (sticker == null)
                throw new ArgumentNullException(nameof(sticker));
            ChatId = chatId;
            File = sticker; //TODO Refactor
        }

        public StickerMessage(string chatId, string fileId)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (string.IsNullOrWhiteSpace(fileId))
                throw new ArgumentNullException(nameof(fileId));
            ChatId = chatId;
            FileId = fileId;
        }

        [JsonProperty(PropertyName = "sticker", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "disable_notification", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableNotification { get; set; } = false;

        [JsonProperty(PropertyName = "reply_to_message_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ReplyToMessageId { get; set; } = 0;

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; } = null;

        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public string ChatId { get; set; }

        [JsonProperty(PropertyName = "sticker", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InputFile File { get; set; }

        public string ApiMethod { get; } = "sendSticker";

        public Dictionary<string, object> ToParameterDictionary()
        {
            return new Dictionary<string, object>
            {
                {"chat_id", ChatId},
                {"sticker", File ?? (object) FileId},
                {"disable_notification", DisableNotification},
                {"reply_to_message_id", ReplyToMessageId},
                {"reply_markup", ReplyMarkup}
            };
        }
    }
}