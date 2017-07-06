using sapHowmuch.Api.Repositories;
using sapHowmuch.Api.Services;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// Journal Voucher 컨트롤러
	/// </summary>
	//[Authorize]
	[LoggingFilter]
	[RoutePrefix("api/journalvoucher")]
	public class VoucherController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;
		private readonly IEventStreamService _service;

		/// <summary>
		/// Initialize a new instance of the <see cref="VoucherController" /> class
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance</param>
		/// <param name="service"><c>EventStreamService</c> instance</param>
		public VoucherController(ISapQueryRepository repository, IEventStreamService service)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			this._repository = repository;

			if (service == null)
			{
				throw new ArgumentNullException(nameof(service));
			}

			this._service = service;
		}
	}
}