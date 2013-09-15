using System.Linq;

namespace BareMinimumCore
{
	public static class Extensions
	{
		public static bool In<T>(this T t, params T[] values)
		{
			return values.Contains(t);
		}
	}
}
