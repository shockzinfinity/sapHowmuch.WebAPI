using System.Collections.Generic;
using System.Linq;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class GeneralExtensions
	{
		public static bool In<T>(this T source, params T[] values)
		{
			return values.Contains(source);
		}

		public static bool In<T>(this T source, IEnumerable<T> valueList)
		{
			return valueList.Contains(source);
		}
	}
}