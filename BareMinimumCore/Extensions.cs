using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BareMinimumCore
{
	public static class Extensions
	{
		public static bool In<T>(this T t, params T[] values)
		{
			return values.Contains(t);
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable == null || !enumerable.Any();
		}

		public static bool IsNullOrEmpty(this IEnumerable enumerable)
		{
			return enumerable == null || !enumerable.Cast<object>().Any();
		}
	}
}
