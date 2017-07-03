using sapHowmuch.Api.Infrastructure.Models.Responses.Data;

namespace sapHowmuch.Api.Business.Models.Responses.Data
{
	public class CountryCreateResponseData : BaseResponseData
	{
		public string Code { get; set; }
		public string Name { get; set; }
	}
}