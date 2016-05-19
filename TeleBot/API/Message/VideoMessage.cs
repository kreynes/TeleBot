﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API.Message
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class VideoMessage : IMediaMessage
    {
        public VideoMessage(string chatId, InputFile video)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace.", nameof(chatId));
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            ChatId = chatId;
            File = video; //TODO Refactor
        }

        public VideoMessage(string chatId, string fileId)
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

        [JsonProperty(PropertyName = "video", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InputFile File { get; set; }

        [JsonProperty(PropertyName = "video", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "duration", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Duration { get; set; } = 0;

        [JsonProperty(PropertyName = "width", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Width { get; set; } = 0;

        [JsonProperty(PropertyName = "height", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Height { get; set; } = 0;

        [JsonProperty(PropertyName = "caption", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Caption { get; set; } = "";

        [JsonProperty(PropertyName = "disable_notification", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool DisableNotification { get; set; } = false;

        [JsonProperty(PropertyName = "reply_to_message_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ReplyToMessageId { get; set; } = 0;

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public IReplyMarkup ReplyMarkup { get; set; } = null;

        public string ApiMethod { get; } = "sendVideo";

        public Dictionary<string, object> ToParameterDictionary()
        {
            return new Dictionary<string, object>
            {
                {"chat_id", ChatId},
                {"document", File ?? (object)FileId},
                {"duration", Duration},
                {"width", Width},
                {"height", Height},
                {"disable_notification", DisableNotification},
                {"reply_to_message_id", ReplyToMessageId},
                {"reply_markup", ReplyMarkup}
            };
        }
    }
}

