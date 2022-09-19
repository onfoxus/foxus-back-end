using Foxus.API.Application.Usuario.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Usuario.Handler
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, bool>
    {
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;
        public CreateUsuarioCommandHandler(IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var usuario = new Domain.Usuario
            {
                Login = request.Login,
                Senha = request.Senha,
                Nome = request.Nome
            };

            await _usuarioRepository.AddAsync(usuario, cancellationToken).ConfigureAwait(false);

            return await _usuarioRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
