using Foxus.API.Application.TaskSecundaria.Command;
using Foxus.Domain;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskSecundaria.Handler
{
    public class CreateTarefaSecundariaCommandHandler : IRequestHandler<CreateTarefaSecundariaCommand, bool>
    {
        private readonly IGenericRepository<Domain.TarefaSecundaria> _tarefaSecundariaRepository;
        public CreateTarefaSecundariaCommandHandler(IGenericRepository<Domain.TarefaSecundaria> tarefaSecundariaRepository)
        {
            _tarefaSecundariaRepository = tarefaSecundariaRepository;
        }

        public async Task<bool> Handle(CreateTarefaSecundariaCommand request, CancellationToken cancellationToken)
        {
            var tarefasSecundarias = await _tarefaSecundariaRepository.GetAllAsync(noTracking: true, cancellationToken: cancellationToken).ConfigureAwait(false);

            foreach (var tarefa in tarefasSecundarias)
            {
                if (tarefa.Titulo == request.Titulo)
                    return false;
            }

            if (!request.Validation.IsValid)
                return false;

            var tarefaSecundaria = new Domain.TarefaSecundaria
            {
                Titulo = request.Titulo,
                Finalizada = request.Finalizada
            };

            await _tarefaSecundariaRepository.AddAsync(tarefaSecundaria, cancellationToken).ConfigureAwait(false);

            return await _tarefaSecundariaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
