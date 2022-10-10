using Foxus.API.Application.TaskPrimaria.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Foxus.API.Application.Execucao.Query;

namespace Foxus.API.Application.Execucao.Handler
{
    public class GetAllExecucaoHandler : IRequestHandler<GetAllExecucoesQuery, IEnumerable<Domain.Execucao>>
    {
        private readonly IGenericRepository<Domain.Execucao> _execucaoRepository;

        public GetAllExecucaoHandler(IGenericRepository<Domain.Execucao> execucaoRepository)
        {
            _execucaoRepository = execucaoRepository;
        }

        public async Task<IEnumerable<Domain.Execucao>> Handle(GetAllExecucoesQuery request, CancellationToken cancellationToken)
        {
            return await _execucaoRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
