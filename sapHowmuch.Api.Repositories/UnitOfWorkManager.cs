using sapHowmuch.Api.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace sapHowmuch.Api.Repositories
{
	public class UnitOfWorkManager : IUnitOfWorkManager
	{
		private IEnumerable<IDbContextFactory> _contextFactories;
		private bool _disposed;

		public UnitOfWorkManager(params IDbContextFactory[] contextFactories)
		{
			if (contextFactories == null)
			{
				throw new ArgumentNullException(nameof(contextFactories));
			}
			if (contextFactories.Length == 0)
			{
				throw new InvalidOperationException("No parameter provided");
			}

			this._contextFactories = contextFactories;
		}

		#region IUnitOfWorkManager implementation

		public IUnitOfWork CreateInstance<TContext>() where TContext : DbContext
		{
			var contextFactory = this._contextFactories.SingleOrDefault(p => p.DbContextType == typeof(TContext));

			if (contextFactory == null)
			{
				throw new InvalidOperationException("No DbContext found");
			}

			return new UnitOfWork<TContext>(contextFactory);
		}

		public void Dispose()
		{
			if (this._disposed)
			{
				return;
			}

			//foreach (var factory in _contextFactories)
			//{
			//	factory.Dispose();
			//}

			this._disposed = true;
		}

		#endregion IUnitOfWorkManager implementation
	}
}