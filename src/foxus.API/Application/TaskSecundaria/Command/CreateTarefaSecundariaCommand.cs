using FluentValidation.Results;
using Foxus.API.Application.TaskSecundaria.Validation;
using Foxus.Domain;
using MediatR;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Foxus.API.Application.TaskSecundaria.Command
{
    public class CreateTarefaSecundariaCommand : IRequest<bool>
    {
        public string Titulo { get; set; }
        public bool Finalizada { get; set; }

        [JsonIgnore]
        public ValidationResult Validation { get; }

        public CreateTarefaSecundariaCommand(string titulo, bool finalizada)
        {
            Titulo = titulo;
            Finalizada = finalizada;

            var validator = new CreateTarefaSecundariaCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}