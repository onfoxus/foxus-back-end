using Foxus.API.Application.Execucao.Command;
using Foxus.API.Application.TaskPrimaria.Command;
using Foxus.Domain;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Execucao.Handler
{
    public class UpdateExecucaoCommandHandler : IRequestHandler<UpdateExecucaoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Execucao> _execucaoRepository;
        private readonly IGenericRepository<Domain.TarefaPrimaria> _tarefaPrimariaRepository;
        private readonly IGenericRepository<Domain.PomodoroTimer> _pomodoroTimerRepository;
        private readonly IGenericRepository<Domain.Usuario> _usuarioRepository;

        public UpdateExecucaoCommandHandler(IGenericRepository<Domain.Execucao> execucaoRepository,
            IGenericRepository<Domain.TarefaPrimaria> tarefaPrimariaRepository,
            IGenericRepository<Domain.PomodoroTimer> pomodoroTimerRepository,
            IGenericRepository<Domain.Usuario> usuarioRepository)
        {
            _execucaoRepository = execucaoRepository;
            _tarefaPrimariaRepository = tarefaPrimariaRepository;
            _pomodoroTimerRepository = pomodoroTimerRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(UpdateExecucaoCommand request, CancellationToken cancellationToken)
        {
            var execucao = await _execucaoRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            if (execucao == null)
                return false;

            var listaTarefasPrimarias = new List<TarefaPrimaria>();

            foreach (TarefaPrimaria tarefaPrimaria in request.TarefasPrimarias)
            {
                var tarefa = await _tarefaPrimariaRepository.GetByKeysAsync(cancellationToken, tarefaPrimaria.Id).ConfigureAwait(false);
                
                if (tarefa == null)
                    return false;

                listaTarefasPrimarias.Add(tarefa);
            }

            var pomodoroTimer = await _pomodoroTimerRepository.GetByKeysAsync(cancellationToken, request.PomodoroTimer.Id).ConfigureAwait(false);

            if (pomodoroTimer == null)
                return false;

            var usuario = await _usuarioRepository.GetByKeysAsync(cancellationToken, request.Usuario.Id).ConfigureAwait(false);

            if (usuario == null)
                return false;

            execucao.TarefasPrimarias = listaTarefasPrimarias;
            execucao.Duracao = request.Duracao;
            execucao.PomodoroTimer = pomodoroTimer;
            execucao.Usuario = usuario;

            _execucaoRepository.Update(execucao);

            return await _execucaoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
