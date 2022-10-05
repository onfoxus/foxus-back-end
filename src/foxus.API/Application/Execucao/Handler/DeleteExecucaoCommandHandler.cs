using Foxus.API.Application.Execucao.Command;
using Foxus.Infrastructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foxus.API.Application.Execucao.Handler
{
    public class DeleteExecucaoCommandHandler : IRequestHandler<DeleteExecucaoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Execucao> _execucaoRepository;

        public DeleteExecucaoCommandHandler(IGenericRepository<Domain.Execucao> execucaoRepository)
        {
            _execucaoRepository = execucaoRepository;
        }

        public async Task<bool> Handle(DeleteExecucaoCommand request, CancellationToken cancellationToken)
        {
            var execucao = await _execucaoRepository.GetByKeysAsync(cancellationToken, request.Id).ConfigureAwait(false);

            _execucaoRepository.Delete(execucao);

            return await _execucaoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
