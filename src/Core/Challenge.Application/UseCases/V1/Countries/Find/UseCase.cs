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
                var country = await _countriesService.FindByName(inputData.Name);
                if (country is null)
                    throw new ArgumentOutOfRangeException("Name", inputData.Name, Resources.CountryNameNotFound);

                var outputData = new OutputData(
                    country.Name,
                    country.Abbreviation,
                    country.Flag,
                    country.Population,
                    country.Capital,
                    country.Region,
                    country.Currencies.Select(currency => new OutputDataCurrency(currency.Name)).ToArray(),
                    country.EconomicGroups.Select(economicBloc => new OutputDataEconomicBloc(economicBloc.Acronym, economicBloc.Name)).ToArray(),
                    country.Languages,
                    country.Timezones,
                    country.Borders);

                _outputPort.Success(outputData);
            }
            catch (ArgumentOutOfRangeException outOfRangeEx)
            {
                _outputPort.NotFound(outOfRangeEx.ActualValue);
            }

        }
    }
}
