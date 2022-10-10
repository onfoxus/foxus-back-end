using FluentValidation;
using Foxus.API.Application.TaskPrimaria.Query;

namespace Foxus.API.Application.TaskPrimaria.Validation
{
    public class GetTarefaPrimariaQueryValidator : AbstractValidator<GetTarefaPrimariaQuery>
    {
        public GetTarefaPrimariaQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
