using MediatR;
using System;

namespace Foxus.API.Application.PomodoroTimer.Command
{
    public class UpdatePomodoroTimerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public TimeSpan TempoFoco { get; set; }
        public TimeSpan TempoDescanso { get; set; }
    }
}
