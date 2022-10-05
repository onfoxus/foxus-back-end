using MediatR;

namespace Foxus.API.Application.Execucao.Command
{
    public class DeleteExecucaoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
