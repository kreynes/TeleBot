using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeleBot
{
    public class Bot
    {
        readonly string authToken;
        const string baseUrl = "https://api.telegram.org/bot";
        readonly HttpClient client;

        public int UpdateLimit { get; set; } = 100;
        public int PollTimeout { get; set; } = 0;
        public int MessageOffset { get; set; } = 0;


        public Bot(string authenticationToken)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken))
                throw new ArgumentNullException(nameof(authenticationToken));

            authToken = authenticationToken;
            client = new HttpClient();
        }



        public async Task<User> SendGetMeAsync()
        {
            return await SendGetRequest<User>("getMe");
        }

        public async Task<Update[]> SendGetUpdatesAsync()
        {
            return await SendPostRequest<Update[]>("getUpdates", new
            {
                offset = MessageOffset,
                limit = UpdateLimit,
                timeeout = PollTimeout
            });
        }

        public async Task<Message> SendMessageAsync(string chatId, string messageText, ParseMode mode = ParseMode.Default, bool disableLinkPreview = false, bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarkup = null)
        {
            return await SendPostRequest<Message>("sendMessage", new MessageParameters
            {
                ChatId = chatId,
                Text = messageText,
                Mode = mode,
                DisableWebPagePreview = disableLinkPreview,
                DisableNotification = disableNotification,
                MessageReplyId = replyMessageId,
                //ReplyMarkup = replyMarkup
            });
        }

        public async Task<Message> SendForwardMessage(string chatId, string fromChatId, int messageId, bool disableNotification = false)
        {
            return await SendPostRequest<Message>("forwardMessage", new
            {
                chat_id = chatId,
                from_chat_id = fromChatId,
                disable_notification = disableNotification,
                MessageId = messageId
            });
        }


        async Task<T> SendGetRequest<T>(string method)
        {
            var uri = new Uri($"{baseUrl}{authToken}/{method}");
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
        async Task<T> SendPostRequest<T>(string method, object value)
        {
            var uri = new Uri($"{baseUrl}{authToken}/{method}");
            var json = JsonConvert.SerializeObject(value);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            Response<T> respObj = null;
            string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            respObj = JsonConvert.DeserializeObject<Response<T>>(responseString);
            response.EnsureSuccessStatusCode();
            if (respObj == null)
                throw new ApiRequestException($"Did not receive response!\r\n {response.StatusCode} {response.Content.ToString()}");
            return respObj.Result;
        }
    }
}

