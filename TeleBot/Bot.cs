using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace TeleBot
{
    public class Bot
    {
        const string baseUrl = "https://api.telegram.org/bot";
        readonly HttpClient client;

        public string AuthenticationToken { get; internal set; }
        public int UpdateLimit { get; set; } = 100;
        public int PollTimeout { get; set; } = 0;
        public int MessageOffset { get; set; } = 0;


        public Bot(string authenticationToken)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken))
                throw new ArgumentNullException(nameof(authenticationToken));

            AuthenticationToken = authenticationToken;
            client = new HttpClient();
        }



        public async Task<User> SendGetMeAsync()
        {
            return await SendGetRequest<User>("getMe");
        }

        public async Task<Update[]> SendGetUpdatesAsync()
        {
            return await SendPostRequest<Update[]>("getUpdates", BuildJsonContent(new
            {
                offset = MessageOffset,
                limit = UpdateLimit,
                timeout = PollTimeout
            }));
        }

        public async Task<Message> SendMessageAsync(string chatId, string messageText, ParseMode mode = ParseMode.Default, bool disableLinkPreview = false, bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarkup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (string.IsNullOrWhiteSpace(messageText))
                throw new ArgumentException("Null or whitespace", nameof(messageText));

            return await SendPostRequest<Message>("sendMessage", BuildJsonContent(new MessageParameters
            {
                ChatId = chatId,
                Text = messageText,
                Mode = mode,
                DisableWebPagePreview = disableLinkPreview,
                DisableNotification = disableNotification,
                MessageReplyId = replyMessageId,
                ReplyMarkup = replyMarkup
            }));
        }

        public async Task<Message> SendForwardMessage(string chatId, string fromChatId, int messageId, bool disableNotification = false)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (string.IsNullOrWhiteSpace(fromChatId))
                throw new ArgumentException("Null or whitespace", nameof(fromChatId));
            if (messageId == 0)
                throw new ArgumentException("Cannot specify default value", nameof(messageId));

            return await SendPostRequest<Message>("forwardMessage", BuildJsonContent(new
            {
                chat_id = chatId,
                from_chat_id = fromChatId,
                disable_notification = disableNotification,
                message_id = messageId,
            }));
        }

        public async Task<Message> SendPhoto(string chatId, InputFile photoFile, string caption = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (photoFile == null)
                throw new ArgumentNullException(nameof(photoFile));

            return await SendPostRequest<Message>("sendPhoto", BuildFormDataContent(new Dictionary<string, object>
            {
                {"chat_id", chatId},
                {"photo", photoFile},
                {"caption", caption},
                {"disable_notification", disableNotification},
                {"reply_to_message_id", replyMessageId},
                {"reply_markup", replyMarukup}
            }));
        }

        public async Task<Message> SendAudio(string chatId, InputFile audioFile, int duration = 0, string performer = "", string title = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (audioFile == null)
                throw new ArgumentNullException(nameof(audioFile));
            //TODO Add MP3 header check as Telegram Bot API only accepts MP3 file formats for uploading 

            return await SendPostRequest<Message>("sendAudio", BuildFormDataContent(new Dictionary<string, object>
            {
                {"chat_id", chatId},
                {"audio", audioFile},
                {"duration", duration},
                {"performer", performer},
                {"title", title},
                {"disable_notification", disableNotification},
                {"reply_to_message_id", replyMessageId},
                {"reply_markup", replyMarukup}
            }));
        }

        HttpContent BuildJsonContent(object jsonObject)
        {
            if (jsonObject == null)
                throw new ArgumentNullException(nameof(jsonObject));
            var json = JsonConvert.SerializeObject(jsonObject);
            return new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        }

        HttpContent BuildFormDataContent(Dictionary<string, object> formDataParameters)
        {
            if (formDataParameters == null)
                throw new ArgumentNullException(nameof(formDataParameters));

            var formData = new MultipartFormDataContent();
            foreach (var param in formDataParameters.Where(x => x.Value != null))
            {
                if (param.Value is string || param.Value is int)
                {
                    formData.Add(new StringContent(param.Value.ToString()), param.Key);
                }
                else if (param.Value is bool)
                {
                    formData.Add(new StringContent((bool)param.Value ? "true" : "false"), param.Key);
                }
                else if (param.Value is InputFile)
                {
                    formData.Add(new StreamContent(((InputFile)param.Value).FileData), param.Key, ((InputFile)param.Value).Filename);
                }
                else
                {
                    formData.Add(new StringContent(JsonConvert.SerializeObject(param.Value, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
                    })), param.Key);
                }
            }
            return formData;
        }

        async Task<T> SendGetRequest<T>(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("Null or whitespace", nameof(method));

            var uri = new Uri($"{baseUrl}{AuthenticationToken}/{method}");
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            Response<T> respObj = null;
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                respObj = JsonConvert.DeserializeObject<Response<T>>(responseString);
            }
            if (!respObj.Ok)
                throw new ApiRequestException(respObj.Description, respObj.ErrorCode);
            return respObj.Result;
        }
        async Task<T> SendPostRequest<T>(string method, HttpContent content)
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("Null or whitespace", nameof(method));
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            var uri = $"{baseUrl}{AuthenticationToken}/{method}";
            var response = await client.PostAsync(uri, content);
            Response<T> respObj = null;
            string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            respObj = JsonConvert.DeserializeObject<Response<T>>(responseString);
            response.EnsureSuccessStatusCode();
            if (respObj == null)
                respObj = new Response<T> { Ok = false, Description = "Message not sent!" };
            if (!respObj.Ok)
                throw new ApiRequestException($"{respObj.Description} {respObj.ErrorCode}");
            return respObj.Result;
        }
    }
}

