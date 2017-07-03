namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapEmployeeStatusEntity : DocumentTypeEntity
	{
		public override int Id { get { return StatusID; } }

		/// <summary>
		/// 근무상태코드
		/// </summary>
		public int StatusID { get; set; }

		/// <summary>
		/// 근무상태명
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 근무상태설명
		/// </summary>
		public string Descriptio { get; set; }
	}
}