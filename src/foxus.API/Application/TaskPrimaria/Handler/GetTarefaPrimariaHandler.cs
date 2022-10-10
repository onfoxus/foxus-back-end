using Foxus.API.Application.TaskPrimaria.Query;
using Foxus.Domain;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskPrimaria.Handler
{
    public class GetTarefaPrimariaHandler : IRequestHandler<GetTarefaPrimariaQuery, Domain.TarefaPrimaria>
    {
        private readonly IGenericRepository<Domain.TarefaPrimaria> _tarefaPrimariaRepository;

        public GetTarefaPrimariaHandler(IGenericRepository<TarefaPrimaria> tarefaPrimariaRepository)
        {
            _tarefaPrimariaRepository = tarefaPrimariaRepository;
        }

        public async Task<TarefaPrimaria> Handle(GetTarefaPrimariaQuery request, CancellationToken cancellationToken)
        {
            return await _tarefaPrimariaRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);
        }
    }
}
