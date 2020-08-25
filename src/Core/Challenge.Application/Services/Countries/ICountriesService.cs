using Challenge.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Application.Services.Countries
{
    public interface ICountriesService
    {
        Task<IEnumerable<ICountry>> GetAll();
        Task<ICountry> Find();
    }
}
