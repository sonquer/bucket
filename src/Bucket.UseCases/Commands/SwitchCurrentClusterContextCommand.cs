using Bucket.Domain.Entities;
using MediatR;

namespace Bucket.UseCases.Commands
{
    public class SwitchCurrentClusterContextCommand : INotification
    {
        public ClusterEntity ClusterEntity { get; }

        public SwitchCurrentClusterContextCommand(ClusterEntity clusterEntity)
        {
            ClusterEntity = clusterEntity;
        }
    }
}
