using FluentValidation;
using Foxus.API.Application.PomodoroTimer.Query;
using Foxus.API.Application.Usuario.Validation;

namespace Foxus.API.Application.PomodoroTimer.Validation
{
    public class GetPomodoroTimerQueryValidator : AbstractValidator<GetPomodoroTimerQuery>
    {
        public GetPomodoroTimerQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
