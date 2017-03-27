using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class SapHowmuchUsernameValidator : UserValidator<ApplicationUser>
	{
		private List<string> _allowedEmailDomains = new List<string> { "naver.com", "gmail.com", "nate.com", "iquest.co.kr", "hotmail.com" };

		public SapHowmuchUsernameValidator(UserManager<ApplicationUser, string> manager) : base(manager)
		{
		}

		public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
		{
			IdentityResult result = await base.ValidateAsync(user);

			var emailDomain = user.Email.Split('@')[1];

			if (!_allowedEmailDomains.Contains(emailDomain.ToLower()))
			{
				var errors = result.Errors.ToList();
				errors.Add($"Email domain '{emailDomain}' is not allowed.");

				result = new IdentityResult(errors);
			}

			return result;
		}
	}
}