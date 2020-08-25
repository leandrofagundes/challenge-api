using Challenge.CountryServiceProxy.Entities;
using System.Collections.Generic;
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

        public void Add(IEnumerable<Country> countries)
        {
            _cache.AddRange(countries);
        }

        internal IEnumerable<Country> GetAll()
        {
            return _cache;
        }
    }
}
