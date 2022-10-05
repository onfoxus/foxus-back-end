using FluentValidation;
using Foxus.API.Application.Execucao.Command;

namespace Foxus.API.Application.Execucao.Validation
{
    public class CreateExecucaoCommandValidator : AbstractValidator<CreateExecucaoCommand>
    {
        public CreateExecucaoCommandValidator()
        {
            RuleFor(x => x.TarefasPrimarias)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Usuario)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Duracao)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PomodoroTimer)
                .NotNull()
                .NotEmpty();
        }
    }
}
