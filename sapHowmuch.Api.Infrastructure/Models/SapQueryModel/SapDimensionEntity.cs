namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapDimensionEntity : DocumentTypeEntity
	{
		public override int Id { get { return DimCode; } }

		/// <summary>
		/// Dimension Code
		/// </summary>
		public int DimCode { get; set; }

		/// <summary>
		/// Dimension Name
		/// </summary>
		public string DimName { get; set; }

		/// <summary>
		/// Activated? [Y/N]
		/// </summary>
		public bool DimActive { get; set; }

		/// <summary>
		/// Dimension Description
		/// </summary>
		public string DimDescription { get; set; }
	}
}