using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Foxus.API.Application.Login.Query;

namespace Foxus.API.Controllers
{
    [ApiController]
    [Route("api/v1/login")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLoginAsync(GetLoginQuery getLoginQuery, CancellationToken cancellation)
        {
            var usuarioValido = await _mediator.Send(getLoginQuery, cancellation).ConfigureAwait(false);

            return usuarioValido != null ? Ok(usuarioValido) : NoContent();
        }
    }
}
