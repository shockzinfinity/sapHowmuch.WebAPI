using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Business.Models.Responses;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Repositories;
using sapHowmuch.Api.Services;
using sapHowmuch.Api.Web.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace sapHowmuch.Api.Web.Controllers
{
	/// <summary>
	/// 사원 컨트롤러
	/// </summary>
	[Authorize]
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
		/// <param name="service"><c>EventStreamService</c> instance.</param>
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
		[Route("add")]
		public async Task<EmployeeInfoCreateResponse> AddEmployee(EmployeeInfoCreateRequest request)
		{
			// NOTE: default flow for api logic
			// 이벤트스트림 생성 -> api 로직 핸들링
			// event stream 에서 기록을 안하기 위해서는 이벤트 스트림 request 를 생성하지 않고,
			// 바로 event stream id 를 생성하면 된다.
			var eventStreamRequest = new EventStreamCreateRequest() { StreamId = Guid.NewGuid() };
			var eventStreamResponse = await this._service.CreateEventStreamAsync(eventStreamRequest);

			EmployeeInfoCreateResponse response;

			if (eventStreamResponse.Error != null)
			{
				response = new EmployeeInfoCreateResponse()
				{
					Error = eventStreamResponse.Error
				};
			}

			request.StreamId = eventStreamResponse.Data.StreamId;

			response = await this._service.CreateEmployeeInfoAsync(request);

			return await Task.FromResult(response);
		}
	}
}