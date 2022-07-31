using Bucket.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.Domain.Interfaces.Repositories
{
    public interface IClusterRepository
    {
        Task<IEnumerable<ClusterEntity>> GetClusterConfiguration(CancellationToken cancellationToken);
    }
}
