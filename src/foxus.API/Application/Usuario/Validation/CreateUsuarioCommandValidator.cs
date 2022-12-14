using FluentValidation;
using Foxus.API.Application.Usuario.Command;
using Foxus.Infrastructure.Data;

namespace Foxus.API.Application.Usuario.Validation
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioCommandValidator()
        {
            RuleFor(x => x.Login)
                
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
