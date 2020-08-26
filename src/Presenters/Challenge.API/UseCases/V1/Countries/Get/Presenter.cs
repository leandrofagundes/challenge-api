using Challenge.Application.UseCases.V1.Countries.Get;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.UseCases.V1.Countries.Get
{
    public sealed class Presenter :
        IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

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
            this.ViewModel = new OkObjectResult(outputData);
        }
    }
}