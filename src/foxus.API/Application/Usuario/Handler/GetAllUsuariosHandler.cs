using Foxus.API.Application.Usuario.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Usuario.Handler
{
    public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<Domain.Usuario>>
    {
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;

        public GetAllUsuariosHandler(IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Domain.Usuario>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
