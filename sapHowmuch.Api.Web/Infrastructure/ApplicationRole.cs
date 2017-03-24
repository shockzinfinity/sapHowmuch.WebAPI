using Microsoft.AspNet.Identity.EntityFramework;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class ApplicationRole : IdentityRole
	{
		public ApplicationRole()
		{
		}

		public ApplicationRole(string name) : base(name)
		{
		}

		public string Description { get; set; }
	}
}