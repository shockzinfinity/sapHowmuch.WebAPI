using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Web.Infrastructure
{
	[Table("UserProfile")]
	public class UserProfile
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProfileId { get; set; }

		public string FullName { get; set; }
		public DateTime JoinDate { get; set; }
		public string Description { get; set; }
	}
}