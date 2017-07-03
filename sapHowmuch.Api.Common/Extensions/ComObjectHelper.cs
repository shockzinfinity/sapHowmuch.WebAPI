using System.Runtime.InteropServices;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class ComObjectHelper
	{
		public static void ReleaseComObject(object instance)
		{
			if (instance != null)
			{
				try
				{
					while (Marshal.ReleaseComObject(instance) > 0) ;
				}
				catch { }
				finally
				{
					instance = null;
				}
			}
		}
	}
}