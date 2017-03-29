using sapHowmuch.Api.Repositories.SapEntities;
using System.Data.Entity;

namespace sapHowmuch.Api.Repositories
{
	public partial class SapDbContext : DbContext
	{
		public SapDbContext() : base("name=SapDbContext")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}

		public virtual DbSet<OACT> OACTs { get; set; }
		public virtual DbSet<OHEM> OHEMs { get; set; }
		public virtual DbSet<OCRD> OCRDs { get; set; }
		public virtual DbSet<OCRY> OCRYs { get; set; }
		public virtual DbSet<OHPS> OHPSs { get; set; }
		public virtual DbSet<OHST> OHSTs { get; set; }
		public virtual DbSet<OITM> OITMs { get; set; }
		public virtual DbSet<OPRC> OPRCs { get; set; }
		public virtual DbSet<OUDP> OUDPs { get; set; }
	}
}