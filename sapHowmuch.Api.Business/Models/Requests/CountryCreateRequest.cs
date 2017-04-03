using sapHowmuch.Api.Infrastructure.Models.Requests;

namespace sapHowmuch.Api.Business.Models.Requests
{
	public class CountryCreateRequest : BaseRequest
	{
		public string Code { get; set; }
		public string Name { get; set; }
	}
}