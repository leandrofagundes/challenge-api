using Challenge.Application.Services.Countries;
using Challenge.CountryServiceProxy.CacheDb;
using Challenge.Domain.Entities;
using Challenge.Domain.Interfaces;
using System;
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

        public async Task<IReadOnlyCollection<ICountry>> GetByRegion(string regionName)
        {
            var region = await _cache.Region(regionName);
            return new ReadOnlyCollection<ICountry>(region);
        }

        public async Task<IReadOnlyCollection<ICountry>> GetRoute(ICountry originCountry, ICountry destinyCountry)
        {
            var regionCountries = await GetByRegion(originCountry.Region);
            var regionCountriesLessOrigin = regionCountries.Where(country => country.Abbreviation != originCountry.Abbreviation).ToList();

            var bestRoute = QualifiedSearch(regionCountriesLessOrigin, originCountry, destinyCountry);
            return new ReadOnlyCollection<ICountry>(bestRoute);
        }

        
        private List<ICountry> QualifiedSearch(List<ICountry> regionCountries, ICountry origin, ICountry targetCountry)
        {
            Queue<ICountry> countriesToCheck = new Queue<ICountry>();
            HashSet<ICountry> checkedCountries = new HashSet<ICountry>();
            Stack<ICountry> bestRoute = new Stack<ICountry>();

            Dictionary<string, ICountry> relations = new Dictionary<string, ICountry>();

            countriesToCheck.Enqueue(origin);
            checkedCountries.Add(origin);

            while (countriesToCheck.Count > 0)
            {
                ICountry currentCountry = countriesToCheck.Dequeue();
                if (currentCountry.Name == targetCountry.Name)
                {
                    bestRoute.Push(currentCountry);
                    var lastIn = currentCountry;
                    while (relations.Any())
                    {
                        if (relations.ContainsKey(lastIn.Abbreviation))
                        {
                            var abbreviationToRemove = lastIn.Abbreviation;
                            lastIn = relations[abbreviationToRemove];
                            bestRoute.Push(lastIn);
                            relations.Remove(abbreviationToRemove);
                        }
                        else
                            relations.Clear();
                    }
                    return bestRoute.ToList();
                }

                var borderCountries = regionCountries.Where(regionCountry => currentCountry.Borders.Contains(regionCountry.Abbreviation)).ToArray();

                foreach (var border in borderCountries)
                {
                    if (!checkedCountries.Contains(border))
                    {
                        relations.Add(border.Abbreviation, currentCountry);
                        countriesToCheck.Enqueue(border);
                        checkedCountries.Add(border);
                    }
                    regionCountries.Remove(border);
                }
            }

            return new List<ICountry>();
        }

        private Country[] FilterCountries(Country[] countries, string filters)
        {
            var normalizedFilter = filters.ToLower().Trim();
            var filteredCountries = countries.ToList();

            filteredCountries = filteredCountries.Where(
                country => country.Name.ToLower().Contains(normalizedFilter) ||
                (country.Abbreviation != null && country.Abbreviation.ToLower().Contains(normalizedFilter)) ||
                country.Currencies.Any(currency => currency.Name != null && currency.Name != null && currency.Name.ToLower().Contains(normalizedFilter))).ToList();

            return filteredCountries.ToArray();
        }
    }
}
