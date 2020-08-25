using Challenge.Application.Services.Countries;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class UseCase :
        IUseCase
    {
        private readonly ICountriesService _countriesService;
        private readonly IOutputPort _outputPort;

        public UseCase(
            ICountriesService countriesService,
            IOutputPort outputPort)
        {
            _countriesService = countriesService;
            _outputPort = outputPort;
        }

        public async Task Execute(InputData inputData)
        {
            var countries = await _countriesService.GetAll();

            var outputDataCountries = countries.Select(country => new OutputDataCountryItem(
                country.Name,
                country.CIOC,
                country.Currencies.Select(currency => new OutputDataCountryCurrencyItem(currency.Name)).ToArray(),
                country.RegionalBlocs.Select(regionalBloc => new OutputDataCountryRegionalBlocItem(regionalBloc.Name)).ToArray()
                ));

            var outputData = new OutputData(outputDataCountries);

            _outputPort.Success(outputData);
        }
    }
}
