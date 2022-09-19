using MediatR;

namespace Foxus.API.Application.PomodoroTimer.Command
{
    public class DeletePomodoroTimerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
