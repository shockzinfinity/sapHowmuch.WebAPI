using System;

namespace sapHowmuch.Api.Infrastructure.Models
{
	/// <summary>
	/// This Chart of Account of SAP Business One, customizing by connected company.
	/// </summary>
	public class SapCoaEntity : MasterTypeEntity
	{
		public override string Code { get { return AcctCode; } }

		/// <summary>
		/// 계정 코드
		/// </summary>
		public string AcctCode { get; set; } // nvarchar(15), not null

		/// <summary>
		/// 계정 명
		/// </summary>
		public string AcctName { get; set; } // nvarchar(100), null

		/// <summary>
		/// 계정 Level
		/// </summary>
		public short? Levels { get; set; }

		/// <summary>
		/// 계정 유형
		/// Account Category ('I' = Sales, 'E' = Expenditure, 'N' = Other)
		/// </summary>
		public string ActType { get; set; } // char(1), null

		public string ValidFor { get; set; } // char(1), null

		public DateTime? ValidFrom { get; set; } // datetime, null

		public DateTime? ValidTo { get; set; } // datetime, null

		public string FrozenFor { get; set; } // char(1), null

		public DateTime? FrozenFrom { get; set; } // datetime, null

		public DateTime? FrozenTo { get; set; } // datetime, null

		/// <summary>
		/// 계정 통화
		/// ## 는 '모든 통화'
		/// </summary>
		public string ActCurr { get; set; } // nvarchar(3), null

		/// <summary>
		/// 비고
		/// </summary>
		public string Details { get; set; } // nvarchar(254), null

		/// <summary>
		/// 등록일
		/// </summary>
		public DateTime? CreateDate { get; set; } // datetime, null
	}
}