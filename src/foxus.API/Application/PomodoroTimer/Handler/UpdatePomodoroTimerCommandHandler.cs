using Foxus.API.Application.PomodoroTimer.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.PomodoroTimer.Handler
{
    public class UpdatePomodoroTimerCommandHandler : IRequestHandler<UpdatePomodoroTimerCommand, bool>
    {
        private readonly IGenericRepository<Domain.PomodoroTimer> _pomodoroTimerRepository;
        public UpdatePomodoroTimerCommandHandler(IGenericRepository<Domain.PomodoroTimer> pomodoroTimerRepository)
        {
            _pomodoroTimerRepository = pomodoroTimerRepository;

        }
        public async Task<bool> Handle(UpdatePomodoroTimerCommand request, CancellationToken cancellationToken)
        {
            var pomodoroTimer = await _pomodoroTimerRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            pomodoroTimer.TempoFoco = request.TempoFoco;
            pomodoroTimer.TempoDescanso = request.TempoDescanso;

            _pomodoroTimerRepository.Update(pomodoroTimer);

            return await _pomodoroTimerRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
