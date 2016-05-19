using System;
namespace TeleBot
{
    public interface IEditMessage
    {
        string ChatId { get; set; }
        int MessageId { get; set; }
        string InlineMessageId { get; set; }
        string ApiMethod { get; }
    }
}

