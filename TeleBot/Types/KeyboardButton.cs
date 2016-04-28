using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class KeyboardButton
    {
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; internal set; }

        [JsonProperty(PropertyName = "request_contact", Required = Required.Default)]
        public bool RequestContact { get; internal set; }

        [JsonProperty(PropertyName = "request_location", Required = Required.Default)]
        public bool RequestLocation { get; internal set; }
    }
}

