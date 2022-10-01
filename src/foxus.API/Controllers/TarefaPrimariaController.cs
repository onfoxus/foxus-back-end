using Foxus.API.Application.TaskPrimaria.Command;
using Foxus.API.Application.TaskPrimaria.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace Foxus.API.Controllers
{
    [ApiController]
    [Route("api/v1/tarefaprimaria")]
    public class TarefaPrimariaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarefaPrimariaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {
            var tarefasPrimarias = await _mediator.Send(new GetAllTarefasPrimariasQuery(), cancellation).ConfigureAwait(false);

            return tarefasPrimarias.Any() ? Ok(tarefasPrimarias) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync(CreateTarefaPrimariaCommand createTarefaPrimariaCommand, CancellationToken cancellationToken)
        {
            if (!createTarefaPrimariaCommand.Validation.IsValid)
                return BadRequest(createTarefaPrimariaCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createTarefaPrimariaCommand, cancellationToken).ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(UpdateTarefaPrimariaCommand updateTarefaPrimariaCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(updateTarefaPrimariaCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(DeleteTarefaPrimariaCommand deleteTarefaPrimariaCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteTarefaPrimariaCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}
