using sapHowmuch.Api.Web.Infrastructure;
using System.Net.Http;
using System.Web.Http.Routing;

namespace sapHowmuch.Api.Web.Models
{
	public class ModelFactory
	{
		private UrlHelper _urlHelper;
		private ApplicationUserManager _appUserManager;
		private ApplicationRoleManager _appRoleManager;

		public ModelFactory(HttpRequestMessage request, ApplicationUserManager userManager, ApplicationRoleManager roleManager)
		{
			_urlHelper = new UrlHelper(request);
			_appRoleManager = roleManager;
			_appUserManager = userManager;
		}

		public UserReturnModel Create(ApplicationUser user)
		{
			return new UserReturnModel
			{
				Url = _urlHelper.Link("GetUserById", new { id = user.Id }),
				Id = user.Id,
				UserName = user.UserName,
				FullName = user.ProfileInfo.FullName,
				Email = user.Email,
				EmailConfirmed = user.EmailConfirmed,
				JoinDate = user.ProfileInfo.JoinDate,
				Description = user.ProfileInfo.Description,
				Roles = _appUserManager.GetRolesAsync(user.Id).Result,
				Claims = _appUserManager.GetClaimsAsync(user.Id).Result
			};
		}

		public RoleReturnModel Create(ApplicationRole role)
		{
			return new RoleReturnModel
			{
				Url = _urlHelper.Link("GetRoleById", new { id = role.Id }),
				Id = role.Id,
				Name = role.Name,
				Description = role.Description
			};
		}

		public ClientReturnModel Create(Client client)
		{
			return new ClientReturnModel
			{
				Id = client.Id,
				Name = client.Name,
				Secret = client.Secret,
				Active = client.Active,
				AllowedOrigin = client.AllowedOrigin,
				ApplicationType = client.ApplicationType,
				RefreshTokenLifeTime = client.RefreshTokenLifeTime
			};
		}
	}
}