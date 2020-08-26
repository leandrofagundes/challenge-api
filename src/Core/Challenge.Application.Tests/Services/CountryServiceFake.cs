using Challenge.Application.Services.Countries;
using Challenge.Domain.Entities;
using Challenge.Domain.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public Task<ICountry> FindByName(string name)
        {
            var countryByCode = _countries.FirstOrDefault(country => country.Name == name);
            return Task.FromResult((ICountry)countryByCode);
        }

        Task<IReadOnlyCollection<ICountry>> ICountriesService.GetAll(string filters)
        {
            if (string.IsNullOrWhiteSpace(filters))
                filters = string.Empty;

            var normalizedFilter = filters.ToLower().Trim();

            var filteredCountries = _countries.Where(
                country => country.Name.ToLower().Contains(normalizedFilter) ||
                (country.Abbreviation != null && country.Abbreviation.ToLower().Contains(normalizedFilter)) ||
                country.Currencies.Any(currency => currency.Name.ToLower().Contains(normalizedFilter)))
                .Cast<ICountry>().ToList();

            var readonlyList = new ReadOnlyCollection<ICountry>(filteredCountries);
            return Task.FromResult((IReadOnlyCollection<ICountry>)readonlyList);
        }
    }
}