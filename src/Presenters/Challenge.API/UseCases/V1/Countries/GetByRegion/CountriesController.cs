using Challenge.Application.UseCases.V1.Countries.GetByRegion;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.API.UseCases.V1.Countries.GetByRegion
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/region/{regionName}")]
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
        /// Busca uma lista de pa�ses de um determinado continente.
        /// </summary>
        /// <param name="regionName">Nome do continente que deseja-se obter os pa�ses.</param>
        /// <param name="token">Cancellation Token usado quando o ponto que fez a requisi��o quiser desistir da consulta.</param>
        /// <returns>O retorno <see cref="StatusCodes.Status200OK"/> contendo a lista de pa�ses encontrados. Essa lista pode ser vazia.</returns>
        /// <response code="500">Ocorreu um erro no servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseData))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] string regionName, CancellationToken token)
        {
            var inputData = new InputData(regionName);

            await _mediator.PublishAsync(inputData, token);

            return _presenter.ViewModel;
        }

    }
}