using FluentValidation.Results;
using Foxus.API.Application.TaskSecundaria.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Foxus.API.Application.TaskSecundaria.Query
{
    public class GetTarefaSecundariaQuery : IRequest<Domain.TarefaSecundaria>
    {
        public GetTarefaSecundariaQuery(int id)
        {
            Id = id;

            var validator = new GetTarefaSecundariaQueryValidator();
            Validation = validator.Validate(this);
        }

        public int Id { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
    }
}
