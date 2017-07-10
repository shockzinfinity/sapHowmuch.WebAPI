using sapHowmuch.Api.Web.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// Client 인증 관련 컨트롤러
	/// </summary>
	[ApiExplorerSettings(IgnoreApi = true)] // hide specific controller in swagger controller list
	[Authorize(Roles = "SuperAdmin")]
	[RoutePrefix("api/audience")]
	public class AudienceController : BaseApiController
	{
		/// <summary>
		/// Get all clients.
		/// </summary>
		/// <returns></returns>
		 [Route("")]
		public IHttpActionResult GetAudiences()
		{
			var lists = this.AppRefreshTokenManager.GetClients();

			return Ok(lists);
		}

		/// <summary>
		/// Create new client.
		/// </summary>
		/// <param name="clientModel"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("")]
		public async Task<IHttpActionResult> CreateClient([FromBody] ClientBindingModel clientModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var newClient = await this.AppRefreshTokenManager.AddClientAsync(clientModel);

			if (newClient != null)
			{
				return Ok(this.TheModelFactory.Create(newClient));
			}

			ModelState.AddModelError("", $"Client: '{clientModel.Name}' could not be added to clients.");

			return BadRequest(ModelState);
		}

		/// <summary>
		/// Delete user
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("{id:guid}", Name = "DeleteClient")]
		public async Task<IHttpActionResult> DeleteClient(string id)
		{
			var client = this.AppRefreshTokenManager.FindClient(id);
			if (client != null)
			{
				var result = await this.AppRefreshTokenManager.RemoveClient(id);

				if (!result)
				{
					ModelState.AddModelError("", $"Client: '{id}' could not delete.");

					return BadRequest(ModelState);
				}

				return Ok();
			}

			return NotFound();
		}
	}
}