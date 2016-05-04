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
        public int UpdateLimit { get; set; } = 10;
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
            return await SendPostRequest<Update[]>("getUpdates", HttpContentBuilder.BuildJsonContent(new
            {
                offset = MessageOffset,
                limit = UpdateLimit,
                timeout = PollTimeout
            }));
        }

        public async Task<Message> SendMessageAsync(TextMessage message)
        {
            return await SendPostRequest<Message>("sendMessage", HttpContentBuilder.BuildJsonContent(message));
        }

        public async Task<Message> SendMessageAsync(string chatId, string messageText, ParseMode mode = ParseMode.Default,
                                                    bool disableLinkPreview = false, bool disableNotification = false, int replyMessageId = 0,
                                                    IReplyMarkup replyMarkup = null)
        {
            return await SendPostRequest<Message>("sendMessage", HttpContentBuilder.BuildJsonContent(new TextMessage(chatId, messageText)
            {
                ParseMode = mode,
                DisableLinkPreview = disableLinkPreview,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarkup
            }));
        }

        public async Task<Message> SendForwardMessageAsync(ForwardMessage message)
        {
            return await SendPostRequest<Message>("forwardMessage", HttpContentBuilder.BuildJsonContent(message));
        }

        public async Task<Message> SendForwardMessageAsync(string chatId, string fromChatId, int messageId, bool disableNotification = false)
        {
            return await SendPostRequest<Message>("forwardMessage", HttpContentBuilder.BuildJsonContent(new ForwardMessage(chatId, fromChatId, messageId)
            {
                DisableNotification = disableNotification,
            }));
        }

        public async Task<Message> SendPhotoAsync(string chatId, InputFile photoFile, string caption = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (photoFile == null)
                throw new ArgumentNullException(nameof(photoFile));

            return await SendPostRequest<Message>("sendPhoto", HttpContentBuilder.BuildMultipartData(new Dictionary<string, object>
            {
                {"chat_id", chatId},
                {"photo", photoFile},
                {"caption", caption},
                {"disable_notification", disableNotification},
                {"reply_to_message_id", replyMessageId},
                {"reply_markup", replyMarukup}
            }));
        }

        public async Task<Message> SendAudioAsync(string chatId, InputFile audioFile, int duration = 0, string performer = "", string title = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (audioFile == null)
                throw new ArgumentNullException(nameof(audioFile));
            //TODO Add MP3 header check as Telegram Bot API only accepts MP3 file formats for uploading 

            return await SendPostRequest<Message>("sendAudio", HttpContentBuilder.BuildMultipartData(new Dictionary<string, object>
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

        public async Task<Message> SendDocumentAsync(string chatId, InputFile documentFile, string caption = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (documentFile == null)
                throw new ArgumentNullException(nameof(documentFile));

            return await SendPostRequest<Message>("sendDocument", HttpContentBuilder.BuildMultipartData(new Dictionary<string, object>
            {
                {"chat_id", chatId},
                {"document", documentFile},
                {"caption", caption},
                {"disable_notification", disableNotification},
                {"reply_to_message_id", replyMessageId},
                {"reply_markup", replyMarukup}
            }));
        }

        public async Task<Message> SendStickerAsync(string chatId, InputFile stickerFile, bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (stickerFile == null)
                throw new ArgumentNullException(nameof(stickerFile));

            return await SendPostRequest<Message>("sendSticker", HttpContentBuilder.BuildMultipartData(new Dictionary<string, object>
            {
                {"chat_id", chatId},
                {"sticker", stickerFile},
                {"disable_notification", disableNotification},
                {"reply_to_message_id", replyMessageId},
                {"reply_markup", replyMarukup}
            }));
        }

        public async Task<Message> SendVideoAsync(string chatId, InputFile videoFile, int duration = 0, int width = 0, int height = 0, string caption = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (videoFile == null)
                throw new ArgumentNullException(nameof(videoFile));

            return await SendPostRequest<Message>("sendVideo", HttpContentBuilder.BuildMultipartData(new Dictionary<string, object>
            {
                {"chat_id", chatId},
                {"video", videoFile},
                {"duration", duration},
                {"width", width},
                {"height", height},
                {"caption", caption},
                {"disable_notification", disableNotification},
                {"reply_to_message_id", replyMessageId},
                {"reply_markup", replyMarukup}
            }));
        }

        public async Task<Message> SendVoiceAsync(string chatId, InputFile voiceFile, int duration = 0, bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (voiceFile == null)
                throw new ArgumentNullException(nameof(voiceFile));

            return await SendPostRequest<Message>("sendSticker", HttpContentBuilder.BuildMultipartData(new Dictionary<string, object>
            {
                {"chat_id", chatId},
                {"voice", voiceFile},
                {"duration", duration},
                {"disable_notification", disableNotification},
                {"reply_to_message_id", replyMessageId},
                {"reply_markup", replyMarukup}
            }));
        }

        public async Task<Message> SendLocationAsync(string chatId, float latitudeValue, float longitudeValue, bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));

            return await SendPostRequest<Message>("sendLocation", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId,
                latitude = latitudeValue,
                longitude = longitudeValue,
                disable_notification = disableNotification,
                reply_to_message_id = replyMessageId,
                reply_markup = replyMarukup
            }));
        }

        public async Task<Message> SendContactAsync(string chatId, string phoneNumber, string firstName, string lastName = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            if (string.IsNullOrWhiteSpace(chatId))
                throw new ArgumentException("Null or whitespace", nameof(chatId));
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Null or whitespace", nameof(phoneNumber));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Null or whitespace", nameof(firstName));

            return await SendPostRequest<Message>("sendContact", HttpContentBuilder.BuildJsonContent(new
            {
                chat_id = chatId,
                phone_number = phoneNumber,
                first_name = firstName,
                last_name = lastName,
                disable_notification = disableNotification,
                reply_to_message_id = replyMessageId,
                reply_markup = replyMarukup
            }));
        }

        async Task<T> SendGetRequest<T>(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("Null or whitespace", nameof(method));

            var uri = new Uri($"{baseUrl}{AuthenticationToken}/{method}");
            var response = await client.GetAsync(uri);
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

        async Task<T> SendPostRequest<T>(string method, HttpContent content)
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("Null or whitespace", nameof(method));
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            var uri = $"{baseUrl}{AuthenticationToken}/{method}";
            var response = await client.PostAsync(uri, content);
            Response<T> respObj = null;
            string responseString = await response.Content.ReadAsStringAsync();
            respObj = JsonConvert.DeserializeObject<Response<T>>(responseString);
            if (respObj == null)
                throw new ApiRequestException("Did not receive a response from server!");
            if (!respObj.Ok)
                throw new ApiRequestException(respObj.Description, respObj.ErrorCode);
            return respObj.Result;
        }
    }
}

