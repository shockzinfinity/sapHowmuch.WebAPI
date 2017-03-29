using sapHowmuch.Api.Infrastructure.Models;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Responses;
using sapHowmuch.Api.Repositories;
using sapHowmuch.Api.Services;
using sapHowmuch.Api.Web.Infrastructure;
using sapHowmuch.Api.Web.Models;
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
	[LoggingFilter]
	[RoutePrefix("api/employee")]
	public class EmployeeController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;
		private readonly IEventStreamService _service;

		/// <summary>
		/// Initialises a new instance of the <see cref="EmployeeController" /> class.
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance.</param>
		public EmployeeController(ISapQueryRepository repository, IEventStreamService service)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			this._repository = repository;

			if (service == null)
			{
				throw new ArgumentNullException(nameof(service));
			}

			this._service = service;
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
				return Ok(list);
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

		/// <summary>
		/// Create employee info 
		/// </summary>
		/// <param name="request">The <see cref="EmployeeInfoCreateRequest" /> instance.</param>
		/// <returns>Returns the <see cref="EmployeeInfoCreateResponse" /> instance. </returns>
		[HttpPost]
		[Route("add-employee")]
		public async Task<EmployeeInfoCreateResponse> AddEmployee(EmployeeInfoCreateRequest request)
		{
			//if (!ModelState.IsValid)
			//{
			//	return BadRequest(ModelState);
			//}

			//var empSap = new SapEmployeeInfoEntity()
			//{
			//	ExtEmpno = toAddEmployee.ExtEmpno,
			//	FirstName = toAddEmployee.FirstName,
			//	LastName = toAddEmployee.LastName,
			//	StartDate = toAddEmployee.StartDate,
			//	Status = toAddEmployee.Status,
			//	TermDate = toAddEmployee.TermDate,
			//	Active = toAddEmployee.Active,
			//	Dept = toAddEmployee.Dept,
			//	Position = toAddEmployee.Position,
			//	HomeCountr = toAddEmployee.HomeCountr,
			//	BrthCountr = toAddEmployee.BrthCountr,
			//	Sex = toAddEmployee.Sex,
			//	BirthDate = toAddEmployee.BirthDate,
			//	HomeTel = toAddEmployee.HomeTel,
			//	Mobile = toAddEmployee.Mobile,
			//	Email = toAddEmployee.Email,
			//	HomeStreet = toAddEmployee.HomeStreet,
			//	HomeZip = toAddEmployee.HomeZip,
			//	MartStatus = toAddEmployee.MartStatus
			//};

			throw new NotImplementedException();
		}
	}
}