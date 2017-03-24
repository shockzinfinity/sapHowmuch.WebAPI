using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext() : base("ApplicationDbContext", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public virtual IDbSet<Client> Clients { get; set; }
		public virtual IDbSet<RefreshToken> RefreshTokens { get; set; }
	}
}