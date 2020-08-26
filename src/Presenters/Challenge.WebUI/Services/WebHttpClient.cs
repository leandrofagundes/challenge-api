using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.WebUI.Services
{
    public sealed class WebHttpClient
    {
        private readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IgnoreNullValues = true };
        private HttpClient HttpClient { get; set; }
        public string GetBaseAddress()
        {
            return this.HttpClient.BaseAddress.ToString();
        }

        public WebHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<T> FindAsync<T>(string uriPath)
        {
            T responseObject = default;
            using var httpResponse = await HttpClient.GetAsync(uriPath);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseDataStringfied = await httpResponse.Content.ReadAsStringAsync();
                responseObject = DeserializeResponseData<T>(responseDataStringfied);
            }
            else
                await CreateException(httpResponse);

            return responseObject;
        }

        public async Task<U> GetAsync<T, U>(string uriPath, T requestData, CancellationToken cancellationToken)
        {

            var queryString = SerializeRequestDataIntoQueryString(requestData);
            uriPath = QueryHelpers.AddQueryString(uriPath, queryString);

            U responseObject = default;

            using var httpResponse = await HttpClient.GetAsync(uriPath, cancellationToken);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseDataStringfied = await httpResponse.Content.ReadAsStringAsync();
                responseObject = DeserializeResponseData<U>(responseDataStringfied);
            }
            else
                await CreateException(httpResponse);

            return responseObject;
        }

        private Dictionary<string, string> SerializeRequestDataIntoQueryString<T>(T requestData)
        {
            var dictionaries = (from property in requestData.GetType().GetProperties()
                                where property.GetValue(requestData, null) != null
                                select new { Key = property.Name, Value = Convert.ToString(property.GetValue(requestData)) })
                                .ToDictionary(item => item.Key, item => item.Value);

            return dictionaries;
        }

        private T DeserializeResponseData<T>(string stringfiedDataObject)
        {
            var objectData = JsonSerializer.Deserialize<T>(stringfiedDataObject, this.JsonOptions);
            return objectData;
        }


        private async Task CreateException(HttpResponseMessage httpResponse)
        {
            if (httpResponse is null)
                throw new ArgumentNullException();

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Conflict:
                case HttpStatusCode.UnprocessableEntity:
                    throw new ArgumentException(responseContent);
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
                case HttpStatusCode.NotFound:
                    throw new ArgumentOutOfRangeException();
                case HttpStatusCode.InternalServerError:
                    throw new InvalidOperationException();
                default:
                    throw new Exception(responseContent);
            }
        }
    }
}
