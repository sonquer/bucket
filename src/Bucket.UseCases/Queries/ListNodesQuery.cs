using k8s.Models;
using MediatR;

namespace Bucket.UseCases.Queries
{
    public class ListNodesQuery : IRequest<V1NodeList>
    {
    }
}
