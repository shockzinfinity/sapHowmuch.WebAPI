using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
		{
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			var appDbContext = context.Get<ApplicationDbContext>();
			var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(appDbContext));

			appUserManager.UserValidator = new SapHowmuchUsernameValidator(appUserManager)
			{
				AllowOnlyAlphanumericUserNames = true,
				RequireUniqueEmail = true
			};

			appUserManager.PasswordValidator = new SapHowmuchPasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false
			};

			return appUserManager;
		}
	}
}