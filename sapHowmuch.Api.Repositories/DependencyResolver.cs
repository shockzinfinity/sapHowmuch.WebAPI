using Autofac;
using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.Models;
using System.ComponentModel.Composition;

namespace sapHowmuch.Api.Repositories
{
	[Export(typeof(IComponent))]
	public class DependencyResolver : IComponent
	{
		private const string DbContextName = "ApiDbContext";
		private const string SapContextName = "SapDbContext";

		#region IComponent implementation

		public void Setup(IRegisterComponent registerComponent)
		{
			registerComponent.Builder.RegisterType<DbContextFactory<ApiDbContext>>()
				.Named<IDbContextFactory>(DbContextName)
				.As<IDbContextFactory>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.RegisterType<DbContextFactory<SapDbContext>>()
				.Named<IDbContextFactory>(SapContextName)
				.As<IDbContextFactory>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.Register(p => new UnitOfWorkManager(p.ResolveNamed<IDbContextFactory>(DbContextName)))
				.As<IUnitOfWorkManager>()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			//registerComponent.Builder.RegisterType<BaseRepository<EventStream>>()
			//	.AsImplementedInterfaces()
			//	.PropertiesAutowired()
			//	.InstancePerLifetimeScope();

			registerComponent.Builder.Register(p => new BaseRepository<EventStream>(p.ResolveNamed<IDbContextFactory>(DbContextName)))
				.AsImplementedInterfaces()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();

			registerComponent.Builder.Register(p => new SapQueryRepository(p.ResolveNamed<IDbContextFactory>(SapContextName)))
				.AsImplementedInterfaces()
				.PropertiesAutowired()
				.InstancePerLifetimeScope();
		}

		#endregion IComponent implementation
	}
}