using Foxus.API.Application.TaskPrimaria.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskPrimaria.Handler
{
    public class GetAllTarefasPrimariasHandler : IRequestHandler<GetAllTarefasPrimariasQuery, IEnumerable<Domain.TarefaPrimaria>>
    {
        private readonly IGenericRepository<Domain.TarefaPrimaria> _tarefaPrimariaRepository;

        public GetAllTarefasPrimariasHandler(IGenericRepository<Domain.TarefaPrimaria> tarefaPrimariaRepository)
        {
            _tarefaPrimariaRepository = tarefaPrimariaRepository;
        }

        public async Task<IEnumerable<Domain.TarefaPrimaria>> Handle(GetAllTarefasPrimariasQuery request, CancellationToken cancellationToken)
        {
            return await _tarefaPrimariaRepository.GetAllAsync(
                noTracking: false,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}