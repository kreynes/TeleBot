using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using TeleBot.API;
using TeleBot.API.Enums;
using TeleBot.API.Extensions;
using TeleBot.API.Message;
using TeleBot.API.Types;

namespace TeleBot
{
    public class Bot
    {
        const string baseUrl = "https://api.telegram.org/bot";

        HttpClient client;

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
            return await SendGetMeAsync(CancellationToken.None);
        }

        public async Task<User> SendGetMeAsync(CancellationToken cancellationToken)
        {
            return await SendGetRequest<User>("getMe", cancellationToken);
        }

        public async Task<Update[]> SendGetUpdatesAsync()
        {
            return await SendGetUpdatesAsync(CancellationToken.None);
        }

        public async Task<Update[]> SendGetUpdatesAsync(CancellationToken cancellationToken)
        {
            return await SendPostRequest<Update[]>("getUpdates", HttpContentBuilder.BuildJsonContent(new
            {
                offset = MessageOffset,
                limit = UpdateLimit,
                timeout = PollTimeout
            }), cancellationToken);
        }

        public async Task<Message> SendMessageAsync(TextMessage message)
        {
            return await SendMessageAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendMessageAsync(TextMessage message, CancellationToken cancellationToken)
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
            return await SendForwardMessageAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendForwardMessageAsync(ForwardMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("forwardMessage", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendForwardMessageAsync(string chatId, string fromChatId, int messageId,
                                                           bool disableNotification = false)
        {
            return await SendPostRequest<Message>("forwardMessage", HttpContentBuilder.BuildJsonContent(new ForwardMessage(chatId, fromChatId, messageId)
            {
                DisableNotification = disableNotification
            }));
        }

        public async Task<Message> SendPhotoAsync(PhotoMessage message)
        {
            return await SendPostRequest<Message>("sendPhoto", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()));
        }

        public async Task<Message> SendPhotoAsync(string chatId, InputFile photoFile, string caption = "",
                                                  bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            return await SendPostRequest<Message>("sendPhoto", HttpContentBuilder.BuildMultipartData(new PhotoMessage(chatId, photoFile)
            {
                Caption = caption,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }.ToParameterDictionary()));
        }

        public async Task<Message> SendAudioAsync(AudioMessage message)
        {
            return await SendPostRequest<Message>("sendAudio", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()));
        }

        public async Task<Message> SendAudioAsync(string chatId, InputFile audioFile, int duration = 0,
                                                  string performer = "", string title = "", bool disableNotification = false,
                                                  int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            return await SendPostRequest<Message>("sendAudio", HttpContentBuilder.BuildMultipartData(new AudioMessage(chatId, audioFile)
            {
                Duration = duration,
                Performer = performer,
                Title = title,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }.ToParameterDictionary()));
        }

        public async Task<Message> SendDocumentAsync(DocumentMessage message)
        {
            return await SendPostRequest<Message>("sendDocument", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()));
        }

        public async Task<Message> SendDocumentAsync(string chatId, InputFile documentFile, string caption = "",
                                                     bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {

            return await SendPostRequest<Message>("sendDocument", HttpContentBuilder.BuildMultipartData(new DocumentMessage(chatId, documentFile)
            {
                Caption = caption,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }.ToParameterDictionary()));
        }

        public async Task<Message> SendStickerAsync(StickerMessage message)
        {
            return await SendPostRequest<Message>("sendSticker", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()));
        }

        public async Task<Message> SendStickerAsync(string chatId, InputFile stickerFile, bool disableNotification = false,
                                                    int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            return await SendPostRequest<Message>("sendSticker", HttpContentBuilder.BuildMultipartData(new StickerMessage(chatId, stickerFile)
            {
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }.ToParameterDictionary()));
        }

        public async Task<Message> SendVideoAsync(VideoMessage message)
        {
            return await SendPostRequest<Message>("sendVideo", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()));
        }

        public async Task<Message> SendVideoAsync(string chatId, InputFile videoFile, int duration = 0,
                                                  int width = 0, int height = 0, string caption = "",
                                                  bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            return await SendPostRequest<Message>("sendVideo", HttpContentBuilder.BuildMultipartData(new VideoMessage(chatId, videoFile)
            {
                Duration = duration,
                Width = width,
                Height = height,
                Caption = caption,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }.ToParameterDictionary()));
        }

        public async Task<Message> SendVoiceAsync(VoiceMessage message)
        {
            return await SendPostRequest<Message>("sendVoice", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()));
        }

        public async Task<Message> SendVoiceAsync(string chatId, InputFile voiceFile, int duration = 0,
                                                  bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            return await SendPostRequest<Message>("sendVoice", HttpContentBuilder.BuildMultipartData(new VoiceMessage(chatId, voiceFile)
            {
                Duration = duration,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }.ToParameterDictionary()));
        }

        public async Task<Message> SendLocationAsync(LocationMessage message)
        {
            return await SendPostRequest<Message>("sendLocation", HttpContentBuilder.BuildJsonContent(message));
        }

        public async Task<Message> SendLocationAsync(string chatId, float latitudeValue, float longitudeValue,
                                                     bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            return await SendPostRequest<Message>("sendLocation", HttpContentBuilder.BuildJsonContent(new LocationMessage(chatId, latitudeValue, longitudeValue)
            {
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }));
        }

        public async Task<Message> SendVenueAsync(VenueMessage message)
        {
            return await SendPostRequest<Message>("sendVenue", HttpContentBuilder.BuildJsonContent(message));
        }

        public async Task<Message> SendVenueAsync(string chatId, float latitude, float longitude,
                                                  string title, string address, string foursquareId = "",
                                                  bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarkup = null)
        {
            return await SendPostRequest<Message>("sendVenue", HttpContentBuilder.BuildJsonContent(new VenueMessage(chatId, latitude, longitude, title, address)
            {
                FoursquareId = foursquareId,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarkup
            }));
        }

        public async Task<Message> SendContactAsync(ContactMessage message)
        {
            return await SendPostRequest<Message>("sendContact", HttpContentBuilder.BuildJsonContent(message));
        }

        public async Task<Message> SendContactAsync(string chatId, string phoneNumber, string firstName, string lastName = "", bool disableNotification = false, int replyMessageId = 0, IReplyMarkup replyMarukup = null)
        {
            return await SendPostRequest<Message>("sendContact", HttpContentBuilder.BuildJsonContent(new ContactMessage(chatId, phoneNumber, firstName)
            {
                LastName = lastName,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyMessageId,
                ReplyMarkup = replyMarukup
            }));
        }

        async Task<T> SendGetRequest<T>(string method)
        {
            return await SendGetRequest<T>(method, CancellationToken.None);
        }

        async Task<T> SendGetRequest<T>(string method, CancellationToken cancellationToken)
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

        async Task<T> SendPostRequest<T>(string method, HttpContent content)
        {
            return await SendPostRequest<T>(method, content, CancellationToken.None);
        }

        async Task<T> SendPostRequest<T>(string method, HttpContent content, CancellationToken cancellationToken)
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
    }
}

