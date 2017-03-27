﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using sapHowmuch.Api.Web.Infrastructure;
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
}