using sapHowmuch.Api.Infrastructure.Models.Responses.Data;
using System.Collections.Generic;

namespace sapHowmuch.Api.Business.Models.Responses.Data
{
	public class JournalVoucherCreateResponseData : BaseResponseData
	{
		public int VoucherListNumber { get; set; }
		public IEnumerable<JournalEntry> Entries { get; set; }
	}
}