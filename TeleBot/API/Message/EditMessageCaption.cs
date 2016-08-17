using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EditMessageCaption : IEditMessage
    {
        public EditMessageCaption(string caption, string chatId = "", int messageId = 0, string inlineMessageId = "")
        {
            if (string.IsNullOrWhiteSpace(chatId) && messageId == 0 && string.IsNullOrEmpty(inlineMessageId))
                throw new ArgumentException("One of the optional parameters must be supplied!");
            if (string.IsNullOrWhiteSpace(caption))
                throw new ArgumentException("Null or whitespace.", nameof(caption));
            ChatId = chatId;
            MessageId = messageId;
            InlineMessageId = inlineMessageId;
            Caption = Caption;
        }

        [JsonProperty(PropertyName = "caption", Required = Required.Always)]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ChatId { get; set; }

        [JsonProperty(PropertyName = "message_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MessageId { get; set; }

        [JsonProperty(PropertyName = "inline_message_id", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string InlineMessageId { get; set; }

        public string ApiMethod { get; } = "editMessageCaption";
    }
}