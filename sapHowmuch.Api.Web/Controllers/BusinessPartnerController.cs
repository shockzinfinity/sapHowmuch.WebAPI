using sapHowmuch.Api.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// 비즈니스파트너 컨트롤러
	/// </summary>
	[Authorize]
	[RoutePrefix("api/bp")]
	public class BusinessPartnerController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="BusinessPartnerController"/> class.
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance.</param>
		public BusinessPartnerController(ISapQueryRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			this._repository = repository;
		}

		/// <summary>
		/// Gets all business partners.
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(_repository.GetBusinessPartners().Result);
		}

		/// <summary>
		/// Gets a specific business partner.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		[Route("{code}")]
		public async Task<IHttpActionResult> Get(string code)
		{
			var bp = await _repository.GetBusinessPartnerBy(code);

			if (bp != null)
			{
				return Ok(bp);
			}

			return NotFound();
		}
	}
}