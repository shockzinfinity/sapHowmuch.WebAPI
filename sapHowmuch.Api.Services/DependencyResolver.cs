using Autofac;
using sapHowmuch.Api.Common.Interfaces;
using System.ComponentModel.Composition;

namespace sapHowmuch.Api.Services
{
	[Export(typeof(IComponent))]
	public class DependencyResolver : IComponent
	{
		#region IComponent implementation

		public void Setup(IRegisterComponent registerComponent)
		{
			registerComponent.Builder.RegisterType<EventStreamService>()
				.As<IEventStreamService>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();
		}

		#endregion IComponent implementation
	}
}