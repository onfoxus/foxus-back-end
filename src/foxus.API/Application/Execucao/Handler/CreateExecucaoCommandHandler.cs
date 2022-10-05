using Foxus.API.Application.Execucao.Command;
using Foxus.Domain;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Execucao.Handler
{
    public class CreateExecucaoCommandHandler : IRequestHandler<CreateExecucaoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Execucao> _execucaoRepository;
        private readonly IGenericRepository<Domain.TarefaPrimaria> _tarefaPrimariaRepository;
        private readonly IGenericRepository<Domain.PomodoroTimer> _pomodoroTimerRepository;
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;

        public CreateExecucaoCommandHandler(IGenericRepository<Domain.Execucao> execucaoRepository, 
            IGenericRepository<Domain.TarefaPrimaria> tarefaPrimariaRepository,
            IGenericRepository<Domain.PomodoroTimer> pomodoroTimerRepository,
            IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _execucaoRepository = execucaoRepository;
            _tarefaPrimariaRepository = tarefaPrimariaRepository;
            _pomodoroTimerRepository = pomodoroTimerRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(CreateExecucaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var listaTarefasPrimarias = new List<TarefaPrimaria>();

            foreach(TarefaPrimaria tarefaPrimaria in request.TarefasPrimarias)
            {
                var tarefa = await _tarefaPrimariaRepository.GetByKeysAsync(cancellationToken, tarefaPrimaria.Id).ConfigureAwait(false);

                listaTarefasPrimarias.Add(tarefa);
            }

            var pomodoroTimer = await _pomodoroTimerRepository.GetByKeysAsync(cancellationToken, request.PomodoroTimer.Id).ConfigureAwait(false);
            var usuario = await _usuarioRepository.GetByKeysAsync(cancellationToken, request.Usuario.Id).ConfigureAwait(false);

            var execucao = new Domain.Execucao
            {
                TarefasPrimarias = listaTarefasPrimarias,
                Duracao = request.Duracao,
                PomodoroTimer = pomodoroTimer,
                Usuario = usuario
            };

            await _execucaoRepository.AddAsync(execucao, cancellationToken).ConfigureAwait(false);

            return await _execucaoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
