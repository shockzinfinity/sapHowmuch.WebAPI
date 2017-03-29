namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapCountryEntity : MasterTypeEntity
	{
		public override string Code { get { return CountryCode; } }

		/// <summary>
		/// 국가코드
		/// </summary>
		public string CountryCode { get; set; }

		/// <summary>
		/// 국가명
		/// </summary>
		public string Name { get; set; }
	}
}