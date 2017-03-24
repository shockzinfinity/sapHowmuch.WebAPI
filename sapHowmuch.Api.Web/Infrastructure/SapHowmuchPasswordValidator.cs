using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class SapHowmuchPasswordValidator : PasswordValidator
	{
		public override async Task<IdentityResult> ValidateAsync(string password)
		{
			IdentityResult result = await base.ValidateAsync(password);

			if (password.Contains("abcdef") || password.Contains("123456"))
			{
				var errors = result.Errors.ToList();
				errors.Add("Password can not containe sequence of chars");
				result = new IdentityResult(errors);
			}

			return result;
		}
	}
}