using System;

namespace sapHowmuch.Api.Infrastructure.Models.Responses.Data
{
	/// <summary>
	/// This represents the response data entity for event stream.
	/// </summary>
	public class EventStreamResponseData : BaseResponseData
	{
		/// <summary>
		/// Gets or sets the stream Id.
		/// </summary>
		public Guid StreamId { get; set; }
	}
}