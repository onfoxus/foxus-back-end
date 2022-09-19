using MediatR;
using System.Collections.Generic;

namespace Foxus.API.Application.Usuario.Query
{
    public class GetAllUsuariosQuery : IRequest<IEnumerable<Domain.Usuario>>
    {

    }
}
