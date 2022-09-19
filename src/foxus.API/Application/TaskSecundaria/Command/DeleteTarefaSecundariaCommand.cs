using MediatR;

namespace Foxus.API.Application.TaskSecundaria.Command
{
    public class DeleteTarefaSecundariaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
