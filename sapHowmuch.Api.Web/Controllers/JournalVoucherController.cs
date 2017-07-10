using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Business.Models.Responses;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Responses.Data;
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
	/// Journal Voucher 컨트롤러
	/// </summary>
	[Authorize]
	[LoggingFilter]
	[RoutePrefix("api/voucher")]
	public class JournalVoucherController : BaseApiController
	{
		private readonly ISapQueryRepository _repository;
		private readonly IEventStreamService _service;

		/// <summary>
		/// Initialize a new instance of the <see cref="JournalVoucherController" /> class
		/// </summary>
		/// <param name="repository"><c>SapQueryRepository</c> instance</param>
		/// <param name="service"><c>EventStreamService</c> instance</param>
		public JournalVoucherController(ISapQueryRepository repository, IEventStreamService service)
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
		/// Get all voucher lists
		/// </summary>
		/// <returns></returns>
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(_repository.GetJournalVouchersLists().Result);
		}

		/// <summary>
		/// Get a specific voucher list
		/// </summary>
		/// <param name="batchNum"></param>
		/// <returns></returns>
		[Route("{batchNum}")]
		public async Task<IHttpActionResult> Get(int batchNum)
		{
			var list = await _repository.GetJournalVouchersListBy(batchNum);

			if (list != null)
			{
				return Ok(list);
			}

			return NotFound();
		}

		/// <summary>
		/// Create Journal Voucher
		/// </summary>
		/// <param name="request">The <see cref="JournalVoucherCreateRequest" /> instance</param>
		/// <returns>Returns the <see cref="JournalVoucherCreateResponse" /> instance</returns>
		[HttpPost]
		[Route("add")]
		public async Task<JournalVoucherCreateResponse> AddVoucher(JournalVoucherCreateRequest request)
		{
			JournalVoucherCreateResponse response;
			
			// TODO: validation logic (라인 체크 및 기타 등등) - 일단 수동으로 체크

			if (request == null || request.Entries == null || request.Entries.Count() < 1)
			{
				response = new JournalVoucherCreateResponse
				{
					Error = new ResponseError
					{
						Message = "Bad request"
					}
				};

				return await Task.FromResult(response);
			}

			// NOTE: 이벤트 스트림 생성
			var eventStreamRequest = new EventStreamCreateRequest() { StreamId = Guid.NewGuid() };
			var eventStreamResponse = await this._service.CreateEventStreamAsync(eventStreamRequest);


			if (eventStreamResponse.Error != null)
			{
				response = new JournalVoucherCreateResponse()
				{
					Error = eventStreamResponse.Error
				};
			}

			request.StreamId = eventStreamResponse.Data.StreamId;

			response = await this._service.CreateJournalVoucherAsync(request);

			// memo 에 테스트를 위해 streamId 를 넣었음
			// 해당 streamId를 조회

			var result = await _repository.GetJournalVouchersListBy(request.StreamId);

			response.Data.VoucherListNumber = result.BatchNum;

			return await Task.FromResult(response);
		}
	}
}