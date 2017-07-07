using System;
using System.Collections.Generic;

namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapJournalVouchersListEntity : DocumentTypeEntity
	{
		public override int Id { get { return BatchNum; } }

		/// <summary>
		/// 분개장 번호
		/// </summary>
		public int BatchNum { get; set; }

		/// <summary>
		/// 문서상태
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// 포함된 전표 갯수
		/// </summary>
		public int NumOfTrans { get; set; }

		/// <summary>
		/// Posting Date
		/// </summary>
		public DateTime? DateID { get; set; }

		/// <summary>
		/// Elements
		/// </summary>
		public IEnumerable<SapJournalVoucherEntity> Elements { get; set; }
	}
}