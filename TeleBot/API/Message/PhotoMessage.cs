﻿using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PhotoMessage
    {
        public PhotoMessage(string chatId, InputFile photo)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (photo == null)
                throw new ArgumentNullException(nameof(photo));
            ChatId = chatId;
            Photo = photo;
        }

        public PhotoMessage(string chatId, string fileId)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (string.IsNullOrWhiteSpace(fileId))
                throw new ArgumentNullException(nameof(fileId));
            ChatId = chatId;
            FileId = fileId;
        }

        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public string ChatId { get; set; }

        [JsonProperty(PropertyName = "photo", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InputFile Photo { get; set; }

        [JsonProperty(PropertyName = "photo", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "caption", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Caption { get; set; } = "";

        [JsonProperty(PropertyName = "disable_notification", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableNotification { get; set; } = false;

        [JsonProperty(PropertyName = "reply_to_message_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ReplyToMessageId { get; set; } = 0;

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; } = null;
    }
}

