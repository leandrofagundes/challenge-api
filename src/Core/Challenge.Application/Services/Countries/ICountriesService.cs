using Challenge.Domain.Interfaces;
using System.Threading.Tasks;

namespace Challenge.Application.Services.Countries
{
    public interface ICountriesService
    {
        Task<ICountry[]> GetAll();
    }
}
