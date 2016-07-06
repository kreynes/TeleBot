using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InputContactMessageContent : IMessageContent
    {
        public InputContactMessageContent(string phoneNumber, string firstName)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Null or whitespace.", nameof(phoneNumber));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Null or whitespace.", nameof(firstName));
            PhoneNumber = phoneNumber;
            FirstName = firstName;
        }

        [JsonProperty(PropertyName = "phone_number", Required = Required.Always)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "first_name", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string LastName { get; set; }
    }
}

