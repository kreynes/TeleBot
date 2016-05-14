using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Update
    {
        [JsonProperty(PropertyName = "update_id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "message", Required = Required.Default)]
        public Message Message { get; set; }

        [JsonProperty(PropertyName = "callback_query", Required = Required.Default)]
        public CallbackQuery CallbackQuery { get; set; }
    }
}

