using AutoMapper;
using Newtonsoft.Json;
using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Infrastructure.EventHandlers
{
	/// <summary>
	/// This represents the processor entity for the <see cref="EventStreamCreatedEvent" /> class.
	/// </summary>
	public class EventStreamCreatedEventHandler : BaseEventHandler<EventStreamCreatedEvent>
	{
		private readonly IBaseRepository<EventStream> _eventStreamRepository;
		private readonly string _eventType;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventStreamCreatedEventHandler" /> class.
		/// </summary>
		/// <param name="mapper">event stream mapper instance.</param>
		/// <param name="eventStreamRepository">event stream repository instance.</param>
		public EventStreamCreatedEventHandler(IBaseRepository<EventStream> eventStreamRepository)
		{
			if (eventStreamRepository == null)
			{
				throw new ArgumentNullException(nameof(eventStreamRepository));
			}

			this._eventStreamRepository = eventStreamRepository;

			this._eventType = typeof(EventStreamCreatedEvent).FullName;
		}

		#region BaseEventHandler overrides

		/// <summary>
		/// Called while loading events from the repository asynchronously.
		/// </summary>
		/// <param name="streamId">The stream id.</param>
		/// <returns>Returns the list of events.</returns>
		protected override async Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId)
		{
			var streams = await this._eventStreamRepository
				.Get()
				.Where(p => p.EventType.Equals(this._eventType, StringComparison.InvariantCultureIgnoreCase))
				.Where(e => e.StreamId == streamId)
				.OrderByDescending(p => p.Sequence)
				.ToListAsync();

			var events = streams.Select(p => JsonConvert.DeserializeObject<EventStreamCreatedEvent>(p.EventBody));

			return events;
		}

		/// <summary>
		/// Called while processing the event asynchronously.
		/// </summary>
		/// <param name="ev">Event instance.</param>
		/// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
		protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
		{
			var stream = Mapper.Map<EventStream>(ev as EventStreamCreatedEvent);

			this._eventStreamRepository.Add(stream);

			return await Task.FromResult(true);
		}

		#endregion BaseEventHandler overrides
	}
}