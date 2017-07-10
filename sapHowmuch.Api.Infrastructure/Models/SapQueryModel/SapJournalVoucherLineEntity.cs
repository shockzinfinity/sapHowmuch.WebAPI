using System;

namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapJournalVoucherLineEntity : DocumentTypeEntity
	{
		public override int Id { get { return TransId; } }

		/// <summary>
		/// transaction number
		/// </summary>
		public int TransId { get; set; }

		/// <summary>
		/// line id
		/// </summary>
		public int Line_ID { get; set; }

		/// <summary>
		/// 계정과목코드
		/// </summary>
		public string Account { get; set; }

		/// <summary>
		/// 차/대변 여부
		/// </summary>
		public string DebCred { get; set; }

		/// <summary>
		/// 차변
		/// </summary>
		public decimal? Debit { get; set; }

		/// <summary>
		/// 대변
		/// </summary>
		public decimal? Credit { get; set; }

		/// <summary>
		/// 만기일
		/// </summary>
		public DateTime? DueDate { get; set; }

		/// <summary>
		/// 참조일
		/// </summary>
		public DateTime? RefDate { get; set; }

		/// <summary>
		/// BP or Account code
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// 상계계정코드
		/// </summary>
		public string ContraAct { get; set; }
	}
}