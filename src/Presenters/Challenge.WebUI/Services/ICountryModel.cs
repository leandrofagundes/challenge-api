using Challenge.WebUI.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.WebUI.Services
{
    public interface ICountryModel
    {
        Task<CountriesSearchResponseData[]> SearchCountries(CountriesSearchRequestData requestData, CancellationToken token);
        Task<CountryDetailResponseData> GetDetails(string countryName);
        Task<CountryDetailsRegionResponseData[]> GetInRegion(string regionName);
        Task<RouteResponseData[]> GetRoute(string origin, string destiny);
    }
}
