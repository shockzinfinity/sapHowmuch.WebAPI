using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// Test 를 위한 Protected Controller
	/// </summary>
	[Authorize]
	[RoutePrefix("api/test")]
	public class ProtectedController : BaseApiController
	{
		/// <summary>
		/// GET
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok();
		}
	}
}