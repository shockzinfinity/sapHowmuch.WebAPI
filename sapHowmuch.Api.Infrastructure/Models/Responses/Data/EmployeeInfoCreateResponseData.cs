using System;

namespace sapHowmuch.Api.Infrastructure.Models.Responses.Data
{
	/// <summary>
	/// This represents the response data entity for employee info.
	/// </summary>
	public class EmployeeInfoCreateResponseData : BaseResponseData
	{
		public string ExtEmpno { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? StartDate { get; set; }
		public int? Status { get; set; }
		public DateTime? TermDate { get; set; }
		public string Active { get; set; }
		public int? Dept { get; set; }
		public int Position { get; set; }
		public string HomeCountr { get; set; }
		public string BrthCountr { get; set; }
		public string Sex { get; set; }
		public DateTime? BirthDate { get; set; }
		public string HomeTel { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public string HomeStreet { get; set; }
		public string HomeZip { get; set; }
		public string MartStatus { get; set; }
	}
}