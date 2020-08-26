using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy.APIClient;
using Challenge.CountryServiceProxy.CacheDb;
using Challenge.CountryServiceProxy.Entities;
using Challenge.Domain.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICountry Find(string name)
        {
            return _inMemoryCacheDb.Find(name);
        }

        public async Task<IEnumerable<ICountry>> GetAll(string filters)
        {
            if (_inMemoryCacheDb.IsEmpty())
                await ReloadCache();

            var countries = _inMemoryCacheDb.GetAll();

            if (!string.IsNullOrWhiteSpace(filters))
                countries = FilterCountries(countries, filters);

            return countries;
        }

        private IReadOnlyCollection<Country> FilterCountries(IReadOnlyCollection<Country> countries, string filters)
        {
            var normalizedFilter = filters.ToLower().Trim();
            var filteredCountries = countries.ToList();

            filteredCountries = filteredCountries.Where(
                country => country.Name.ToLower().Contains(normalizedFilter) ||
                (country.Abbreviation != null && country.Abbreviation.ToLower().Contains(normalizedFilter)) ||
                country.Currencies.Any(currency => currency.Name != null && currency.Name.ToLower().Contains(normalizedFilter))).ToList();

            return new ReadOnlyCollection<Country>(filteredCountries);
        }

        private async Task ReloadCache()
        {
            var countriesDTO = await _restCountriesAPIClient.GetAll();
            var countries = countriesDTO.Select(country => new Country(
                country.Name,
                country.CIOC,
                country.Flag,
                country.Population,
                country.Capital,
                country.Currencies.Select(currency => new Currency(currency.Code, currency.Name, currency.Symbol)).ToArray(),
                country.RegionalBlocs.Select(regionalBloc => new EconomicBloc(regionalBloc.Acronym, regionalBloc.Name)).ToArray(),
                country.Timezones,
                country.Languages.Select(language => language.Name).ToArray(),
                country.Borders));

            _inMemoryCacheDb.Add(countries);
        }
    }
}
