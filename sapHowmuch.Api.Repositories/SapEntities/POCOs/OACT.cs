using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories.SapEntities
{
	[Table("OACT")]
	public partial class OACT
	{
		[Key]
		[StringLength(15)]
		public string AcctCode { get; set; }

		[StringLength(100)]
		public string AcctName { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? CurrTotal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? EndTotal { get; set; }

		[StringLength(1)]
		public string Finanse { get; set; }

		[StringLength(8)]
		public string Groups { get; set; }

		[StringLength(1)]
		public string Budget { get; set; }

		[StringLength(1)]
		public string Frozen { get; set; }

		[StringLength(1)]
		public string Free_2 { get; set; }

		[StringLength(1)]
		public string Postable { get; set; }

		[StringLength(1)]
		public string Fixed { get; set; }

		public short? Levels { get; set; }

		[StringLength(10)]
		public string ExportCode { get; set; }

		public int? GrpLine { get; set; }

		[StringLength(15)]
		public string FatherNum { get; set; }

		[StringLength(15)]
		public string AccntntCod { get; set; }

		[StringLength(1)]
		public string CashBox { get; set; }

		public short? GroupMask { get; set; }

		[StringLength(1)]
		public string RateTrans { get; set; }

		[StringLength(1)]
		public string TaxIncome { get; set; }

		[StringLength(1)]
		public string ExmIncome { get; set; }

		public int? ExtrMatch { get; set; }

		public int? IntrMatch { get; set; }

		[StringLength(1)]
		public string ActType { get; set; }

		[StringLength(1)]
		public string Transfered { get; set; }

		[StringLength(1)]
		public string BlncTrnsfr { get; set; }

		[StringLength(1)]
		public string OverType { get; set; }

		[StringLength(8)]
		public string OverCode { get; set; }

		public int? SysMatch { get; set; }

		[StringLength(1)]
		public string PrevYear { get; set; }

		[StringLength(3)]
		public string ActCurr { get; set; }

		[StringLength(15)]
		public string RateDifAct { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SysTotal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? FcTotal { get; set; }

		[StringLength(1)]
		public string Protected { get; set; }

		[StringLength(1)]
		public string RealAcct { get; set; }

		[StringLength(1)]
		public string Advance { get; set; }

		public DateTime? CreateDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		[StringLength(100)]
		public string FrgnName { get; set; }

		[StringLength(254)]
		public string Details { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ExtraSum { get; set; }

		[StringLength(20)]
		public string Project { get; set; }

		[StringLength(1)]
		public string RevalMatch { get; set; }

		[StringLength(1)]
		public string DataSource { get; set; }

		[StringLength(1)]
		public string LocMth { get; set; }

		public int? MTHCounter { get; set; }

		public int? BNKCounter { get; set; }

		public short? UserSign { get; set; }

		[StringLength(1)]
		public string LocManTran { get; set; }

		public int? LogInstanc { get; set; }

		[StringLength(20)]
		public string ObjType { get; set; }

		[StringLength(1)]
		public string ValidFor { get; set; }

		public DateTime? ValidFrom { get; set; }

		public DateTime? ValidTo { get; set; }

		[StringLength(30)]
		public string ValidComm { get; set; }

		[StringLength(1)]
		public string FrozenFor { get; set; }

		public DateTime? FrozenFrom { get; set; }

		public DateTime? FrozenTo { get; set; }

		[StringLength(30)]
		public string FrozenComm { get; set; }

		public int? Counter { get; set; }

		[StringLength(20)]
		public string Segment_0 { get; set; }

		[StringLength(20)]
		public string Segment_1 { get; set; }

		[StringLength(20)]
		public string Segment_2 { get; set; }

		[StringLength(20)]
		public string Segment_3 { get; set; }

		[StringLength(20)]
		public string Segment_4 { get; set; }

		[StringLength(20)]
		public string Segment_5 { get; set; }

		[StringLength(20)]
		public string Segment_6 { get; set; }

		[StringLength(20)]
		public string Segment_7 { get; set; }

		[StringLength(20)]
		public string Segment_8 { get; set; }

		[StringLength(20)]
		public string Segment_9 { get; set; }

		[StringLength(210)]
		public string FormatCode { get; set; }

		[StringLength(1)]
		public string CfwRlvnt { get; set; }

		[StringLength(1)]
		public string ExchRate { get; set; }

		[StringLength(15)]
		public string RevalAcct { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? LastRevBal { get; set; }

		public DateTime? LastRevDat { get; set; }

		[StringLength(8)]
		public string DfltVat { get; set; }

		[StringLength(1)]
		public string VatChange { get; set; }

		public int? Category { get; set; }

		[StringLength(4)]
		public string TransCode { get; set; }

		[StringLength(8)]
		public string OverCode5 { get; set; }

		[StringLength(8)]
		public string OverCode2 { get; set; }

		[StringLength(8)]
		public string OverCode3 { get; set; }

		[StringLength(8)]
		public string OverCode4 { get; set; }

		[StringLength(8)]
		public string DfltTax { get; set; }

		[StringLength(1)]
		public string TaxPostAcc { get; set; }

		[StringLength(2)]
		public string AcctStrLe { get; set; }

		[StringLength(10)]
		public string MeaUnit { get; set; }

		[StringLength(4)]
		public string BalDirect { get; set; }

		public short? UserSign2 { get; set; }

		[StringLength(2)]
		public string PlngLevel { get; set; }

		[StringLength(1)]
		public string MultiLink { get; set; }

		[StringLength(1)]
		public string PrjRelvnt { get; set; }

		[StringLength(1)]
		public string Dim1Relvnt { get; set; }

		[StringLength(1)]
		public string Dim2Relvnt { get; set; }

		[StringLength(1)]
		public string Dim3Relvnt { get; set; }

		[StringLength(1)]
		public string Dim4Relvnt { get; set; }

		[StringLength(1)]
		public string Dim5Relvnt { get; set; }

		[StringLength(1)]
		public string AccrualTyp { get; set; }

		public int? DatevAcct { get; set; }

		[StringLength(1)]
		public string DatevAutoA { get; set; }

		[StringLength(1)]
		public string DatevFirst { get; set; }

		public int? SnapShotId { get; set; }

		[StringLength(1)]
		public string PCN874Rpt { get; set; }

		[StringLength(1)]
		public string SCAdjust { get; set; }

		public int? BPLId { get; set; }

		[StringLength(100)]
		public string BPLName { get; set; }

		[StringLength(60)]
		public string SubLedgerN { get; set; }

		[StringLength(32)]
		public string VATRegNum { get; set; }

		[Required]
		[StringLength(210)]
		public string ActId { get; set; }

		[StringLength(15)]
		public string ClosingAcc { get; set; }

		[StringLength(2)]
		public string PurpCode { get; set; }

		[StringLength(30)]
		public string RefCode { get; set; }

		[StringLength(1)]
		public string BlocManPos { get; set; }
	}
}