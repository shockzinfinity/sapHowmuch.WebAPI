using sapHowmuch.Api.Infrastructure.Models;
using System.Data.Entity;

namespace sapHowmuch.Api.Repositories
{
	public partial class ApiDbContext : DbContext
	{
		public ApiDbContext() : base("name=WebApiDbContext")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}

		public virtual IDbSet<EventStream> EventStreams { get; set; }
		//public virtual IDbSet<>
	}
}