namespace sapHowmuch.Api.Infrastructure.Models
{
	/// <summary>
	/// This provides interfaces to the classes inheriting the <see cref="MasterTypeEntity" />, <see cref="DocumentTypeEntity"/> classes.
	/// </summary>
	/// <typeparam name="TKey">primary key type</typeparam>
	public interface ISapEntity<in TKey>
	{
	}
}