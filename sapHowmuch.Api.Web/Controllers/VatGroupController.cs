using sapHowmuch.Api.Repositories;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// 세금 그룹 컨트롤러
	/// </summary>
	[Authorize]
	[LoggingFilter]
	[RoutePrefix("api/vat")]
	public class VatGroupController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;

		/// <summary>
		/// Initialize a new instance of the <see cref="VatGroupController" /> class
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance</param>
		public VatGroupController(ISapQueryRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			this._repository = repository;
		}

		/// <summary>
		/// Get all vat group code; 세금 그룹 코드 리스트
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(_repository.GetVatGroups().Result);
		}

		/// <summary>
		/// Get a specific vat group; 특정 세금 그룹 코드
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		[Route("{code}")]
		public async Task<IHttpActionResult> Get(string code)
		{
			var vat = await _repository.GetVatGroupBy(code);

			if (vat != null)
			{
				return Ok(vat);
			}

			return NotFound();
		}
	}
}