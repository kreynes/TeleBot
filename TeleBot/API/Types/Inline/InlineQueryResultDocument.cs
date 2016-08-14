using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InlineQueryResultDocument
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "caption", Required = Required.Always)]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "document_url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "mime_type", Required = Required.Always)]
        public string MimeType { get; set; }

        [JsonProperty(PropertyName = "description", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        [JsonProperty(PropertyName = "input_message_content", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public object InputMessageContent { get; set; }

        [JsonProperty(PropertyName = "thumb_url", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "thumb_width", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ThumbnailWidth { get; set; }

        [JsonProperty(PropertyName = "thumb_height", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ThumbnailHeight { get; set; }
    }
}
