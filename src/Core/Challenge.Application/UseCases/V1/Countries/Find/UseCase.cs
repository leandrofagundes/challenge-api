using Challenge.Application.Services.Countries;
using System.Threading.Tasks;

namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class UseCase :
        IUseCase
    {
        private readonly ICountriesService _countriesService;

        public UseCase(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        public async Task Execute(InputData inputData)
        {
            await _countriesService.GetAll();
        }
    }
}
