using MediatR;

namespace Foxus.API.Application.TaskSecundaria.Command
{
    public class UpdateTarefaSecundariaCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Finalizada { get; set; }
    }
}
