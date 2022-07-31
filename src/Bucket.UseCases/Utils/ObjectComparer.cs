using System.Text.Json;

namespace Bucket.UseCases.Utils
{
	public static class ObjectComparer<T> where T : class
	{
		public static bool IsSimilar(T left, T right)
		{
			var leftObjectAsJson = JsonSerializer.Serialize(left);
			var rightObjectAsJson = JsonSerializer.Serialize(right);

			return leftObjectAsJson == rightObjectAsJson;
        }
	}
}
