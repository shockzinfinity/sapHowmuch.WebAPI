namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapEmployeePositionEntity : DocumentTypeEntity
	{
		public override int Id { get { return PosID; } }

		/// <summary>
		/// 직위코드
		/// </summary>
		public int PosID { get; set; }

		/// <summary>
		/// 직위명
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 직위설명
		/// </summary>
		public string Descriptio { get; set; }

		/// <summary>
		/// 사용여부(기본값N)
		/// </summary>
		public string LocFields { get; set; }
	}
}