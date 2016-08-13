using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class ReplyKeyboardHide : IReplyMarkup
    {
        [JsonProperty(PropertyName = "hide_keyboard", Required = Required.Always)]
        public bool HideKeyboard { get; set; }

        [JsonProperty(PropertyName = "selective", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool Selective { get; set; }
    }
}

