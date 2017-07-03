namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapBusinessPartnerEntity : MasterTypeEntity
	{
		public override string Code { get { return CardCode; } }

		/// <summary>
		/// BP 코드
		/// </summary>
		public string CardCode { get; set; }

		/// <summary>
		/// BP 명
		/// </summary>
		public string CardName { get; set; }

		/// <summary>
		/// BP 타입
		/// </summary>
		public string CardType { get; set; }
	}
}