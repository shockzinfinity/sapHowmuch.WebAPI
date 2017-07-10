using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using System.Collections.Generic;
using System.IdentityModel.Tokens;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class SecurityTokensTokens : AbstractAudience<SecurityToken>
	{
		private string _issuer;

		public SecurityTokensTokens(string issuer)
		{
			_issuer = issuer;
		}

		public override IEnumerator<SecurityToken> GetEnumerator()
		{
			foreach (var audience in Audiences())
			{
				foreach (var securityToken in new SymmetricKeyIssuerSecurityTokenProvider(_issuer, TextEncodings.Base64Url.Decode(audience.Secret)).SecurityTokens)
				{
					yield return securityToken;
				}
			}
		}
	}
}