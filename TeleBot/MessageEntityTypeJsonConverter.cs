using System;
using Newtonsoft.Json;

namespace TeleBot
{
    public class MessageEntityTypeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            MessageEntityType? type = null;
            switch (enumString)
            {
                case "mention":
                    type = MessageEntityType.Mention;
                    break;
                case "hashtag":
                    type = MessageEntityType.Hashtag;
                    break;
                case "bot_command":
                    type = MessageEntityType.BotCommand;
                    break;
                case "url":
                    type = MessageEntityType.Url;
                    break;
                case "email":
                    type = MessageEntityType.Email;
                    break;
                case "bold":
                    type = MessageEntityType.Bold;
                    break;
                case "italic":
                    type = MessageEntityType.Italic;
                    break;
                case "code":
                    type = MessageEntityType.Code;
                    break;
                case "pre":
                    type = MessageEntityType.Pre;
                    break;
                case "text_link":
                    type = MessageEntityType.TextLink;
                    break;
            }
            return type;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var type = (MessageEntityType)value;
            switch (type)
            {
                case MessageEntityType.Mention:
                    writer.WriteValue("mention");
                    break;
                case MessageEntityType.Hashtag:
                    writer.WriteValue("hashtag");
                    break;
                case MessageEntityType.BotCommand:
                    writer.WriteValue("bot_command");
                    break;
                case MessageEntityType.Url:
                    writer.WriteValue("url");
                    break;
                case MessageEntityType.Email:
                    writer.WriteValue("email");
                    break;
                case MessageEntityType.Bold:
                    writer.WriteValue("bold");
                    break;
                case MessageEntityType.Italic:
                    writer.WriteValue("italic");
                    break;
                case MessageEntityType.Code:
                    writer.WriteValue("code");
                    break;
                case MessageEntityType.Pre:
                    writer.WriteValue("pre");
                    break;
                case MessageEntityType.TextLink:
                    writer.WriteValue("text_link");
                    break;
            }
        }
    }
}

