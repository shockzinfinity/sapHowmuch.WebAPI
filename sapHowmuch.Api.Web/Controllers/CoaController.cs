using sapHowmuch.Api.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// 계정과목 컨트롤러
	/// </summary>
	[Authorize]
	[RoutePrefix("api/coa")]
	public class CoaController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;

		/// <summary>
		/// Initialises a new instance of the <see cref="CoaController" /> class.
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance.</param>
		public CoaController(ISapQueryRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			this._repository = repository;
		}

		/// <summary>
		/// Gets all chart of account; 계정과목코드 리스트 조회
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(_repository.GetChartOfAccount().Result);
		}

		/// <summary>
		/// Gets a specific account; 특정 계정과목 조회
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		[Route("{code}")]
		public async Task<IHttpActionResult> Get(string code)
		{
			var account = await _repository.GetChartOfAccountBy(code);

			if (account != null)
			{
				return Ok(account);
			}

			return NotFound();
		}
	}
}