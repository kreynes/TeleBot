using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Audio
    {
        [JsonProperty(PropertyName = "file_id", Required = Required.Always)]
        public string FileId { get; internal set; }

        [JsonProperty(PropertyName = "duration", Required = Required.Always)]
        public int Duration { get; internal set; }

        [JsonProperty(PropertyName = "performer", Required = Required.Default)]
        public string Performer { get; internal set; }

        [JsonProperty(PropertyName = "title", Required = Required.Default)]
        public string Title { get; internal set; }

        [JsonProperty(PropertyName = "mime_type", Required = Required.Default)]
        public string MimeType { get; internal set; }

        [JsonProperty(PropertyName = "file_size", Required = Required.Default)]
        public int FileSize { get; internal set; }
    }
}