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
	/// 국가 컨트롤러
	/// </summary>
	[Authorize]
	[LoggingFilter]
	[RoutePrefix("api/country")]
	public class CountryController : BaseApiController
	{
		private readonly ISapQueryRepository _queryRepository;
		private readonly IEventStreamService _service;

		/// <summary>
		/// Initialises a new instance of the <see cref="CountryController" /> class.
		/// </summary>
		/// <param name="queryRepository"><c>SapQueryRepository</c> instance.</param>
		/// <param name="service"><c>EventStreamService</c> instance.</param>
		public CountryController(ISapQueryRepository queryRepository, IEventStreamService service)
		{
			if (queryRepository == null)
			{
				throw new ArgumentNullException(nameof(queryRepository));
			}

			this._queryRepository = queryRepository;

			if (service == null)
			{
				throw new ArgumentNullException(nameof(service));
			}

			this._service = service;
		}

		/// <summary>
		/// Get countries
		/// </summary>
		[Route("")]
		public async Task<IHttpActionResult> Get()
		{
			var list = await _queryRepository.GetCountries();

			if (list.Count() > 0)
			{
				return Ok(list);
			}

			return NotFound();
		}

		/// <summary>
		/// Get country by country code.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		[Route("{code}")]
		public async Task<IHttpActionResult> Get(string code)
		{
			var country = await _queryRepository.GetCountrieBy(code);

			if (country != null)
			{
				return Ok(country);
			}

			return NotFound();
		}

		[HttpPost]
		[Route("add-country")]
		public async Task<CountryCreateResponse> AddCountry(CountryCreateRequest request)
		{
			var eventStreamRequest = new EventStreamCreateRequest() { StreamId = Guid.NewGuid() };
			var eventStreamResponse = await this._service.CreateEventStreamAsync(eventStreamRequest);

			CountryCreateResponse response;

			if (eventStreamResponse.Error != null)
			{
				response = new CountryCreateResponse()
				{
					Error = eventStreamResponse.Error
				};

				return await Task.FromResult(response);
			}

			request.StreamId = eventStreamResponse.Data.StreamId;
			response = await this._service.CreateCountryAsync(request);

			return await Task.FromResult(response);
		}
	}
}