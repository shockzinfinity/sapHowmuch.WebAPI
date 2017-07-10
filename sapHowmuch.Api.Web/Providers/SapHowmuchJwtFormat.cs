using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Thinktecture.IdentityModel.Tokens;

namespace sapHowmuch.Api.Web.Providers
{
	public class SapHowmuchJwtFormat : ISecureDataFormat<AuthenticationTicket>
	{
		private readonly string _issuer = string.Empty;
		private List<Client> _allowedAudiences = new List<Client>();

		public SapHowmuchJwtFormat(string issuer)
		{
			_issuer = issuer;
		}

		public string Protect(AuthenticationTicket data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			string audienceId = data.Properties.Dictionary[Startup.ClientPropertyName];
			var client = HttpContext.Current.GetOwinContext().Get<RefreshTokenManager>().FindClient(audienceId);
			string symmetricKeyBase64 = client.Secret;

			var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyBase64);
			var signingCredentials = new HmacSigningCredentials(keyByteArray);

			var issued = data.Properties.IssuedUtc;
			var expires = data.Properties.ExpiresUtc;
			var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);

			var handler = new JwtSecurityTokenHandler();
			var jwt = handler.WriteToken(token);

			return jwt;
		}

		public AuthenticationTicket Unprotect(string protectedText)
		{
			Func<IEnumerable<Client>> allowedAudience = () => HttpContext.Current.GetOwinContext().Get<RefreshTokenManager>().GetAllowedClients();

			var handler = new JwtSecurityTokenHandler();

			TokenValidationParameters validationParams = new TokenValidationParameters
			{
				AudienceValidator = (audiences, securityToken, validationParam) =>
				{
					if (_allowedAudiences.Select(c => c.Id).Intersect(audiences).Count() > 0)
					{
						_allowedAudiences.Clear();
						_allowedAudiences = allowedAudience().ToList();
					}

					return allowedAudience().Select(c => c.Id).Intersect(audiences).Count() > 0;
				},
				ValidIssuer = _issuer,
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningTokens = new SecurityTokensTokens(_issuer) { Audiences = allowedAudience },
				ClockSkew = TimeSpan.Zero // default value of this property is 5, it adds 5 mins to expiration time.
			};

			SecurityToken token = null;

			try
			{
				var result = handler.ValidateToken(protectedText, validationParams, out token);
				ClaimsIdentity claimsIdentity = new ClaimsIdentity(result.Claims, "JWT");

				//var props = new AuthenticationProperties
				//{
				//	AllowRefresh = true,
				//	IsPersistent = true
				//};

				//var ticket = new AuthenticationTicket(claimsIdentity, props);
				var ticket = new AuthenticationTicket(claimsIdentity, null);

				return ticket;
			}
			catch
			{
				throw;
			}
		}
	}
}