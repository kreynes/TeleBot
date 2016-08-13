using Newtonsoft.Json;
using TeleBot.API.Enums;
using TeleBot.API.Extensions;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Chat
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public long Id { get; internal set; }

        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(ChatTypeEnumConverter))]
        public ChatType Type { get; internal set; }

        [JsonProperty(PropertyName = "title", Required = Required.Default)]
        public string Title { get; internal set; }

        [JsonProperty(PropertyName = "username", Required = Required.Default)]
        public string Username { get; internal set; }

        [JsonProperty(PropertyName = "first_name", Required = Required.Default)]
        public string FirstName { get; internal set; }

        [JsonProperty(PropertyName = "last_name", Required = Required.Default)]
        public string LastName { get; internal set; }
    }
}

