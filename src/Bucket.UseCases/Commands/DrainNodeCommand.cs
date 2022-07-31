using MediatR;

namespace Bucket.UseCases.Commands
{
	public class DrainNodeCommand : INotification
	{
		public string NodeName { get; set; }

		public DrainNodeCommand(string nodeName)
		{
			NodeName = nodeName;
		}
	}
}
