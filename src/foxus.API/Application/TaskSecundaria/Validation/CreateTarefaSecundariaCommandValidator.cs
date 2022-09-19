using FluentValidation;
using Foxus.API.Application.TaskSecundaria.Command;

namespace Foxus.API.Application.TaskSecundaria.Validation
{
    public class CreateTarefaSecundariaCommandValidator : AbstractValidator<CreateTarefaSecundariaCommand>
    {
        public CreateTarefaSecundariaCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Finalizada)
                .NotNull();
        }
    }
}
