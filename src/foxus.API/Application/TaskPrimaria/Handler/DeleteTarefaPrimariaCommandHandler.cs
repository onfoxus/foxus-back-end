using Foxus.API.Application.TaskPrimaria.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskPrimaria.Handler
{
    public class DeleteTarefaPrimariaCommandHandler : IRequestHandler<DeleteTarefaPrimariaCommand, bool>
    {
        private readonly IGenericRepository<Domain.TarefaPrimaria> _tarefaPrimariaRepository;
        public DeleteTarefaPrimariaCommandHandler(IGenericRepository<Domain.TarefaPrimaria> tarefaPrimariaRepository)
        {
            _tarefaPrimariaRepository = tarefaPrimariaRepository;
        }

        public async Task<bool> Handle(DeleteTarefaPrimariaCommand request, CancellationToken cancellationToken)
        {
            var tarefaPrimaria = await _tarefaPrimariaRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            _tarefaPrimariaRepository.Delete(tarefaPrimaria);

            return await _tarefaPrimariaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
