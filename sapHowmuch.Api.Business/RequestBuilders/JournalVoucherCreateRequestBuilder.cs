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
	public class JournalVoucherCreateRequestBuilder : IRequestBuilder
	{
		private readonly IEnumerable<IEventHandler> _handlers;

		public JournalVoucherCreateRequestBuilder(params IEventHandler[] handlers)
		{
			if (handlers == null)
			{
				throw new ArgumentNullException(nameof(handlers));
			}

			this._handlers = handlers;
		}

		public async Task BuildAsync(BaseRequest request)
		{
			var handlers = this._handlers.Where(p => p.CanBuild<JournalVoucherCreateRequest>(request));

			foreach (var handler in handlers)
			{
				await handler.BuildRequestAsync(request);
			}
		}

		private bool _disposed;

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