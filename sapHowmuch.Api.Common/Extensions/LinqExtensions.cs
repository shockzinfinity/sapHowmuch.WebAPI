using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class LinqExtensions
	{
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> seenKeys = new HashSet<TKey>();

			foreach (TSource element in source)
			{
				if (seenKeys.Add(keySelector(element))) yield return element;
			}
		}

		/// <summary>
		/// OrderBy (TSQL style)
		/// <code>
		/// list.OrderBy("Name desc");
		/// </code>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="sortExpression"></param>
		/// <returns></returns>
		public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortExpression)
		{
			sortExpression += "";
			string[] parts = sortExpression.Split(' ');
			bool descending = false;
			string property = "";

			if (parts.Length > 0 && parts[0] != "")
			{
				property = parts[0];

				if (parts.Length > 1)
				{
					descending = parts[1].ToLower().Contains("esc");
				}

				PropertyInfo prop = typeof(T).GetProperty(property);

				if (prop == null) throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");

				if (descending) return list.OrderByDescending(x => prop.GetValue(x, null));
				else list.OrderBy(x => prop.GetValue(x, null));
			}

			return list;
		}

		public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> keySelector, bool desc)
		{
			if (enumerable == null) return null;

			if (desc) return enumerable.OrderByDescending(keySelector);

			return enumerable.OrderBy(keySelector);
		}

		public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, IComparable> keySelector1, Func<TSource, IComparable> keySelector2, params Func<TSource, IComparable>[] keySelectors)
		{
			if (enumerable == null) return null;

			IEnumerable<TSource> current = enumerable;

			if (keySelectors != null)
			{
				for (int i = keySelectors.Length - 1; i >= 0; i--)
				{
					current = current.OrderBy(keySelectors[i]);
				}
			}

			current = current.OrderBy(keySelector2);

			return current.OrderBy(keySelector1);
		}

		public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> enumerable, bool descending, Func<TSource, IComparable> keySelector, params Func<TSource, IComparable>[] keySelectors)
		{
			if (enumerable == null)
			{
				return null;
			}

			IEnumerable<TSource> current = enumerable;

			if (keySelectors != null)
			{
				for (int i = keySelectors.Length - 1; i >= 0; i--)
				{
					current = current.OrderBy(keySelectors[i], descending);
				}
			}

			return current.OrderBy(keySelector, descending);
		}

		/// <summary>
		/// Pivot 변환
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TFirstKey"></typeparam>
		/// <typeparam name="TSecondKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="source"></param>
		/// <param name="firstKeySelector"></param>
		/// <param name="secondKeySelector"></param>
		/// <param name="aggregate"></param>
		/// <returns></returns>
		public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>
			(this IEnumerable<TSource> source
			, Func<TSource, TFirstKey> firstKeySelector
			, Func<TSource, TSecondKey> secondKeySelector
			, Func<IEnumerable<TSource>, TValue> aggregate)
		{
			var retVal = new Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>();

			var l = source.ToLookup(firstKeySelector);

			foreach (var item in l)
			{
				var dict = new Dictionary<TSecondKey, TValue>();
				retVal.Add(item.Key, dict);
				var subdict = item.ToLookup(secondKeySelector);
				foreach (var subitem in subdict)
				{
					dict.Add(subitem.Key, aggregate(subitem));
				}
			}

			return retVal;
		}

		/// <summary>
		/// IEnumerable -> ObservableCollection 변환
		/// XAML 에서 쓰임
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="coll"></param>
		/// <returns></returns>
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
		{
			var c = new ObservableCollection<T>();

			foreach (var e in coll)
			{
				c.Add(e);
			}

			return c;
		}

		/// <summary>
		/// IQueryable -> List Async
		/// async 메서드 에서 await 를 붙여서 사용
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		//public static Task<List<T>> ToListAsync<T>(this IQueryable<T> list)
		//{
		//	return Task.Run(() => list.ToList());
		//}

		/// <summary>
		/// Random 하게 OrderBy
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="target"></param>
		/// <returns></returns>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> target)
		{
			Random r = new Random();

			return target.OrderBy(x => (r.Next()));
		}

		/// <summary>
		/// ObservableCollection 에 AddRange
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="oc"></param>
		/// <param name="collection"></param>
		public static void AddRange<T>(this ObservableCollection<T> oc, IEnumerable<T> collection)
		{
			if (collection == null) throw new ArgumentNullException("collection");

			foreach (var item in collection)
			{
				oc.Add(item);
			}
		}

		/// <summary>
		/// 결과의 GroupBy
		/// <code>
		/// <para>Dictionary&lt;string, List&lt;Product&gt;&gt; results = productList.GroupBy(product => product.Category).ToDictionary()</para>
		/// </code>
		/// </summary>
		/// <typeparam name="TKey">그룹핑 할 Key 타입</typeparam>
		/// <typeparam name="TValue">리스트의 그룹요소</typeparam>
		/// <param name="groupings">GroupBy() 구문의 그룹반복기</param>
		/// <returns>딕셔너리의 키로 그룹핑된 TKey 타입과 각 결과 List</returns>
		public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings)
		{
			return groupings.ToDictionary(group => group.Key, group => group.ToList());
		}

		/// <summary>
		/// Distinct
		/// <para></para>
		/// var instrumentSet = _instrumentBag.Distinct(i => i.Name);
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="TKey"></typeparam>
		/// <param name="this"></param>
		/// <param name="keySelector"></param>
		/// <returns></returns>
		public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> @this, Func<T, TKey> keySelector)
		{
			return @this.GroupBy(keySelector).Select(grps => grps).Select(e => e.First());
		}

		/// <summary>
		/// To CSV file
		/// </summary>
		/// <param name="table"></param>
		/// <param name="filePath"></param>
		/// <param name="delimeter"></param>
		/// <param name="includeHeader"></param>
		public static void ToCSV(this DataTable table, string filePath, string delimeter, bool includeHeader)
		{
			StringBuilder result = new StringBuilder();

			if (includeHeader)
			{
				foreach (DataColumn column in table.Columns)
				{
					result.Append(column.ColumnName);
					result.Append(delimeter);
				}

				result.Remove(--result.Length, 0);
				result.Append(Environment.NewLine);
			}

			foreach (DataRow row in table.Rows)
			{
				foreach (object item in row.ItemArray)
				{
					if (item is DBNull) result.Append(delimeter);
					else
					{
						string itemAsString = item.ToString();
						itemAsString = itemAsString.Replace("\"", "\"\"");

						itemAsString = "\"" + itemAsString + "\"";
						result.Append(itemAsString + delimeter);
					}
				}
				result.Remove(--result.Length, 0);
				result.Append(Environment.NewLine);
			}

			using (StreamWriter writer = new StreamWriter(filePath, true))
			{
				writer.Write(result.ToString());
			}
		}

		/// <summary>
		/// DataReader 를 통한 CSV 형태 반환
		/// </summary>
		/// <param name="dataReader"></param>
		/// <param name="includeHeaderAsFirstRow"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static List<string> ToCSV(this IDataReader dataReader, bool includeHeaderAsFirstRow, string separator)
		{
			List<string> csvRows = new List<string>();
			StringBuilder sb = null;

			if (includeHeaderAsFirstRow)
			{
				sb = new StringBuilder();
				for (int index = 0; index < dataReader.FieldCount; index++)
				{
					if (dataReader.GetName(index) != null) sb.Append(dataReader.GetName(index));

					if (index < dataReader.FieldCount - 1) sb.Append(separator);
				}
				csvRows.Add(sb.ToString());
			}

			while (dataReader.Read())
			{
				sb = new StringBuilder();

				for (int index = 0; index < dataReader.FieldCount - 1; index++)
				{
					if (!dataReader.IsDBNull(index))
					{
						string value = dataReader.GetValue(index).ToString();
						if (dataReader.GetFieldType(index) == typeof(string))
						{
							if (value.IndexOf("\"") >= 0) value = value.Replace("\"", "\"\"");

							if (value.IndexOf(separator) >= 0) value = "\"" + value + "\"";
						}
						sb.Append(value);
					}
					if (index < dataReader.FieldCount - 1) sb.Append(separator);
				}

				if (!dataReader.IsDBNull(dataReader.FieldCount - 1))
					sb.Append(dataReader.GetValue(dataReader.FieldCount - 1).ToString().Replace(separator, " "));

				csvRows.Add(sb.ToString());
			}

			dataReader.Close();
			sb = null;

			return csvRows;
		}

		public static string ToCSV<T>(this IEnumerable<T> instance, char separator)
		{
			StringBuilder csv;

			if (instance != null)
			{
				csv = new StringBuilder();
				instance.ForEach(value => csv.AppendFormat("{0}{1}", value, separator));
				return csv.ToString(0, csv.Length - 1);
			}

			return null;
		}

		public static string ToCSV<T>(this IEnumerable<T> instance)
		{
			StringBuilder csv;
			if (instance != null)
			{
				csv = new StringBuilder();
				instance.ForEach(v => csv.AppendFormat("{0},", v));
				return csv.ToString(0, csv.Length - 1);
			}

			return null;
		}

		/// <summary>
		/// <code>
		/// --> Make another extension method
		/// public static List<T> ToList<T>(this object[] items)
		/// {
		///     return items.ToList<T>(o => { return (T)o; });
		/// }
		///
		/// Reduces this : http://extensionmethod.net/Details.aspx?ID=351
		///
		/// To this:
		///
		/// public static List<T> EnumToList<T>() where T : struct
		/// {
		///     return Enum.GetValues(typeof(T)).ToList<T>(enumVal => { return (T)Enum.Parse(typeof(T), enumVal.ToString()); });
		/// }
		///
		/// --> Use in Linq
		///
		/// var myItems = from i in array.ToList<MyType>( o => { return (MyType)o; }) select i;
		/// </code>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <param name="mapFunction"></param>
		/// <returns></returns>
		public static List<T> ToList<T>(this Array items, Func<object, T> mapFunction)
		{
			if (items == null || mapFunction == null) return new List<T>();

			List<T> coll = new List<T>();

			for (int i = 0; i < items.Length; i++)
			{
				T val = mapFunction(items.GetValue(i));

				if (val != null) coll.Add(val);
			}

			return coll;
		}

		/// <summary>
		/// 배열 교차
		/// <para></para>
		/// Input: transpose [[1,2,3],[4,5,6],[7,8,9]]
		/// Output: [[1,4,7],[2,5,8],[3,6,9]]
		/// var result = new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } }.Transpose();
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="values"></param>
		/// <returns></returns>
		public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> values)
		{
			if (values.Count() == 0) return values;
			if (values.First().Count() == 0) return Transpose(values.Skip(1));

			var x = values.First().First();
			var xs = values.First().Skip(1);
			var xss = values.Skip(1);

			return new[] { new[] { x }
				.Concat(xss.Select(ht => ht.First())) }
				.Concat(new[] { xs }
				.Concat(xss.Select(ht => ht.Skip(1)))
				.Transpose());
		}

		/// <summary>
		/// ForEach
		/// <para></para>
		/// List<string> names = new List<string> { "beatle", "assassin", "chrisis", "erique", "fanlan" };
		/// names.ForEach(name => Console.WriteLine(name));
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="action"></param>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
			{
				action(item);
			}

			return source;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable arr, Action<T> act)
		{
			return arr.Cast<T>().ForEach<T>(act);
		}

		public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
		{
			var list = new List<RT>();

			foreach (var item in array)
			{
				var obj = func(item);
				if (obj != null) list.Add(obj);
			}

			return list;
		}

		/// <summary>
		/// 컴파일 타임 시에는 모르는 값 기준으로, 해당 소스를 필터링 해야할 경우
		/// <para>
		/// List<Customer> custs = new List<Customer>{
		/// new Customer {FirstName = "Peggy", AcctBalance = 12442.98},
		/// new Customer {FirstName = "Sally", AcctBalance = 32.39},
		/// new Customer {FirstName = "Billy", AcctBalance = 25.33},
		/// new Customer {FirstName = "Tommy", AcctBalance = 12345}
		/// };
		///
		/// bool showAccountBalancesUnder5000 = false;
		///
		/// var custList = custs.WhereIf(showAccountBalancesUnder5000, c=>c.AcctBalance < 5000).ToList();
		///
		/// showAccountBalancesUnder5000 = true;
		///
		/// var custListUnder5000 = custs.WhereIf(showAccountBalancesUnder5000, c=>c.AcctBalance < 5000).ToList();
		/// </para>
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <param name="condition"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
		{
			if (condition) return source.Where(predicate);
			else return source;
		}

		/// <summary>
		/// WhereIf 오버로딩
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <param name="condition"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
		{
			if (condition) return source.Where(predicate);
			else return source;
		}

		/// <summary>
		/// DateTime today = DateTime.Now;
		/// var from = new DateTime(2012, 2, 1);
		/// var to = new DateTime(2012, 12, 20);
		/// bool isBetween = today.Between(from, to);
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static bool Between<T>(this T value, T from, T to) where T : IComparable<T>
		{
			return value.CompareTo(from) >= 0 && value.CompareTo(to) <= 0;
		}
	}
}