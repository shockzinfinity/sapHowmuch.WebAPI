using System;
using System.Data.Entity;

namespace sapHowmuch.Api.Common.Interfaces
{
	/// <summary>
	/// <c>DbContextFactory</c> class 에 대한 인터페이스
	/// </summary>
	public interface IDbContextFactory : IDisposable
	{
		/// <summary>
		/// Gets the <c>DbContext</c> instance.
		/// </summary>
		DbContext Context { get; }

		/// <summary>
		/// Gets the type of the <c>DbContext</c> instance.
		/// </summary>
		Type DbContextType { get; }
	}
}