using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using TeleBot.API.Types;

namespace TeleBot.API
{
    internal static class HttpContentBuilder
    {
        internal static HttpContent BuildJsonContent(object jsonObject)
        {
            if (jsonObject == null)
                throw new ArgumentNullException(nameof(jsonObject));
            var json = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        internal static HttpContent BuildMultipartData(Dictionary<string, object> formDataParameters)
        {
            if (formDataParameters == null)
                throw new ArgumentNullException(nameof(formDataParameters));

            var formData = new MultipartFormDataContent();
            foreach (var param in formDataParameters.Where(x => x.Value != null))
            {
                if ((param.Value is string && (string) param.Value != default(string))
                    || (param.Value is int && (int) param.Value != default(int)))
                {
                    formData.Add(new StringContent(param.Value.ToString()), param.Key);
                }
                else if (param.Value is bool && (bool) param.Value != default(bool))
                {
                    formData.Add(new StringContent((bool) param.Value ? "true" : "false"), param.Key);
                }
                else if (param.Value is InputFile)
                {
                    formData.Add(new StreamContent(((InputFile) param.Value).FileData), param.Key,
                        ((InputFile) param.Value).Filename);
                }
                else if (!(param.Value is string | param.Value is int | param.Value is bool | false))
                {
                    formData.Add(new StringContent(JsonConvert.SerializeObject(param.Value, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    })), param.Key);
                }
            }
            return formData;
        }
    }
}