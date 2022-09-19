using Foxus.API.Application.Usuario.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Usuario.Handler
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, bool>
    {
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;
        public DeleteUsuarioCommandHandler(IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            _usuarioRepository.Delete(usuario);

            return await _usuarioRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
