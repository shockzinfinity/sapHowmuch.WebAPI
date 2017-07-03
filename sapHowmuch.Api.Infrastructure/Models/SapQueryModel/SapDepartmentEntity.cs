namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapDepartmentEntity : DocumentTypeEntity
	{
		public override int Id { get { return Code; } }

		/// <summary>
		/// 부서코드
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// 부서명
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 부서설명
		/// </summary>
		public string Remarks { get; set; }

		/// <summary>
		/// 상위부서코드
		/// </summary>
		public string Father { get; set; }
	}
}