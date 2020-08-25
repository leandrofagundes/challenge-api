using Challenge.CountryServiceProxy.Entities;
using Challenge.Domain.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;

namespace Challenge.CountryServiceProxy.CacheDb
{
    public sealed class InMemoryCacheDb
    {
        private readonly List<Country> _cache;
        private readonly Timer _timer;

        private const int SecondsToMinutesFactor = 60000;
        public InMemoryCacheDb(int cacheResetInMinutes = 0)
        {
            if (cacheResetInMinutes > 0)
            {
                _timer = new Timer(SecondsToMinutesFactor * cacheResetInMinutes);
                _timer.Elapsed += Timer_Elapsed;
                _timer.Start();
            }

            _cache = new List<Country>();
        }

        internal bool IsEmpty()
        {
            return _cache.Count == 0;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();

            _cache.Clear();

            _timer.Start();
        }

        public ICountry Find(string name)
        {
            return _cache.FirstOrDefault(country => country.Name.Equals(name));
        }

        public void Add(IEnumerable<Country> countries)
        {
            _cache.Clear();
            _cache.AddRange(countries);
        }

        internal IReadOnlyCollection<Country> GetAll()
        {
            return new ReadOnlyCollection<Country>(_cache);
        }
    }
}
