using AutoMapper;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(sapHowmuch.Api.Web.Startup))]

namespace sapHowmuch.Api.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			if (appBuilder == null)
			{
				throw new ArgumentNullException(nameof(appBuilder));
			}

			var container = DependencyConfig.Configure();

			// TODO: Mapper initialize
			Mapper.Initialize(cfg =>
			{
				//cfg.AddProfiles()
			});

			MvcConfig.Configure(appBuilder, container);
			WebApiConfig.Configure(appBuilder, container);
		}
	}
}