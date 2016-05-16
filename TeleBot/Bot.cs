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
            return await SendPostRequest<Message>("sendMessage", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendForwardMessageAsync(ForwardMessage message)
        {
            return await SendForwardMessageAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendForwardMessageAsync(ForwardMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("forwardMessage", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendPhotoAsync(PhotoMessage message)
        {
            return await SendPhotoAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendPhotoAsync(PhotoMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendPhoto", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()), cancellationToken);
        }

        public async Task<Message> SendAudioAsync(AudioMessage message)
        {
            return await SendAudioAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendAudioAsync(AudioMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendAudio", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()), cancellationToken);
        }

        public async Task<Message> SendDocumentAsync(DocumentMessage message)
        {
            return await SendDocumentAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendDocumentAsync(DocumentMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendDocument", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()), cancellationToken);
        }

        public async Task<Message> SendStickerAsync(StickerMessage message)
        {
            return await SendStickerAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendStickerAsync(StickerMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendSticker", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()), cancellationToken);
        }

        public async Task<Message> SendVideoAsync(VideoMessage message)
        {
            return await SendVideoAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendVideoAsync(VideoMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendVideo", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()), cancellationToken);
        }

        public async Task<Message> SendVoiceAsync(VoiceMessage message)
        {
            return await SendVoiceAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendVoiceAsync(VoiceMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendVoice", HttpContentBuilder.BuildMultipartData(message.ToParameterDictionary()), cancellationToken);
        }

        public async Task<Message> SendLocationAsync(LocationMessage message)
        {
            return await SendLocationAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendLocationAsync(LocationMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendLocation", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendVenueAsync(VenueMessage message)
        {
            return await SendVenueAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendVenueAsync(VenueMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendVenue", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
        }

        public async Task<Message> SendContactAsync(ContactMessage message)
        {
            return await SendContactAsync(message, CancellationToken.None);
        }

        public async Task<Message> SendContactAsync(ContactMessage message, CancellationToken cancellationToken)
        {
            return await SendPostRequest<Message>("sendContact", HttpContentBuilder.BuildJsonContent(message), cancellationToken);
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

