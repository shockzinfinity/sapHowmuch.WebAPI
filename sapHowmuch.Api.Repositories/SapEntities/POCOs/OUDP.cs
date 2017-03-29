using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("OUDP")]
	public partial class OUDP
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public short Code { get; set; }

		[Required]
		[StringLength(20)]
		public string Name { get; set; }

		[StringLength(100)]
		public string Remarks { get; set; }

		public short? UserSign { get; set; }

		[StringLength(20)]
		public string Father { get; set; }
	}
}