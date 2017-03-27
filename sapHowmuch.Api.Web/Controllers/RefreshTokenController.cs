using System.Threading.Tasks;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// Refresh Token 컨트롤러
	/// </summary>
	//[Authorize(Roles = "SuperAdmin")]
	//[ApiExplorerSettings(IgnoreApi = true)] // hide specific controller in swagger controller list
	[RoutePrefix("api/refreshtoken")]
	public class RefreshTokenController : BaseApiController
	{
		/// <summary>
		/// Gets all refresh tokens in current WebApi
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(this.AppRefreshTokenManager.GetAllRefreshTokens());
		}

		/// <summary>
		/// Delete refresh token
		/// </summary>
		/// <param name="tokenId"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("{tokenId}")]
		public async Task<IHttpActionResult> Delete(string tokenId)
		{
			var result = await this.AppRefreshTokenManager.RemoveRefreshToken(tokenId);

			if (result)
			{
				return Ok();
			}

			return BadRequest($"Token : '{tokenId}' does not exist.");
		}
	}
}