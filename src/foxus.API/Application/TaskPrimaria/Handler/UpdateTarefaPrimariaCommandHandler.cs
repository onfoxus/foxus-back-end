using Foxus.API.Application.TaskPrimaria.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskPrimaria.Handler
{
    public class UpdateTarefaPrimariaCommandHandler : IRequestHandler<UpdateTarefaPrimariaCommand, bool>
    {
        private readonly IGenericRepository<Domain.TarefaPrimaria> _tarefaPrimariaRepository;
        public UpdateTarefaPrimariaCommandHandler(IGenericRepository<Domain.TarefaPrimaria> tarefaPrimariaRepository)
        {
            _tarefaPrimariaRepository = tarefaPrimariaRepository;
        }

        public async Task<bool> Handle(UpdateTarefaPrimariaCommand request, CancellationToken cancellationToken)
        {
            var tarefaPrimaria = await _tarefaPrimariaRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            if (tarefaPrimaria == null)
                return false;

            tarefaPrimaria.Titulo = request.Titulo;
            tarefaPrimaria.Finalizada = request.Finalizada;
            tarefaPrimaria.TarefasSecundarias = request.TarefasSecundarias;
            tarefaPrimaria.Descricao = request.Descricao;
            tarefaPrimaria.Prioridade = request.Prioridade;
            tarefaPrimaria.DataCadastro = request.DataCadastro;
            tarefaPrimaria.Duracao = request.Duracao;
            tarefaPrimaria.Execucoes = request.Execucoes;

            _tarefaPrimariaRepository.Update(tarefaPrimaria);

            return await _tarefaPrimariaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
