using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        [JsonProperty(PropertyName = "keyboard", Required = Required.Always)]
        public KeyboardButton[] Keyboard { get; internal set; }

        [JsonProperty(PropertyName = "resize_keyboard", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool ResizeKeyboard { get; internal set; }

        [JsonProperty(PropertyName = "one_time_keyboard", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool OneTimeKeyboard { get; internal set; }

        [JsonProperty(PropertyName = "selective", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool Selective { get; set; }
    }
}