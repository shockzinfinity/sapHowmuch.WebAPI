using SAPbobsCOM;
using sapHowmuch.Api.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class SapRecordsetExtensions
	{
		public static List<T> FillDataByDatabaseFieldAttribute<T>(this Recordset recordset, string query) where T : class
		{
			List<T> retList = new List<T>();

			try
			{
				if (string.IsNullOrWhiteSpace(query))
					throw new ArgumentNullException("query");

				recordset.DoQuery(query);

				if (recordset.RecordCount > 0)
				{
					recordset.MoveFirst();

					while (!recordset.EoF)
					{
						T requestClass = Activator.CreateInstance(typeof(T), null) as T;

						// 지정된 attribute에 따른 프로퍼티 리스트 배열 받아와서
						// 그 프로퍼티들에서 루프 시작
						// 각 요소에 recordset field value 를 setvalue 해서
						// 리턴할 오브젝트에 셋팅
						// 오브젝트 갯수는 레코드셋 카운트의 수만큼이 됨.
						var properties = typeof(T).GetPropertiesBySpecific<DatabaseFieldAttribute>();
						foreach (PropertyInfo item in properties)
						{
							// TODO: DB 타입, SAP 타입 체크 필요
							//SAPbobsCOM.BoFieldTypes
							//SAPbobsCOM.BoFldSubTypes
							// NULL 체크 필요
							// 자동 타입 변환 필요

							item.SetValue(requestClass, recordset.Fields.Item(item.GetAttributeValueBy<DatabaseFieldAttribute>(d => d.FieldName)).Value, null);
						}

						retList.Add(requestClass);

						recordset.MoveNext();
					}
				}

				return retList;
			}
			catch
			{
				throw;
			}
			finally
			{
				if (recordset != null) Marshal.ReleaseComObject(recordset);
			}
		}
	}
}