using System;
using System.Diagnostics;
using System.Globalization;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class ValidationExtensions
	{
		public static bool IsNumeric(this object val)
		{
			if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
			{
				decimal dValue = decimal.Zero;
				return decimal.TryParse(val.ToString(), out dValue);
			}

			return false;
		}

		public static bool IsDate(this object val)
		{
			try
			{
				if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
				{
					string buffer = val.ToString().Replace("/", "").Replace(".", "");
					string[] dateFormats = new string[] { "yyyyMMdd", "yyyy/MM/dd", "yyyy년MM월dd일", "yyyy-MM-dd" };
					DateTime result = DateTime.MinValue;

					foreach (string format in dateFormats)
					{
						if (DateTime.TryParseExact(buffer, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
						{
							return true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(string.Format("IsDate Exception: {0}", ex.Message));
				return false;
			}

			return false;
		}
	}
}