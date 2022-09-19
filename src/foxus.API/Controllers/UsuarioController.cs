using Foxus.API.Application.Usuario.Command;
using Foxus.API.Application.Usuario.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {
            var usuarios = await _mediator.Send(new GetAllUsuariosQuery(), cancellation).ConfigureAwait(false);

            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync(CreateUsuarioCommand createUsuarioCommand, CancellationToken cancellationToken)
        {
            if (!createUsuarioCommand.Validation.IsValid)
                return BadRequest(createUsuarioCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createUsuarioCommand, cancellationToken).ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(UpdateUsuarioCommand updateUsuarioCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(updateUsuarioCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(DeleteUsuarioCommand deleteUsuarioCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteUsuarioCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}
