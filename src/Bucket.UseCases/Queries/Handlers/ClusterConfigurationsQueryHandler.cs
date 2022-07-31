using Bucket.Domain.Entities;
using Bucket.Domain.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.UseCases.Queries.Handlers
{
    public class ClusterConfigurationsQueryHandler : IRequestHandler<ClusterConfigurationsQuery, IEnumerable<ClusterEntity>>
    {
        private readonly IClusterRepository _clusterRepository;

        public ClusterConfigurationsQueryHandler(IClusterRepository clusterRepository)
        {
            _clusterRepository = clusterRepository;
        }

        public async Task<IEnumerable<ClusterEntity>> Handle(ClusterConfigurationsQuery request, CancellationToken cancellationToken)
        {
            return await _clusterRepository.GetClusterConfiguration(cancellationToken);
        }
    }
}
