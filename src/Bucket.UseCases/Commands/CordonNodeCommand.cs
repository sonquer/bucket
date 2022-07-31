using MediatR;

namespace Bucket.UseCases.Commands
{
	public class CordonNodeCommand : INotification
	{
		public string NodeName { get; set; }

		public CordonNodeCommand(string nodeName)
		{
			NodeName = nodeName;
		}
	}
}
