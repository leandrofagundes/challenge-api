using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy.Entities;
using Challenge.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Application.Tests.Services
{
    public sealed class CountryServiceFake :
        ICountriesService
    {
        private readonly List<Country> _countries;
        public CountryServiceFake()
        {
            _countries = new List<Country>
            {
                new Country(
                    "Brazil",
                    "BRA",
                    "",
                    0,
                    "",
                    new Currency[]{new Currency("BRL","Brazilian Real","R$")},
                    new EconomicBloc[]{new EconomicBloc("USAN", "Union of South American Nations") },
                    new string[]{ },new string[]{ },new string[]{ }),
                new Country(
                "Argentina",
                "ARG",
                "",
                0,
                "",
                new Currency[] { new Currency("ARG", "Argentinian pesos", "$") },
                new EconomicBloc[] { new EconomicBloc("USAN", "Union of South American Nations") },
                    new string[]{ },new string[]{ },new string[]{ }),
                new Country(
                    "United States of America",
                    "USA",
                    "",
                    0,
                    "",
                    new Currency[] { new Currency("USD", "United States dollar", "$") },
                    new EconomicBloc[] { new EconomicBloc("NAFTA", "North American Free Trade Agreement") },
                    new string[]{ },new string[]{ },new string[]{ }),
                new Country(
                    "United States of Canada",
                    "CAN",
                    "",
                    0,
                    "",
                    new Currency[] { new Currency("USD", "United States dollar", "$") },
                    new EconomicBloc[] { new EconomicBloc("NAFTA", "North American Free Trade Agreement") },
                    new string[]{ },new string[]{ },new string[]{ })
            };
        }


        public ICountry Find(string name)
        {
            var countryByCode = _countries.FirstOrDefault(country => country.Name == name);
            return countryByCode;
        }

        public Task<IEnumerable<ICountry>> GetAll()
        {
            return Task.FromResult(_countries.Cast<ICountry>());
        }

        public Task<IEnumerable<ICountry>> GetAll(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                filter = string.Empty;

            var normalizedFilter = filter.ToLower().Trim();

            var filteredCountries = _countries.Where(
               country => country.Name.ToLower().Contains(normalizedFilter) ||
               (country.Abbreviation != null && country.Abbreviation.ToLower().Contains(normalizedFilter)) ||
               country.Currencies.Any(currency => currency.Name.ToLower().Contains(normalizedFilter))).ToList();

            return Task.FromResult(filteredCountries.Cast<ICountry>());
        }
    }
}