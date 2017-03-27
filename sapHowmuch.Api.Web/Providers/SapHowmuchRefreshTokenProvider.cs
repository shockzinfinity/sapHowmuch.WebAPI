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

			var refreshTokenId = Guid.NewGuid().ToString("n");
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
			if (result)
				context.SetToken(refreshTokenId);
		}

		public void Receive(AuthenticationTokenReceiveContext context)
		{
			throw new NotImplementedException();
		}

		public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
		{
			var allowedOrigin = context.OwinContext.Get<string>(Startup.ClientAllowedOriginPropertyName);
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
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