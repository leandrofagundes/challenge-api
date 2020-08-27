using Challenge.Application.UseCases.V1.Countries.GetByRegion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Challenge.API.UseCases.V1.Countries.GetByRegion
{
    public sealed class Presenter :
        IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Cancelled()
        {
            this.ViewModel = new ObjectResult(null)
            {
                StatusCode = StatusCodes.Status204NoContent
            };
        }

        public void ExternalServiceError()
        {
            this.ViewModel = new ObjectResult(null)
            {
                StatusCode = StatusCodes.Status408RequestTimeout
            };
        }

        public void NotFound(object value)
        {
            this.ViewModel = new NotFoundObjectResult(value);
        }

        public void Success(OutputData outputData)
        {
            var responseData = outputData.Countries.Select(
                country => new ResponseData
                {
                    Name = country.Name,
                    Abbreviation = country.Abbreviation,
                    Flag = country.Flag
                }).ToList();

            this.ViewModel = new OkObjectResult(responseData);
    }
}
}