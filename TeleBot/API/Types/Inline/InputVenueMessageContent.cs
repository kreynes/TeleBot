using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InputVenueMessageContent : IMessageContent
    {
        public InputVenueMessageContent(float latitude, float longitude, string title, string address)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Null or whitespace.", nameof(title));
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Null or whitespace.", nameof(address));
            Latitude = latitude;
            Longitude = longitude;
            Title = title;
            Address = address;
        }
        [JsonProperty(PropertyName = "latitude", Required = Required.Always)]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude", Required = Required.Always)]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "address", Required = Required.Always)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "foursquare_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string FoursquareId { get; set; }
    }
}

