namespace sapHowmuch.Api.Repositories.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class initial : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.EventStream",
				c => new
				{
					EventId = c.Guid(nullable: false),
					StreamId = c.Guid(nullable: false),
					Sequence = c.Long(),
					EventName = c.String(nullable: false, maxLength: 256),
					EventType = c.String(nullable: false, maxLength: 256),
					EventBody = c.String(nullable: false),
					DateOccurred = c.DateTime(nullable: false),
					DateRecorded = c.DateTime(nullable: false),
					DateProjected = c.DateTime(nullable: false),
					ProjectedBy = c.Guid(nullable: false),
				})
				.PrimaryKey(t => t.EventId);
		}

		public override void Down()
		{
			DropTable("dbo.EventStream");
		}
	}
}