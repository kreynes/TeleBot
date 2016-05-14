using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Venue
    {
        [JsonProperty(PropertyName = "location", Required = Required.Always)]
        public Location Location { get; internal set; }

        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; internal set; }

        [JsonProperty(PropertyName = "address", Required = Required.Always)]
        public string Address { get; internal set; }

        [JsonProperty(PropertyName = "foursquare_id", Required = Required.Default)]
        public string FoursquareId { get; internal set; }
    }
}

