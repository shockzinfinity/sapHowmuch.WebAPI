using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

[assembly: OwinStartup(typeof(sapHowmuch.Api.Web.Startup))]

namespace sapHowmuch.Api.Web
{
	public class Startup
	{
		public static IEnumerable<Client> AcceptedClients;

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

			var issuer = ConfigurationManager.AppSettings["Issuer"];

			// TODO: JWT settings

			var container = DependencyConfig.Configure();

			// for AutoMapper
			Mapper.Initialize(cfg =>
			{
				cfg.AddProfiles(
					"sapHowmuch.Api.Infrastructure",
					"sapHowmuch.Api.EventProcessors",
					"sapHowmuch.Api.Repositories",
					"sapHowmuch.Api.Services");
			});

			MvcConfig.Configure(appBuilder, container);
			WebApiConfig.Configure(appBuilder, container);

			appBuilder.UseCors(CorsOptions.AllowAll);
		}
	}
}