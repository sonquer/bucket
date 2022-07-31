using Bucket.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Bucket.UseCases.Queries
{
    public class ClusterConfigurationsQuery : IRequest<IEnumerable<ClusterEntity>>
    {
    }
}
