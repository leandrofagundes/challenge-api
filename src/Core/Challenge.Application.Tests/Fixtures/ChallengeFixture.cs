using Challenge.Application.Services.Countries;
using Challenge.Application.Tests.Services;

namespace Challenge.Application.Tests.Fixtures
{
    public sealed class ChallengeFixture
    {
        public ICountriesService CountryService { get; }
        public ChallengeFixture()
        {
            this.CountryService = new CountryServiceFake();
        }
    }
}
