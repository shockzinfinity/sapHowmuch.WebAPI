using System.IO;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class IOExtensions
	{
		public static void CreateDirectory(this DirectoryInfo dirInfo)
		{
			if (dirInfo.Parent != null) CreateDirectory(dirInfo.Parent);
			if (!dirInfo.Exists) dirInfo.Create();
		}
	}
}