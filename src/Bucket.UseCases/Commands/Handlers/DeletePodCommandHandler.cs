using Bucket.UseCases.Services;
using k8s;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bucket.UseCases.Commands.Handlers
{
    public class DeletePodCommandHandler : INotificationHandler<DeletePodCommand>
	{
        private readonly CurrentContextService _currentContextService;

        public DeletePodCommandHandler(CurrentContextService currentContextService)
        {
            _currentContextService = currentContextService;
        }

        public async Task Handle(DeletePodCommand notification, CancellationToken cancellationToken)
		{
            await _currentContextService.GetContext()!.CoreV1.DeleteNamespacedPodAsync(notification.Name, 
                notification.Namespace, 
                cancellationToken: cancellationToken);
        }
	}
}
