using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    public interface IMessageWithReply
    {
        int ReplyToMessageId { get; set; }

        IReplyMarkup ReplyMarkup { get; set; }
    }
}