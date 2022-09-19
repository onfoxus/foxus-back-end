using System;

namespace Foxus.Domain
{
    public class PomodoroTimer
    {
        public int Id { get; set; }
        public TimeSpan TempoFoco { get; set; }
        public TimeSpan TempoDescanso { get; set; }
    }
}
