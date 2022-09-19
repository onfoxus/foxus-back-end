using MediatR;

namespace Foxus.API.Application.Usuario.Command
{
    public class UpdateUsuarioCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
    }
}
