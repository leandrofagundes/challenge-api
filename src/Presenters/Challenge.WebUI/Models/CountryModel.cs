using Challenge.WebUI.DTOs;
using Challenge.WebUI.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.WebUI.Models
{
    public class CountryModel :
        ICountryModel
    {
        private readonly WebHttpClient _webHttpClient;
        public CountryModel(WebHttpClient webHttpClient)
        {
            _webHttpClient = webHttpClient;
        }

        public async Task<CountryDetailResponseData> GetDetails(string countryName)
        {
            var responseData = await _webHttpClient.GetAsync<CountryDetailResponseData>($"v1/countries/{countryName}");
            return responseData;
        }

        public async Task<CountryDetailsRegionResponseData[]> GetInRegion(string regionName)
        {
            var responseData = await _webHttpClient.GetAsync<CountryDetailsRegionResponseData[]>(
                $"v1/countries/region/{regionName}");
            return responseData;
        }

        public async Task<RouteResponseData[]> GetRoute(string origin, string destiny)
        {
            var responseData = await _webHttpClient.GetAsync<RouteResponseData[]>(
                $"v1/countries/route/{origin}/{destiny}");
            return responseData;
        }

        public async Task<CountriesSearchResponseData[]> SearchCountries(CountriesSearchRequestData requestData, CancellationToken token)
        {
            var responseData = await _webHttpClient.GetAsync<CountriesSearchRequestData, CountriesSearchResponseData[]>(
                "v1/countries/",
                requestData,
                token);

            return responseData;
        }
    }
}
