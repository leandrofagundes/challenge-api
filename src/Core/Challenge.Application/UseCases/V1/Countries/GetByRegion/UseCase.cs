using Challenge.Application.Services.Countries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Application.UseCases.V1.Countries.GetByRegion
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
                var countries = await _countriesService.GetByRegion(inputData.RegionName);

                var outputDataCountries = countries.Select(country => new OutputDataCountryItem(
                    country.Name,
                    country.Abbreviation,
                    country.Flag
                    )).ToList();

                var outputData = new OutputData(outputDataCountries);

                _outputPort.Success(outputData);
            }
            catch (InvalidOperationException)
            {
                _outputPort.ExternalServiceError();
            }
        }
    }
}
