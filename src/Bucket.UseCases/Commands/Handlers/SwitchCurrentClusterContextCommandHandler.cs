using Bucket.UseCases.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.UseCases.Commands.Handlers
{
    public class SwitchCurrentClusterContextCommandHandler : INotificationHandler<SwitchCurrentClusterContextCommand>
    {
        private readonly CurrentContextService _contextService;

        public SwitchCurrentClusterContextCommandHandler(CurrentContextService contextService)
        {
            _contextService = contextService;
        }

        public async Task Handle(SwitchCurrentClusterContextCommand notification, CancellationToken cancellationToken)
        {
            _contextService.SwitchClusterContext(notification.ClusterEntity);
        }
    }
}
