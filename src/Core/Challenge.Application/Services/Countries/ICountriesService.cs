using Challenge.Application.Services.Countries.DTOs;
using System.Threading.Tasks;

namespace Challenge.Application.Services.Countries
{
    public interface ICountriesService
    {
        Task<CountryDTO[]> GetAll();
    }
}
