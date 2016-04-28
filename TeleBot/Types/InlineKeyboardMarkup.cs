using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class InlineKeyboardMarkup
    {
        [JsonProperty(PropertyName = "keyboard", Required = Required.Always)]
        public KeyboardButton[][] Keyboard { get; internal set; }

        [JsonProperty(PropertyName = "resize_keyboard", Required = Required.Default)]
        public bool ResizeKeyboard { get; internal set; }

        [JsonProperty(PropertyName = "one_time_keyboard", Required = Required.Default)]
        public bool OneTimeKeyboard { get; internal set; }

        [JsonProperty(PropertyName = "selective", Required = Required.Default)]
        public bool Selective { get; internal set; }
    }
}
