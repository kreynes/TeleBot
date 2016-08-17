using Newtonsoft.Json;

namespace TeleBot.API.Types.Inline
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InlineQueryResultArticle : IInlineQueryResult
    {
        [JsonProperty(PropertyName = "input_message_content", Required = Required.Always)]
        public object InputMessageContent { get; set; }

        [JsonProperty(PropertyName = "url", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "hide_url", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool HideUrl { get; set; }

        [JsonProperty(PropertyName = "description", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "thumb_url", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "thumb_url", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ThumbnailWidth { get; set; }

        [JsonProperty(PropertyName = "thumb_url", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ThumbnailHeight { get; set; }

        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}