using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("OCRY")]
	public partial class OCRY
	{
		[Key]
		[StringLength(3)]
		public string Code { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		public short? AddrFormat { get; set; }

		public short? UserSign { get; set; }

		[StringLength(1)]
		public string IsEC { get; set; }

		[StringLength(3)]
		public string ReportCode { get; set; }

		public short? TaxIdDigts { get; set; }

		public int? BnkCodDgts { get; set; }

		public int? BnkBchDgts { get; set; }

		public int? BnkActDgts { get; set; }

		public int? BnkCtKDgts { get; set; }

		[StringLength(3)]
		public string ValDomAcct { get; set; }

		[StringLength(1)]
		public string ValIban { get; set; }

		[StringLength(1)]
		public string IsBlackLst { get; set; }

		[StringLength(3)]
		public string UICCode { get; set; }

		[StringLength(4)]
		public string CntCodNum { get; set; }

		[StringLength(3)]
		public string Siscomex { get; set; }
	}
}