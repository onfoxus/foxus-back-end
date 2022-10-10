using Foxus.API.Application.Execucao.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Execucao.Handler
{
    public class GetExecucaoHandler : IRequestHandler<GetExecucaoQuery, Domain.Execucao>
    {
        private readonly IGenericRepository<Domain.Execucao> _execucaoRepository;

        public GetExecucaoHandler(IGenericRepository<Domain.Execucao> execucaoRepository)
        {
            _execucaoRepository = execucaoRepository;
        }

        public async Task<Domain.Execucao> Handle(GetExecucaoQuery request, CancellationToken cancellationToken)
        {
            return await _execucaoRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);
        }
    }
}
