using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.EventHandlers;
using sapHowmuch.Api.Infrastructure.EventProcessors;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sapHowmuch.Api.EventProcessors
{
	/// <summary>
	/// This represents the processor entity for events.
	/// </summary>
	public class EventProcessor : IEventProcessor
	{
		private readonly IUnitOfWorkManager _uowm;
		private readonly IEnumerable<IEventHandler> _handlers;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventProcessor" /> class.
		/// </summary>
		/// <param name="uowm"><see cref="IUnitOfWorkManager" /> instance.</param>
		/// <param name="handlers">List of event handlers.</param>
		public EventProcessor(IUnitOfWorkManager uowm, params IEventHandler[] handlers)
		{
			if (uowm == null)
			{
				throw new ArgumentNullException(nameof(uowm));
			}

			this._uowm = uowm;

			if (handlers == null)
			{
				throw new ArgumentNullException(nameof(handlers));
			}

			this._handlers = handlers;
		}

		#region IEventProcessor implementation

		private bool _disposed;

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (this._disposed)
			{
				return;
			}

			this._disposed = true;
		}

		/// <summary>
		/// Processes the list of events asynchronously.
		/// </summary>
		/// <param name="evs">List of events.</param>
		/// <returns>Returns <c>True</c>, if all events have been consumed; otherwise returns <c>False.</c></returns>
		public async Task<bool> ProcessEventsAsync(IEnumerable<BaseEvent> evs)
		{
			var results = new List<bool>();

			using (var uow = this._uowm.CreateInstance<ApiDbContext>())
			{
				uow.BeginTransaction();

				try
				{
					foreach (var ev in evs)
					{
						var handlers = this.GetHandlers(ev);

						foreach (var handler in handlers)
						{
							var result = await handler.ProcessAsync(ev);
							results.Add(result);
						}
					}

					uow.Commit();
				}
				catch
				{
					uow.Rollback();
					results.Add(false);
					throw;
				}
			}

			return await Task.FromResult(results.TrueForAll(p => p));
		}

		#endregion IEventProcessor implementation

		private IEnumerable<IEventHandler> GetHandlers(BaseEvent ev)
		{
			var handlers = this._handlers.Where(p => p.CanProcess(ev));

			return handlers;
		}
	}
}