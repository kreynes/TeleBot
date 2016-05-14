using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class InlineKeyboardButton
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; internal set; }

        [JsonProperty(PropertyName = "url", Required = Required.Default)]
        public string Url { get; internal set; }

        [JsonProperty(PropertyName = "callback_data", Required = Required.Default)]
        public string CallbackData { get; internal set; }

        [JsonProperty(PropertyName = "switch_inline_query", Required = Required.Default)]
        public string SwitchInlineQuery { get; internal set; }
    }
}

