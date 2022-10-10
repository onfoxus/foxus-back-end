using Foxus.API.Application.TaskPrimaria.Command;
using Foxus.Domain;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskPrimaria.Handler
{
    public class CreateTarefaPrimariaCommandHandler : IRequestHandler<CreateTarefaPrimariaCommand, bool>
    {
        private readonly IGenericRepository<Domain.TarefaPrimaria> _tarefaPrimariaRepository;
        public CreateTarefaPrimariaCommandHandler(IGenericRepository<Domain.TarefaPrimaria> tarefaPrimariaRepository)
        {
            _tarefaPrimariaRepository = tarefaPrimariaRepository;
        }

        public async Task<bool> Handle(CreateTarefaPrimariaCommand request, CancellationToken cancellationToken)
        {
            var tarefasPrimarias = await _tarefaPrimariaRepository.GetAllAsync(noTracking: true, cancellationToken: cancellationToken).ConfigureAwait(false);

            foreach (var tarefa in tarefasPrimarias)
            {
                if (tarefa.Titulo == request.Titulo)
                    return false;
            }

            if (!request.Validation.IsValid)
                return false;

            var tarefaPrimaria = new Domain.TarefaPrimaria
            {
                Titulo = request.Titulo,
                Finalizada = request.Finalizada,
                TarefasSecundarias = request.TarefasSecundarias,
                Descricao = request.Descricao,
                Prioridade = request.Prioridade,
                DataCadastro = request.DataCadastro,
                Duracao = request.Duracao
            };

            await _tarefaPrimariaRepository.AddAsync(tarefaPrimaria, cancellationToken).ConfigureAwait(false);

            return await _tarefaPrimariaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}