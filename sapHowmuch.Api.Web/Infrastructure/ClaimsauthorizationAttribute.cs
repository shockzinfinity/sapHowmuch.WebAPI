﻿using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace sapHowmuch.Api.Web.Infrastructure
{
	/// <summary>
	/// This represents authorization by claims
	/// </summary>
	public class ClaimsauthorizationAttribute : AuthorizationFilterAttribute
	{
		/// <summary>
		/// Claim type
		/// </summary>
		public string ClaimType { get; set; }

		/// <summary>
		/// Claim Value
		/// </summary>
		public string ClaimValue { get; set; }

		/// <summary>
		/// Authorization check
		/// </summary>
		/// <param name="actionContext"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
		{
			var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

			if (!principal.Identity.IsAuthenticated)
			{
				actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

				return Task.FromResult<object>(null);
			}

			if (!string.IsNullOrWhiteSpace(ClaimType) && !string.IsNullOrWhiteSpace(ClaimValue))
			{
				if (!(principal.HasClaim(c => c.Type == ClaimType && c.Value == ClaimValue)))
				{
					actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

					return Task.FromResult<object>(null);
				}
			}

			return Task.FromResult<object>(null);
		}
	}
}