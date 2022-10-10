using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Foxus.API.Application.PomodoroTimer.Command;
using Foxus.API.Application.PomodoroTimer.Query;
using System.Linq;

namespace Foxus.API.Controllers
{
    [ApiController]
    [Route("api/v1/pomodorotimer")]
    public class PomodoroTimerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PomodoroTimerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {
            var pomodoroTimers = await _mediator.Send(new GetAllPomodoroTimersQuery(), cancellation).ConfigureAwait(false);

            return pomodoroTimers.Any() ? Ok(pomodoroTimers) : NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellation)
        {
            var pomodoroTimer = await _mediator.Send(new GetPomodoroTimerQuery(id), cancellation).ConfigureAwait(false);

            return !pomodoroTimer.Equals(null) ? Ok(pomodoroTimer) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync(CreatePomodoroTimerCommand createPomodoroTimerCommand, CancellationToken cancellationToken)
        {
            if (!createPomodoroTimerCommand.Validation.IsValid)
                return BadRequest(createPomodoroTimerCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createPomodoroTimerCommand, cancellationToken).ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(UpdatePomodoroTimerCommand updatePomodoroTimerCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(updatePomodoroTimerCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(DeletePomodoroTimerCommand deletePomodoroTimerCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deletePomodoroTimerCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}
