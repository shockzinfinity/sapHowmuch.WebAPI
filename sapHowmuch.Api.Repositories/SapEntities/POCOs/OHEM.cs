using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories.SapEntities
{
	[Table("OHEM")]
	public partial class OHEM
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int empID { get; set; }

		[StringLength(50)]
		public string lastName { get; set; }

		[StringLength(50)]
		public string firstName { get; set; }

		[StringLength(50)]
		public string middleName { get; set; }

		[StringLength(1)]
		public string sex { get; set; }

		[StringLength(20)]
		public string jobTitle { get; set; }

		public int? type { get; set; }

		public short? dept { get; set; }

		public short? branch { get; set; }

		[StringLength(100)]
		public string workStreet { get; set; }

		[StringLength(100)]
		public string workBlock { get; set; }

		[StringLength(20)]
		public string workZip { get; set; }

		[StringLength(100)]
		public string workCity { get; set; }

		[StringLength(100)]
		public string workCounty { get; set; }

		[StringLength(3)]
		public string workCountr { get; set; }

		[StringLength(3)]
		public string workState { get; set; }

		public int? manager { get; set; }

		public int? userId { get; set; }

		public int? salesPrson { get; set; }

		[StringLength(20)]
		public string officeTel { get; set; }

		[StringLength(20)]
		public string officeExt { get; set; }

		[StringLength(20)]
		public string mobile { get; set; }

		[StringLength(20)]
		public string pager { get; set; }

		[StringLength(20)]
		public string homeTel { get; set; }

		[StringLength(20)]
		public string fax { get; set; }

		[StringLength(100)]
		public string email { get; set; }

		public DateTime? startDate { get; set; }

		public int? status { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? salary { get; set; }

		[StringLength(1)]
		public string salaryUnit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? emplCost { get; set; }

		[StringLength(1)]
		public string empCostUnt { get; set; }

		public DateTime? termDate { get; set; }

		public int? termReason { get; set; }

		[StringLength(30)]
		public string bankCode { get; set; }

		[StringLength(100)]
		public string bankBranch { get; set; }

		[StringLength(30)]
		public string bankBranNo { get; set; }

		[StringLength(100)]
		public string bankAcount { get; set; }

		[StringLength(100)]
		public string homeStreet { get; set; }

		[StringLength(100)]
		public string homeBlock { get; set; }

		[StringLength(20)]
		public string homeZip { get; set; }

		[StringLength(100)]
		public string homeCity { get; set; }

		[StringLength(100)]
		public string homeCounty { get; set; }

		[StringLength(3)]
		public string homeCountr { get; set; }

		[StringLength(3)]
		public string homeState { get; set; }

		public DateTime? birthDate { get; set; }

		[StringLength(3)]
		public string brthCountr { get; set; }

		[StringLength(1)]
		public string martStatus { get; set; }

		public short? nChildren { get; set; }

		[StringLength(64)]
		public string govID { get; set; }

		[StringLength(3)]
		public string citizenshp { get; set; }

		[StringLength(64)]
		public string passportNo { get; set; }

		public DateTime? passportEx { get; set; }

		[StringLength(200)]
		public string picture { get; set; }

		[Column(TypeName = "ntext")]
		public string remark { get; set; }

		[Column(TypeName = "ntext")]
		public string attachment { get; set; }

		[StringLength(3)]
		public string salaryCurr { get; set; }

		[StringLength(3)]
		public string empCostCur { get; set; }

		[Column(TypeName = "ntext")]
		public string WorkBuild { get; set; }

		[Column(TypeName = "ntext")]
		public string HomeBuild { get; set; }

		public int? position { get; set; }

		public int? AtcEntry { get; set; }

		[StringLength(100)]
		public string AddrTypeW { get; set; }

		[StringLength(100)]
		public string AddrTypeH { get; set; }

		[StringLength(100)]
		public string StreetNoW { get; set; }

		[StringLength(100)]
		public string StreetNoH { get; set; }

		[StringLength(1)]
		public string DispMidNam { get; set; }

		[StringLength(1)]
		public string NamePos { get; set; }

		[StringLength(1)]
		public string DispComma { get; set; }

		[StringLength(8)]
		public string CostCenter { get; set; }

		[StringLength(20)]
		public string CompanyNum { get; set; }

		public int? VacPreYear { get; set; }

		public int? VacCurYear { get; set; }

		[StringLength(20)]
		public string MunKey { get; set; }

		[StringLength(2)]
		public string TaxClass { get; set; }

		[StringLength(2)]
		public string InTaxLiabi { get; set; }

		[StringLength(9)]
		public string EmTaxCCode { get; set; }

		[StringLength(9)]
		public string RelPartner { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? ExemptAmnt { get; set; }

		[StringLength(20)]
		public string ExemptUnit { get; set; }

		[Column(TypeName = "numeric")]
		public decimal? AddiAmnt { get; set; }

		[StringLength(20)]
		public string AddiUnit { get; set; }

		[StringLength(50)]
		public string TaxOName { get; set; }

		[StringLength(20)]
		public string TaxONum { get; set; }

		[StringLength(50)]
		public string HeaInsName { get; set; }

		[StringLength(50)]
		public string HeaInsCode { get; set; }

		[StringLength(20)]
		public string HeaInsType { get; set; }

		[StringLength(20)]
		public string SInsurNum { get; set; }

		[StringLength(2)]
		public string StatusOfP { get; set; }

		[StringLength(2)]
		public string StatusOfE { get; set; }

		[StringLength(20)]
		public string BCodeDateV { get; set; }

		[StringLength(1)]
		public string DevBAOwner { get; set; }

		[StringLength(50)]
		public string FNameSP { get; set; }

		[StringLength(50)]
		public string SurnameSP { get; set; }

		public int? LogInstanc { get; set; }

		public short? UserSign { get; set; }

		public short? UserSign2 { get; set; }

		public DateTime? UpdateDate { get; set; }

		[StringLength(5)]
		public string PersGroup { get; set; }

		[StringLength(5)]
		public string JTCode { get; set; }

		[StringLength(20)]
		public string ExtEmpNo { get; set; }

		[StringLength(100)]
		public string BirthPlace { get; set; }

		[StringLength(2)]
		public string PymMeth { get; set; }

		[StringLength(3)]
		public string ExemptCurr { get; set; }

		[StringLength(3)]
		public string AddiCurr { get; set; }

		public int? STDCode { get; set; }

		[StringLength(150)]
		public string FatherName { get; set; }

		[StringLength(100)]
		public string CPF { get; set; }

		[StringLength(20)]
		public string CRC { get; set; }

		[StringLength(1)]
		public string ContResp { get; set; }

		[StringLength(1)]
		public string RepLegal { get; set; }

		[StringLength(1)]
		public string DirfDeclar { get; set; }

		[StringLength(3)]
		public string UF_CRC { get; set; }

		[StringLength(30)]
		public string IDType { get; set; }

		[StringLength(1)]
		public string Active { get; set; }

		public int? BPLId { get; set; }

		[StringLength(60)]
		public string ManualNUM { get; set; }

		public DateTime? PassIssue { get; set; }

		[StringLength(254)]
		public string PassIssuer { get; set; }

		[StringLength(3)]
		public string QualCode { get; set; }

		[StringLength(1)]
		public string PRWebAccss { get; set; }

		[StringLength(1)]
		public string PrePRWeb { get; set; }

		[StringLength(15)]
		public string BPLink { get; set; }
	}
}
