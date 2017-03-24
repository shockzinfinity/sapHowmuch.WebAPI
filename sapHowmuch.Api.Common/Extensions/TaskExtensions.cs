using System;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class TaskExtensions
	{
		public static object TryResult<T>(this Task<T> task)
		{
			if (task != null)
			{
				try
				{
					return task.Result;
				}
				catch (Exception)
				{
				}
			}
			return task;
		}
	}
}