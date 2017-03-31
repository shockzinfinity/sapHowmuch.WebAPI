namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapBudgetDepartmentEntity : MasterTypeEntity
	{
		public override string Code { get { return PrcCode; } }

		/// <summary>
		/// 예산부서 코드
		/// </summary>
		public string PrcCode { get; set; }

		/// <summary>
		/// 예산부서 명
		/// </summary>
		public string PrcName { get; set; }
	}
}