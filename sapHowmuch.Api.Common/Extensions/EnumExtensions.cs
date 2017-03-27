using SAPbobsCOM;
using System;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class EnumExtensions
	{
		#region for SAP Business One

		public static BoYesNoEnum ToSBOYesOrNo(this string value)
		{
			if (string.IsNullOrWhiteSpace(value) || value.Trim() != "Y")
			{
				return BoYesNoEnum.tNO;
			}
			else
			{
				return BoYesNoEnum.tYES;
			}
		}

		public static BoGenderTypes ToSBOGenderType(this string value)
		{
			switch (value.Trim())
			{
				case "M": return BoGenderTypes.gt_Male;
				case "F": return BoGenderTypes.gt_Female;
				default: return BoGenderTypes.gt_Undefined;
			}
		}

		public static BoMeritalStatuses ToSBOMeritalStatus(this string value)
		{
			switch (value.Trim())
			{
				case "S": return BoMeritalStatuses.mts_Single;
				case "M": return BoMeritalStatuses.mts_Married;
				default: return BoMeritalStatuses.mts_Single;
			}
		}

		public static BoObjectTypes ToSBOType(this string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentNullException("value");

			return (BoObjectTypes)Enum.Parse(typeof(BoObjectTypes), value);
		}

		#endregion for SAP Business One
	}
}