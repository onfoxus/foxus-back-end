using Foxus.API.Application.TaskPrimaria.Command;
using Foxus.API.Application.TaskSecundaria.Command;
using Foxus.API.Application.TaskSecundaria.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Controllers
{
    [ApiController]
    [Route("api/v1/tarefasecundaria")]
    public class TarefaSecundariaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarefaSecundariaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {
            var tarefasSecundarias = await _mediator.Send(new GetAllTarefasSecundariasQuery(), cancellation).ConfigureAwait(false);

            return tarefasSecundarias.Any() ? Ok(tarefasSecundarias) : NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(UpdateTarefaSecundariaCommand updateTarefaSecundariaCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(updateTarefaSecundariaCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(DeleteTarefaSecundariaCommand deleteTarefaSecundariaCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteTarefaSecundariaCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}
