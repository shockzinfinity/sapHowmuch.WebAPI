using sapHowmuch.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// 사원 컨트롤러
	/// </summary>
	[RoutePrefix("api/employee")]
	public class EmployeeController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;

		/// <summary>
		/// Initialises a new instance of the <see cref="EmployeeController" /> class.
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance.</param>
		public EmployeeController(ISapQueryRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			this._repository = repository;
		}

		/// <summary>
		/// Gets employee list.
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public async Task<IHttpActionResult> Get()
		{
			var list = await _repository.GetEmployees();

			if (list.Count() > 0)
			{
				return Ok(_repository.GetEmployees().Result);
			}

			return NotFound();
		}

		/// <summary>
		/// Gets employee info of given id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Route("{id}")]
		public async Task<IHttpActionResult> Get(int id)
		{
			var employee = await _repository.GetEmployees();

			if (employee != null)
			{
				return Ok(employee);
			}

			return NotFound();
		}

		/// <summary>
		/// Gets employee info of given name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[Route("{name}")]
		public async Task<IHttpActionResult> Get(string name)
		{
			var employee = await _repository.GetEmployeeBy(name);

			if (employee != null)
			{
				return Ok(employee);
			}

			return NotFound();
		}
	}
}