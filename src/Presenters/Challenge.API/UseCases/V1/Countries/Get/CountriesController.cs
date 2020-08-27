using Challenge.Application.UseCases.V1.Countries.Get;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.API.UseCases.V1.Countries.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        /// Busca uma lista de países baseado no filtro informado.
        /// </summary>
        /// <param name="filter">Filtro que pode ser utilizado para pesquisa com base no nome do país, sigla ou moeda.</param>
        /// <param name="token">Cancellation Token usado quando o ponto que fez a requisição quiser desistir da consulta.</param>
        /// <returns>O retorno <see cref="StatusCodes.Status200OK"/> contendo a lista de países encontrados. Essa lista pode ser vazia.</returns>
        /// <response code="500">Ocorreu um erro no servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseData))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] string filter, CancellationToken token)
        {
            var inputData = new InputData(filter);

            await _mediator.PublishAsync(inputData, token);

            return _presenter.ViewModel;
        }

    }
}