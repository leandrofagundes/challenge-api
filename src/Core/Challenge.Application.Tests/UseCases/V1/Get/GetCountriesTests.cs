using Challenge.Application.Tests.Fixtures;
using Challenge.Application.UseCases.V1.Countries.Get;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Challenge.Application.Tests.UseCases.V1.Get
{
    public sealed class GetCountriesTests : IClassFixture<ChallengeFixture>
    {
        private readonly ChallengeFixture _fixture;
        public GetCountriesTests(ChallengeFixture fixture)
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

            var cancellationTokenSource = new CancellationTokenSource();
            await useCase.Execute(new InputData(string.Empty), cancellationTokenSource.Token);

            Assert.NotEmpty(presenter.OutputData.Countries);
        }

        [Fact]
        public async Task GetAllFromApi_ShouldSuccess()
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceAPI,
                presenter);

            var cancellationTokenSource = new CancellationTokenSource();
            await useCase.Execute(new InputData(string.Empty), cancellationTokenSource.Token);

            Assert.NotEmpty(presenter.OutputData.Countries);
        }
    }
}
