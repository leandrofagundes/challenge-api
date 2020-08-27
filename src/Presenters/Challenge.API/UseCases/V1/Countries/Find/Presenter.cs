using Challenge.Application.UseCases.V1.Countries.Find;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Challenge.API.UseCases.V1.Countries.Find
{
    public sealed class Presenter :
        IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void NotFound(object value)
        {
            this.ViewModel = new NotFoundObjectResult(value);
        }

        public void Success(OutputData outputData)
        {
            var responseData = new ResponseData
            {
                Name = outputData.Name,
                Abbreviation = outputData.Abbreviation,
                Currencies = string.Join(", ", outputData.Currencies.Select(currency => currency.Name)),
                Region = outputData.Region,
                Population = outputData.Population,
                Flag = outputData.Flag,
                EconomicBlocs = string.Join(", ", outputData.EconomicBlocs.Select(bloc => bloc.Acronym)),
                Capital = outputData.Capital,
                Borders = string.Join(", ", outputData.Borders),
                Languages = string.Join(", ", outputData.Languages),
                Timezone = string.Join(", ", outputData.Timezones)
            };

            this.ViewModel = new OkObjectResult(responseData);
        }
    }
}