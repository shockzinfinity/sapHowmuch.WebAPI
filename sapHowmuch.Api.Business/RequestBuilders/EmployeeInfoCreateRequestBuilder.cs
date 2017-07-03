using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Infrastructure.EventHandlers;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.RequestBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Business.RequestBuilders
{
	/// <summary>
	/// This represents the builder entity for user create request.
	/// </summary>
	public class EmployeeInfoCreateRequestBuilder : IRequestBuilder
	{
		private readonly IEnumerable<IEventHandler> _handlers;

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeInfoCreateRequestBuilder" /> class.
		/// </summary>
		/// <param name="handlers">The list of event handler instances.</param>
		public EmployeeInfoCreateRequestBuilder(params IEventHandler[] handlers)
		{
			if (handlers == null)
			{
				throw new ArgumentNullException(nameof(handlers));
			}

			this._handlers = handlers;
		}

		/// <summary>
		/// Builds requests asynchronously.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns>Returns <see cref="Task" />.</returns>
		public async Task BuildAsync(BaseRequest request)
		{
			var handlers = this._handlers.Where(p => p.CanBuild<EmployeeInfoCreateRequest>(request));

			foreach (var handler in handlers)
			{
				await handler.BuildRequestAsync(request);
			}
		}

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
	}
}