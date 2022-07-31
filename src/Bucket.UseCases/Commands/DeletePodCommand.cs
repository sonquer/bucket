using MediatR;

namespace Bucket.UseCases.Commands
{
	public class DeletePodCommand : INotification
	{
		public string Name { get; set; }

		public string Namespace { get; set; }

		public DeletePodCommand(string name, string @namespace)
		{
			Name = name;
			Namespace = @namespace;
		}
	}
}
