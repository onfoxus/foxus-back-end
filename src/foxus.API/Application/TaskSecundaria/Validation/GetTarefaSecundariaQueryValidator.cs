using FluentValidation;
using Foxus.API.Application.TaskSecundaria.Query;

namespace Foxus.API.Application.TaskSecundaria.Validation
{
    public class GetTarefaSecundariaQueryValidator : AbstractValidator<GetTarefaSecundariaQuery>
    {
        public GetTarefaSecundariaQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
