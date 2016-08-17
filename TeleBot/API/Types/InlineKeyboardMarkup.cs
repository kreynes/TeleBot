using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class InlineKeyboardMarkup
    {
        [JsonProperty(PropertyName = "inline_keyboard", Required = Required.Always)]
        public KeyboardButton[][] Keyboard { get; set; }
    }
}