using MediatR;
using System;
using FluentValidation.Results;
using Foxus.API.Application.PomodoroTimer.Validation;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Foxus.API.Application.PomodoroTimer.Command
{
    public class CreatePomodoroTimerCommand : IRequest<bool>
    {        
        public TimeSpan TempoFoco { get; set; }
        public TimeSpan TempoDescanso { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; }

        public CreatePomodoroTimerCommand(TimeSpan tempoFoco, TimeSpan tempoDescanso)
        {
            TempoFoco = tempoFoco;
            TempoDescanso = tempoDescanso;

            var validator = new CreatePomodoroTimerCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
