using Microsoft.AspNet.Identity.Owin;
using sapHowmuch.Api.Web.Infrastructure;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	public class BaseApiController : ApiController
	{
		protected ApplicationUserManager AppUserManager
		{
			get { return Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
		}

		protected ApplicationRoleManager AppRoleManager
		{
			get { return Request.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
		}

		protected RefreshTokenManager AppRefreshTokenManager
		{
			get { return Request.GetOwinContext().GetUserManager<RefreshTokenManager>(); }
		}
	}
}