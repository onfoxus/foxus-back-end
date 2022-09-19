using Foxus.API.Application.PomodoroTimer.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.PomodoroTimer.Handler
{
    public class CreatePomodoroTimerCommandHandler : IRequestHandler<CreatePomodoroTimerCommand, bool>
    {
        private readonly IGenericRepository<Domain.PomodoroTimer> _pomodoroTimerRepository;
        public CreatePomodoroTimerCommandHandler(IGenericRepository<Domain.PomodoroTimer> pomodoroTimerRepository)
        {
            _pomodoroTimerRepository = pomodoroTimerRepository;
        }

        public async Task<bool> Handle(CreatePomodoroTimerCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var pomodoroTimer = new Domain.PomodoroTimer
            {
                TempoFoco = request.TempoFoco,
                TempoDescanso = request.TempoDescanso
            };

            await _pomodoroTimerRepository.AddAsync(pomodoroTimer, cancellationToken).ConfigureAwait(false);

            return await _pomodoroTimerRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
