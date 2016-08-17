using System;
using Newtonsoft.Json;
using TeleBot.API.Enums;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EditTextMessage : IEditMessage
    {
        public EditTextMessage(string text, string chatId = "", int messageId = 0, string inlineMessageId = "")
        {
            if (string.IsNullOrWhiteSpace(chatId) && messageId == 0 && string.IsNullOrEmpty(inlineMessageId))
                throw new ArgumentException("One of the optional parameters must be supplied!");
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Null or whitespace.", nameof(text));
            ChatId = chatId;
            MessageId = messageId;
            InlineMessageId = inlineMessageId;
            Text = text;
        }

        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "parse_mode", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ParseMode ParseMode { get; set; } = ParseMode.Default;

        [JsonProperty(PropertyName = "disable_web_page_preview", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableLinkPreview { get; set; } = false;

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; } = null;

        [JsonProperty(PropertyName = "chat_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ChatId { get; set; } = "";

        [JsonProperty(PropertyName = "message_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MessageId { get; set; }

        [JsonProperty(PropertyName = "inline_message_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string InlineMessageId { get; set; } = "";

        public string ApiMethod { get; } = "editMessageText";
    }
}