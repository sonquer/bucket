using Bucket.UseCases.Services;
using k8s;
using k8s.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.UseCases.Queries.Handlers
{
    public class ListPodsInAllNamespacesQueryHandler : IRequestHandler<ListPodsInAllNamespacesQuery, V1PodList>
    {
        private readonly CurrentContextService _currentContextService;

        public ListPodsInAllNamespacesQueryHandler(CurrentContextService currentContextService)
        {
            _currentContextService = currentContextService;
        }

        public async Task<V1PodList> Handle(ListPodsInAllNamespacesQuery request, CancellationToken cancellationToken)
        {
            if (_currentContextService.IsConnectedToCluster == false)
            {
                return new V1PodList();
            }

            return await _currentContextService.GetContext()!.CoreV1.ListPodForAllNamespacesAsync(cancellationToken: cancellationToken);
        }
    }
}
