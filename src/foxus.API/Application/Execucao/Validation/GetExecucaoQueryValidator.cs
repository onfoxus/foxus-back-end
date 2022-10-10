using FluentValidation;
using Foxus.API.Application.Execucao.Query;
using Foxus.API.Application.PomodoroTimer.Query;

namespace Foxus.API.Application.Execucao.Validation
{
    public class GetExecucaoQueryValidator : AbstractValidator<GetExecucaoQuery>
    {
        public GetExecucaoQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
