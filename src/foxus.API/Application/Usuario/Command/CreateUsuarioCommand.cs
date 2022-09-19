using FluentValidation.Results;
using Foxus.API.Application.Usuario.Validation;
using MediatR;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Foxus.API.Application.Usuario.Command
{
    public class CreateUsuarioCommand : IRequest<bool>
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; }

        public CreateUsuarioCommand(string login, string senha, string nome)
        {
            Login = login;
            Senha = senha;
            Nome = nome;

            var validator = new CreateUsuarioCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
