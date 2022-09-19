using MediatR;

namespace Foxus.API.Application.TaskPrimaria.Command
{
    public class DeleteTarefaPrimariaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
