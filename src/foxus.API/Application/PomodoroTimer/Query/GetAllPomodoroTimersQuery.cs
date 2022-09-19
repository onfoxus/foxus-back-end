using MediatR;
using System.Collections.Generic;

namespace Foxus.API.Application.PomodoroTimer.Query
{
    public class GetAllPomodoroTimersQuery : IRequest<IEnumerable<Domain.PomodoroTimer>>
    {
    }
}
