using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("OHST")]
	public partial class OHST
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int statusID { get; set; }

		[Required]
		[StringLength(20)]
		public string name { get; set; }

		[Column(TypeName = "ntext")]
		public string descriptio { get; set; }
	}
}