using System;
using System.Collections.Generic;

namespace sapHowmuch.Api.Business.Models
{
	public class JournalEntry
	{
		public DateTime ReferenceDate { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime TaxDate { get; set; }
		public string Memo { get; set; }
		public IEnumerable<JournalEntryLine> Lines { get; set; }
	}
}