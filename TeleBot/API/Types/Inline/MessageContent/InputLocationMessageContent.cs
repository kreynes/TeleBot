using Newtonsoft.Json;

namespace TeleBot.API.Types.Inline.MessageContent
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InputLocationMessageContent
    {
        public InputLocationMessageContent(float latitude, float longitude)
        {
            //TODO add float validation of sorts
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonProperty(PropertyName = "message_text", Required = Required.Always)]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "parse_mode", Required = Required.Always)]
        public float Longitude { get; set; }
    }
}