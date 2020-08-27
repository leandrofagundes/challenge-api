using Challenge.Application.UseCases.V1.Countries.GetRoute;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Challenge.API.UseCases.V1.Countries.GetRoute
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/route/{origin}/{destiny}")]
    [ApiController]
    public sealed class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly Presenter _presenter;

        public CountriesController(
            IMediator mediator,
            Presenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Busca a rota entre dois países.
        /// </summary>
        /// <param name="origin">Nome do país de origem que deseja-se obter a rota.</param>
        /// <param name="destiny">Nome do país destino que deseja-se obter a rota.</param>
        /// <returns>O retorno <see cref="StatusCodes.Status200OK"/> contendo a lista de países encontrados. Essa lista pode ser vazia.</returns>
        /// <response code="400">Os dados dos países informados são inválidos.</response>
        /// <response code="500">Ocorreu um erro no servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseData))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string origin, string destiny)
        {
            var inputData = new InputData(origin, destiny);

            await _mediator.PublishAsync(inputData);

            return _presenter.ViewModel;
        }

    }
}