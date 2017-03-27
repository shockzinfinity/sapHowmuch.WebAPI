using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using sapHowmuch.Api.Web.Infrastructure;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Web.Providers
{
	public class SapHowmuchOAuthProvider : OAuthAuthorizationServerProvider
	{
		// NOTE: 클라이언트 측에 대한 검증 부분에 대한 내용 정리
		// 1. access_token, refres_token 에 대해서 쿠키에 구울 것인가, auth 쿠키에 구울 것인가? - 토큰정보에 대한 암호화에 대한 부분
		// 2. client_secret 에 대한 공유 - Javascript client 의 경우, 따로 저장하고 있지 못함.(노출이 쉬우므로...)
		// 3. refresh 정책 결정 - exp 전에 refresh 할 것인가? 아니면 요청마다 refresh 할 것인가? 그도 아니면 exp 남은 시간을 보고 refresh 할 것인가?
		// 4. refresh token 자체가 golden ticket 이 될 수 있으므로, 이 부분에 대한 보관 방법에 대한 고민이 필요하다. - 메모리에 휘발성? 아니면 auth_cookie
		// 5. 보관하고 있더라도, 암호화해서 해쉬화해서 가지고 있을 것인가?
		// 6. 한 클라이언트만 로그인 가능하도록 하기 위해서는 클라이언트 머신키를 보유하는 것도 한가지 방법이다. - 하지만, 이 또한 fraud 가능성이 있다.

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			string clientId = string.Empty;
			string clientSecret = string.Empty;

			if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
			{
				context.TryGetFormCredentials(out clientId, out clientSecret);
			}

			if (string.IsNullOrWhiteSpace(context.ClientId))
			{
				context.SetError("invalid_clientId", "ClientId should be sent.");

				return Task.FromResult<object>(null);
			}

			Client client = context.OwinContext.Get<RefreshTokenManager>().FindClient(context.ClientId);

			if (client == null)
			{
				context.SetError("invalid_clientId", $"Client '{context.ClientId}' is not registered in the system.");

				return Task.FromResult<object>(null);
			}

			if (client.ApplicationType == ApplicationType.NativeConfidential) // Javascript client 가 아닐 경우, client secret 체크
			{
				if (string.IsNullOrWhiteSpace(clientSecret))
				{
					context.SetError("invalid_clientId", "Client secret should be sent.");

					return Task.FromResult<object>(null);
				}
				else
				{
					// NOTE: 암호화된 상태로 넘기도록 요청할 경우 이 부분의 로직을 변경
					if (clientSecret != client.Secret)
					{
						context.SetError("invalid_clientId", "Client secret is invalid.");

						return Task.FromResult<object>(null);
					}
				}
			}

			if (!client.Active)
			{
				context.SetError("invalid_clientId", "Client is inactive.");

				return Task.FromResult<object>(null);
			}

			context.OwinContext.Set(Startup.ClientAllowedOriginPropertyName, client.AllowedOrigin);
			context.OwinContext.Set(Startup.ClientRefreshTokenLifeTimePropertyName, client.RefreshTokenLifeTime.ToString());

			context.Validated();

			return Task.FromResult<object>(null);
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			var allowedOrigin = context.OwinContext.Get<string>(Startup.ClientAllowedOriginPropertyName);

			if (string.IsNullOrWhiteSpace(allowedOrigin))
			{
				allowedOrigin = "*"; // NOTE: CORS 관련 정책 변경 시 수정
			}

			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

			var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
			ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

			if (user == null)
			{
				context.SetError("invalid_grant", "The username or password is incorrect.");

				return;
			}

			if (!user.EmailConfirmed)
			{
				context.SetError("invalid_grant", "User did not confirm email.");

				return;
			}

			// NOTE: user locking 정책 변경 시 로직 추가

			ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

			// 확장클레임 추가 부분
			oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
			oAuthIdentity.AddClaim(new Claim("sub", context.UserName));
			// NOTE: Role 추가 여부 결정

			var props = new AuthenticationProperties(new Dictionary<string, string>
			{
				{ Startup.ClientPropertyName, (context.ClientId == null) ? string.Empty:context.ClientId  },
				//{ "userName", context.UserName }
			});

			var ticket = new AuthenticationTicket(oAuthIdentity, props);

			context.Validated(ticket);
		}

		//public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		//{
		//	return base.TokenEndpoint(context);
		//}

		public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
		{
			// grant_type = refresh_token 체크
			var originalClient = context.Ticket.Properties.Dictionary[Startup.ClientPropertyName];
			var currentClient = context.ClientId;

			if (originalClient != currentClient)
			{
				context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");

				return Task.FromResult<object>(null);
			}

			// change auth ticket for refresh token request
			var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
			// NOTE: 여기서 추가 클레임 로직을 설정해서 리턴할 수 있음.
			// ex) API 측에서 일괄적으로 클라이언트들에게 적용해야 되는 클레임 변경 사항들에 대해서
			// db context 등에서 검색해서 클레임을 추가하거나,
			// 리프레시 토큰 아이디에 대해 특정 클레임을 설정하는 등의 작업

			var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
			context.Validated(newTicket);

			return Task.FromResult<object>(null);
		}
	}
}