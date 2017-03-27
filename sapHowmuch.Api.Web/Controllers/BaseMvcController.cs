using System;
using System.Web;
using System.Web.Mvc;

namespace sapHowmuch.Api.Web.Controllers
{
	public class BaseMvcController : Controller
	{
		/// <summary>
		/// Gets the <see cref="HttpContextBase" /> instance.
		/// </summary>
		public new HttpContextBase HttpContext { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseMvcController" /> class.
		/// </summary>
		public BaseMvcController()
		{
			this.HttpContext = base.HttpContext;
		}

		/// <summary>
		/// Sets the <see cref="HttpContextBase" /> instance.
		/// </summary>
		/// <param name="httpContext">
		/// The <see cref="HttpContextBase" /> instance.
		/// </param>
		public void SetHttpContext(HttpContextBase httpContext)
		{
			if (httpContext == null)
			{
				throw new ArgumentNullException(nameof(httpContext));
			}

			this.HttpContext = httpContext;
		}
	}
}