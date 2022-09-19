using MediatR;
using System.Collections.Generic;

namespace Foxus.API.Application.TaskPrimaria.Query
{
    public class GetAllTarefasPrimariasQuery : IRequest<IEnumerable<Domain.TarefaPrimaria>>
    {

    }
}
