using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class CallbackQuery
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; internal set; }

        [JsonProperty(PropertyName = "from", Required = Required.Always)]
        public User From { get; internal set; }

        [JsonProperty(PropertyName = "message", Required = Required.Default)]
        public Message Message { get; internal set; }

        [JsonProperty(PropertyName = "inline_message_id", Required = Required.Default)]
        public string InlineMessageId { get; internal set; }

        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public string Data { get; internal set; }
    }
}

