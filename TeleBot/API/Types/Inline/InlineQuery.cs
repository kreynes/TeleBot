using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InlineQuery
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "from", Required = Required.Always)]
        public User Sender { get; set; }

        [JsonProperty(PropertyName = "location", Required = Required.Default)]
        public Location Location { get; set; }

        [JsonProperty(PropertyName = "query", Required = Required.Always)]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "offset", Required = Required.Always)]
        public string Offset { get; set; }
    }
}

