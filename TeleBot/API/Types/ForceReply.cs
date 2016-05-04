using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class ForceReply : IReplyMarkup
    {
        [JsonProperty(PropertyName = "force_reply", Required = Required.Always)]
        public bool Force { get; set; }

        [JsonProperty(PropertyName = "selective", Required = Required.Default)]
        public bool Selective { get; set; }
    }
}

