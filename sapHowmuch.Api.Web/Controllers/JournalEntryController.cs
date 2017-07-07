using sapHowmuch.Api.Repositories;
using sapHowmuch.Api.Services;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// 분개 컨트롤러
	/// </summary>
	[Authorize]
	[LoggingFilter]
	[RoutePrefix("api/journal")]
	public class JournalEntryController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;
		private readonly IEventStreamService _service;

		/// <summary>
		/// Initialize a new instance of the <see cref="JournalEntryController" /> class
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance</param>
		/// <param name="service"><c>EventStreamService</c> instance</param>
		public JournalEntryController(ISapQueryRepository repository, IEventStreamService service)
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

		/// <summary>
		/// Get all journal entries
		/// TODO: paging
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(_repository.GetJournalEntries().Result);
		}

		/// <summary>
		/// Get a journal entry
		/// </summary>
		/// <param name="transId"></param>
		/// <returns></returns>
		[Route("{transId}")]
		public async Task<IHttpActionResult> Get(int transId)
		{
			var journal = await _repository.GetJournalEntryBy(transId);

			if (journal != null)
			{
				return Ok(journal);
			}

			return NotFound();
		}
	}
}