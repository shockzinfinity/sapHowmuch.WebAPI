﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using sapHowmuch.Api.Common;
using sapHowmuch.Api.Web.Controllers;
using System.Reflection;
using System.Web;

namespace sapHowmuch.Api.Web
{
	public static class DependencyConfig
	{
		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			ComponentLoader.LoadContainer(builder, ".\\bin", "todocqrs.Infrastructure.dll");
			ComponentLoader.LoadContainer(builder, ".\\bin", "todocqrs.EventProcessors.dll");
			ComponentLoader.LoadContainer(builder, ".\\bin", "todocqrs.Repositories.dll");
			ComponentLoader.LoadContainer(builder, ".\\bin", "todocqrs.Services.dll");

			builder.RegisterModule<AutofacWebTypesModule>();

			// for mvc5
			builder.RegisterControllers(typeof(Startup).Assembly)
				.OnActivating(e =>
				{
					var httpContext = e.Context.Resolve<HttpContextBase>();
					// TODO: controller context injection
					((BaseMvcController)e.Instance).SetHttpContext(httpContext);
				})
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			// for web api
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			var container = builder.Build();

			return container;
		}
	}
}