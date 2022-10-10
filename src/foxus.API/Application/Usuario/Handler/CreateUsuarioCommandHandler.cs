using Foxus.API.Application.Usuario.Command;
using Foxus.API.Helper;
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
            var usuarios = await _usuarioRepository.GetAllAsync(noTracking: true, cancellationToken: cancellationToken).ConfigureAwait(false);

            if (!request.Validation.IsValid)
                return false;

            foreach(var user in usuarios)
            {
                if (user.Login == request.Login)
                    return false;
            }            

            var usuario = new Domain.Usuario
            {
                Login = request.Login,
                Senha = request.Senha.GerarHash(),
                Nome = request.Nome
            };

            await _usuarioRepository.AddAsync(usuario, cancellationToken).ConfigureAwait(false);

            return await _usuarioRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
