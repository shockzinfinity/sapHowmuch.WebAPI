using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Infrastructure;
using sapHowmuch.Api.Common.Extensions;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Web.Providers
{
	public class SapHowmuchRefreshTokenProvider : IAuthenticationTokenProvider
	{
		public void Create(AuthenticationTokenCreateContext context)
		{
			throw new NotImplementedException();
		}

		public async Task CreateAsync(AuthenticationTokenCreateContext context)
		{
			var clientId = context.Ticket.Properties.Dictionary[Startup.ClientPropertyName];

			if (string.IsNullOrWhiteSpace(clientId))
			{
				return;
			}

			var refreshTokenId = Guid.NewGuid().ToString("N");
			var manager = context.OwinContext.Get<RefreshTokenManager>();
			var lifeTime = context.OwinContext.Get<string>(Startup.ClientRefreshTokenLifeTimePropertyName);

			var token = new RefreshToken
			{
				Id = refreshTokenId.GetHash(),
				ClientId = clientId,
				Subject = context.Ticket.Identity.Name,
				IssuedUtc = DateTime.UtcNow,
				ExpiresUtc = DateTime.UtcNow.AddSeconds(Convert.ToDouble(lifeTime))
			};

			context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
			context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

			token.ProtectedTicket = context.SerializeTicket();

			var result = await manager.AddRefreshToken(token);

			// TODO: refresh token 의 보안성을 위해 여기서 해쉬화해서 넘겨줄 필요가 있음.
			// 또한, 보안적으로 고려할 수 있는 것이
			// 해당 클라이언트(audience)의 MachineKey 를 지정하고
			// 그 머신키를 기반으로 해쉬화할 수도 있음.
			// 하지만 그 전에 보장되어야 하는 것은 머신키가 복제불가능하고 유일해야 한다는 조건이 붙는다.
			// 다른 방법으로는 클라이언트 인증서를 가지고 암호화 하는 방법일 수 있다. (2017-07-05)
			// 서버상에서 토큰을 받아가는 클라이언트(혹은 유저)에 대한 클라이언트 인증서를 전달받고
			// 해당 클라이언트 인증서를 획득해서 refresh token 에 대한 암호화를 처리
			// 암호화된 refresh token id 를 클라이언트에 전달한 후에
			// 추후 client의 인증서를 기반으로 decryption 한 이후에 refresh token 을 생성한다.
			// 보안적으로 좀더 다른 방식도 연구할 필요가 있다.
			if (result)
				context.SetToken(refreshTokenId);
		}

		public void Receive(AuthenticationTokenReceiveContext context)
		{
			throw new NotImplementedException();
		}

		public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
		{
			// TODO: refresh token 요청을 받을 경우, 보안 이슈적인 측면을 좀 더 고려해야한다.
			// 매직키가 될 가능성이 존재함.
			// 여기서 클라이언트 시크릿 검증 ?
			var allowedOrigin = context.OwinContext.Get<string>(Startup.ClientAllowedOriginPropertyName);
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

			// TODO: deserializing
			string hashedTokenId = context.Token.GetHash();

			var refreshToken = await context.OwinContext.Get<RefreshTokenManager>().FindRefreshToken(hashedTokenId);

			if (refreshToken != null)
			{
				context.DeserializeTicket(refreshToken.ProtectedTicket);

				var result = await context.OwinContext.Get<RefreshTokenManager>().RemoveRefreshToken(hashedTokenId);
			}
		}
	}
}