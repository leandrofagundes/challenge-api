using Challenge.Application.Tests.Fixtures;
using Challenge.Application.UseCases.V1.Countries.GetByRegion;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Challenge.Application.Tests.UseCases.V1.GetByRegion
{
    public sealed class GetByRegionTests : IClassFixture<ChallengeFixture>
    {
        private readonly ChallengeFixture _fixture;
        public GetByRegionTests(ChallengeFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldSuccess()
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceFake,
                presenter);

            await useCase.Execute(new InputData("Americas"));

            Assert.NotEmpty(presenter.OutputData.Countries);
        }

        [Theory]
        [InlineData("Americas", "Brazil")]
        [InlineData("Europe", "Italy")]
        [InlineData("Asia", "Japan")]
        public async Task ShouldContainsCountry(string regionName, string countryName)
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceFake,
                presenter);

            var cancellationTokenSource = new CancellationTokenSource();
            await useCase.Execute(new InputData(regionName));

            var containsCountry = presenter.OutputData.Countries.Any(country => country.Name.Equals(countryName));

            Assert.NotEmpty(presenter.OutputData.Countries);
            Assert.True(containsCountry);
        }

        [Fact]
        public async Task ShouldReturnEmpty()
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceFake,
                presenter);

            await useCase.Execute(new InputData("SAdjlk SAdlkj ASçsad ASDk"));

            Assert.Empty(presenter.OutputData.Countries);
        }

        [Theory]
        [InlineData("Americas", "Germany")]
        [InlineData("Europe", "Brasil")]
        [InlineData("Asia", "Brazil")]
        public async Task ShouldNotContainsCountry(string regionName, string countryName)
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceFake,
                presenter);

            var cancellationTokenSource = new CancellationTokenSource();
            await useCase.Execute(new InputData(regionName));

            var containsCountry = presenter.OutputData.Countries.Any(country => country.Name.Equals(countryName));

            Assert.NotEmpty(presenter.OutputData.Countries);
            Assert.False(containsCountry);
        }
    }
}
