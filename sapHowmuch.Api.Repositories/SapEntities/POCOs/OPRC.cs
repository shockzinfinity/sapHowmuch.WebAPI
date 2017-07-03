using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("OPRC")]
	public partial class OPRC
	{
		[Key]
		[StringLength(8)]
		public string PrcCode { get; set; }

		[StringLength(30)]
		public string PrcName { get; set; }

		[StringLength(4)]
		public string GrpCode { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Balance { get; set; }

		[StringLength(1)]
		public string Locked { get; set; }

		[StringLength(1)]
		public string DataSource { get; set; }

		public short? UserSign { get; set; }

		public short? DimCode { get; set; }

		[StringLength(8)]
		public string CCTypeCode { get; set; }

		public DateTime? ValidFrom { get; set; }

		public DateTime? ValidTo { get; set; }

		[StringLength(1)]
		public string Active { get; set; }

		public int? LogInstanc { get; set; }

		public short? UserSign2 { get; set; }

		public DateTime? UpdateDate { get; set; }
	}
}