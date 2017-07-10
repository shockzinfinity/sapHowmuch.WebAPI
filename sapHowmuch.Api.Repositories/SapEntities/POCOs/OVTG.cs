using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("OVTG")]
	public partial class OVTG
	{
		[Key]
		[StringLength(8)]
		public string Code { get; set; }

		[StringLength(50)]
		public string Name { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Rate { get; set; }

		public DateTime? EffecDate { get; set; }

		[StringLength(1)]
		public string Category { get; set; }

		[StringLength(15)]
		public string Account { get; set; }

		[StringLength(1)]
		public string Locked { get; set; }

		[StringLength(1)]
		public string DataSource { get; set; }

		public short? UserSign { get; set; }

		[StringLength(1)]
		public string IsEC { get; set; }

		[StringLength(1)]
		public string Indicator { get; set; }

		[StringLength(1)]
		public string AcqstnRvrs { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? NonDedct { get; set; }

		[StringLength(15)]
		public string AcqsTax { get; set; }

		[StringLength(1)]
		public string GoddsShip { get; set; }

		[StringLength(15)]
		public string NonDedAcc { get; set; }

		[StringLength(15)]
		public string DeferrAcc { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? EquVatPr { get; set; }

		[StringLength(100)]
		public string ReportCode { get; set; }

		[StringLength(1)]
		public string FixdAssts { get; set; }

		[StringLength(1)]
		public string CalcMethod { get; set; }

		[StringLength(1)]
		public string TaxType { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? FixedAmnt { get; set; }

		[StringLength(10)]
		public string ExtCode { get; set; }

		[StringLength(1)]
		public string Correction { get; set; }

		[StringLength(8)]
		public string VatCrctn { get; set; }

		[StringLength(8)]
		public string RetVatCode { get; set; }

		public int? RepType { get; set; }

		public int? LogInstanc { get; set; }

		public DateTime? UpdateDate { get; set; }

		[StringLength(1)]
		public string TaxCtgr { get; set; }

		[StringLength(15)]
		public string EquAccount { get; set; }

		public short? UserSign2 { get; set; }

		[StringLength(1)]
		public string IsIGIC { get; set; }

		[StringLength(1)]
		public string ServSupply { get; set; }

		[StringLength(1)]
		public string Inactive { get; set; }

		[StringLength(1)]
		public string TaxCtgrBL { get; set; }

		public int? R349Code { get; set; }

		[StringLength(15)]
		public string VatRevAcc { get; set; }

		[StringLength(15)]
		public string CashDisAcc { get; set; }

		[StringLength(15)]
		public string DpmTaxOAcc { get; set; }

		[StringLength(15)]
		public string VatDedAcc { get; set; }

		[StringLength(15)]
		public string CstmExpAcc { get; set; }

		[StringLength(15)]
		public string CstmAlcAcc { get; set; }

		[StringLength(5)]
		public string TaxRegion { get; set; }

		[StringLength(3)]
		public string ExemReason { get; set; }

		[StringLength(1)]
		public string Agent { get; set; }

		[StringLength(7)]
		public string OpCode { get; set; }

		[StringLength(1)]
		public string Export { get; set; }

		[StringLength(3)]
		public string Section { get; set; }

		[StringLength(1)]
		public string SplitPaymt { get; set; }

		[StringLength(15)]
		public string SplitPayAc { get; set; }

		[StringLength(1)]
		public string TaxAgent { get; set; }

		[StringLength(3)]
		public string SectionLim { get; set; }

		[StringLength(10)]
		public string VatSubjCod { get; set; }

		public int? VatType { get; set; }

		public int? VatCategor { get; set; }

		[StringLength(1)]
		public string Parag44 { get; set; }

		[StringLength(1)]
		public string ProrataDed { get; set; }
	}
}