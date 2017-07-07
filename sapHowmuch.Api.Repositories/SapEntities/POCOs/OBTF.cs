namespace sapHowmuch.Api.Repositories
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("OBTF")]
	public partial class OBTF
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int BatchNum { get; set; }

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TransId { get; set; }

		[StringLength(1)]
		public string BtfStatus { get; set; }

		[StringLength(20)]
		public string TransType { get; set; }

		[StringLength(11)]
		public string BaseRef { get; set; }

		public DateTime? RefDate { get; set; }

		[StringLength(50)]
		public string Memo { get; set; }

		[StringLength(100)]
		public string Ref1 { get; set; }

		[StringLength(100)]
		public string Ref2 { get; set; }

		public int? CreatedBy { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? LocTotal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? FcTotal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SysTotal { get; set; }

		[StringLength(4)]
		public string TransCode { get; set; }

		[StringLength(3)]
		public string OrignCurr { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? TransRate { get; set; }

		public int? BtfLine { get; set; }

		[StringLength(3)]
		public string TransCurr { get; set; }

		[StringLength(20)]
		public string Project { get; set; }

		public DateTime? DueDate { get; set; }

		public DateTime? TaxDate { get; set; }

		[StringLength(1)]
		public string PCAddition { get; set; }

		public int? FinncPriod { get; set; }

		[StringLength(1)]
		public string DataSource { get; set; }

		public DateTime? UpdateDate { get; set; }

		public DateTime? CreateDate { get; set; }

		public short? UserSign { get; set; }

		public short? UserSign2 { get; set; }

		[StringLength(1)]
		public string RefndRprt { get; set; }

		public int? LogInstanc { get; set; }

		[StringLength(20)]
		public string ObjType { get; set; }

		[StringLength(2)]
		public string Indicator { get; set; }

		[StringLength(1)]
		public string AdjTran { get; set; }

		[StringLength(1)]
		public string RevSource { get; set; }

		public DateTime? StornoDate { get; set; }

		public int? StornoToTr { get; set; }

		[StringLength(1)]
		public string AutoStorno { get; set; }

		[StringLength(1)]
		public string Corisptivi { get; set; }

		public DateTime? VatDate { get; set; }

		[StringLength(1)]
		public string StampTax { get; set; }

		public short? Series { get; set; }

		public int? Number { get; set; }

		[StringLength(1)]
		public string AutoVAT { get; set; }

		public short? DocSeries { get; set; }

		[StringLength(4)]
		public string FolioPref { get; set; }

		public int? FolioNum { get; set; }

		public short? CreateTime { get; set; }

		[StringLength(1)]
		public string BlockDunn { get; set; }

		[StringLength(1)]
		public string ReportEU { get; set; }

		[StringLength(1)]
		public string Report347 { get; set; }

		[StringLength(1)]
		public string Printed { get; set; }

		[StringLength(60)]
		public string DocType { get; set; }

		public int? AttNum { get; set; }

		[StringLength(1)]
		public string GenRegNo { get; set; }

		public int? RG23APart2 { get; set; }

		public int? RG23CPart2 { get; set; }

		public int? MatType { get; set; }

		[StringLength(155)]
		public string Creator { get; set; }

		[StringLength(155)]
		public string Approver { get; set; }

		public int? Location { get; set; }

		public short? SeqCode { get; set; }

		public int? Serial { get; set; }

		[StringLength(3)]
		public string SeriesStr { get; set; }

		[StringLength(3)]
		public string SubStr { get; set; }

		[StringLength(1)]
		public string AutoWT { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTSum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTSumSC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTSumFC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTApplied { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTAppliedS { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTAppliedF { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BaseAmnt { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BaseAmntSC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BaseAmntFC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BaseVtAt { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BaseVtAtSC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BaseVtAtFC { get; set; }

		[StringLength(11)]
		public string VersionNum { get; set; }

		public int? BaseTrans { get; set; }

		[StringLength(1)]
		public string ResidenNum { get; set; }

		[StringLength(1)]
		public string OperatCode { get; set; }

		[StringLength(27)]
		public string Ref3 { get; set; }

		[StringLength(1)]
		public string SSIExmpt { get; set; }

		[Column(TypeName = "ntext")]
		public string SignMsg { get; set; }

		[Column(TypeName = "ntext")]
		public string SignDigest { get; set; }

		[StringLength(50)]
		public string CertifNum { get; set; }

		public int? KeyVersion { get; set; }

		public int? CUP { get; set; }

		public int? CIG { get; set; }

		[StringLength(254)]
		public string SupplCode { get; set; }

		public int? SPSrcType { get; set; }

		public int? SPSrcID { get; set; }

		public int? SPSrcDLN { get; set; }

		[StringLength(1)]
		public string DeferedTax { get; set; }

		public int? AgrNo { get; set; }

		public int? SeqNum { get; set; }

		[StringLength(1)]
		public string ECDPosTyp { get; set; }

		[StringLength(5)]
		public string RptPeriod { get; set; }

		public DateTime? RptMonth { get; set; }

		public int? ExTransId { get; set; }

		[StringLength(1)]
		public string PrlLinked { get; set; }

		[StringLength(5)]
		public string PTICode { get; set; }

		[StringLength(1)]
		public string Letter { get; set; }

		public int? FolNumFrom { get; set; }

		public int? FolNumTo { get; set; }

		[StringLength(3)]
		public string RepSection { get; set; }

		[StringLength(1)]
		public string ExclTaxRep { get; set; }
	}
}