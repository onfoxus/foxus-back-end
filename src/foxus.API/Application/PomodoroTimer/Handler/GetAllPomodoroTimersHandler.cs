using Foxus.API.Application.PomodoroTimer.Query;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.PomodoroTimer.Handler
{
    public class GetAllPomodoroTimersHandler : IRequestHandler<GetAllPomodoroTimersQuery, IEnumerable<Domain.PomodoroTimer>>
    {
        private readonly IGenericRepository<Domain.PomodoroTimer> _pomodoroTimerRepository;

        public GetAllPomodoroTimersHandler(IGenericRepository<Domain.PomodoroTimer> pomodoroTimerRepository)
        {
            _pomodoroTimerRepository = pomodoroTimerRepository;
        }
        public async Task<IEnumerable<Domain.PomodoroTimer>> Handle(GetAllPomodoroTimersQuery request, CancellationToken cancellationToken)
        {
            return await _pomodoroTimerRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}