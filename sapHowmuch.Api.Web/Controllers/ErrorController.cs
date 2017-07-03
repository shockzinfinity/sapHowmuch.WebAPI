using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// This controller is handled 404 error
	/// </summary>
	[ApiExplorerSettings(IgnoreApi = true)] // hide specific controller in swagger controller list
	public class ErrorController : ApiController
	{
		/// <summary>
		/// Handle 404 (NotFound)
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		[HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions]
		public IHttpActionResult NotFound(string path)
		{
			Elmah.ErrorSignal.FromCurrentContext().Raise(new HttpException(404, "404 Not found: /" + path));

			return NotFound();
		}
	}
}