using Foxus.API.Application.TaskSecundaria.Query;
using Foxus.Domain;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskSecundaria.Handler
{
    public class GetTarefaSecundariaHandler : IRequestHandler<GetTarefaSecundariaQuery, Domain.TarefaSecundaria>
    {
        private readonly IGenericRepository<Domain.TarefaSecundaria> _tarefaSecundariaRepository;

        public GetTarefaSecundariaHandler(IGenericRepository<TarefaSecundaria> tarefaSecundariaRepository)
        {
            _tarefaSecundariaRepository = tarefaSecundariaRepository;
        }

        public async Task<TarefaSecundaria> Handle(GetTarefaSecundariaQuery request, CancellationToken cancellationToken)
        {
            return await _tarefaSecundariaRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);
        }
    }
}
