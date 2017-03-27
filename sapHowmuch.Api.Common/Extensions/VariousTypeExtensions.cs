using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class VariousTypeExtensions
	{
		public static void SetExtendedProperty(this DataColumn column, object key, object value)
		{
			column.ExtendedProperties.Add(key, value);
		}

		public static object GetExtendedProperty(this DataColumn column, object key)
		{
			object retVal = null;

			if (column.ExtendedProperties[key] != null) retVal = column.ExtendedProperties[key];

			return retVal;
		}

		/// <summary>
		/// object 가 null 이 아니라면, Func 돌려서 값 리턴, 널이면 default 반환
		/// <para>Example:</para>
		/// var username = HttpContext.Current.IfNotNull( ctx => ctx.User.IfNotNull( user => user.Identity.IfNotNull( iden => iden.Name ) ) );
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="target"></param>
		/// <param name="getValue"></param>
		/// <returns></returns>
		public static TResult IfNotNull<T, TResult>(this T target, Func<T, TResult> getValue)
		{
			if (target != null) return getValue(target);
			else return default(TResult);
		}

		/// <summary>
		/// 순서 뒤섞기
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
		{
			var r = new Random((int)DateTime.Now.Ticks);
			var shuffedList = list.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item);

			return shuffedList.ToList();
		}

		/// <summary>
		/// DataTable -> List<T> 로 변환을 제공합니다.
		/// </summary>
		/// <typeparam name="T">Class name</typeparam>
		/// <param name="dataTable">변환하고자 하는 data table</param>
		/// <returns>List<T></returns>
		public static List<T> ToList<T>(this DataTable dataTable) where T : new()
		{
			var dataList = new List<T>();

			// 읽어들일 클래스의 프로퍼티 어트리뷰트
			const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

			var objFieldNames = typeof(T).GetProperties(flags).Cast<PropertyInfo>()
				.Select(item => new
				{
					Name = item.Name,
					Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
				}).ToList();

			var dtFieldNames = dataTable.Columns.Cast<DataColumn>()
				.Select(item => new
				{
					Name = item.ColumnName,
					Type = item.DataType
				}).ToList();

			foreach (DataRow dtRow in dataTable.AsEnumerable().ToList())
			{
				var classObj = new T();

				foreach (var dtfield in dtFieldNames)
				{
					PropertyInfo pis = classObj.GetType().GetProperty(dtfield.Name);

					var field = objFieldNames.Find(x => x.Name == dtfield.Name);

					if (field != null)
					{
						if (pis.PropertyType == typeof(DateTime))
						{
							pis.SetValue(classObj, ConvertToDateTime(dtRow[dtfield.Name]), null);
						}
						else if (pis.PropertyType == typeof(int))
						{
							pis.SetValue(classObj, ConvertToInt(dtRow[dtfield.Name]), null);
						}
						else if (pis.PropertyType == typeof(long))
						{
							pis.SetValue(classObj, ConvertToLong(dtRow[dtfield.Name]), null);
						}
						else if (pis.PropertyType == typeof(decimal))
						{
							pis.SetValue(classObj, ConvertToDecimal(dtRow[dtfield.Name]), null);
						}
						else if (pis.PropertyType == typeof(string))
						{
							if (dtRow[dtfield.Name].GetType() == typeof(DateTime))
							{
								pis.SetValue(classObj, ConvertToDateString(dtRow[dtfield.Name]), null);
							}
							else
							{
								pis.SetValue(classObj, ConvertToString(dtRow[dtfield.Name]), null);
							}
						}
					}
				}
				dataList.Add(classObj);
			}
			return dataList;
		}

		/// <summary>
		/// null 이면 Empty object 반환
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static object ReturnEmptyIfNull(this object value)
		{
			if (value == null) return new object();

			return value;
		}

		/// <summary>
		/// null 이면 0 을 반환(for primitive type)
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static object ReturnZeroIfNull(this object value)
		{
			if (value == null) return 0;

			return value;
		}

		/// <summary>
		/// null 이면 DateTime Min 값을 반환
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static object ReturnDateTimeMinIfNull(this object date)
		{
			if (date == null) return new DateTime();

			return date;
		}

		/// <summary>
		/// 날짜형식 문자열 반환
		/// </summary>
		/// <param name="date"></param>
		/// <returns>yyyyMMdd 형식의 문자열</returns>
		private static string ConvertToDateString(this object date)
		{
			if (date == null) return string.Empty;

			return Convert.ToDateTime(date).ToString("yyyyMMdd");
		}

		/// <summary>
		/// null 일 경우엔 string.Empty를 반환하는 string 변환
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static string ConvertToString(this object value)
		{
			return Convert.ToString(value.ReturnEmptyIfNull());
		}

		/// <summary>
		/// null 일 경우, 0을 반환하는 int 변환
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static int ConvertToInt(this object value)
		{
			return Convert.ToInt32(value.ReturnZeroIfNull());
		}

		/// <summary>
		/// null 일 경우, 0을 반환하는 long 변환
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static long ConvertToLong(this object value)
		{
			return Convert.ToInt64(value.ReturnZeroIfNull());
		}

		/// <summary>
		/// null 일 경우, 0을 반환하는 decimal 변환
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static decimal ConvertToDecimal(this object value)
		{
			return Convert.ToDecimal(value.ReturnZeroIfNull());
		}

		/// <summary>
		/// null 일 경우, DateTime 중 최소값을 반환하는 DateTime 변환
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		private static DateTime ConvertToDateTime(this object date)
		{
			return Convert.ToDateTime(date.ReturnDateTimeMinIfNull());
		}

		/// <summary>
		/// DataTable 변환
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="varList"></param>
		/// <returns></returns>
		public static DataTable ToDataTable<T>(this IEnumerable<T> varList)
		{
			DataTable dtReturn = new DataTable();

			PropertyInfo[] props = null;

			if (varList == null) return dtReturn;

			foreach (T rec in varList)
			{
				if (props == null)
				{
					props = rec.GetType().GetProperties();

					foreach (PropertyInfo pi in props)
					{
						Type colType = pi.PropertyType;

						if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
						{
							colType = colType.GetGenericArguments()[0];
						}

						dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
					}
				}

				DataRow dr = dtReturn.NewRow();

				foreach (PropertyInfo pi in props)
				{
					dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
				}

				dtReturn.Rows.Add(dr);
			}

			return dtReturn;
		}

		/// <summary>
		/// Null 체크, 통합을 위해...
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNull(this object source)
		{
			return source == null;
		}

		/// <summary>
		/// IEnumerable -> Collection
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumerable"></param>
		/// <returns></returns>
		public static Collection<T> ToCollectino<T>(this IEnumerable<T> enumerable)
		{
			var collection = new Collection<T>();

			foreach (T item in enumerable)
			{
				collection.Add(item);
			}

			return collection;
		}

		/// <summary>
		/// 값만 복사, 메모리 레퍼런스는 복사하지 않음
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		public static T Clone<T>(this object item)
		{
			if (!item.IsNull())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				using (MemoryStream stream = new MemoryStream())
				{
					formatter.Serialize(stream, item);
					stream.Seek(0, SeekOrigin.Begin);

					T result = (T)formatter.Deserialize(stream);

					return result;
				}
			}
			else return default(T);
		}
	}
}