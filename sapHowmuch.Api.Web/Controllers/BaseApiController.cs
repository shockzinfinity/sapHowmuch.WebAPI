using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using sapHowmuch.Api.Web.Infrastructure;
using sapHowmuch.Api.Web.Models;
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

		private ModelFactory _modelFactory;
		protected ModelFactory TheModelFactory
		{
			get { return _modelFactory ?? new ModelFactory(this.Request, this.AppUserManager, this.AppRoleManager); }
		}

		protected IHttpActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return InternalServerError();
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (string error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error);
					}

					if (ModelState.IsValid)
					{
						return BadRequest();
					}

					return BadRequest(ModelState);
				}
			}

			return null;
		}
	}
}