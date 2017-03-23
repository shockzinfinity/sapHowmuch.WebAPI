using Autofac;
using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.EventProcessors;
using System.ComponentModel.Composition;

namespace sapHowmuch.Api.EventProcessors
{
	[Export(typeof(IComponent))]
	public class DependencyResolver : IComponent
	{
		#region IComponent implementation

		public void Setup(IRegisterComponent registerComponent)
		{
			registerComponent.Builder.RegisterType<EventProcessor>()
				.As<IEventProcessor>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();
		}

		#endregion IComponent implementation
	}
}