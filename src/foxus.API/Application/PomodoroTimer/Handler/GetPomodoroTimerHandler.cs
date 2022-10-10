using Foxus.API.Application.PomodoroTimer.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.PomodoroTimer.Handler
{
    public class GetPomodoroTimerHandler : IRequestHandler<GetPomodoroTimerQuery, Domain.PomodoroTimer>
    {
        private readonly IGenericRepository<Domain.PomodoroTimer> _pomodoroTimerRepository;

        public GetPomodoroTimerHandler(IGenericRepository<Domain.PomodoroTimer> pomodoroTimerRepository)
        {
            _pomodoroTimerRepository = pomodoroTimerRepository;
        }

        public async Task<Domain.PomodoroTimer> Handle(GetPomodoroTimerQuery request, CancellationToken cancellationToken)
        {
            return await _pomodoroTimerRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);
        }
    }
}
