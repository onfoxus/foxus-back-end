using FluentValidation;
using Foxus.API.Application.PomodoroTimer.Command;

namespace Foxus.API.Application.PomodoroTimer.Validation
{
    public class CreatePomodoroTimerCommandValidator : AbstractValidator<CreatePomodoroTimerCommand>
    {
        public CreatePomodoroTimerCommandValidator()
        {
            RuleFor(x => x.TempoFoco)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.TempoDescanso)
                .NotNull()
                .NotEmpty();
        }
    }
}
