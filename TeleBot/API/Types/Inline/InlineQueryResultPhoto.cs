using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InlineQueryResultPhoto : IInlineQueryResult
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "photo_url", Required = Required.Always)]
        public string PhotoUrl { get; set; }

        [JsonProperty(PropertyName = "thumb_url", Required = Required.Always)]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "photo_width", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int PhotoWidth { get; set; }

        [JsonProperty(PropertyName = "photo_height", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int PhotoHeight { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "caption", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        [JsonProperty(PropertyName = "input_message_content", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public object InputMessageContent { get; set; }
    }
}
