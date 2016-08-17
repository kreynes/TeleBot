using Newtonsoft.Json;
using TeleBot.API.Enums;
using TeleBot.API.Extensions;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class MessageEntity
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof (MessageEntityTypeJsonConverter))]
        public MessageEntityType Type { get; internal set; }

        [JsonProperty(PropertyName = "offset", Required = Required.Always)]
        public int Offset { get; internal set; }

        [JsonProperty(PropertyName = "length", Required = Required.Always)]
        public int Length { get; internal set; }

        [JsonProperty(PropertyName = "url", Required = Required.Default)]
        public string Url { get; internal set; }

        [JsonProperty(PropertyName = "user", Required = Required.Default)]
        public User User { get; internal set; }
    }
}