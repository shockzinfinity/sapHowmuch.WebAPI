using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sapHowmuch.Api.Repositories
{
	[Table("ODIM")]
	public partial class ODIM
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public short DimCode { get; set; }

		[StringLength(15)]
		public string DimName { get; set; }

		[StringLength(1)]
		public string DimActive { get; set; }

		[StringLength(50)]
		public string DimDesc { get; set; }
	}
}