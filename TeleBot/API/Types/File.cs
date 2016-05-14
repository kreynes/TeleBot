using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class File
    {
        [JsonProperty(PropertyName = "file_id", Required = Required.Always)]
        public string Id { get; internal set; }

        [JsonProperty(PropertyName = "file_size", Required = Required.Default)]
        public int Size { get; internal set; }

        [JsonProperty(PropertyName = "file_path", Required = Required.Default)]
        public int Path { get; internal set; }
    }
}

