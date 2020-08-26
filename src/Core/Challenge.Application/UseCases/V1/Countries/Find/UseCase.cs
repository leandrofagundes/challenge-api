using Challenge.Application.Properties;
using Challenge.Application.Services.Countries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Application.UseCases.V1.Countries.Find
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
            try
            {
                var country = _countriesService.Find(inputData.NumericCode);
                if (country is null)
                    throw new ArgumentOutOfRangeException("NumericCode", inputData.NumericCode, Resources.CountryNumericCodeNotFound);

                var outputData = new OutputData(
                    country.Name,
                    country.Abbreviation,
                    country.Currencies.Select(currency => new OutputDataCurrency(currency.Name)).ToArray(),
                    country.EconomicGroups.Select(regionalBloc => new OutputDataRegionalBloc(regionalBloc.Name)).ToArray());

                _outputPort.Success(outputData);

                await Task.CompletedTask;
            }
            catch (ArgumentOutOfRangeException outOfRangeEx)
            {
                _outputPort.NotFound(outOfRangeEx.Message, outOfRangeEx.ActualValue);
            }

        }
    }
}
