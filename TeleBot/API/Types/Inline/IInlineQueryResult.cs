namespace TeleBot.API.Types.Inline
{
    public interface IInlineQueryResult
    {
        string Type { get; set; }
        string Id { get; set; }
        string Title { get; set; }
        InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}