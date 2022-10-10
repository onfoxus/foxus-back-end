using FluentValidation.Results;
using Foxus.API.Application.Execucao.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Foxus.API.Application.Execucao.Query
{
    public class GetExecucaoQuery : IRequest<Domain.Execucao>
    {
        public GetExecucaoQuery(int id)
        {
            Id = id;

            var validator = new GetExecucaoQueryValidator();
            Validation = validator.Validate(this);
        }
        public int Id { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
    }
}
