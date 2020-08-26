using Challenge.Application.UseCases.V1.Countries.Find;
using Microsoft.AspNetCore.Mvc;

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
            this.ViewModel = new OkObjectResult(outputData);
        }
    }
}