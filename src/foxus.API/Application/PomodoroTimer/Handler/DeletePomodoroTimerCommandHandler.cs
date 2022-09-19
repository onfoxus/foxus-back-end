using Foxus.API.Application.PomodoroTimer.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.PomodoroTimer.Handler
{
    public class DeletePomodoroTimerCommandHandler : IRequestHandler<DeletePomodoroTimerCommand, bool>
    {
        private readonly IGenericRepository<Domain.PomodoroTimer> _pomodoroTimerRepository;
        public DeletePomodoroTimerCommandHandler(IGenericRepository<Domain.PomodoroTimer> pomodoroTimerRepository)
        {
            _pomodoroTimerRepository = pomodoroTimerRepository;
        }

        public async Task<bool> Handle(DeletePomodoroTimerCommand request, CancellationToken cancellationToken)
        {
            var pomodoroTimer = await _pomodoroTimerRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            _pomodoroTimerRepository.Delete(pomodoroTimer);

            return await _pomodoroTimerRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
