using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models.Requests;

namespace sapHowmuch.Api.Infrastructure.RequestHandlers
{
	/// <summary>
	/// This represents the base request handler entity. This must be inherited.
	/// </summary>
	/// <typeparam name="TRequest">Type of request.</typeparam>
	/// <typeparam name="TEvent">Type of event.</typeparam>
	public abstract class BaseRequestHandler<TRequest, TEvent> : IRequestHandler where TRequest : BaseRequest where TEvent : BaseEvent
	{
		#region IRequestHandler implementation

		/// <summary>
		/// Checks whether the given request can be handled or not.
		/// </summary>
		/// <param name="request">Request instance.</param>
		/// <returns>Returns <c>True</c>, if the given request can be processed; otherwise returns <c>False</c>.</returns>
		public virtual bool CanHandle(BaseRequest request)
		{
			var req = request as TRequest;

			return req != null;
		}

		/// <summary>
		/// Create the event from the request.
		/// </summary>
		/// <param name="request">Request instance.</param>
		/// <returns>Returns the event created.</returns>
		public BaseEvent CreateEvent(BaseRequest request)
		{
			return this.OnCreatingEvent(request);
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

		#endregion IRequestHandler implementation

		/// <summary>
		/// Called while creating the event from the request.
		/// </summary>
		/// <param name="request">Request instance.</param>
		/// <returns>Returns the event created.</returns>
		protected abstract TEvent OnCreatingEvent(BaseRequest request);
	}
}