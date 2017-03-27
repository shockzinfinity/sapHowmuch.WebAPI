using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	[Authorize]
	[RoutePrefix("api/test")]
	public class ProtectedController :BaseApiController
	{
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok();
		}
	}
}