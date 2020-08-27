using Challenge.Application.Tests.Fixtures;
using Challenge.Application.UseCases.V1.Countries.Find;
using System;
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
        [InlineData("Brazil", "BRA")]
        [InlineData("Argentina", "ARG")]
        [InlineData("Antigua and Barbuda", "ANT")]
        public async Task ShouldSuccess(string name, string abbreviation)
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceFake,
                presenter);

            await useCase.Execute(new InputData(name));

            Assert.Equal(abbreviation, presenter.OutputData.Abbreviation);
        }

        [Fact]
        public async Task ShouldThrowsNotFound()
        {
            var presenter = new Presenter();

            var useCase = new UseCase(
                _fixture.CountryServiceFake,
                presenter);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await useCase.Execute(new InputData("Island"));
            });
        }
    }
}
