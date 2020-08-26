using Challenge.Application.Services.Countries;
using Challenge.Application.Tests.Services;

namespace Challenge.Application.Tests.Fixtures
{
    public sealed class ChallengeFixture
    {
        public ICountriesService CountryServiceFake { get; }
        public ICountriesService CountryServiceAPI { get; }
        public ChallengeFixture()
        {
            this.CountryServiceFake = new CountryServiceFake();
            this.CountryServiceAPI = new CountryServiceProxy.CountryService(new CountryServiceProxy.CacheDb.InMemoryCacheDb(0), new CountryServiceProxy.APIClient.RestCountriesAPIClient(new System.Net.Http.HttpClient() { BaseAddress = new System.Uri("https://restcountries.eu/rest/") }));
        }
    }
}
