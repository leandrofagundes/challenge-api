using Challenge.Application.Tests.Fixtures;
using Challenge.Application.UseCases.V1.Countries.Find;
using System.Threading.Tasks;
using Xunit;

namespace Challenge.Application.Tests.UseCases.V1.Find
{
    public sealed class FindCountryTest :
        IClassFixture<ChallengeFixture>
    {
        private readonly ChallengeFixture _fixture;
        public FindCountryTest(ChallengeFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("079")]
        public async Task ShouldSuccess(string numericCode)
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceFake,
                presenter);

            await useCase.Execute(new InputData(numericCode));

            Assert.Equal("BRA", presenter.OutputData.CIOC);
        }
    }
}
