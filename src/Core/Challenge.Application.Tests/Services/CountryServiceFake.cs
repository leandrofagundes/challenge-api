using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy.DTOs;
using Challenge.Domain.Entities;
using Challenge.Domain.Interfaces;
using Newtonsoft.Json;
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
            var countriesDTO = JsonConvert.DeserializeObject<List<CountryDTO>>(FakeDBConstant.APIJSONResult);

            _countries = countriesDTO.Select(countryDTO => new Country(
                      countryDTO.Name,
                      countryDTO.Alpha3Code,
                      countryDTO.Flag,
                      countryDTO.Region,
                      countryDTO.Population,
                      countryDTO.Capital,
                      countryDTO.Currencies.Select(currencyDTO => new Currency(currencyDTO.Code, currencyDTO.Name, currencyDTO.Symbol)).ToArray(),
                      countryDTO.RegionalBlocs.Select(regionalBlocDTO => new EconomicBloc(regionalBlocDTO.Acronym, regionalBlocDTO.Name)).ToArray(),
                      countryDTO.Timezones,
                      countryDTO.Languages.Select(languateDTO => languateDTO.Name).ToArray(),
                      countryDTO.Borders
                     )).ToList();
        }


        public Task<ICountry> FindByName(string name)
        {
            var countryByCode = _countries.FirstOrDefault(country => country.Name == name);
            return Task.FromResult((ICountry)countryByCode);
        }

        public Task<IReadOnlyCollection<ICountry>> GetByRegion(string regionName)
        {
            var region = _countries.Where(
                country => country.Region.ToLower().Trim().Equals(regionName.ToLower().Trim())
                ).ToList();

            var readonlyList = new ReadOnlyCollection<Country>(region);
            return Task.FromResult((IReadOnlyCollection<ICountry>)readonlyList);
        }

        Task<IReadOnlyCollection<ICountry>> ICountriesService.GetAll(string filters)
        {
            if (string.IsNullOrWhiteSpace(filters))
                filters = string.Empty;

            var normalizedFilter = filters.ToLower().Trim();

            var filteredCountries = _countries.Where(
                country => country.Name.ToLower().Contains(normalizedFilter) ||
                (country.Abbreviation != null && country.Abbreviation.ToLower().Contains(normalizedFilter)) ||
                country.Currencies.Any(currency => currency != null && currency.Name != null && currency.Name.ToLower().Contains(normalizedFilter)))
                .Cast<ICountry>().ToList();

            var readonlyList = new ReadOnlyCollection<ICountry>(filteredCountries);
            return Task.FromResult((IReadOnlyCollection<ICountry>)readonlyList);
        }
    }
}