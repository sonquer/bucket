using Bucket.UseCases.Services;
using k8s;
using k8s.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.UseCases.Queries.Handlers
{
    public class ListNodesQueryHandler : IRequestHandler<ListNodesQuery, V1NodeList>
    {
        private readonly CurrentContextService _currentContextService;

        public ListNodesQueryHandler(CurrentContextService currentContextService)
        {
            _currentContextService = currentContextService;
        }

        public async Task<V1NodeList> Handle(ListNodesQuery request, CancellationToken cancellationToken)
        {
            if (_currentContextService.IsConnectedToCluster == false)
            {
                return new V1NodeList();
            }

            return await _currentContextService.GetContext()!.CoreV1.ListNodeAsync(cancellationToken: cancellationToken);
        }
    }
}
