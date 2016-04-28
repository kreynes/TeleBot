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
        HttpClient client;

        public int UpdateLimit { get; set; } = 100;
        public int PollTimeout { get; set; } = 0;
        public int MessageOffset { get; set; } = 0;


        public Bot(string authenticationToken)
        {
            authToken = authenticationToken;
            client = new HttpClient();
        }



        public async Task<User> SendGetMeAsync()
        {
            return await SendGetRequest<User>("getMe");
        }

        public async Task<Update[]> SendGetUpdates()
        {
            return await SendPostRequest<Update[]>("getUpdates", new Dictionary<string, object>()
            {
                { "offset", MessageOffset },
                { "limit", UpdateLimit },
                { "timeout", PollTimeout }
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
        async Task<T> SendPostRequest<T>(string method, Dictionary<string, object> parameters = null)
        {
            var uri = new Uri($"{baseUrl}{authToken}/{method}");
            HttpResponseMessage response;
            using (var form = new MultipartFormDataContent())
            {
                foreach (var param in parameters)
                {
                    if (param.Value != null)
                    {
                        form.Add(GetContent(param));
                    }
                }
                response = await client.PostAsync(uri, form).ConfigureAwait(false);
            }
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

        static HttpContent GetContent(object value)
        {
            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.String:
                case TypeCode.Int32:
                    return new StringContent(value.ToString());
                case TypeCode.Boolean:
                    return new StringContent((bool)value ? "true" : "false");
                default:
                    return new StringContent(JsonConvert.SerializeObject(value, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    }));
            }
        }
    }
}

