using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using sapHowmuch.Api.Web.Infrastructure;
using sapHowmuch.Api.Web.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

[assembly: OwinStartup(typeof(sapHowmuch.Api.Web.Startup))]

namespace sapHowmuch.Api.Web
{
	/// <summary>
	/// This represents the entity for OWIN pipeline startup.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Gets or sets a value indicating whether the mapper definition has been initialised or not.
		/// </summary>

		/// <summary>
		/// Gets OWIN property name of allowedOrigin
		/// </summary>
		public const string ClientAllowedOriginPropertyName = "as:clientAllowedOrigin";

		/// <summary>
		/// Gets OWIN property name of refresh token life time
		/// </summary>
		public const string ClientRefreshTokenLifeTimePropertyName = "as:clientRefreshTokenLifeTime";

		/// <summary>
		/// Gets OWIN property name of audience (client id)
		/// </summary>
		public const string ClientPropertyName = "as:client_id";

		/// <summary>
		/// Gets allowed origin against this web api
		/// </summary>
		public static IEnumerable<Client> AcceptedClients;

		/// <summary>
		/// Configures the OWIN pipeline.
		/// </summary>
		/// <param name="appBuilder">The <see cref="IAppBuilder" /> instance.</param>
		/// <exception cref="ArgumentNullException">Throws when <c>appBuilder</c> is null.</exception>
		public void Configuration(IAppBuilder appBuilder)
		{
			if (appBuilder == null)
			{
				throw new ArgumentNullException(nameof(appBuilder));
			}

			appBuilder.CreatePerOwinContext(ApplicationDbContext.Create);
			appBuilder.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
			appBuilder.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
			appBuilder.CreatePerOwinContext<RefreshTokenManager>(RefreshTokenManager.Create);

			using (var db = new ApplicationDbContext())
			{
				AcceptedClients = db.Clients.ToList();
			}

			ConfigureOAuth(appBuilder);

			var container = DependencyConfig.Configure();

			// for AutoMapper
			Mapper.Initialize(cfg =>
			{
				cfg.AddProfiles(
					"sapHowmuch.Api.Infrastructure",
					"sapHowmuch.Api.EventProcessors",
					"sapHowmuch.Api.Business",
					"sapHowmuch.Api.Repositories",
					"sapHowmuch.Api.Services");
			});

			appBuilder.UseCors(CorsOptions.AllowAll);

			MvcConfig.Configure(appBuilder, container);
			WebApiConfig.Configure(appBuilder, container);
		}

		private void ConfigureOAuth(IAppBuilder app)
		{
			var issuer = ConfigurationManager.AppSettings["tokenIssuer"];

			OAuthAuthorizationServerOptions serverOptions = new OAuthAuthorizationServerOptions
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/auth/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
				Provider = new SapHowmuchOAuthProvider(),
				AccessTokenFormat = new SapHowmuchJwtFormat(issuer),
				RefreshTokenProvider = new SapHowmuchRefreshTokenProvider()
			};

			app.UseOAuthAuthorizationServer(serverOptions);

			// NOTE: 기본적으로 issuer 와 audience 로 체크
			// 고로, 클라이언트에서는 client_id 만을 request 에 실어서 보내도 된다.
			// 전반적인 시나리오는
			// 토큰의 expire 타임은 짧게 가져가고
			// refresh token 을 제공하여, 토큰의 재사용을 유도하는 정책으로 간다.
			var audience = ConfigurationManager.AppSettings["resourceApiClientId"];
			var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["resourceApiClientSecret"]);

			app.UseJwtBearerAuthentication(
				new JwtBearerAuthenticationOptions
				{
					AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
					AllowedAudiences = new[] { audience },
					IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
					{
						new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
					}
				});
		}
	}
}