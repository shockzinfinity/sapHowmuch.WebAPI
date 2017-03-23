using sapHowmuch.Api.Common.Interfaces;
using System;
using System.Data.Entity;

namespace sapHowmuch.Api.Repositories
{
	public class DbContextFactory<TContext> : IDbContextFactory where TContext : DbContext
	{
		private TContext _dbContext;

		#region IDbContextFactory implementation

		public virtual DbContext Context { get { return this._dbContext ?? Activator.CreateInstance<TContext>(); } }

		public Type DbContextType { get { return typeof(TContext); } }

		private bool _disposed;

		public void Dispose()
		{
			if (this._disposed)
			{
				return;
			}

			this._disposed = true;
		}

		#endregion IDbContextFactory implementation
	}
}