using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    class MessageParameters
    {
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        internal string ChatId { get; set; }

        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        internal string Text { get; set; }

        [JsonProperty(PropertyName = "parse_mode", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        internal ParseMode Mode { get; set; }

        [JsonProperty(PropertyName = "disable_web_page_preview", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        internal bool DisableWebPagePreview { get; set; }

        [JsonProperty(PropertyName = "disable_notification", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        internal bool DisableNotification { get; set; }

        [JsonProperty(PropertyName = "reply_to_message_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        internal int MessageReplyId { get; set; }

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        internal IReplyMarkup ReplyMarkup { get; set; }

    }
}