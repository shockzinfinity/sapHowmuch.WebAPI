using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("OITM")]
	public partial class OITM
	{
		[Key]
		[StringLength(50)]
		public string ItemCode { get; set; }

		[StringLength(100)]
		public string ItemName { get; set; }

		[StringLength(100)]
		public string FrgnName { get; set; }

		public short? ItmsGrpCod { get; set; }

		public short? CstGrpCode { get; set; }

		[StringLength(8)]
		public string VatGourpSa { get; set; }

		[StringLength(254)]
		public string CodeBars { get; set; }

		[StringLength(1)]
		public string VATLiable { get; set; }

		[StringLength(1)]
		public string PrchseItem { get; set; }

		[StringLength(1)]
		public string SellItem { get; set; }

		[StringLength(1)]
		public string InvntItem { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OnHand { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? IsCommited { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OnOrder { get; set; }

		[StringLength(15)]
		public string IncomeAcct { get; set; }

		[StringLength(15)]
		public string ExmptIncom { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? MaxLevel { get; set; }

		[StringLength(8)]
		public string DfltWH { get; set; }

		[StringLength(15)]
		public string CardCode { get; set; }

		[StringLength(50)]
		public string SuppCatNum { get; set; }

		[StringLength(100)]
		public string BuyUnitMsr { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? NumInBuy { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ReorderQty { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? MinLevel { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? LstEvlPric { get; set; }

		public DateTime? LstEvlDate { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? CustomPer { get; set; }

		[StringLength(1)]
		public string Canceled { get; set; }

		public int? MnufctTime { get; set; }

		[StringLength(1)]
		public string WholSlsTax { get; set; }

		[StringLength(1)]
		public string RetilrTax { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SpcialDisc { get; set; }

		public short? DscountCod { get; set; }

		[StringLength(1)]
		public string TrackSales { get; set; }

		[StringLength(100)]
		public string SalUnitMsr { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? NumInSale { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Consig { get; set; }

		public int? QueryGroup { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Counted { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OpenBlnc { get; set; }

		[StringLength(1)]
		public string EvalSystem { get; set; }

		public short? UserSign { get; set; }

		[StringLength(1)]
		public string FREE { get; set; }

		[StringLength(200)]
		public string PicturName { get; set; }

		[StringLength(1)]
		public string Transfered { get; set; }

		[StringLength(1)]
		public string BlncTrnsfr { get; set; }

		[Column(TypeName = "ntext")]
		public string UserText { get; set; }

		[StringLength(17)]
		public string SerialNum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? CommisPcnt { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? CommisSum { get; set; }

		public short? CommisGrp { get; set; }

		[StringLength(1)]
		public string TreeType { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? TreeQty { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? LastPurPrc { get; set; }

		[StringLength(3)]
		public string LastPurCur { get; set; }

		public DateTime? LastPurDat { get; set; }

		[StringLength(3)]
		public string ExitCur { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ExitPrice { get; set; }

		[StringLength(8)]
		public string ExitWH { get; set; }

		[StringLength(1)]
		public string AssetItem { get; set; }

		[StringLength(1)]
		public string WasCounted { get; set; }

		[StringLength(1)]
		public string ManSerNum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SHeight1 { get; set; }

		public short? SHght1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SHeight2 { get; set; }

		public short? SHght2Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SWidth1 { get; set; }

		public short? SWdth1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SWidth2 { get; set; }

		public short? SWdth2Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SLength1 { get; set; }

		public short? SLen1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Slength2 { get; set; }

		public short? SLen2Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SVolume { get; set; }

		public short? SVolUnit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SWeight1 { get; set; }

		public short? SWght1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SWeight2 { get; set; }

		public short? SWght2Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BHeight1 { get; set; }

		public short? BHght1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BHeight2 { get; set; }

		public short? BHght2Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BWidth1 { get; set; }

		public short? BWdth1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BWidth2 { get; set; }

		public short? BWdth2Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BLength1 { get; set; }

		public short? BLen1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? Blength2 { get; set; }

		public short? BLen2Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BVolume { get; set; }

		public short? BVolUnit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BWeight1 { get; set; }

		public short? BWght1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? BWeight2 { get; set; }

		public short? BWght2Unit { get; set; }

		[StringLength(3)]
		public string FixCurrCms { get; set; }

		public short? FirmCode { get; set; }

		public DateTime? LstSalDate { get; set; }

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

		public DateTime? CreateDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		[StringLength(20)]
		public string ExportCode { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SalFactor1 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SalFactor2 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SalFactor3 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SalFactor4 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? PurFactor1 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? PurFactor2 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? PurFactor3 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? PurFactor4 { get; set; }

		[StringLength(40)]
		public string SalFormula { get; set; }

		[StringLength(40)]
		public string PurFormula { get; set; }

		[StringLength(8)]
		public string VatGroupPu { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? AvgPrice { get; set; }

		[StringLength(30)]
		public string PurPackMsr { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? PurPackUn { get; set; }

		[StringLength(30)]
		public string SalPackMsr { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? SalPackUn { get; set; }

		public short? SCNCounter { get; set; }

		[StringLength(1)]
		public string ManBtchNum { get; set; }

		[StringLength(1)]
		public string ManOutOnly { get; set; }

		[StringLength(1)]
		public string DataSource { get; set; }

		[StringLength(1)]
		public string validFor { get; set; }

		public DateTime? validFrom { get; set; }

		public DateTime? validTo { get; set; }

		[StringLength(1)]
		public string frozenFor { get; set; }

		public DateTime? frozenFrom { get; set; }

		public DateTime? frozenTo { get; set; }

		[StringLength(1)]
		public string BlockOut { get; set; }

		[StringLength(30)]
		public string ValidComm { get; set; }

		[StringLength(30)]
		public string FrozenComm { get; set; }

		public int? LogInstanc { get; set; }

		[StringLength(20)]
		public string ObjType { get; set; }

		[StringLength(16)]
		public string SWW { get; set; }

		[StringLength(1)]
		public string Deleted { get; set; }

		public int? DocEntry { get; set; }

		[StringLength(15)]
		public string ExpensAcct { get; set; }

		[StringLength(15)]
		public string FrgnInAcct { get; set; }

		public short? ShipType { get; set; }

		[StringLength(1)]
		public string GLMethod { get; set; }

		[StringLength(15)]
		public string ECInAcct { get; set; }

		[StringLength(15)]
		public string FrgnExpAcc { get; set; }

		[StringLength(15)]
		public string ECExpAcc { get; set; }

		[StringLength(1)]
		public string TaxType { get; set; }

		[StringLength(1)]
		public string ByWh { get; set; }

		[StringLength(1)]
		public string WTLiable { get; set; }

		[StringLength(1)]
		public string ItemType { get; set; }

		[StringLength(20)]
		public string WarrntTmpl { get; set; }

		[StringLength(20)]
		public string BaseUnit { get; set; }

		[StringLength(3)]
		public string CountryOrg { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? StockValue { get; set; }

		[StringLength(1)]
		public string Phantom { get; set; }

		[StringLength(1)]
		public string IssueMthd { get; set; }

		[StringLength(1)]
		public string FREE1 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? PricingPrc { get; set; }

		[StringLength(1)]
		public string MngMethod { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ReorderPnt { get; set; }

		[StringLength(100)]
		public string InvntryUom { get; set; }

		[StringLength(1)]
		public string PlaningSys { get; set; }

		[StringLength(1)]
		public string PrcrmntMtd { get; set; }

		public short? OrdrIntrvl { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OrdrMulti { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? MinOrdrQty { get; set; }

		public int? LeadTime { get; set; }

		[StringLength(1)]
		public string IndirctTax { get; set; }

		[StringLength(8)]
		public string TaxCodeAR { get; set; }

		[StringLength(8)]
		public string TaxCodeAP { get; set; }

		public int? OSvcCode { get; set; }

		public int? ISvcCode { get; set; }

		public int? ServiceGrp { get; set; }

		public int? NCMCode { get; set; }

		[StringLength(3)]
		public string MatType { get; set; }

		public int? MatGrp { get; set; }

		[StringLength(2)]
		public string ProductSrc { get; set; }

		public int? ServiceCtg { get; set; }

		[StringLength(1)]
		public string ItemClass { get; set; }

		[StringLength(1)]
		public string Excisable { get; set; }

		public int? ChapterID { get; set; }

		[StringLength(40)]
		public string NotifyASN { get; set; }

		[StringLength(20)]
		public string ProAssNum { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? AssblValue { get; set; }

		public int? DNFEntry { get; set; }

		public short? UserSign2 { get; set; }

		[StringLength(30)]
		public string Spec { get; set; }

		[StringLength(4)]
		public string TaxCtg { get; set; }

		public short? Series { get; set; }

		public int? Number { get; set; }

		public int? FuelCode { get; set; }

		[StringLength(2)]
		public string BeverTblC { get; set; }

		[StringLength(2)]
		public string BeverGrpC { get; set; }

		public int? BeverTM { get; set; }

		[Column(TypeName = "ntext")]
		public string Attachment { get; set; }

		public int? AtcEntry { get; set; }

		public int? ToleranDay { get; set; }

		public int? UgpEntry { get; set; }

		public int? PUoMEntry { get; set; }

		public int? SUoMEntry { get; set; }

		public int? IUoMEntry { get; set; }

		public short? IssuePriBy { get; set; }

		[StringLength(20)]
		public string AssetClass { get; set; }

		[StringLength(15)]
		public string AssetGroup { get; set; }

		[StringLength(12)]
		public string InventryNo { get; set; }

		public int? Technician { get; set; }

		public int? Employee { get; set; }

		public int? Location { get; set; }

		[StringLength(1)]
		public string StatAsset { get; set; }

		[StringLength(1)]
		public string Cession { get; set; }

		[StringLength(1)]
		public string DeacAftUL { get; set; }

		[StringLength(1)]
		public string AsstStatus { get; set; }

		public DateTime? CapDate { get; set; }

		public DateTime? AcqDate { get; set; }

		public DateTime? RetDate { get; set; }

		[StringLength(1)]
		public string GLPickMeth { get; set; }

		[StringLength(1)]
		public string NoDiscount { get; set; }

		[StringLength(1)]
		public string MgrByQty { get; set; }

		[StringLength(100)]
		public string AssetRmk1 { get; set; }

		[StringLength(100)]
		public string AssetRmk2 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? AssetAmnt1 { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? AssetAmnt2 { get; set; }

		[StringLength(15)]
		public string DeprGroup { get; set; }

		[StringLength(32)]
		public string AssetSerNo { get; set; }

		[StringLength(100)]
		public string CntUnitMsr { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? NumInCnt { get; set; }

		public int? INUoMEntry { get; set; }

		[StringLength(1)]
		public string OneBOneRec { get; set; }

		[StringLength(2)]
		public string RuleCode { get; set; }

		[StringLength(10)]
		public string ScsCode { get; set; }

		[StringLength(2)]
		public string SpProdType { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? IWeight1 { get; set; }

		public short? IWght1Unit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? IWeight2 { get; set; }

		public short? IWght2Unit { get; set; }

		[StringLength(1)]
		public string CompoWH { get; set; }

		public int? CreateTS { get; set; }

		public int? UpdateTS { get; set; }

		[StringLength(1)]
		public string VirtAstItm { get; set; }

		[StringLength(50)]
		public string SouVirAsst { get; set; }

		[StringLength(1)]
		public string InCostRoll { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? PrdStdCst { get; set; }

		[StringLength(1)]
		public string EnAstSeri { get; set; }

		[StringLength(50)]
		public string LinkRsc { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? OnHldPert { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? onHldLimt { get; set; }
	}
}