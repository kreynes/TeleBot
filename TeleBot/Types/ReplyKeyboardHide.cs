﻿using System;
using Newtonsoft.Json;

namespace TeleBot
{
    [JsonObject]
    public class ReplyKeyboardHide
    {
        [JsonProperty(PropertyName = "hide_keyboard", Required = Required.Always)]
        public bool HideKeyboard { get; internal set; }

        [JsonProperty(PropertyName = "selective", Required = Required.Default)]
        public bool Selective { get; internal set; }
    }
}
