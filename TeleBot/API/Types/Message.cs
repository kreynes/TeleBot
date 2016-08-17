using Newtonsoft.Json;

namespace TeleBot.API.Types
{
    [JsonObject]
    public class Message
    {
        [JsonProperty(PropertyName = "message_id", Required = Required.Always)]
        public int Id { get; internal set; }

        [JsonProperty(PropertyName = "from", Required = Required.Default)]
        public User From { get; internal set; }

        [JsonProperty(PropertyName = "date", Required = Required.Always)]
        public int Date { get; internal set; }

        [JsonProperty(PropertyName = "chat", Required = Required.Always)]
        public Chat Chat { get; internal set; }

        [JsonProperty(PropertyName = "forward_from", Required = Required.Default)]
        public User ForwardFrom { get; internal set; }

        [JsonProperty(PropertyName = "forward_from_chat", Required = Required.Default)]
        public Chat ForwardFromChat { get; internal set; }

        [JsonProperty(PropertyName = "forward_date", Required = Required.Default)]
        public int ForwardDate { get; internal set; }

        [JsonProperty(PropertyName = "reply_to_message", Required = Required.Default)]
        public Message ReplyToMessage { get; internal set; }

        [JsonProperty(PropertyName = "edit_date", Required = Required.Default)]
        public int EditDate { get; internal set; }

        [JsonProperty(PropertyName = "text", Required = Required.Default)]
        public string Text { get; internal set; }

        [JsonProperty(PropertyName = "entities", Required = Required.Default)]
        public MessageEntity[] Entities { get; internal set; }

        [JsonProperty(PropertyName = "audio", Required = Required.Default)]
        public Audio Audio { get; internal set; }

        [JsonProperty(PropertyName = "document", Required = Required.Default)]
        public Document Document { get; internal set; }

        [JsonProperty(PropertyName = "photo", Required = Required.Default)]
        public PhotoSize[] Photo { get; internal set; }

        [JsonProperty(PropertyName = "sticker", Required = Required.Default)]
        public Sticker Sticker { get; internal set; }

        [JsonProperty(PropertyName = "video", Required = Required.Default)]
        public Video Video { get; internal set; }

        [JsonProperty(PropertyName = "voice", Required = Required.Default)]
        public Voice Voice { get; internal set; }

        [JsonProperty(PropertyName = "caption", Required = Required.Default)]
        public string Caption { get; internal set; }

        [JsonProperty(PropertyName = "contact", Required = Required.Default)]
        public Contact Contact { get; internal set; }

        [JsonProperty(PropertyName = "type", Required = Required.Default)]
        public Location Location { get; internal set; }

        [JsonProperty(PropertyName = "venue", Required = Required.Default)]
        public Venue Venue { get; internal set; }

        [JsonProperty(PropertyName = "new_chat_member", Required = Required.Default)]
        public User NewChatMember { get; internal set; }

        [JsonProperty(PropertyName = "left_chat_member", Required = Required.Default)]
        public User LeftChatMember { get; internal set; }

        [JsonProperty(PropertyName = "new_chat_title", Required = Required.Default)]
        public string NewChatTitle { get; internal set; }

        [JsonProperty(PropertyName = "new_chat_photo", Required = Required.Default)]
        public PhotoSize[] NewChatPhoto { get; internal set; }

        [JsonProperty(PropertyName = "delete_chat_photo", Required = Required.Default)]
        public bool DeleteChatPhoto { get; internal set; }

        [JsonProperty(PropertyName = "group_chat_created", Required = Required.Default)]
        public bool GroupChatCreated { get; internal set; }

        [JsonProperty(PropertyName = "supergroup_chat_created", Required = Required.Default)]
        public bool SupergroupChatCreated { get; internal set; }

        [JsonProperty(PropertyName = "channel_chat_created", Required = Required.Default)]
        public bool ChannelChatCreated { get; internal set; }

        [JsonProperty(PropertyName = "migrate_to_chat_id", Required = Required.Default)]
        public int MigrateToChatId { get; internal set; }

        [JsonProperty(PropertyName = "migrate_from_chat_id", Required = Required.Default)]
        public int MigrateFromChatId { get; internal set; }

        [JsonProperty(PropertyName = "pinned_message", Required = Required.Default)]
        public Message PinnedMessage { get; internal set; }
    }
}