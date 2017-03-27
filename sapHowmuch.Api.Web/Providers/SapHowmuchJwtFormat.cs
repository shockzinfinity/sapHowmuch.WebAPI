﻿using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.IdentityModel.Tokens;
using System.Web;

namespace sapHowmuch.Api.Web.Providers
{
	public class SapHowmuchJwtFormat : ISecureDataFormat<AuthenticationTicket>
	{
		private readonly string _issuer = string.Empty;

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

			var keyByteArray = new InMemorySymmetricSecurityKey(TextEncodings.Base64Url.Decode(symmetricKeyBase64));
			var signingCredentials = new SigningCredentials(keyByteArray, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

			var issued = data.Properties.IssuedUtc;
			var expires = data.Properties.ExpiresUtc;
			var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);

			var handler = new JwtSecurityTokenHandler();
			var jwt = handler.WriteToken(token);

			return jwt;
		}

		public AuthenticationTicket Unprotect(string protectedText)
		{
			throw new NotImplementedException();

			#region 임시주석처리 2017-03-27

			//// TODO: OAuthBearerAuthentication 을 사용할 경우에 동작? - 체크 필요
			//List<SymmetricSecurityKey> keys = new List<SymmetricSecurityKey>();

			//foreach (var client in Startup.AcceptedClients)
			//{
			//	var base64Key = client.Secret;
			//	keys.Add(new SymmetricSecurityKey(TextEncodings.Base64Url.Decode(base64Key)));
			//}

			//var handler = new JwtSecurityTokenHandler();
			//TokenValidationParameters validationParams = new TokenValidationParameters
			//{
			//	// TODO: client 에 따른 암호 키가 문제가 된다면 이 부분을 수정해야한다.
			//	ValidIssuer = _issuer,
			//	ValidAudiences = Startup.AcceptedClients.Select(c => c.Id),
			//	IssuerSigningKeys = keys,
			//	ValidateLifetime = true,
			//	ClockSkew = TimeSpan.Zero
			//};

			//SecurityToken token = null;

			//try
			//{
			//	var result = handler.ValidateToken(protectedText, validationParams, out token);
			//	ClaimsIdentity claimsIdentity = new ClaimsIdentity(result.Claims, "JWT");

			//	var ticket = new AuthenticationTicket(claimsIdentity, null); // TODO: properties 업데이트?

			//	return ticket;
			//}
			//catch
			//{
			//	throw;
			//}

			#endregion 임시주석처리 2017-03-27
		}
	}
}