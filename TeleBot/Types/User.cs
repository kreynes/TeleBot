using System;
using Newtonsoft.Json;
namespace TeleBot
{
    [JsonObject]
    public class User
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public int ID { get; internal set; }

        [JsonProperty(PropertyName = "first_name", Required = Required.Always)]
        public string FirstName { get; internal set; }

        [JsonProperty(PropertyName = "last_name", Required = Required.Default)]
        public string LastName { get; internal set; }

        [JsonProperty(PropertyName = "username", Required = Required.Default)]
        public string Username { get; internal set; }
    }
}

