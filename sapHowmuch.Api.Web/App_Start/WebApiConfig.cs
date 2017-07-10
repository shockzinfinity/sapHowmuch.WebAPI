using Autofac;
using Autofac.Integration.WebApi;
using Elmah.Contrib.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using sapHowmuch.Api.Web.Infrastructure;
using System.Linq;
using System.Reflection;
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

			// for swagger
			config.ConfigSwagger(); // NOTE: 라우팅 순서 중요

			// for elmah
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

		private static string GetControllerName()
		{
			var controllerName = Assembly.GetCallingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(ApiController)) && x.FullName.StartsWith(MethodBase.GetCurrentMethod().DeclaringType.Namespace + ".Controllers")).ToList().Select(x => x.Name.Replace("Controller", ""));

			return string.Join("|", controllerName);
		}
	}
}