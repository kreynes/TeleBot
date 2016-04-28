﻿using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class Voice
    {
        [JsonProperty(PropertyName = "file_id", Required = Required.Always)]
        public string FileID { get; internal set; }

        [JsonProperty(PropertyName = "duration", Required = Required.Always)]
        public int Duration { get; internal set; }

        [JsonProperty(PropertyName = "mime_type", Required = Required.Default)]
        public string MimeType { get; internal set; }

        [JsonProperty(PropertyName = "file_size", Required = Required.Default)]
        public int FileSize { get; internal set; }
    }
}

