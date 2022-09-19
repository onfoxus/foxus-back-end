using FluentValidation;
using Foxus.API.Application.TaskPrimaria.Command;

namespace Foxus.API.Application.TaskPrimaria.Validation
{
    public class CreateTarefaPrimariaCommandValidator : AbstractValidator<CreateTarefaPrimariaCommand>
    {
        public CreateTarefaPrimariaCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Finalizada)
                .NotNull();

            RuleFor(x => x.Prioridade)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataCadastro)
                .NotNull()
                .NotEmpty();
        }
    }
}
