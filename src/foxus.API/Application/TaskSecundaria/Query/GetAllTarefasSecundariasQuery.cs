using MediatR;
using System.Collections.Generic;

namespace Foxus.API.Application.TaskSecundaria.Query
{
    public class GetAllTarefasSecundariasQuery : IRequest<IEnumerable<Domain.TarefaSecundaria>>
    {

    }
}
