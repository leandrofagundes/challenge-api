using Challenge.Application.UseCases.V1.Countries.Find;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Challenge.API.UseCases.V1.Countries.Find
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/{name}")]
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
        /// Busca os detalhes de um Pa�s.
        /// </summary>
        /// <param name="name">Nome do Pa�s</param>
        /// <returns>O retorno <see cref="StatusCodes.Status200OK"/> juntamente com o registro obtido.</returns>
        /// <response code="200">Registro foi encontrado corretamente e ser� retornado.</response>
        /// <response code="404">N�o foi encontrado nenhum conte�do para o pa�s informado.</response>
        /// <response code="500">Ocorreu um erro no servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseData))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Find([Required] string name)
        {
            var inputData = new InputData(name);

            await _mediator.PublishAsync(inputData);

            return _presenter.ViewModel;
        }

    }
}