using Challenge.Application.Services.Countries;
using Challenge.Application.Services.Countries.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Application.Tests.Services
{
    public sealed class CountryServiceFake :
        ICountriesService
    {
        public Task<CountryDTO[]> GetAll()
        {
            var listCountries = new List<CountryDTO>
            {
                new CountryDTO(){
                    Name="Brazil",
                    CIOC="BRA",
                    Currencies=new CurrencyDTO[]
                    {
                        new CurrencyDTO {  Code="BRL",Name="Brazilian Real",Symbol="R$"}
                    },
                    RegionalBlocs = new RegionalBlocDTO[]
                    {
                        new RegionalBlocDTO { Acronym="USAN", Name = "Union of South American Nations" }
                    }
                },
                new CountryDTO(){
                    Name="United States of America",
                    CIOC="USA",
                    Currencies=new CurrencyDTO[]
                    {
                        new CurrencyDTO {  Code="USD",Name="United States dollar",Symbol="$"}
                    },
                    RegionalBlocs = new RegionalBlocDTO[]
                    {
                        new RegionalBlocDTO { Acronym="NAFTA", Name = "North American Free Trade Agreement" }
                    }
                },
                new CountryDTO(){
                    Name="Canada",
                    CIOC="CAN",
                    Currencies=new CurrencyDTO[]
                    {
                        new CurrencyDTO {  Code="CAD",Name="Canadian dollar",Symbol="$"}
                    },
                    RegionalBlocs = new RegionalBlocDTO[]
                    {
                        new RegionalBlocDTO { Acronym="NAFTA", Name = "North American Free Trade Agreement" }
                    }
                },
                new CountryDTO(){
                    Name="Argentina",
                    CIOC="ARG",
                    Currencies=new CurrencyDTO[]
                    {
                        new CurrencyDTO {  Code="ARS",Name="Argentine peso",Symbol="$"}
                    },
                    RegionalBlocs = new RegionalBlocDTO[]
                    {
                        new RegionalBlocDTO { Acronym="USAN", Name = "Union of South American Nations" }
                    }
                }
            };

            return Task.FromResult(listCountries.ToArray());
        }
    }
}
