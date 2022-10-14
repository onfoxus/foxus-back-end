using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Foxus.API.Application.Login.Query;
using Foxus.API.Services;
using Microsoft.IdentityModel.Tokens;

namespace Foxus.API.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("login")]
        public async Task<ActionResult<dynamic>> LoginAsync(GetLoginQuery getLoginQuery, CancellationToken cancellation)
        {
            var usuarioValido = await _mediator.Send(getLoginQuery, cancellation).ConfigureAwait(false);

            if (usuarioValido != null)
            {
                var token = TokenService.GenerateToken(usuarioValido);
                var refreshToken = TokenService.GenerateRefreshToken();
                TokenService.SaveRefreshToken(usuarioValido.LoginUsuario, refreshToken);

                return new
                {
                    login = usuarioValido.LoginUsuario,
                    token = token,
                    refreshToken = refreshToken
                };
            }
            else
                return Unauthorized();
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(string token, string refreshToken)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var login = principal.Identity.Name;
            var savedRefreshToken = TokenService.GetRefreshToken(login);

            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newJwtToken = TokenService.GenerateToken(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();

            TokenService.DeleteRefreshToken(login, refreshToken);
            TokenService.SaveRefreshToken(login, newRefreshToken);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }
    }
}
