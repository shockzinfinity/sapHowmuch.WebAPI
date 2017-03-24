using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class ApplicationUser : IdentityUser
	{
		public virtual UserProfile ProfileInfo { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager, string authenticationType)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

			return userIdentity;
		}
	}
}