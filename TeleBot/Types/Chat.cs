using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class Chat
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public int ID { get; internal set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        [JsonConverter(typeof(ChatTypeEnumConverter))]
        public ChatType Type { get; internal set; }

        [JsonProperty(PropertyName = "id", Required = Required.Default)]
        public string Title { get; internal set; }

        [JsonProperty(PropertyName = "id", Required = Required.Default)]
        public string Username { get; internal set; }

        [JsonProperty(PropertyName = "id", Required = Required.Default)]
        public string FirstName { get; internal set; }

        [JsonProperty(PropertyName = "id", Required = Required.Default)]
        public string LastName { get; internal set; }
    }
}

