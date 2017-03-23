using sapHowmuch.Api.Infrastructure.Models.Responses.Data;

namespace sapHowmuch.Api.Infrastructure.Models.Responses
{
	/// <summary>
	/// This represents the base response entity.
	/// </summary>
	/// <typeparam name="T">Type of response data.</typeparam>
	public class BaseResponse<T> where T : BaseResponseData
	{
		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		public T Data { get; set; }

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		public ResponseError Error { get; set; }
	}
}