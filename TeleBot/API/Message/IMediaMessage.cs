using TeleBot.API.Types;
using System.Collections.Generic;

namespace TeleBot
{
    public interface IMediaMessage
    {
        string ChatId { get; set; }
        InputFile File { get; set; }
        string ApiMethod { get; }
        Dictionary<string, object> ToParameterDictionary();
    }
}

