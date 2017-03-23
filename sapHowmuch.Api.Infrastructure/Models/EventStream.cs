using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Infrastructure.Models
{
	[Table("EventStream")]
	public class EventStream
	{
		[Key]
		public Guid EventId { get; set; }

		public Guid StreamId { get; set; }
		public long? Sequence { get; set; }

		[Required]
		[StringLength(256)]
		public string EventName { get; set; }

		[Required]
		[StringLength(256)]
		public string EventType { get; set; }

		[Required]
		public string EventBody { get; set; }

		public DateTime DateOccurred { get; set; }
		public DateTime DateRecorded { get; set; }
		public DateTime DateProjected { get; set; }
		public Guid ProjectedBy { get; set; }
	}
}