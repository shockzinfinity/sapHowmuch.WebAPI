namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapVatGroupEntity : MasterTypeEntity
	{
		public override string Code { get { return VatCode; } }

		/// <summary>
		/// 세금코드
		/// </summary>
		public string VatCode { get; set; }

		/// <summary>
		/// 세금명
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 매출/매입
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// 집계코드
		/// </summary>
		public string ReportCode { get; set; }

		/// <summary>
		/// 계정코드
		/// </summary>
		public string Account { get; set; }
	}
}