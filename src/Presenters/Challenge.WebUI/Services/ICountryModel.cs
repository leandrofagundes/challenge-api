using Challenge.WebUI.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.WebUI.Services
{
    public interface ICountryModel
    {
        Task<CountriesSearchResponseData[]> SearchCountries(CountriesSearchRequestData countriesSearchRequestData, CancellationToken token);

        Task<CountryDetailResponseData> GetDetails(string countryName);
    }
}
