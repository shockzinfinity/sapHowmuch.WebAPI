using sapHowmuch.Api.Repositories;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// Item 컨트롤러
	/// </summary>
	[Authorize]
	[LoggingFilter]
	[RoutePrefix("api/item")]
	public class ItemController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;

		/// <summary>
		/// Initialize a new instance of the <see cref="ItemController" /> class
		/// </summary>
		/// <param name="repository"><c>SqpQueryRepository</c> instance</param>
		public ItemController(ISapQueryRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			this._repository = repository;
		}

		/// <summary>
		/// Get all Items
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(_repository.GetItems().Result);
		}

		/// <summary>
		/// Get a specific item
		/// </summary>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		[Route("{itemCode}")]
		public async Task<IHttpActionResult> Get(string itemCode)
		{
			var item = await _repository.GetItemBy(itemCode);

			if (item != null)
			{
				return Ok(item);
			}

			return NotFound();
		}
	}
}