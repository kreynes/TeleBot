using Newtonsoft.Json;

namespace TeleBot.API.Types.Inline
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InputQueryResultGif
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "gif_url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "gif_width", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "gif_height", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "thumb_url", Required = Required.Always)]
        public string ThumnailUrl { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "caption", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        [JsonProperty(PropertyName = "input_message_content", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public object InputMessageContent { get; set; }
    }
}