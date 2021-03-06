﻿using System;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Common.Interfaces
{
	/// <summary>
	/// <c>UnitOfWork</c> class 에 대한 인터페이스
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Gets the type of the <c>DbContext</c> instance.
		/// </summary>
		Type DbContextType { get; }

		/// <summary>
		/// Begins database transactions.
		/// </summary>
		void BeginTransaction();

		/// <summary>
		/// Saves database changes.
		/// </summary>
		void SaveChanges();

		/// <summary>
		/// Saves database changes.
		/// </summary>
		/// <returns>
		/// Returns <see cref="Task" />.
		/// </returns>
		Task SaveChangesAsync();

		/// <summary>
		/// Commits database transactions.
		/// </summary>
		void Commit();

		/// <summary>
		/// Commits database transactions.
		/// </summary>
		/// <returns>
		/// Returns <see cref="Task" />.
		/// </returns>
		Task CommitAsync();

		/// <summary>
		/// Rolls back database transactions.
		/// </summary>
		void Rollback();
	}
}