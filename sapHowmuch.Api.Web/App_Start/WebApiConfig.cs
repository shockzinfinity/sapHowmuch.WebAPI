using Autofac;
using Autofac.Integration.WebApi;
using Elmah.Contrib.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace sapHowmuch.Api.Web
{
	public static class WebApiConfig
	{
		public static void Configure(IAppBuilder appBuilder, IContainer container)
		{
			var config = new HttpConfiguration()
			{
				DependencyResolver = new AutofacWebApiDependencyResolver(container)
			};

			config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());

			// Routes
			config.MapHttpAttributeRoutes();

			config.Routes.IgnoreRoute("axd", "{resource}.axd/{*pathInfo}");

			config.Routes.MapHttpRoute(
				name: "NotFound",
				routeTemplate: "{*path}",
				defaults: new { controller = "Error", action = "NotFound" }
				);

			// Formatters
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			config.Formatters.JsonFormatter.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

			config.EnsureInitialized();

			appBuilder.UseWebApi(config);
		}
	}
}