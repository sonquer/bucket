using Bucket.UseCases.Services;
using k8s;
using k8s.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.UseCases.Commands.Handlers
{
    public class UncordonNodeCommandHandler : INotificationHandler<UncordonNodeCommand>
	{
        private readonly CurrentContextService _currentContextService;

        public UncordonNodeCommandHandler(CurrentContextService currentContextService)
        {
            _currentContextService = currentContextService;
        }

        public async Task Handle(UncordonNodeCommand notification, CancellationToken cancellationToken)
		{
            await _currentContextService.GetContext()!.CoreV1.PatchNodeAsync(new V1Patch(new { spec = new { unschedulable = false } }, 
                V1Patch.PatchType.StrategicMergePatch), notification.NodeName, cancellationToken: cancellationToken);
        }
    }
}
