using Newtonsoft.Json;
using TeleBot.API.Extensions;

namespace TeleBot.API.Enums
{
    [JsonConverter(typeof (ParseModeEnumConverter))]
    public enum ParseMode
    {
        Default,
        Markdown,
        Html
    }
}