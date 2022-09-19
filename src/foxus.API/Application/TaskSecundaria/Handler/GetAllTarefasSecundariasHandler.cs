using Foxus.API.Application.TaskSecundaria.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskSecundaria.Handler
{
    public class GetAllTarefasSecundariasHandler : IRequestHandler<GetAllTarefasSecundariasQuery, IEnumerable<Domain.TarefaSecundaria>>
    {
        private readonly IGenericRepository<Domain.TarefaSecundaria> _tarefaSecundariaRepository;

        public GetAllTarefasSecundariasHandler(IGenericRepository<Domain.TarefaSecundaria> tarefaSecundariaRepository)
        {
            _tarefaSecundariaRepository = tarefaSecundariaRepository;
        }

        public async Task<IEnumerable<Domain.TarefaSecundaria>> Handle(GetAllTarefasSecundariasQuery request, CancellationToken cancellationToken)
        {
            return await _tarefaSecundariaRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}