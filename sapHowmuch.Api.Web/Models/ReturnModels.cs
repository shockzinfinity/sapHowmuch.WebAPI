using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace sapHowmuch.Api.Web.Models
{
	public class UserReturnModel
	{
		public string Url { get; set; }
		public string Id { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public string Description { get; set; }
		public DateTime JoinDate { get; set; }
		public IList<string> Roles { get; set; }
		public IList<Claim> Claims { get; set; }
	}

	public class RoleReturnModel
	{
		public string Url { get; set; }
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}

	public class ClientReturnModel
	{
		public string Id { get; set; }
		public string Secret { get; set; }
		public string Name { get; set; }
		public ApplicationType ApplicationType { get; set; }
		public bool Active { get; set; }
		public int RefreshTokenLifeTime { get; set; }
		public string AllowedOrigin { get; set; }
	}

	public class EmployeeReturnModel
	{
		public string Url { get; set; }
		public int Id { get; set; }
	}
}