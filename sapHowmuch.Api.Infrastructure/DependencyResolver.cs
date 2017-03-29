using Autofac;
using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.EventHandlers;
using sapHowmuch.Api.Infrastructure.RequestBuilders;
using sapHowmuch.Api.Infrastructure.RequestHandlers;
using System.ComponentModel.Composition;

namespace sapHowmuch.Api.Infrastructure
{
	[Export(typeof(IComponent))]
	public class DependencyResolver : IComponent
	{
		#region IComponent implementation

		public void Setup(IRegisterComponent registerComponent)
		{
			registerComponent.Builder.RegisterType<EventStreamCreatedEventHandler>()
				.As<IEventHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<EventStreamCreateRequestHandler>()
				.As<IRequestHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<EmployeeInfoCreateRequestBuilder>()
				.As<IRequestBuilder>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<EmployeeInfoCreateRequestHandler>()
				.As<IRequestHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<EmployeeInfoCreatedEventHandler>()
				.As<IEventHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();
		}

		#endregion IComponent implementation
	}
}