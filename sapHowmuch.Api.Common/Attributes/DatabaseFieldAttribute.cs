using System;

namespace sapHowmuch.Api.Common.Attributes
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	public class DatabaseFieldAttribute : Attribute
	{
		private string _fieldName = "";
		public string FieldName { get { return _fieldName; } set { _fieldName = value; } }

		public DatabaseFieldAttribute(string fieldName)
		{
			_fieldName = fieldName;
		}
	}
}