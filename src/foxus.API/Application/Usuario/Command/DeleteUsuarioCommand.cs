using MediatR;

namespace Foxus.API.Application.Usuario.Command
{
    public class DeleteUsuarioCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
