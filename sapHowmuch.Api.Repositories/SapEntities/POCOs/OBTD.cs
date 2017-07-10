namespace sapHowmuch.Api.Repositories
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("OBTD")]
	public partial class OBTD
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int BatchNum { get; set; }

		[StringLength(1)]
		public string Status { get; set; }

		public short? NumOfTrans { get; set; }

		public DateTime? DateID { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? LocTotal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? FcTotal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SysTotal { get; set; }

		[StringLength(50)]
		public string MemoID { get; set; }

		public short? UserSign { get; set; }

		[StringLength(50)]
		public string Remarks { get; set; }
	}
}