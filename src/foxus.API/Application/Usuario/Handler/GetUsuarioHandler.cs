using Foxus.API.Application.Login.Query;
using Foxus.API.Application.Usuario.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Usuario.Handler
{
    public class GetUsuarioHandler : IRequestHandler<GetUsuarioQuery, Domain.Usuario>
    {
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;

        public GetUsuarioHandler(IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Domain.Usuario> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);
        }
    }
}