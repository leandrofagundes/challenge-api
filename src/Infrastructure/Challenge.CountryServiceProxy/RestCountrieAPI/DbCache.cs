using Challenge.CountryServiceProxy.RestCountrieAPI;
using Challenge.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.CountryServiceProxy.CacheDb
{
    public sealed class DbCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly APIClient _apiHTTPClient;

        public DbCache(IMemoryCache memoryCache, APIClient apiHTTPClient)
        {
            _memoryCache = memoryCache;
            _apiHTTPClient = apiHTTPClient;
        }

        public async Task<Country[]> All()
        {
            return await _memoryCache.GetOrCreateAsync("all", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                entry.SetPriority(CacheItemPriority.High);

                return await LoadData();
            });
        }

        private async Task<Country[]> LoadData()
        {
            var countriesDTOS = await _apiHTTPClient.GetAllFromRemote();
            var countries = countriesDTOS.Select(countryDTO => new Country(
                      countryDTO.Name,
                      countryDTO.CIOC,
                      countryDTO.Flag,
                      countryDTO.Region,
                      countryDTO.Population,
                      countryDTO.Capital,
                      countryDTO.Currencies.Select(currencyDTO => new Currency(currencyDTO.Code, currencyDTO.Name, currencyDTO.Symbol)).ToArray(),
                      countryDTO.RegionalBlocs.Select(regionalBlocDTO => new EconomicBloc(regionalBlocDTO.Acronym, regionalBlocDTO.Name)).ToArray(),
                      countryDTO.Timezones,
                      countryDTO.Languages.Select(languateDTO => languateDTO.Name).ToArray(),
                      countryDTO.Borders
                     )).ToArray();

            return countries;
        }

        internal async Task<Country[]> Region(string regionName)
        {
            return await _memoryCache.GetOrCreateAsync(regionName, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                entry.SetPriority(CacheItemPriority.High);

                return await LoadRegion(regionName);
            });
        }

        private async Task<Country[]> LoadRegion(string regionName)
        {
            var countriesDTOS = await _apiHTTPClient.GetRegionFromRemote(regionName);
            var countries = countriesDTOS.Select(countryDTO => new Country(
                      countryDTO.Name,
                      countryDTO.CIOC,
                      countryDTO.Flag,
                      countryDTO.Region,
                      countryDTO.Population,
                      countryDTO.Capital,
                      countryDTO.Currencies.Select(currencyDTO => new Currency(currencyDTO.Code, currencyDTO.Name, currencyDTO.Symbol)).ToArray(),
                      countryDTO.RegionalBlocs.Select(regionalBlocDTO => new EconomicBloc(regionalBlocDTO.Acronym, regionalBlocDTO.Name)).ToArray(),
                      countryDTO.Timezones,
                      countryDTO.Languages.Select(languateDTO => languateDTO.Name).ToArray(),
                      countryDTO.Borders
                     )).ToArray();

            return countries;
        }

    }
}
