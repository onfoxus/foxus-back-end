using FluentValidation;
using Foxus.API.Application.Usuario.Query;

namespace Foxus.API.Application.Usuario.Validation
{
    public class GetUsuarioQueryValidator : AbstractValidator<GetUsuarioQuery>
    {
        public GetUsuarioQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();                
        }
    }
}
