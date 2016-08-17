using System.Collections.Generic;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    public interface IMediaMessage
    {
        string ChatId { get; set; }
        InputFile File { get; set; }
        string ApiMethod { get; }
        Dictionary<string, object> ToParameterDictionary();
    }
}