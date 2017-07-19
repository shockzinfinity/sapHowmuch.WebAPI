using sapHowmuch.Api.Infrastructure.Models.Requests;
using System.Collections.Generic;

namespace sapHowmuch.Api.Business.Models.Requests
{
	/// <summary>
	/// Request for JournalVoucher create
	/// </summary>
	public class JournalVoucherCreateRequest : BaseRequest
	{
		public IEnumerable<JournalEntry> Entries { get; set; }
	}
}