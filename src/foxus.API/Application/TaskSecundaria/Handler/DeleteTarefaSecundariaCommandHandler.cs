using Foxus.API.Application.TaskSecundaria.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskSecundaria.Handler
{
    public class DeleteTarefaSecundariaCommandHandler : IRequestHandler<DeleteTarefaSecundariaCommand, bool>
    {
        private readonly IGenericRepository<Domain.TarefaSecundaria> _tarefaSecundariaRepository;
        public DeleteTarefaSecundariaCommandHandler(IGenericRepository<Domain.TarefaSecundaria> tarefaSecundariaRepository)
        {
            _tarefaSecundariaRepository = tarefaSecundariaRepository;
        }

        public async Task<bool> Handle(DeleteTarefaSecundariaCommand request, CancellationToken cancellationToken)
        {
            var tarefaSecundaria = await _tarefaSecundariaRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            _tarefaSecundariaRepository.Delete(tarefaSecundaria);

            return await _tarefaSecundariaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
