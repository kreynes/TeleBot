namespace TeleBot.API.Message
{
    public interface IMessage
    {
        string ChatId { get; set; }
        
        bool DisableNotification { get; set; }
    }
}