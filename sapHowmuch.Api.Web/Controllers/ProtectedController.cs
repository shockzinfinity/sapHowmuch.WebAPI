using System.Linq;
using System.Security.Claims;
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
		/// GET method with Authentication and Authorization
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			var identity = User.Identity as ClaimsIdentity;

			return Ok(identity.Claims.Select(c => new
			{
				Type = c.Type,
				Value = c.Value
			}));
		}
	}
}