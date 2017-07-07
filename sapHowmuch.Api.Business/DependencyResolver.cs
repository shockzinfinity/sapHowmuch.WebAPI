using Autofac;
using sapHowmuch.Api.Business.EventHandlers;
using sapHowmuch.Api.Business.RequestBuilders;
using sapHowmuch.Api.Business.RequestHandlers;
using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.EventHandlers;
using sapHowmuch.Api.Infrastructure.RequestBuilders;
using sapHowmuch.Api.Infrastructure.RequestHandlers;
using System.ComponentModel.Composition;

namespace sapHowmuch.Api.Business
{
	[Export(typeof(IComponent))]
	public class DependencyResolver : IComponent
	{
		public void Setup(IRegisterComponent registerComponent)
		{
			registerComponent.Builder.RegisterInstance(new SapCompany())
				.AsSelf()
				.PropertiesAutowired();

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

			registerComponent.Builder.RegisterType<CountryCreateRequestBuilder>()
				.As<IRequestBuilder>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<CountryCreateRequestHandler>()
				.As<IRequestHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<CountryCreatedEventHandler>()
				.As<IEventHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<JournalVoucherCreateRequestBuilder>()
				.As<IRequestBuilder>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<JournalVoucherCreateRequestHandler>()
				.As<IRequestHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<JournalVoucherCreatedEventHandler>()
				.As<IEventHandler>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();
		}
	}
}