using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Foxus.API.Application.Execucao.Command;
using Foxus.API.Application.Execucao.Query;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Foxus.API.Controllers
{
    [ApiController]
    [Route("api/v1/execucao")]
    public class ExecucaoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExecucaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {
            var execucoes = await _mediator.Send(new GetAllExecucoesQuery(), cancellation).ConfigureAwait(false);

            return execucoes.Any() ? Ok(execucoes) : NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellation)
        {
            var execucao = await _mediator.Send(new GetExecucaoQuery(id), cancellation).ConfigureAwait(false);

            return execucao != null ? Ok(execucao) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreateExecucaoCommand createExecucaoCommand, CancellationToken cancellationToken)
        {
            if (!createExecucaoCommand.Validation.IsValid)
                return BadRequest(createExecucaoCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createExecucaoCommand, cancellationToken).ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(DeleteExecucaoCommand deleteExecucaoCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteExecucaoCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}