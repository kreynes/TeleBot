using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    public class ChatMember
    {
        [JsonProperty(PropertyName = "user", Required = Required.Always)]
        public User User { get; internal set; }

        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public string Status { get; internal set; }
    }
}