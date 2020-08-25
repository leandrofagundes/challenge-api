using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy.APIClient;
using Challenge.CountryServiceProxy.CacheDb;
using Challenge.CountryServiceProxy.Entities;
using Challenge.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.CountryServiceProxy
{
    public sealed class CountryService :
        ICountriesService
    {
        private readonly InMemoryCacheDb _inMemoryCacheDb;
        private readonly RestCountriesAPIClient _restCountriesAPIClient;

        public CountryService(
            InMemoryCacheDb inMemoryCacheDb,
            RestCountriesAPIClient restCountriesAPIClient)
        {
            _inMemoryCacheDb = inMemoryCacheDb;
            _restCountriesAPIClient = restCountriesAPIClient;
        }

        public async Task<IEnumerable<ICountry>> GetAll()
        {
            if (_inMemoryCacheDb.IsEmpty())
                await ReloadCache();

            return _inMemoryCacheDb.GetAll();
        }

        private async Task ReloadCache()
        {
            var countriesDTO = await _restCountriesAPIClient.GetAll();
            var countries = countriesDTO.Select(country => new Country(
                country.Name,
                country.CIOC,
                "",
                country.Currencies.Select(currency => new Currency(currency.Code, currency.Name, currency.Symbol)).ToArray(),
                country.RegionalBlocs.Select(regionalBloc => new EconomicBloc(regionalBloc.Acronym, regionalBloc.Name)).ToArray()));

            _inMemoryCacheDb.Add(countries);
        }
    }
}
