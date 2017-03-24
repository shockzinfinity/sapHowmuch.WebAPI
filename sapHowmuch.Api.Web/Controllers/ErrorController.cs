using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace sapHowmuch.Api.Web.Controllers
{
	[ApiExplorerSettings(IgnoreApi = true)] // hide specific controller in swagger controller list
	public class ErrorController : ApiController
	{
		[HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions]
		public IHttpActionResult NotFound(string path)
		{
			Elmah.ErrorSignal.FromCurrentContext().Raise(new HttpException(404, "404 Not found: /" + path));

			return NotFound();
		}
	}
}