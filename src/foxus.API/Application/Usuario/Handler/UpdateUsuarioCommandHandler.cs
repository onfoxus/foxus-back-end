using Foxus.API.Application.Usuario.Command;
using Foxus.API.Helper;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Usuario.Handler
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, bool>
    {
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;
        public UpdateUsuarioCommandHandler(IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            if (usuario == null)
                return false;

            usuario.Login = request.Login;
            usuario.Senha = request.Senha.GerarHash();
            usuario.Nome = request.Nome;

            _usuarioRepository.Update(usuario);

            return await _usuarioRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
