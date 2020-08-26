using Challenge.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Application.Services.Countries
{
    public interface ICountriesService
    {
        Task<IReadOnlyCollection<ICountry>> GetAll(string filters);
        Task<ICountry> FindByName(string name);
    }
}
