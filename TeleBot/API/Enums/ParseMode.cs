using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonConverter(typeof(ParseModeEnumConverter))]
    public enum ParseMode
    {
        Default,
        Markdown,
        HTML
    }
}

