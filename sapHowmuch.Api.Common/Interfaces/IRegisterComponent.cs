using Autofac;

namespace sapHowmuch.Api.Common.Interfaces
{
	/// <summary>
	/// This provides interfaces to the <c>RegisterComponent</c> class.
	/// </summary>
	public interface IRegisterComponent
	{
		/// <summary>
		/// Gets the Autofac <see cref="ContainerBuilder" /> instance.
		/// </summary>
		ContainerBuilder Builder { get; }
	}
}