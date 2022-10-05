using MediatR;
using System.Collections.Generic;

namespace Foxus.API.Application.Execucao.Query
{
    public class GetAllExecucoesQuery : IRequest<IEnumerable<Domain.Execucao>>
    {
    }
}
