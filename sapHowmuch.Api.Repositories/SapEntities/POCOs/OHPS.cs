using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	public partial class OHPS
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int posID { get; set; }

		[Required]
		[StringLength(20)]
		public string name { get; set; }

		[Column(TypeName = "ntext")]
		public string descriptio { get; set; }

		[StringLength(1)]
		public string LocFields { get; set; }
	}
}