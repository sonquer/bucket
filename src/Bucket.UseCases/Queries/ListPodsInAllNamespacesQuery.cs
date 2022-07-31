using k8s.Models;
using MediatR;

namespace Bucket.UseCases.Queries
{
    public class ListPodsInAllNamespacesQuery : IRequest<V1PodList>
    {
    }
}
