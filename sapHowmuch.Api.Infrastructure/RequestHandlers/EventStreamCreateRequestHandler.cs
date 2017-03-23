using AutoMapper;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models.Requests;

namespace sapHowmuch.Api.Infrastructure.RequestHandlers
{
	/// <summary>
	/// This represents the request handler entity for event stream create.
	/// </summary>
	public class EventStreamCreateRequestHandler : BaseRequestHandler<EventStreamCreateRequest, EventStreamCreatedEvent>
	{
		#region BaseRequestHandler overrides

		/// <summary>
		/// Called while creating the event from the request.
		/// </summary>
		/// <param name="request">Request instance.</param>
		/// <returns>Returns the event created.</returns>
		protected override EventStreamCreatedEvent OnCreatingEvent(BaseRequest request)
		{
			var @event = Mapper.Map<EventStreamCreatedEvent>(request as EventStreamCreateRequest);

			return @event;
		}

		#endregion BaseRequestHandler overrides
	}
}