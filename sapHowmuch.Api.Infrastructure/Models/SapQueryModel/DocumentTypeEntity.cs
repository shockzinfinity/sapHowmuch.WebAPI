namespace sapHowmuch.Api.Infrastructure.Models
{
	/// <summary>
	/// This represents the base document type sap entity. This must be inherited.
	/// </summary>
	public abstract class DocumentTypeEntity : ISapEntity<int>
	{
		public abstract int Id { get; }
	}
}