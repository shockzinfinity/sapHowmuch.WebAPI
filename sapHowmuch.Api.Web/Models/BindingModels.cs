using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace sapHowmuch.Api.Web.Models
{
	public class CreateUserBindingModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }
	}

	public class ChangePasswordBindingModel
	{
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Current password")]
		public string OldPassword { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "New password")]
		public string NewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm new password")]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}

	public class CreateRoleBindingModel
	{
		[Required]
		[StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
		[Display(Name = "Role Name")]
		public string Name { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }
	}

	public class ClaimBindingModel
	{
		[Required]
		[Display(Name = "Claim Type")]
		public string Type { get; set; }

		[Required]
		[Display(Name = "Claim Value")]
		public string Value { get; set; }
	}

	public class ClientBindingModel
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; set; }

		public bool Active { get; set; }
		public int RefreshTokenLifeTime { get; set; }

		[MaxLength(200)]
		public string AllowedOrigin { get; set; }
	}

	public class CreateEmployeeBindingModel
	{
		[Required]
		[Display(Name = "External Employee Number")]
		public string ExtEmpno { get; set; }

		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Start Date")]
		public DateTime? StartDate { get; set; }

		[Required]
		[Display(Name = "Status")]
		public int? Status { get; set; }

		[Required]
		[Display(Name = "Term Date")]
		public DateTime? TermDate { get; set; }

		[Required]
		[Display(Name = "Active")]
		public string Active { get; set; }

		[Required]
		[Display(Name = "Department")]
		public int? Dept { get; set; }

		[Required]
		[Display(Name = "Position")]
		public int Position { get; set; }

		[Required]
		[Display(Name = "Home Country")]
		public string HomeCountr { get; set; }

		[Required]
		[Display(Name = "Birth Place")]
		public string BrthCountr { get; set; }

		[Required]
		[Display(Name = "Sex")]
		public string Sex { get; set; }

		[Required]
		[Display(Name = "Date of Birth")]
		public DateTime? BirthDate { get; set; }

		[Required]
		[Display(Name = "Home Phone")]
		public string HomeTel { get; set; }

		[Required]
		[Display(Name = "Mobile Phone")]
		public string Mobile { get; set; }

		[Required]
		[Display(Name = "eMail")]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Home Address")]
		public string HomeStreet { get; set; }

		[Required]
		[Display(Name = "Home Zip Code")]
		public string HomeZip { get; set; }

		[Required]
		[Display(Name = "Marriage Status")]
		public string MartStatus { get; set; }
	}
}