using Challenge.Application.Services.Countries;
using Challenge.Domain.Interfaces;
using System.Threading.Tasks;

namespace Challenge.CountryServiceProxy
{
    public sealed class CountryService :
        ICountriesService
    {
        public Task<ICountry[]> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
