using MediatR;

namespace Bucket.UseCases.Commands
{
	public class UncordonNodeCommand : INotification
	{
		public string NodeName { get; set; }

		public UncordonNodeCommand(string nodeName)
		{
			NodeName = nodeName;
		}
	}
}
