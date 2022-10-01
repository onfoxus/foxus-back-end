using System;

namespace Foxus.Domain
{
    public class PomodoroTimer
    {
        public virtual int Id { get; set; }
        public virtual TimeSpan TempoFoco { get; set; }
        public virtual TimeSpan TempoDescanso { get; set; }
    }
}
