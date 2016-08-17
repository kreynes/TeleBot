using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Location
    {
        [JsonProperty(PropertyName = "longitude", Required = Required.Always)]
        public float Longitude { get; internal set; }

        [JsonProperty(PropertyName = "latitude", Required = Required.Always)]
        public float Latitude { get; internal set; }
    }
}