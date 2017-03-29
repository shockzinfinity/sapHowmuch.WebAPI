namespace sapHowmuch.Api.Infrastructure.Models
{
	public class SapItemEntity : MasterTypeEntity
	{
		public override string Code { get { return ItemCode; } }
		public string ItemCode { get; set; }
		public string ItemName { get; set; }
		public string ItemGroup { get; set; }
	}
}