using sapHowmuch.Api.Common.Interfaces;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Repositories
{
	public partial class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
	{
		private readonly IDbContextFactory _dbContextFactory;
		private TContext _dbContext;
		private ObjectContext _objectContext;
		private IDbTransaction _transaction;
		private bool _disposed;

		public UnitOfWork(IDbContextFactory contextFactory)
		{
			if (contextFactory == null)
			{
				throw new ArgumentNullException(nameof(contextFactory));
			}

			this._dbContextFactory = contextFactory;
			this._dbContext = this.GetDbContext(this._dbContextFactory);
			this._objectContext = this.GetObjectContext(this._dbContext);
			this.OpenDbConnection();
		}

		#region IUnitOfWork implementation

		public Type DbContextType { get { return typeof(TContext); } }

		public void BeginTransaction()
		{
			this.OpenDbConnection();
			this._transaction = this._objectContext.Connection.BeginTransaction();
		}

		public void Commit()
		{
			if (this._transaction == null)
			{
				return;
			}

			this.SaveChanges();
			this._transaction.Commit();
		}

		public async Task CommitAsync()
		{
			if (this._transaction == null)
			{
				return;
			}

			await this.SaveChangesAsync();
			this._transaction.Commit();
		}

		public void Dispose()
		{
			if (this._disposed)
			{
				return;
			}

			var connectionState = this.GetConnectionState(this._objectContext);
			if (connectionState == ConnectionState.Open)
			{
				this._objectContext.Connection.Close();
			}

			//this.Context.Dispose();
			//this._dbContextFactory.Dispose();

			this._disposed = true;
		}

		public void Rollback()
		{
			if (this._transaction == null)
			{
				return;
			}

			this._transaction.Rollback();

			foreach (var entry in this.Context.ChangeTracker.Entries())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;

					case EntityState.Deleted:
						// TODO: 근본적인 해결책이 필요함.
						// EF 7 의 IRelationalTransaction 을 쓰던가, 수동으로 직접 구현하던가
						// 기본적으로 FK 없이 가는 것이 목표이므로, 당장의 고려대상은 아니다.
						// Note - problem with deleted entities:
						// When an entity is deleted its relationships to other entities are severed.
						// This includes setting FKs to null for nullable FKs or marking the FKs as conceptually null (don't ask!)
						// if the FK property is not nullable. You'll need to reset the FK property values to
						// the values that they had previously in order to re-form the relationships.
						// This may include FK properties in other entities for relationships where the
						// deleted entity is the principal of the relationship–e.g. has the PK
						// rather than the FK. I know this is a pain–it would be great if it could be made easier in the future, but for now it is what it is.
						entry.State = EntityState.Unchanged;
						break;

					case EntityState.Modified:
						entry.State = EntityState.Unchanged;
						break;
				}
			}
		}

		public void SaveChanges()
		{
			this.Context.SaveChanges();
		}

		public async Task SaveChangesAsync()
		{
			await this.Context.SaveChangesAsync();
		}

		#endregion IUnitOfWork implementation

		private TContext Context
		{
			get
			{
				if (this._dbContext != null)
				{
					return this._dbContext;
				}

				this._dbContext = this.GetDbContext(this._dbContextFactory);
				this._objectContext = this.GetObjectContext(this._dbContext);
				this.OpenDbConnection();

				return this._dbContext;
			}
		}

		private TContext GetDbContext(IDbContextFactory contextFactory)
		{
			if (contextFactory == null)
			{
				throw new ArgumentNullException(nameof(contextFactory));
			}
			var dbContext = contextFactory.Context;
			var context = (TContext)Convert.ChangeType(dbContext, typeof(TContext));

			return context;
		}

		private ObjectContext GetObjectContext(TContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			var contextAdapter = (IObjectContextAdapter)context;
			var objectContext = contextAdapter.ObjectContext;

			return objectContext;
		}

		private void OpenDbConnection()
		{
			if (this._objectContext.Connection.State == ConnectionState.Open)
			{
				return;
			}

			this._objectContext.Connection.Open();
		}

		private ConnectionState GetConnectionState(ObjectContext context)
		{
			if (context == null)
			{
				return ConnectionState.Closed;
			}

			if (context.Connection == null)
			{
				return ConnectionState.Closed;
			}

			return context.Connection.State;
		}
	}
}