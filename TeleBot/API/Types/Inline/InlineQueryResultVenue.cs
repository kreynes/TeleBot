﻿using System;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InlineQueryResultVenue
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "latitude", Required = Required.Always)]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude", Required = Required.Always)]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "address", Required = Required.Always)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "foursquare_id", Required = Required.Always)]
        public string FoursquareId { get; set; }

        [JsonProperty(PropertyName = "reply_markup", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        [JsonProperty(PropertyName = "input_message_content", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public object InputMessageContent { get; set; }

        [JsonProperty(PropertyName = "thumb_width", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "thumb_width", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ThumbnailWidth { get; set; }

        [JsonProperty(PropertyName = "thumb_height", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ThumbnailHeight { get; set; }
    }
}