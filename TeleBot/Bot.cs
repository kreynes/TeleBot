using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using System.Timers;
using TeleBot.API;
using TeleBot.API.Extensions;
using TeleBot.API.Message;
using TeleBot.API.Types;

namespace TeleBot
{
    public class Bot : IDisposable
    {
        const string baseUrl = "https://api.telegram.org/bot";

        HttpClient client;

        private bool disposedValue = false;
        private System.Timers.Timer pollingTimer;

        public string AuthenticationToken { get; internal set; }
        public int UpdateLimit { get; set; } = 10;
        public int PollTimeout { get; set; } = 0;
        public int MessageOffset { get; set; } = 0;

        public Bot(string authenticationToken)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken))
                throw new ArgumentNullException(nameof(authenticationToken));

            AuthenticationToken = authenticationToken;
            client = new HttpClient();
            pollingTimer = new System.Timers.Timer(1);
            pollingTimer.Elapsed += PollingTimer_Elapsed;
        }

        async void PollingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var updates = await SendGetUpdatesAsync();
            foreach (var update in updates)
            {
                MessageOffset = update.Id + 1;
            }
        }

        public async Task<User> SendGetMeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendGetRequest<User>("getMe", cancellationToken);
        }

        public async Task<Update[]> SendGetUpdatesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Update[]>("getUpdates", HttpContentBuilder.BuildJsonContent(new
            {
                offset = MessageOffset,
                limit = UpdateLimit,
                timeout = PollTimeout
            }), cancellationToken);
        }

        public async Task<Message> SendMessageAsync(TextMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Message>("sendMessage", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendForwardMessageAsync(ForwardMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Message>("forwardMessage", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }
        //TODO Refactor SendMediaAsync to check media types
        public async Task<Message> SendMediaAsync(IMediaMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Message>(message.ApiMethod, HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()), cancellationToken);
        }

        public async Task<Message> SendLocationAsync(LocationMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Message>("sendLocation", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendVenueAsync(VenueMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Message>("sendVenue", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendContactAsync(ContactMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Message>("sendContact", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }
        //TODO Refactor with an Enum
        public async Task SendChatAction(ChatAction chatAction, CancellationToken cancellationToken = default(CancellationToken))
        {
            await SendPostRequest<bool>("sencAction", HttpContentBuilder.BuildJsonContent(chatAction), cancellationToken);
        }

        public async Task<UserProfilePhotos> SendGetUserProfilePhotos(int userId, int pOffset = 0, int pLimit = 0, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<UserProfilePhotos>("getUserProfilePhotos", HttpContentBuilder.BuildJsonContent(new
            {
                user_id = userId,
                offset = pOffset,
                limit = pLimit
            }), cancellationToken);
        }

        public async Task<File> SendGetFile(string fileId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<File>("getFile", HttpContentBuilder.BuildJsonContent(new
            {
                file_id = fileId
            }), cancellationToken);
        }

        public async Task<bool> SendKickChatMember(string chatId, int userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<bool>("kickChatMember", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId,
                user_id = userId
            }), cancellationToken);
        }

        public async Task<bool> SendLeaveChat(string chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<bool>("leaveChat", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<bool> SendLeaveChat(int chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<bool>("leaveChat", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<bool> SendUnbanChatMember(string chatId, int userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<bool>("unbanChatMember", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId,
                user_id = userId
            }), cancellationToken);
        }

        public async Task<Chat> SendGetChat(string chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Chat>("getChat", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<Chat> SendGetChat(int chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Chat>("getChat", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<ChatMember[]> SendGetChatAdministrators(string chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<ChatMember[]>("getChatAdministrators", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<ChatMember[]> SendGetChatAdministrators(int chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<ChatMember[]>("getChatAdministrators", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<int> SendGetChatMembersCount(string chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<int>("getChatMembersCount", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<int> SendGetChatMembersCount(int chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<int>("getChatMembersCount", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<ChatMember> SendGetChatMamber(string chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<ChatMember>("getChatMember", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }

        public async Task<ChatMember> SendGetChatMamber(int chatId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<ChatMember>("getChatMember", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId
            }), cancellationToken);
        }


        public async Task<bool> SendAnswerCallbackQuery(string callbackQueryId, string pText = "", bool showAlert = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<bool>("answerCallbackQuery", HttpContentBuilder.BuildJsonContent(new
            {
                callback_query_id = callbackQueryId,
                text = pText,
                show_alert = showAlert
            }), cancellationToken);
        }

        public async Task<Message> SendEditMessageAsync(IEditMessage message, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendPostRequest<Message>(message.ApiMethod, HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        async Task<T> SendGetRequest<T>(string method, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("Null or whitespace", nameof(method));

            var uri = new Uri($"{baseUrl}{AuthenticationToken}/{method}");
            var response = await client.GetAsync(uri, cancellationToken);
            Response<T> respObj = null;
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                respObj = JsonConvert.DeserializeObject<Response<T>>(responseString);
            }
            if (!respObj.Ok)
                throw new ApiRequestException(respObj.Description, respObj.ErrorCode);
            return respObj.Result;
        }


        async Task<T> SendPostRequest<T>(string method, HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("Null or whitespace", nameof(method));
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            var uri = $"{baseUrl}{AuthenticationToken}/{method}";
            var response = await client.PostAsync(uri, content, cancellationToken);
            Response<T> respObj = null;
            string responseString = await response.Content.ReadAsStringAsync();
            respObj = JsonConvert.DeserializeObject<Response<T>>(responseString);
            if (respObj == null)
                throw new ApiRequestException("Did not receive a response from server!");
            if (!respObj.Ok)
                throw new ApiRequestException(respObj.Description, respObj.ErrorCode);
            return respObj.Result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    client.Dispose();
                    client = null;
                    pollingTimer.Dispose();
                    pollingTimer = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}

