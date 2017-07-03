namespace sapHowmuch.Api.Repositories
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class JDT1
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TransId { get; set; }

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Line_ID { get; set; }

		[StringLength(15)]
		public string Account { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Debit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Credit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SYSCred { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SYSDeb { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? FCDebit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? FCCredit { get; set; }

		[StringLength(3)]
		public string FCCurrency { get; set; }

		public DateTime? DueDate { get; set; }

		public int? SourceID { get; set; }

		public short? SourceLine { get; set; }

		[StringLength(15)]
		public string ShortName { get; set; }

		public int? IntrnMatch { get; set; }

		public int? ExtrMatch { get; set; }

		[StringLength(15)]
		public string ContraAct { get; set; }

		[StringLength(50)]
		public string LineMemo { get; set; }

		[StringLength(27)]
		public string Ref3Line { get; set; }

		[StringLength(20)]
		public string TransType { get; set; }

		public DateTime? RefDate { get; set; }

		public DateTime? Ref2Date { get; set; }

		[StringLength(100)]
		public string Ref1 { get; set; }

		[StringLength(100)]
		public string Ref2 { get; set; }

		public int? CreatedBy { get; set; }

		[StringLength(11)]
		public string BaseRef { get; set; }

		[StringLength(20)]
		public string Project { get; set; }

		[StringLength(4)]
		public string TransCode { get; set; }

		[StringLength(8)]
		public string ProfitCode { get; set; }

		public DateTime? TaxDate { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SystemRate { get; set; }

		public DateTime? MthDate { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ToMthSum { get; set; }

		public short? UserSign { get; set; }

		public int? BatchNum { get; set; }

		public int? FinncPriod { get; set; }

		public int? RelTransId { get; set; }

		public int? RelLineID { get; set; }

		[StringLength(1)]
		public string RelType { get; set; }

		public int? LogInstanc { get; set; }

		[StringLength(8)]
		public string VatGroup { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BaseSum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? VatRate { get; set; }

		[StringLength(2)]
		public string Indicator { get; set; }

		[StringLength(1)]
		public string AdjTran { get; set; }

		[StringLength(1)]
		public string RevSource { get; set; }

		[StringLength(20)]
		public string ObjType { get; set; }

		public DateTime? VatDate { get; set; }

		[StringLength(27)]
		public string PaymentRef { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SYSBaseSum { get; set; }

		public int? MultMatch { get; set; }

		[StringLength(1)]
		public string VatLine { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? VatAmount { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SYSVatSum { get; set; }

		[StringLength(1)]
		public string Closed { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? GrossValue { get; set; }

		public int? CheckAbs { get; set; }

		public int? LineType { get; set; }

		[StringLength(1)]
		public string DebCred { get; set; }

		public int? SequenceNr { get; set; }

		[StringLength(15)]
		public string StornoAcc { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalDueDeb { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalDueCred { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalFcDeb { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalFcCred { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalScDeb { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalScCred { get; set; }

		[StringLength(1)]
		public string IsNet { get; set; }

		[StringLength(1)]
		public string DunWizBlck { get; set; }

		public int? DunnLevel { get; set; }

		public DateTime? DunDate { get; set; }

		public short? TaxType { get; set; }

		[StringLength(1)]
		public string TaxPostAcc { get; set; }

		[StringLength(8)]
		public string StaCode { get; set; }

		public int? StaType { get; set; }

		[StringLength(8)]
		public string TaxCode { get; set; }

		public DateTime? ValidFrom { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? GrossValFc { get; set; }

		public DateTime? LvlUpdDate { get; set; }

		[StringLength(8)]
		public string OcrCode2 { get; set; }

		[StringLength(8)]
		public string OcrCode3 { get; set; }

		[StringLength(8)]
		public string OcrCode4 { get; set; }

		[StringLength(8)]
		public string OcrCode5 { get; set; }

		public int? MIEntry { get; set; }

		public int? MIVEntry { get; set; }

		public int? ClsInTP { get; set; }

		public int? CenVatCom { get; set; }

		public int? MatType { get; set; }

		public int? PstngType { get; set; }

		public DateTime? ValidFrom2 { get; set; }

		public DateTime? ValidFrom3 { get; set; }

		public DateTime? ValidFrom4 { get; set; }

		public DateTime? ValidFrom5 { get; set; }

		public int? Location { get; set; }

		[StringLength(4)]
		public string WTaxCode { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? EquVatRate { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? EquVatSum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SYSEquSum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? TotalVat { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SYSTVat { get; set; }

		[StringLength(1)]
		public string WTLiable { get; set; }

		[StringLength(1)]
		public string WTLine { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTApplied { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTAppliedS { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTAppliedF { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTSum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTSumFC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? WTSumSC { get; set; }

		[StringLength(1)]
		public string PayBlock { get; set; }

		public int? PayBlckRef { get; set; }

		[StringLength(32)]
		public string LicTradNum { get; set; }

		public int? InterimTyp { get; set; }

		public int? DprId { get; set; }

		[StringLength(20)]
		public string MatchRef { get; set; }

		[StringLength(1)]
		public string Ordered { get; set; }

		public int? CUP { get; set; }

		public int? CIG { get; set; }

		public int? BPLId { get; set; }

		[StringLength(100)]
		public string BPLName { get; set; }

		[StringLength(32)]
		public string VatRegNum { get; set; }

		[StringLength(1)]
		public string SLEDGERF { get; set; }

		[StringLength(100)]
		public string InitRef2 { get; set; }

		[StringLength(27)]
		public string InitRef3Ln { get; set; }

		[StringLength(50)]
		public string ExpUUID { get; set; }

		[StringLength(1)]
		public string ExpOPType { get; set; }

		public int? ExTransId { get; set; }

		public short? DocArr { get; set; }

		public int? DocLine { get; set; }

		[StringLength(2)]
		public string MYFtype { get; set; }
	}
}