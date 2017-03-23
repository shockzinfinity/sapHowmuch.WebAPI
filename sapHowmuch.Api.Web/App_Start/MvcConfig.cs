using Autofac;
using Autofac.Integration.Mvc;
using Owin;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace sapHowmuch.Api.Web
{
	public static class MvcConfig
	{
		public static void Configure(IAppBuilder appBuilder, IContainer container)
		{
			if (appBuilder == null)
			{
				throw new ArgumentNullException(nameof(appBuilder));
			}

			if (container == null)
			{
				throw new ArgumentNullException(nameof(container));
			}

			var resolver = new AutofacDependencyResolver(container);
			DependencyResolver.SetResolver(resolver);

			RegisterRoutes(RouteTable.Routes);
			RegisterAreas();
			RegisterFilters(GlobalFilters.Filters);
		}

		private static void RegisterFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		private static void RegisterAreas()
		{
			AreaRegistration.RegisterAllAreas();
		}

		private static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapMvcAttributeRoutes();
		}
	}
}