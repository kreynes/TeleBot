using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class UserProfilePhotos
    {
        [JsonProperty(PropertyName = "total_count", Required = Required.Always)]
        public int TotalCount { get; internal set; }

        [JsonProperty(PropertyName = "photos", Required = Required.Always)]
        public PhotoSize[][] Photos { get; internal set; }
    }
}
