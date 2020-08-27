using Challenge.Application.Properties;
using Challenge.Application.Services.Countries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Application.UseCases.V1.Countries.GetRoute
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
                var originCountry = await _countriesService.FindByName(inputData.Origin);
                if (originCountry is null)
                    throw new ArgumentOutOfRangeException(Resources.CountryNameNotFound);

                var destinyCountry = await _countriesService.FindByName(inputData.Destiny);
                if (destinyCountry is null)
                    throw new ArgumentOutOfRangeException(Resources.CountryNameNotFound);

                if (!destinyCountry.Region.Equals(originCountry.Region))
                    throw new ArgumentOutOfRangeException(Resources.CountryNameNotFound);

                var countriesInRoute = await _countriesService.GetRoute(originCountry, destinyCountry);
                var outputDataCountries = countriesInRoute.Select(
                    country => new OutputDataRouteCountryItem(
                        country.Name,
                        country.Flag)
                    ).ToList();

                var outputData = new OutputData(outputDataCountries);

                _outputPort.Success(outputData);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _outputPort.InvalidData(ex.Message);
            }
        }
    }
}
