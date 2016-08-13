using System;
using Newtonsoft.Json;
using TeleBot.API.Enums;

namespace TeleBot
{

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InputTextMessageContent
    {
        public InputTextMessageContent(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Null or whitespace.", nameof(text));
            Text = text;
        }
        [JsonProperty(PropertyName = "message_text", Required = Required.Always)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "parse_mode", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ParseMode ParseMode { get; set; } = ParseMode.Default;

        [JsonProperty(PropertyName = "disable_web_page_preview", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableLinkPreview { get; set; } = false;
    }
}

