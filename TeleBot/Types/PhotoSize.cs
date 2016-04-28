using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class PhotoSize
    {
        [JsonProperty(PropertyName = "file_id", Required = Required.Always)]
        public string FileId { get; internal set; }

        [JsonProperty(PropertyName = "width", Required = Required.Always)]
        public int Width { get; internal set; }

        [JsonProperty(PropertyName = "height", Required = Required.Always)]
        public int Height { get; internal set; }

        [JsonProperty(PropertyName = "file_size", Required = Required.Default)]
        public int FileSize { get; internal set; }
    }
}

