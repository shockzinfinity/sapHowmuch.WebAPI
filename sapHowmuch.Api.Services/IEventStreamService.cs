using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Responses;
using System;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Services
{
	/// <summary>
	/// This provides interfaces to the <see cref="EventStreamService" /> class.
	/// </summary>
	public interface IEventStreamService : IDisposable
	{
		/// <summary>
		/// Creates a new event stream asynchronously.
		/// </summary>
		/// <param name="request">The <see cref="EventStreamCreateRequest" /> instance.</param>
		/// <returns>Returns the <see cref="EventStreamCreateResponse" /> instance.</returns>
		Task<EventStreamCreateResponse> CreateEventStreamAsync(EventStreamCreateRequest request);
	}
}