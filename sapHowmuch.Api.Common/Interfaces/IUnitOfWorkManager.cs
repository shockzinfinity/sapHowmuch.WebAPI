using System;
using System.Data.Entity;

namespace sapHowmuch.Api.Common.Interfaces
{
	/// <summary>
	/// <c>UnitOfWorkManager</c> class 에 대한 인터페이스
	/// </summary>
	public interface IUnitOfWorkManager : IDisposable
	{
		/// <summary>
		/// Creates a new <c>UnitOfWork</c> instance.
		/// </summary>
		/// <typeparam name="TContext"><c>DbContext</c> type instance.</typeparam>
		/// <returns>Returns a new <c>UnitOfWork</c> instance.</returns>
		IUnitOfWork CreateInstance<TContext>() where TContext : DbContext;
	}
}