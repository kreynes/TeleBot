using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Contact
    {
        [JsonProperty(PropertyName = "phone_number", Required = Required.Always)]
        public string PhoneNumber { get; internal set; }

        [JsonProperty(PropertyName = "first_name", Required = Required.Always)]
        public string FirstName { get; internal set; }

        [JsonProperty(PropertyName = "last_name", Required = Required.Default)]
        public string LastName { get; internal set; }

        [JsonProperty(PropertyName = "user_id", Required = Required.Default)]
        public int UserId { get; internal set; }
    }
}

