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
                    new Currency[]{new Currency("BRL","Brazilian Real","R$")},
                    new EconomicBloc[]{new EconomicBloc("USAN", "Union of South American Nations") }),
                new Country(
                    "Argentina",
                    "ARG",
                    "",
                    new Currency[]{new Currency("ARG","Argentinian pesos","$")},
                    new EconomicBloc[]{new EconomicBloc("USAN", "Union of South American Nations") }),
                new Country(
                    "United States of America",
                    "USA",
                    "",
                    new Currency[]{new Currency("USD", "United States dollar", "$")},
                    new EconomicBloc[]{new EconomicBloc("NAFTA", "North American Free Trade Agreement") }),
                new Country(
                    "United States of Canada",
                    "CAN",
                    "",
                    new Currency[]{new Currency("USD", "United States dollar", "$")},
                    new EconomicBloc[]{new EconomicBloc("NAFTA", "North American Free Trade Agreement") })
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
    }
}