namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapCostCenterEntity : MasterTypeEntity
	{
		public override string Code { get { return PrcCode; } }

		/// <summary>
		/// 코스트센터 코드
		/// </summary>
		public string PrcCode { get; set; }

		/// <summary>
		/// 코스트센터 명
		/// </summary>
		public string PrcName { get; set; }
	}
}