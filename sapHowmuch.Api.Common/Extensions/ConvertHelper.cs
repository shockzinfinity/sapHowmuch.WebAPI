using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace sapHowmuch.Api.Common.Extensions
{
	/// <summary>
	/// 데이터 타입 변환 헬퍼
	/// </summary>
	public static class ConvertHelper
	{
		/// <summary>
		/// object 타입을 <c>Dictionary{string, object}</c> 타입으로 변환
		/// </summary>
		/// <param name="input">Data object.</param>
		/// <returns><c>Dictionary{string, object}</c>타입 반환.</returns>
		public static IDictionary<string, object> ConvertToDictionary(object input)
		{
			var dictionary = new Dictionary<string, object>();
			if (input == null)
			{
				return dictionary;
			}

			dictionary = input.GetType()
							  .GetProperties(BindingFlags.Public | BindingFlags.Instance)
							  .ToDictionary(pi => pi.Name, pi => pi.GetValue(input));
			return dictionary;
		}

		/// <summary>
		/// object 를 <c>SqlParameter</c> array 로 변환.
		/// </summary>
		/// <param name="input">Data object.</param>
		/// <returns>Returns the <c>SqlParameter</c> array.</returns>
		public static object[] ConvertToParameters(object input)
		{
			if (input == null)
			{
				return null;
			}

			var dictionary = ConvertToDictionary(input);
			if (dictionary == null || !dictionary.Any())
			{
				return null;
			}

			var parameters = dictionary.Select(kvp => new SqlParameter(kvp.Key, kvp.Value) as object);
			return parameters.ToArray();
		}

		/// <summary>
		/// <c>Dictionary{string, object}</c> 를 <c>SqlParameter</c> array 로 변환.
		/// </summary>
		/// <param name="input"><c>Dictionary{string, object}</c> object.</param>
		/// <returns>Returns the <c>SqlParameter</c> array.</returns>
		public static object[] ConvertToParameters(IDictionary<string, object> input)
		{
			if (input == null || !input.Any())
			{
				return null;
			}

			var parameters = input.Select(kvp => new SqlParameter(kvp.Key, kvp.Value) as object);
			return parameters.ToArray();
		}
	}
}