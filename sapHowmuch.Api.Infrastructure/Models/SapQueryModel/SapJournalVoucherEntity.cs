using System;
using System.Collections.Generic;

namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapJournalVoucherEntity : DocumentTypeEntity
	{
		public override int Id { get { return TransId; } }

		/// <summary>
		/// 분개장 번호
		/// </summary>
		public int BatchNum { get; set; }

		/// <summary>
		/// transaction number
		/// </summary>
		public int TransId { get; set; }

		/// <summary>
		/// Status
		/// </summary>
		public string BtfStatus { get; set; }

		/// <summary>
		/// 원천문서타입
		/// </summary>
		public string TransType { get; set; }

		/// <summary>
		/// 원천문서번호
		/// </summary>
		public string BaseRef { get; set; }

		/// <summary>
		/// posting date
		/// </summary>
		public DateTime? RefDate { get; set; }

		/// <summary>
		/// 적요
		/// </summary>
		public string Memo { get; set; }

		/// <summary>
		/// Total in LC
		/// </summary>
		public decimal? LocTotal { get; set; }

		/// <summary>
		/// 만기일
		/// </summary>
		public DateTime? DueDate { get; set; }

		/// <summary>
		/// Tax date
		/// </summary>
		public DateTime? TaxDate { get; set; }

		/// <summary>
		/// 전기기간
		/// </summary>
		public int FinncPriod { get; set; }

		/// <summary>
		/// 오브젝트 타입
		/// </summary>
		public string ObjType { get; set; }

		/// <summary>
		/// 생성일
		/// </summary>
		public DateTime? CreateDate { get; set; }

		/// <summary>
		/// 수정일
		/// </summary>
		public DateTime? UpdateDate { get; set; }

		/// <summary>
		/// Lines
		/// </summary>
		public IEnumerable<SapJournalVoucherLineEntity> Lines { get; set; }
	}
}