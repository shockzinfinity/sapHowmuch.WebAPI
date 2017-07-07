using sapHowmuch.Api.Business.Models;
using sapHowmuch.Api.Infrastructure.Events;
using System.Collections.Generic;

namespace sapHowmuch.Api.Business.Events
{
	public class JournalVoucherCreatedEvent : BaseEvent
	{
		public override string Name => this.GetType().Name;

		public int VoucherListNumber { get; set; }
		public IEnumerable<JournalEntry> Entries { get; set; }
	}
}