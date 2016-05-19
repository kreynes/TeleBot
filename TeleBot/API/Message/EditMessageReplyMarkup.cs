using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EditMessageReplyMarkup : IEditMessage
    {
        public EditMessageReplyMarkup(IReplyMarkup replyMarkup, string chatId = "", int messageId = 0, string inlineMessageId = "")
        {
            if (string.IsNullOrWhiteSpace(chatId) && messageId == 0 && string.IsNullOrEmpty(inlineMessageId))
                throw new ArgumentException("One of the optional parameters must be supplied!");
            if (replyMarkup == null)
                throw new ArgumentException("Null or whitespace.", nameof(replyMarkup));
            ChatId = chatId;
            MessageId = messageId;
            InlineMessageId = inlineMessageId;
            ReplyMarkup = replyMarkup;
        }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ChatId { get; set; } = "";

        [JsonProperty(PropertyName = "message_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MessageId { get; set; } = 0;

        [JsonProperty(PropertyName = "inline_message_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string InlineMessageId { get; set; } = "";

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; } = null;

        public string ApiMethod { get; } = "editMessageCaption";
    }
}

