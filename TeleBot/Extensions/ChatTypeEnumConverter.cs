using System;
using Newtonsoft.Json;

namespace TeleBot
{
    public class ChatTypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return Enum.Parse(typeof(ChatType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var type = (ChatType)value;
            writer.WriteValue(type.ToString().ToLower());
        }
    }
}

