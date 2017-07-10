using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Business.Models.Responses;
using sapHowmuch.Api.Business.Models.Responses.Data;
using sapHowmuch.Api.Infrastructure.EventProcessors;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Responses;
using sapHowmuch.Api.Infrastructure.Models.Responses.Data;
using sapHowmuch.Api.Infrastructure.RequestBuilders;
using sapHowmuch.Api.Infrastructure.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Services
{
	/// <summary>
	/// This represents the service entity for event stream.
	/// </summary>
	public class EventStreamService : IEventStreamService
	{
		private readonly IEventProcessor _processor;
		private readonly IRequestBuilder _builder;
		private readonly IEnumerable<IRequestHandler> _handlers;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventStreamService" /> class.
		/// </summary>
		/// <param name="processor">The event processor instance.</param>
		/// <param name="builder">The request builder instance.</param>
		/// <param name="handlers">The list of request handlers.</param>
		public EventStreamService(IEventProcessor processor, IRequestBuilder builder, params IRequestHandler[] handlers)
		{
			if (processor == null)
			{
				throw new ArgumentNullException(nameof(processor));
			}

			this._processor = processor;

			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}

			this._builder = builder;

			if (handlers == null)
			{
				throw new ArgumentNullException(nameof(handlers));
			}

			this._handlers = handlers;
		}

		#region IEventStreamService implementation

		/// <summary>
		/// Creates a new event stream asynchronously.
		/// </summary>
		/// <param name="request">The <see cref="EventStreamCreateRequest" /> instance.</param>
		/// <returns>Returns the <see cref="EventStreamCreateResponse" /> instance.</returns>
		public async Task<EventStreamCreateResponse> CreateEventStreamAsync(EventStreamCreateRequest request)
		{
			var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));

			if (handler == null)
			{
				return await Task.FromResult(default(EventStreamCreateResponse));
			}

			var ev = handler.CreateEvent(request) as EventStreamCreatedEvent;

			PopulateBaseProperties(ev);

			EventStreamCreateResponse response;

			try
			{
				await this._processor.ProcessEventsAsync(new[] { ev });
				response = new EventStreamCreateResponse
				{
					Data = new EventStreamResponseData
					{
						StreamId = request.StreamId
					}
				};
			}
			catch (Exception ex)
			{
				response = new EventStreamCreateResponse
				{
					Error = new ResponseError
					{
						Message = ex.Message,
						StackTrace = ex.StackTrace
					}
				};
			}

			return await Task.FromResult(response);
		}

		public async Task<EmployeeInfoCreateResponse> CreateEmployeeInfoAsync(EmployeeInfoCreateRequest request)
		{
			await this._builder.BuildAsync(request);

			var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));

			if (handler == null)
			{
				return await Task.FromResult(default(EmployeeInfoCreateResponse));
			}

			var ev = handler.CreateEvent(request) as EmployeeInfoCreatedEvent;
			PopulateBaseProperties(ev);

			EmployeeInfoCreateResponse response;

			try
			{
				await this._processor.ProcessEventsAsync(new[] { ev });

				// TODO: Mapper 고려
				response = new EmployeeInfoCreateResponse()
				{
					Data = new EmployeeInfoCreateResponseData()
					{
						ExtEmpno = ev.ExtEmpno,
						FirstName = ev.FirstName,
						LastName = ev.LastName,
						Sex = ev.Sex,
						Active = ev.Active,
						Dept = ev.Dept,
						BirthDate = ev.BirthDate,
						BrthCountr = ev.BrthCountr,
						Email = ev.Email,
						HomeCountr = ev.HomeCountr,
						HomeStreet = ev.HomeStreet,
						HomeTel = ev.HomeTel,
						HomeZip = ev.HomeZip,
						MartStatus = ev.MartStatus,
						Mobile = ev.Mobile,
						Position = ev.Position,
						StartDate = ev.StartDate,
						Status = ev.Status,
						TermDate = ev.TermDate
					}
				};
			}
			catch (Exception ex)
			{
				response = new EmployeeInfoCreateResponse()
				{
					Error = new ResponseError()
					{
						Message = ex.Message,
						StackTrace = ex.StackTrace
					}
				};
			}

			return await Task.FromResult(response);
		}

		public async Task<CountryCreateResponse> CreateCountryAsync(CountryCreateRequest request)
		{
			await this._builder.BuildAsync(request);

			var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));

			if (handler == null)
			{
				return await Task.FromResult(default(CountryCreateResponse));
			}

			var ev = handler.CreateEvent(request) as CountryCreatedEvent;
			PopulateBaseProperties(ev);

			CountryCreateResponse response;

			try
			{
				await this._processor.ProcessEventsAsync(new[] { ev });

				response = new CountryCreateResponse()
				{
					Data = new CountryCreateResponseData()
					{
						Code = ev.CountryCode,
						Name = ev.CountryName
					}
				};
			}
			catch (Exception ex)
			{
				response = new CountryCreateResponse()
				{
					Error = new ResponseError()
					{
						Message = ex.Message,
						StackTrace = ex.StackTrace
					}
				};
			}

			return await Task.FromResult(response);
		}

		public async Task<JournalVoucherCreateResponse> CreateJournalVoucherAsync(JournalVoucherCreateRequest request)
		{
			await this._builder.BuildAsync(request);

			var handler = this._handlers.SingleOrDefault(p => p.CanHandle(request));

			if (handler == null)
			{
				return await Task.FromResult(default(JournalVoucherCreateResponse));
			}

			var ev = handler.CreateEvent(request) as JournalVoucherCreatedEvent;
			PopulateBaseProperties(ev);

			JournalVoucherCreateResponse response;

			try
			{
				await this._processor.ProcessEventsAsync(new[] { ev });

				response = new JournalVoucherCreateResponse()
				{
					Data = new JournalVoucherCreateResponseData()
					{
						Entries = ev.Entries,
						VoucherListNumber = ev.VoucherListNumber
					}
				};
			}
			catch (Exception ex)
			{
				response = new JournalVoucherCreateResponse()
				{
					Error = new ResponseError()
					{
						Message = ex.Message,
						StackTrace = ex.StackTrace
					}
				};
			}

			return await Task.FromResult(response);
		}

		private bool _disposed;

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public virtual void Dispose()
		{
			if (this._disposed)
			{
				return;
			}

			this._disposed = true;
		}

		#endregion IEventStreamService implementation

		private static void PopulateBaseProperties<T>(T ev) where T : BaseEvent
		{
			ev.EventId = Guid.NewGuid();
			ev.Sequence = DateTime.UtcNow.Ticks;
			ev.DateOccurred = DateTime.UtcNow;
			ev.Projector = Projector.System;
		}
	}
}