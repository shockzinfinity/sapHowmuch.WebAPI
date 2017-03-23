using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace sapHowmuch.Api.Web
{
	public static class WebApiConfig
	{
		public static void Configure(IAppBuilder appBuilder, IContainer container)
		{
			// TODO: autofac dependency resolver
			var config = new HttpConfiguration()
			{
				DependencyResolver = new AutofacWebApiDependencyResolver(container)
			};

			// Routes
			config.MapHttpAttributeRoutes();

			// Formatters
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			config.Formatters.JsonFormatter.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

			appBuilder.UseWebApi(config);
		}
	}
}