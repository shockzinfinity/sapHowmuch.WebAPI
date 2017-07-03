using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("OCRD")]
	public partial class OCRD
	{
		[Key]
		[StringLength(15)]
		public string CardCode { get; set; }

		[StringLength(100)]
		public string CardName { get; set; }

		[StringLength(1)]
		public string CardType { get; set; }

		public short? GroupCode { get; set; }

		[StringLength(1)]
		public string CmpPrivate { get; set; }

		[StringLength(100)]
		public string Address { get; set; }

		[StringLength(20)]
		public string ZipCode { get; set; }

		[StringLength(100)]
		public string MailAddres { get; set; }

		[StringLength(20)]
		public string MailZipCod { get; set; }

		[StringLength(20)]
		public string Phone1 { get; set; }

		[StringLength(20)]
		public string Phone2 { get; set; }

		[StringLength(20)]
		public string Fax { get; set; }

		[StringLength(90)]
		public string CntctPrsn { get; set; }

		[StringLength(100)]
		public string Notes { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Balance { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ChecksBal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? DNotesBal { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OrdersBal { get; set; }

		public short? GroupNum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? CreditLine { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? DebtLine { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Discount { get; set; }

		[StringLength(1)]
		public string VatStatus { get; set; }

		[StringLength(32)]
		public string LicTradNum { get; set; }

		[StringLength(1)]
		public string DdctStatus { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? DdctPrcnt { get; set; }

		public DateTime? ValidUntil { get; set; }

		public int? Chrctrstcs { get; set; }

		public int? ExMatchNum { get; set; }

		public int? InMatchNum { get; set; }

		public short? ListNum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? DNoteBalFC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OrderBalFC { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? DNoteBalSy { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OrderBalSy { get; set; }

		[StringLength(1)]
		public string Transfered { get; set; }

		[StringLength(1)]
		public string BalTrnsfrd { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? IntrstRate { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Commission { get; set; }

		public short? CommGrCode { get; set; }

		[Column(TypeName = "ntext")]
		public string Free_Text { get; set; }

		public int? SlpCode { get; set; }

		[StringLength(1)]
		public string PrevYearAc { get; set; }

		[StringLength(3)]
		public string Currency { get; set; }

		[StringLength(15)]
		public string RateDifAct { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalanceSys { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BalanceFC { get; set; }

		[StringLength(1)]
		public string Protected { get; set; }

		[StringLength(50)]
		public string Cellular { get; set; }

		public short? AvrageLate { get; set; }

		[StringLength(100)]
		public string City { get; set; }

		[StringLength(100)]
		public string County { get; set; }

		[StringLength(3)]
		public string Country { get; set; }

		[StringLength(100)]
		public string MailCity { get; set; }

		[StringLength(100)]
		public string MailCounty { get; set; }

		[StringLength(3)]
		public string MailCountr { get; set; }

		[StringLength(100)]
		public string E_Mail { get; set; }

		[StringLength(200)]
		public string Picture { get; set; }

		[StringLength(50)]
		public string DflAccount { get; set; }

		[StringLength(50)]
		public string DflBranch { get; set; }

		[StringLength(30)]
		public string BankCode { get; set; }

		[StringLength(64)]
		public string AddID { get; set; }

		[StringLength(30)]
		public string Pager { get; set; }

		[StringLength(15)]
		public string FatherCard { get; set; }

		[StringLength(100)]
		public string CardFName { get; set; }

		[StringLength(1)]
		public string FatherType { get; set; }

		[StringLength(1)]
		public string QryGroup1 { get; set; }

		[StringLength(1)]
		public string QryGroup2 { get; set; }

		[StringLength(1)]
		public string QryGroup3 { get; set; }

		[StringLength(1)]
		public string QryGroup4 { get; set; }

		[StringLength(1)]
		public string QryGroup5 { get; set; }

		[StringLength(1)]
		public string QryGroup6 { get; set; }

		[StringLength(1)]
		public string QryGroup7 { get; set; }

		[StringLength(1)]
		public string QryGroup8 { get; set; }

		[StringLength(1)]
		public string QryGroup9 { get; set; }

		[StringLength(1)]
		public string QryGroup10 { get; set; }

		[StringLength(1)]
		public string QryGroup11 { get; set; }

		[StringLength(1)]
		public string QryGroup12 { get; set; }

		[StringLength(1)]
		public string QryGroup13 { get; set; }

		[StringLength(1)]
		public string QryGroup14 { get; set; }

		[StringLength(1)]
		public string QryGroup15 { get; set; }

		[StringLength(1)]
		public string QryGroup16 { get; set; }

		[StringLength(1)]
		public string QryGroup17 { get; set; }

		[StringLength(1)]
		public string QryGroup18 { get; set; }

		[StringLength(1)]
		public string QryGroup19 { get; set; }

		[StringLength(1)]
		public string QryGroup20 { get; set; }

		[StringLength(1)]
		public string QryGroup21 { get; set; }

		[StringLength(1)]
		public string QryGroup22 { get; set; }

		[StringLength(1)]
		public string QryGroup23 { get; set; }

		[StringLength(1)]
		public string QryGroup24 { get; set; }

		[StringLength(1)]
		public string QryGroup25 { get; set; }

		[StringLength(1)]
		public string QryGroup26 { get; set; }

		[StringLength(1)]
		public string QryGroup27 { get; set; }

		[StringLength(1)]
		public string QryGroup28 { get; set; }

		[StringLength(1)]
		public string QryGroup29 { get; set; }

		[StringLength(1)]
		public string QryGroup30 { get; set; }

		[StringLength(1)]
		public string QryGroup31 { get; set; }

		[StringLength(1)]
		public string QryGroup32 { get; set; }

		[StringLength(1)]
		public string QryGroup33 { get; set; }

		[StringLength(1)]
		public string QryGroup34 { get; set; }

		[StringLength(1)]
		public string QryGroup35 { get; set; }

		[StringLength(1)]
		public string QryGroup36 { get; set; }

		[StringLength(1)]
		public string QryGroup37 { get; set; }

		[StringLength(1)]
		public string QryGroup38 { get; set; }

		[StringLength(1)]
		public string QryGroup39 { get; set; }

		[StringLength(1)]
		public string QryGroup40 { get; set; }

		[StringLength(1)]
		public string QryGroup41 { get; set; }

		[StringLength(1)]
		public string QryGroup42 { get; set; }

		[StringLength(1)]
		public string QryGroup43 { get; set; }

		[StringLength(1)]
		public string QryGroup44 { get; set; }

		[StringLength(1)]
		public string QryGroup45 { get; set; }

		[StringLength(1)]
		public string QryGroup46 { get; set; }

		[StringLength(1)]
		public string QryGroup47 { get; set; }

		[StringLength(1)]
		public string QryGroup48 { get; set; }

		[StringLength(1)]
		public string QryGroup49 { get; set; }

		[StringLength(1)]
		public string QryGroup50 { get; set; }

		[StringLength(1)]
		public string QryGroup51 { get; set; }

		[StringLength(1)]
		public string QryGroup52 { get; set; }

		[StringLength(1)]
		public string QryGroup53 { get; set; }

		[StringLength(1)]
		public string QryGroup54 { get; set; }

		[StringLength(1)]
		public string QryGroup55 { get; set; }

		[StringLength(1)]
		public string QryGroup56 { get; set; }

		[StringLength(1)]
		public string QryGroup57 { get; set; }

		[StringLength(1)]
		public string QryGroup58 { get; set; }

		[StringLength(1)]
		public string QryGroup59 { get; set; }

		[StringLength(1)]
		public string QryGroup60 { get; set; }

		[StringLength(1)]
		public string QryGroup61 { get; set; }

		[StringLength(1)]
		public string QryGroup62 { get; set; }

		[StringLength(1)]
		public string QryGroup63 { get; set; }

		[StringLength(1)]
		public string QryGroup64 { get; set; }

		[StringLength(10)]
		public string DdctOffice { get; set; }

		public DateTime? CreateDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		[StringLength(8)]
		public string ExportCode { get; set; }

		public short? DscntObjct { get; set; }

		[StringLength(1)]
		public string DscntRel { get; set; }

		public short? SPGCounter { get; set; }

		public int? SPPCounter { get; set; }

		[StringLength(9)]
		public string DdctFileNo { get; set; }

		public short? SCNCounter { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? MinIntrst { get; set; }

		[StringLength(1)]
		public string DataSource { get; set; }

		public int? OprCount { get; set; }

		[StringLength(50)]
		public string ExemptNo { get; set; }

		public int? Priority { get; set; }

		public short? CreditCard { get; set; }

		[StringLength(64)]
		public string CrCardNum { get; set; }

		public DateTime? CardValid { get; set; }

		public short? UserSign { get; set; }

		[StringLength(1)]
		public string LocMth { get; set; }

		[StringLength(1)]
		public string validFor { get; set; }

		public DateTime? validFrom { get; set; }

		public DateTime? validTo { get; set; }

		[StringLength(1)]
		public string frozenFor { get; set; }

		public DateTime? frozenFrom { get; set; }

		public DateTime? frozenTo { get; set; }

		[StringLength(1)]
		public string sEmployed { get; set; }

		public int? MTHCounter { get; set; }

		public int? BNKCounter { get; set; }

		public int? DdgKey { get; set; }

		public int? DdtKey { get; set; }

		[StringLength(30)]
		public string ValidComm { get; set; }

		[StringLength(30)]
		public string FrozenComm { get; set; }

		[StringLength(1)]
		public string chainStore { get; set; }

		[StringLength(1)]
		public string DiscInRet { get; set; }

		[StringLength(3)]
		public string State1 { get; set; }

		[StringLength(3)]
		public string State2 { get; set; }

		[StringLength(8)]
		public string VatGroup { get; set; }

		public int? LogInstanc { get; set; }

		[StringLength(20)]
		public string ObjType { get; set; }

		[StringLength(2)]
		public string Indicator { get; set; }

		public short? ShipType { get; set; }

		[StringLength(15)]
		public string DebPayAcct { get; set; }

		[StringLength(50)]
		public string ShipToDef { get; set; }

		[StringLength(100)]
		public string Block { get; set; }

		[StringLength(100)]
		public string MailBlock { get; set; }

		[StringLength(32)]
		public string Password { get; set; }

		[StringLength(8)]
		public string ECVatGroup { get; set; }

		[StringLength(1)]
		public string Deleted { get; set; }

		[StringLength(50)]
		public string IBAN { get; set; }

		public int DocEntry { get; set; }

		public int? FormCode { get; set; }

		[StringLength(20)]
		public string Box1099 { get; set; }

		[StringLength(15)]
		public string PymCode { get; set; }

		[StringLength(1)]
		public string BackOrder { get; set; }

		[StringLength(1)]
		public string PartDelivr { get; set; }

		public int? DunnLevel { get; set; }

		public DateTime? DunnDate { get; set; }

		[StringLength(1)]
		public string BlockDunn { get; set; }

		[StringLength(3)]
		public string BankCountr { get; set; }

		[StringLength(1)]
		public string CollecAuth { get; set; }

		[StringLength(5)]
		public string DME { get; set; }

		[StringLength(30)]
		public string InstrucKey { get; set; }

		[StringLength(1)]
		public string SinglePaym { get; set; }

		[StringLength(9)]
		public string ISRBillId { get; set; }

		[StringLength(1)]
		public string PaymBlock { get; set; }

		[StringLength(20)]
		public string RefDetails { get; set; }

		[StringLength(30)]
		public string HouseBank { get; set; }

		[StringLength(15)]
		public string OwnerIdNum { get; set; }

		public int? PyBlckDesc { get; set; }

		[StringLength(3)]
		public string HousBnkCry { get; set; }

		[StringLength(50)]
		public string HousBnkAct { get; set; }

		[StringLength(50)]
		public string HousBnkBrn { get; set; }

		[StringLength(20)]
		public string ProjectCod { get; set; }

		public int? SysMatchNo { get; set; }

		[StringLength(32)]
		public string VatIdUnCmp { get; set; }

		[StringLength(32)]
		public string AgentCode { get; set; }

		public short? TolrncDays { get; set; }

		[StringLength(1)]
		public string SelfInvoic { get; set; }

		[StringLength(1)]
		public string DeferrTax { get; set; }

		[StringLength(20)]
		public string LetterNum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? MaxAmount { get; set; }

		public DateTime? FromDate { get; set; }

		public DateTime? ToDate { get; set; }

		[StringLength(1)]
		public string WTLiable { get; set; }

		[StringLength(20)]
		public string CrtfcateNO { get; set; }

		public DateTime? ExpireDate { get; set; }

		[StringLength(20)]
		public string NINum { get; set; }

		[StringLength(1)]
		public string AccCritria { get; set; }

		[StringLength(4)]
		public string WTCode { get; set; }

		[StringLength(1)]
		public string Equ { get; set; }

		[StringLength(20)]
		public string HldCode { get; set; }

		[StringLength(15)]
		public string ConnBP { get; set; }

		public int? MltMthNum { get; set; }

		[StringLength(1)]
		public string TypWTReprt { get; set; }

		[StringLength(32)]
		public string VATRegNum { get; set; }

		[StringLength(15)]
		public string RepName { get; set; }

		[Column(TypeName = "ntext")]
		public string Industry { get; set; }

		[Column(TypeName = "ntext")]
		public string Business { get; set; }

		[Column(TypeName = "ntext")]
		public string WTTaxCat { get; set; }

		[StringLength(1)]
		public string IsDomestic { get; set; }

		[StringLength(1)]
		public string IsResident { get; set; }

		[StringLength(1)]
		public string AutoCalBCG { get; set; }

		[StringLength(15)]
		public string OtrCtlAcct { get; set; }

		[Column(TypeName = "ntext")]
		public string AliasName { get; set; }

		[Column(TypeName = "ntext")]
		public string Building { get; set; }

		[Column(TypeName = "ntext")]
		public string MailBuildi { get; set; }

		[StringLength(15)]
		public string BoEPrsnt { get; set; }

		[StringLength(15)]
		public string BoEDiscnt { get; set; }

		[StringLength(15)]
		public string BoEOnClct { get; set; }

		[StringLength(15)]
		public string UnpaidBoE { get; set; }

		[StringLength(4)]
		public string ITWTCode { get; set; }

		[StringLength(25)]
		public string DunTerm { get; set; }

		[StringLength(15)]
		public string ChannlBP { get; set; }

		public int? DfTcnician { get; set; }

		public int? Territory { get; set; }

		[StringLength(50)]
		public string BillToDef { get; set; }

		[StringLength(15)]
		public string DpmClear { get; set; }

		[StringLength(100)]
		public string IntrntSite { get; set; }

		public int? LangCode { get; set; }

		public int? HousActKey { get; set; }

		[StringLength(50)]
		public string Profession { get; set; }

		public short? CDPNum { get; set; }

		public int? DflBankKey { get; set; }

		[StringLength(3)]
		public string BCACode { get; set; }

		[StringLength(1)]
		public string UseShpdGd { get; set; }

		[StringLength(32)]
		public string RegNum { get; set; }

		[StringLength(32)]
		public string VerifNum { get; set; }

		[StringLength(2)]
		public string BankCtlKey { get; set; }

		[StringLength(2)]
		public string HousCtlKey { get; set; }

		[StringLength(100)]
		public string AddrType { get; set; }

		[StringLength(1)]
		public string InsurOp347 { get; set; }

		[StringLength(100)]
		public string MailAddrTy { get; set; }

		[StringLength(100)]
		public string StreetNo { get; set; }

		[StringLength(100)]
		public string MailStrNo { get; set; }

		[StringLength(1)]
		public string TaxRndRule { get; set; }

		public int? VendTID { get; set; }

		[StringLength(1)]
		public string ThreshOver { get; set; }

		[StringLength(1)]
		public string SurOver { get; set; }

		[StringLength(15)]
		public string VendorOcup { get; set; }

		[StringLength(1)]
		public string OpCode347 { get; set; }

		[StringLength(15)]
		public string DpmIntAct { get; set; }

		[StringLength(1)]
		public string ResidenNum { get; set; }

		public short? UserSign2 { get; set; }

		[StringLength(10)]
		public string PlngGroup { get; set; }

		[StringLength(32)]
		public string VatIDNum { get; set; }

		[StringLength(1)]
		public string Affiliate { get; set; }

		[StringLength(1)]
		public string MivzExpSts { get; set; }

		[StringLength(1)]
		public string HierchDdct { get; set; }

		[StringLength(1)]
		public string CertWHT { get; set; }

		[StringLength(1)]
		public string CertBKeep { get; set; }

		[StringLength(1)]
		public string WHShaamGrp { get; set; }

		public int? IndustryC { get; set; }

		public int? DatevAcct { get; set; }

		[StringLength(1)]
		public string DatevFirst { get; set; }

		[StringLength(20)]
		public string GTSRegNum { get; set; }

		[StringLength(80)]
		public string GTSBankAct { get; set; }

		[StringLength(80)]
		public string GTSBilAddr { get; set; }

		[StringLength(50)]
		public string HsBnkSwift { get; set; }

		[StringLength(50)]
		public string HsBnkIBAN { get; set; }

		[StringLength(50)]
		public string DflSwift { get; set; }

		[StringLength(1)]
		public string AutoPost { get; set; }

		[StringLength(15)]
		public string IntrAcc { get; set; }

		[StringLength(15)]
		public string FeeAcc { get; set; }

		public int? CpnNo { get; set; }

		public short? NTSWebSite { get; set; }

		[StringLength(50)]
		public string DflIBAN { get; set; }

		public short? Series { get; set; }

		public int? Number { get; set; }

		public int? EDocExpFrm { get; set; }

		[StringLength(1)]
		public string TaxIdIdent { get; set; }

		[Column(TypeName = "ntext")]
		public string Attachment { get; set; }

		public int? AtcEntry { get; set; }

		[StringLength(1)]
		public string DiscRel { get; set; }

		[StringLength(1)]
		public string NoDiscount { get; set; }

		[StringLength(1)]
		public string SCAdjust { get; set; }

		public int? DflAgrmnt { get; set; }

		[StringLength(50)]
		public string GlblLocNum { get; set; }

		[StringLength(50)]
		public string SenderID { get; set; }

		[StringLength(50)]
		public string RcpntID { get; set; }

		public int? MainUsage { get; set; }

		[StringLength(1)]
		public string SefazCheck { get; set; }

		[StringLength(1)]
		public string free312 { get; set; }

		[StringLength(1)]
		public string free313 { get; set; }

		public DateTime? DateFrom { get; set; }

		public DateTime? DateTill { get; set; }

		[StringLength(2)]
		public string RelCode { get; set; }

		[StringLength(11)]
		public string OKATO { get; set; }

		[StringLength(12)]
		public string OKTMO { get; set; }

		[StringLength(20)]
		public string KBKCode { get; set; }

		[StringLength(1)]
		public string TypeOfOp { get; set; }

		public int? OwnerCode { get; set; }

		[StringLength(35)]
		public string MandateID { get; set; }

		public DateTime? SignDate { get; set; }

		public int? Remark1 { get; set; }

		[StringLength(20)]
		public string ConCerti { get; set; }

		public int? TpCusPres { get; set; }

		[StringLength(2)]
		public string RoleTypCod { get; set; }

		[StringLength(1)]
		public string BlockComm { get; set; }

		[StringLength(2)]
		public string EmplymntCt { get; set; }

		[StringLength(1)]
		public string ExcptnlEvt { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ExpnPrfFnd { get; set; }

		[StringLength(1)]
		public string EdrsFromBP { get; set; }

		[StringLength(1)]
		public string EdrsToBP { get; set; }

		public int? CreateTS { get; set; }

		public int? UpdateTS { get; set; }

		[StringLength(1)]
		public string EDocGenTyp { get; set; }
	}
}