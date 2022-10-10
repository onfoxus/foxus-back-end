using FluentValidation.Results;
using Foxus.API.Application.Usuario.Validation;
using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Foxus.API.Application.Usuario.Query
{
    public class GetUsuarioQuery : IRequest<Domain.Usuario>
    {
        public GetUsuarioQuery(int id)
        {
            Id = id;

            var validator = new GetUsuarioQueryValidator();
            Validation = validator.Validate(this);
        }

        public int Id { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
    }
}
