using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        [JsonProperty(PropertyName = "keyboard", Required = Required.Always)]
        public KeyboardButton[] Keyboard { get; set; }

        [JsonProperty(PropertyName = "resize_keyboard", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool ResizeKeyboard { get; set; }

        [JsonProperty(PropertyName = "one_time_keyboard", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool OneTimeKeyboard { get; set; }

        [JsonProperty(PropertyName = "selective", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool Selective { get; set; }
    }
}

