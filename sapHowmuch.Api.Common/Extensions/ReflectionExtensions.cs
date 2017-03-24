using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class ReflectionExtensions
	{
		public static T GetDefaultValue<T>(this PropertyInfo pi)
		{
			if (pi.IsDefined(typeof(DefaultValueAttribute), false))
			{
				DefaultValueAttribute attribute = pi.GetCustomAttributes(false).Where(x => x.GetType() == typeof(DefaultValueAttribute)).FirstOrDefault() as DefaultValueAttribute;

				return (T)attribute.Value;
			}
			else
			{
				return default(T);
			}
		}

		public static TEnum FindEnumFromDescription<TEnum>(this string value) where TEnum : struct, IConvertible
		{
			if (!typeof(TEnum).IsEnum || string.IsNullOrWhiteSpace(value)) return default(TEnum);

			var enumValues = Enum.GetValues(typeof(TEnum));

			foreach (var item in enumValues)
			{
				if (value.ToLower().Equals((item as Enum).EnumDescription().ToLower())) return (TEnum)item;
			}

			return default(TEnum);
		}

		public static string EnumDescription(this Enum enumVal)
		{
			return enumVal.GetAttributeValueBy<DescriptionAttribute>(x => x.Description);
		}

		public static T GetAttributeOf<T>(this Enum enumVal) where T : Attribute
		{
			var type = enumVal.GetType();
			var memberInfo = type.GetMember(enumVal.ToString());
			var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);

			return (attributes.Length > 0) ? (T)attributes[0] : null;
		}

		public static string GetAttributeValueBy<T>(this Enum enumVal, Func<T, string> expression) where T : Attribute
		{
			T attribute = enumVal.GetType().GetMember(enumVal.ToString())
				.Where(member => member.MemberType == MemberTypes.Field)
				.FirstOrDefault()
				.GetCustomAttributes(typeof(T), false)
				.Cast<T>()
				.SingleOrDefault();

			if (attribute == null) return default(string);

			return expression.Invoke(attribute);
		}

		public static string GetAttributeValueBy<T>(this PropertyInfo pi, Func<T, string> expression) where T : Attribute
		{
			T attribute = pi.GetCustomAttributes(typeof(T), false).Cast<T>().SingleOrDefault();

			return expression.Invoke(attribute);
		}

		public static PropertyInfo[] GetPropertiesBySpecific<T>(this Type requestType) where T : Attribute
		{
			return requestType.GetProperties().Where(x => x.IsDefined(typeof(T), false)).ToArray();
		}

		public static TRequestType InstantiateClass<TRequestType>(this string className, params object[] constructorArgs)
		{
			var classType = Assembly.GetExecutingAssembly().GetExportedTypes().Where(x => x.Name == className).FirstOrDefault();

			return (TRequestType)Activator.CreateInstance(classType, constructorArgs);
		}

		public static bool GetAttributeValueBy<T>(this PropertyInfo pi, Func<T, bool> expression) where T : Attribute
		{
			T attribute = pi.GetCustomAttributes(typeof(T), false).Cast<T>().SingleOrDefault();

			return expression.Invoke(attribute);
		}

		public static T GetAttribute<T>(this Assembly callingAssembly) where T : Attribute
		{
			T result = null;

			object[] configAttributes = Attribute.GetCustomAttributes(callingAssembly, typeof(T), false);

			if (configAttributes != null)
			{
				result = (T)configAttributes[0];
			}

			return result;
		}

		/// <summary>
		/// Enum 값의 Description 문자열을 반환
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToDescription(this Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] descriptions = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return (descriptions != null && descriptions.Length > 0) ? descriptions[0].Description : fi.Name;
		}

		/// <summary>
		/// 제공된 values 에 value가 포함되는지 여부
		/// </summary>
		/// <param name="value"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static bool In(this Enum value, params Enum[] values)
		{
			return values.Any(v => v == value);
		}

		/// <summary>
		/// Enum 에 지정되어 있는 Description 어트리뷰트 값을 불러옴.
		/// </summary>
		/// <typeparam name="T">Enum 타입</typeparam>
		/// <param name="enumVal"></param>
		/// <param name="value">읽고자 하는 Enum 요소</param>
		/// <returns></returns>
		public static string GetEnumDescription<T>(this Enum enumVal, string value)
		{
			Type type = typeof(T);
			var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

			if (name == null)
			{
				return string.Empty;
			}

			var field = type.GetField(name);
			var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
		}

		/// <summary>
		/// 해당 Enum 값의 T로 지정되어 있는 어트리뷰트 값 불러옴.
		/// </summary>
		/// <typeparam name="T">읽고자 하는 Attribute 타입</typeparam>
		/// <param name="enumVal">읽고자 하는 Enum 값</param>
		/// <returns>해당 어트리뷰트 형식의 값, 없으면 null</returns>
		public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
		{
			var type = enumVal.GetType();
			var memInfo = type.GetMember(enumVal.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);

			return attributes.Length > 0 ? (T)attributes[0] : null;
		}

		/// <summary>
		/// Enum 의 어트리뷰트 값 불러옴.(람다식 이용)
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumVal"></param>
		/// <param name="expression"></param>
		/// <returns></returns>
		public static string GetAttributeValue<T>(this Enum enumVal, Func<T, string> expression) where T : Attribute
		{
			T attribute = enumVal.GetType().GetMember(enumVal.ToString())
						.Where(member => member.MemberType == MemberTypes.Field)
						.FirstOrDefault()
						.GetCustomAttributes(typeof(T), false)
						.Cast<T>()
						.SingleOrDefault();

			if (attribute == null) return default(string);

			return expression(attribute);
		}

		/// <summary>
		/// Enum 값을 리스트 형태로
		/// <para>
		/// List<DayOfWeek> weekdays =
		/// EnumHelper.EnumToList<DayOfWeek>().FindAll(
		/// delegate (DayOfWeek x)
		/// {
		/// 	return x != DayOfWeek.Sunday && x != DayOfWeek.Saturday;
		/// });
		/// </para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static List<T> EnumToList<T>() where T : struct
		{
			Type enumType = typeof(T);

			// value Type 체크 방법
			if (enumType.BaseType != typeof(Enum)) throw new ArgumentException("T must be of type System.Enum");

			Array enumValArray = Enum.GetValues(enumType);

			List<T> enumValList = new List<T>(enumValArray.Length);

			foreach (int val in enumValArray)
			{
				enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
			}

			return enumValList;
		}
	}
}