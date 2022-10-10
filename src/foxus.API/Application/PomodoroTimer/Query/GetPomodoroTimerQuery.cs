using FluentValidation.Results;
using Foxus.API.Application.PomodoroTimer.Validation;
using Foxus.API.Application.Usuario.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Foxus.API.Application.PomodoroTimer.Query
{
    public class GetPomodoroTimerQuery : IRequest<Domain.PomodoroTimer>
    {
        public GetPomodoroTimerQuery(int id)
        {
            Id = id;

            var validator = new GetPomodoroTimerQueryValidator();
            Validation = validator.Validate(this);
        }
        public int Id { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
    }
}
