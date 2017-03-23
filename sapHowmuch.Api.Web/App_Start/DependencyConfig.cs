using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web;

namespace sapHowmuch.Api.Web
{
	public static class DependencyConfig
	{
		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			// TODO: components loading

			builder.RegisterModule<AutofacWebTypesModule>();

			// for mvc5
			builder.RegisterControllers(typeof(Startup).Assembly)
				.OnActivating(e =>
				{
					var httpContext = e.Context.Resolve<HttpContextBase>();
					// TODO: controller context injection
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