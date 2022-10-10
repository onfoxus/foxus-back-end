using Foxus.API.Application.TaskSecundaria.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.TaskSecundaria.Handler
{
    public class UpdateTarefaSecundariaCommandHandler : IRequestHandler<UpdateTarefaSecundariaCommand, bool>
    {
        private readonly IGenericRepository<Domain.TarefaSecundaria> _tarefaSecundariaRepository;
        public UpdateTarefaSecundariaCommandHandler(IGenericRepository<Domain.TarefaSecundaria> tarefaSecundariaRepository)
        {
            _tarefaSecundariaRepository = tarefaSecundariaRepository;
        }

        public async Task<bool> Handle(UpdateTarefaSecundariaCommand request, CancellationToken cancellationToken)
        {
            var tarefaSecundaria = await _tarefaSecundariaRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            if(tarefaSecundaria == null)
                return false;

            tarefaSecundaria.Titulo = request.Titulo;
            tarefaSecundaria.Finalizada = request.Finalizada;

            _tarefaSecundariaRepository.Update(tarefaSecundaria);

            return await _tarefaSecundariaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
