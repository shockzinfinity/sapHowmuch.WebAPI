using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Infrastructure.EventHandlers
{
	/// <summary>
	/// This represents the processor entity for the <see cref="EmployeeInfoCreatedEvent" /> class.
	/// </summary>
	public class EmployeeInfoCreatedEventHandler : BaseEventHandler<EmployeeInfoCreatedEvent>
	{
		private readonly IBaseRepository<EventStream> _eventRepository;
		// TODO: 엔티티에 대한 리파지터리 전략 결정
		private readonly string _eventType;

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeInfoCreatedEventHandler" /> class.
		/// </summary>
		/// <param name="eventRepository">event stream repository instance.</param>
		public EmployeeInfoCreatedEventHandler(IBaseRepository<EventStream> eventRepository)
		{
			if (eventRepository == null)
			{
				throw new ArgumentNullException(nameof(eventRepository));
			}

			this._eventRepository = eventRepository;

			this._eventType = typeof(EmployeeInfoCreatedEvent).FullName;
		}

		/// <summary>
		/// Called while loading events from the repository asynchronously.
		/// </summary>
		/// <param name="streamId">The stream id.</param>
		/// <returns>Returns the list of events.</returns>
		protected override Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Called while processing the event asynchronously.
		/// </summary>
		/// <param name="ev">Event instance.</param>
		/// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
		protected override Task<bool> OnProcessingAsync(BaseEvent ev)
		{
			throw new NotImplementedException();
		}
	}
}
