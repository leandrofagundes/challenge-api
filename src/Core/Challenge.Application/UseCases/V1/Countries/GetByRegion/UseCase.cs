using Challenge.Application.Services.Countries;
using System;
using System.Linq;
using System.Threading;
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

        public async Task Execute(InputData inputData, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var countries = await _countriesService.GetByRegion(inputData.RegionName);

                cancellationToken.ThrowIfCancellationRequested();

                var outputDataCountries = countries.Select(country => new OutputDataCountryItem(
                    country.Name,
                    country.Abbreviation,
                    country.Flag
                    )).ToList();

                var outputData = new OutputData(outputDataCountries);

                cancellationToken.ThrowIfCancellationRequested();

                _outputPort.Success(outputData);
            }
            catch (OperationCanceledException)
            {
                _outputPort.Cancelled();
            }
            catch (InvalidOperationException)
            {
                _outputPort.ExternalServiceError();
            }
        }
    }
}
