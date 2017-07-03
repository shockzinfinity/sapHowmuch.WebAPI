using System;

namespace sapHowmuch.Api.Infrastructure.Models
{
	/// <summary>
	/// This Chart of Account of SAP Business One, customizing by connected company.
	/// </summary>
	public class SapEmployeeInfoEntity : DocumentTypeEntity
	{
		public override int Id { get { return empId; } }

		/// <summary>
		/// 사원 키
		/// </summary>
		public int empId { get; set; }

		/// <summary>
		/// 외부사원번호
		/// </summary>
		public string ExtEmpno { get; set; }

		/// <summary>
		///  성
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// 이름
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// 입사일자
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// 상태코드
		/// </summary>
		public int? Status { get; set; }

		/// <summary>
		/// 퇴사일자
		/// </summary>
		public DateTime? TermDate { get; set; }

		/// <summary>
		/// 부서코드
		/// </summary>
		public int? Dept { get; set; }

		/// <summary>
		/// 직위 코드
		/// </summary>
		public int? Position { get; set; }

		/// <summary>
		/// 거주지국가코드(KR)
		/// </summary>
		public string HomeCountr { get; set; }

		/// <summary>
		///  국적코드
		/// </summary>
		public string BrthCountr { get; set; }

		/// <summary>
		/// 성별(M,F)
		/// </summary>
		public string Sex { get; set; }

		/// <summary>
		/// 생년월일
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// 자택전화번호
		/// </summary>
		public string HomeTel { get; set; }

		/// <summary>
		/// 휴대폰번호
		/// </summary>
		public string Mobile { get; set; }

		/// <summary>
		/// 이메일
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 상세주소
		/// </summary>
		public string HomeStreet { get; set; }

		/// <summary>
		/// 상세주소번호
		/// </summary>
		public string StreetNoH { get; set; }

		/// <summary>
		/// 우편번호
		/// </summary>
		public string HomeZip { get; set; }

		/// <summary>
		/// 결혼상태
		/// </summary>
		public string MartStatus { get; set; }

		/// <summary>
		/// 근무여부(Y,N)
		/// </summary>
		public string Active { get; set; }
	}
}