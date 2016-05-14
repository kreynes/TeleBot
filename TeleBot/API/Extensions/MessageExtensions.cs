﻿using System;
using System.Collections.Generic;

namespace TeleBot
{
    public static class MessageExtensions
    {
        public static Dictionary<string, object> ToParameterDictionary(this PhotoMessage message)
        {
            return new Dictionary<string, object>
            {
                {"chat_id", message.ChatId},
                {"photo", message.Photo == null ? (object)message.FileId : message.Photo},
                {"caption", message.Caption},
                {"disable_notification", message.DisableNotification},
                {"reply_to_message_id", message.ReplyToMessageId},
                {"reply_markup", message.ReplyMarkup}
            };
        }

        public static Dictionary<string, object> ToParameterDictionary(this AudioMessage message)
        {
            return new Dictionary<string, object>
            {
                {"chat_id", message.ChatId},
                {"audio", message.Audio == null ? (object)message.FileId : message.Audio},
                {"duration", message.Duration},
                {"performer", message.Performer},
                {"title", message.Title},
                {"disable_notification", message.DisableNotification},
                {"reply_to_message_id", message.ReplyToMessageId},
                {"reply_markup", message.ReplyMarkup}
            };
        }

        public static Dictionary<string, object> ToParameterDictionary(this DocumentMessage message)
        {
            return new Dictionary<string, object>
            {
                {"chat_id", message.ChatId},
                {"document", message.Document == null ? (object)message.FileId : message.Document},
                {"caption", message.Caption},
                {"disable_notification", message.DisableNotification},
                {"reply_to_message_id", message.ReplyToMessageId},
                {"reply_markup", message.ReplyMarkup}
            };
        }

        public static Dictionary<string, object> ToParameterDictionary(this StickerMessage message)
        {
            return new Dictionary<string, object>
            {
                {"chat_id", message.ChatId},
                {"sticker", message.Sticker == null ? (object)message.FileId : message.Sticker},
                {"disable_notification", message.DisableNotification},
                {"reply_to_message_id", message.ReplyToMessageId},
                {"reply_markup", message.ReplyMarkup}
            };
        }

        public static Dictionary<string, object> ToParameterDictionary(this VideoMessage message)
        {
            return new Dictionary<string, object>
            {
                {"chat_id", message.ChatId},
                {"document", message.Video == null ? (object)message.FileId : message.Video},
                {"duration", message.Duration},
                {"width", message.Width},
                {"height", message.Height},
                {"disable_notification", message.DisableNotification},
                {"reply_to_message_id", message.ReplyToMessageId},
                {"reply_markup", message.ReplyMarkup}
            };
        }

        public static Dictionary<string, object> ToParameterDictionary(this VoiceMessage message)
        {
            return new Dictionary<string, object>
            {
                {"chat_id", message.ChatId},
                {"voice", message.Voice == null ? (object)message.FileId : message.Voice},
                {"duration", message.Duration},
                {"disable_notification", message.DisableNotification},
                {"reply_to_message_id", message.ReplyToMessageId},
                {"reply_markup", message.ReplyMarkup}
            };
        }
    }
}
