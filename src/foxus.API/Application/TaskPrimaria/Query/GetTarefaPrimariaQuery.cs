using FluentValidation.Results;
using Foxus.API.Application.TaskPrimaria.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Foxus.API.Application.TaskPrimaria.Query
{
    public class GetTarefaPrimariaQuery : IRequest<Domain.TarefaPrimaria>
    {
        public GetTarefaPrimariaQuery(int id)
        {
            Id = id;

            var validator = new GetTarefaPrimariaQueryValidator();
            Validation = validator.Validate(this);
        }

        public int Id { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
    }
}
