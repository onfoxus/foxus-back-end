using Foxus.API.Application.Login.Query;
using Foxus.API.Helper;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Login.Handler
{
    public class GetLoginHandler : IRequestHandler<GetLoginQuery, Domain.Login>
    {
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;

        public GetLoginHandler(IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Domain.Login> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync(noTracking: true, cancellationToken: cancellationToken).ConfigureAwait(false);

            var usuarioValido = usuarios.FirstOrDefault(usuario => usuario.Login == request.LoginUsuario && usuario.Senha == request.Senha.GerarHash());

            if (usuarioValido == null)
                return null;

            return new Domain.Login()
            {
                LoginUsuario = usuarioValido.Login,
                Senha = string.Empty
            };
        }
    }
}
