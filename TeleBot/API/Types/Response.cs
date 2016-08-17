using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Response<T>
    {
        [JsonProperty(PropertyName = "ok", Required = Required.Always)]
        public bool Ok { get; internal set; }

        [JsonProperty(PropertyName = "description", Required = Required.Default)]
        public string Description { get; internal set; }

        [JsonProperty(PropertyName = "error_code", Required = Required.Default)]
        public int ErrorCode { get; internal set; }

        [JsonProperty(PropertyName = "result", Required = Required.Default)]
        public T Result { get; internal set; }
    }
}