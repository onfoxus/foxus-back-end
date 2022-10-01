using Foxus.Domain;
using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Foxus.API.Application.TaskSecundaria.Query
{
    public class GetAllTarefasSecundariasQuery : IRequest<IEnumerable<Domain.TarefaSecundaria>>
    {
        public virtual TarefaPrimaria TarefaPrimaria { get; set; }
        [JsonIgnore]
        public virtual int TarefaPrimariaId { get; set; }
    }
}
