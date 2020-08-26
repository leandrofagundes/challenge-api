using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy.CacheDb;
using Challenge.Domain.Entities;
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
        private readonly DbCache _cache;

        public CountryService(
            DbCache cache)
        {
            _cache = cache;
        }

        public async Task<ICountry> FindByName(string name)
        {
            var countries = await _cache.All();
            return countries.FirstOrDefault(country => country.Name.ToLower().Trim().Equals(name?.ToLower().Trim()));
        }

        public async Task<IReadOnlyCollection<ICountry>> GetAll(string filters)
        {
            var countries = await _cache.All();

            if (!string.IsNullOrWhiteSpace(filters))
                countries = FilterCountries(countries, filters);

            return new ReadOnlyCollection<ICountry>(countries);
        }

        private Country[] FilterCountries(Country[] countries, string filters)
        {
            var normalizedFilter = filters.ToLower().Trim();
            var filteredCountries = countries.ToList();

            filteredCountries = filteredCountries.Where(
                country => country.Name.ToLower().Contains(normalizedFilter) ||
                (country.Abbreviation != null && country.Abbreviation.ToLower().Contains(normalizedFilter)) ||
                country.Currencies.Any(currency => currency.Name != null && currency.Name.ToLower().Contains(normalizedFilter))).ToList();

            return filteredCountries.ToArray();
        }
    }
}
