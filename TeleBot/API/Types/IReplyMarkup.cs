using System;

namespace TeleBot
{
    public interface IReplyMarkup
    {
        bool Selective { get; set; }
    }
}
