using System;
using Newtonsoft.Json;
using TeleBot.API.Enums;

namespace TeleBot.API.Extensions
{
    public class ParseModeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return Enum.Parse(typeof(ParseMode), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!value.Equals(ParseMode.Default))
            {
                var type = (ParseMode)value;
                writer.WriteValue(type.ToString());
            }
            
        }
    }
}

