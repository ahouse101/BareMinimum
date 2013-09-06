using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
