using System;
using TeleBot.API.Types;

namespace TeleBot
{
    public interface IInlineQueryResult
    {
        string Type { get; set; }
        string Id { get; set; }
        string Title { get; set; }
        InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}

