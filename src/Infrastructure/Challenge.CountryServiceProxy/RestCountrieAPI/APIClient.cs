using Challenge.CountryServiceProxy.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Challenge.CountryServiceProxy.RestCountrieAPI
{
    public class APIClient
    {
        private readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IgnoreNullValues = true };
        private readonly HttpClient _httpClient;

        private const string fields = "name;cioc;currencies;flag;regionalBlocs;population;timezones;languages;capital;borders;region";

        public APIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CountryDTO[]> GetAllFromRemote()
        {
            CountryDTO[] countries = null;
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync($"v2/all?fields={fields}");
            }
            catch (WebException webException)
            {
                throw new InvalidOperationException(webException.Message);
            }
            catch (HttpRequestException httpRequestEx)
            {
                throw new InvalidOperationException(httpRequestEx.Message);
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                countries = DeserializeResponseData<CountryDTO[]>(jsonResult);
            }
            else
                await CreateException(response);

            return countries;
        }

        public async Task<CountryDTO[]> GetRegionFromRemote(string regionName)
        {
            CountryDTO[] countries = null;
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync($"v2/region/{regionName}?fields={fields}");
            }
            catch (WebException webException)
            {
                throw new InvalidOperationException(webException.Message);
            }
            catch (HttpRequestException httpRequestEx)
            {
                throw new InvalidOperationException(httpRequestEx.Message);
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                countries = DeserializeResponseData<CountryDTO[]>(jsonResult);
            }
            else
                await CreateException(response);

            return countries;
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
                    throw new UnauthorizedAccessException();
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
                case HttpStatusCode.NotFound:
                    throw new ArgumentOutOfRangeException();
                case HttpStatusCode.InternalServerError:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
