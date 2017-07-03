namespace sapHowmuch.Api.Infrastructure.Models
{
	/// <summary>
	/// This represents the base master type sap entity. This must be inherited.
	/// </summary>
	public abstract class MasterTypeEntity : ISapEntity<string>
	{
		public abstract string Code { get; }
	}
}