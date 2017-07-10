using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Business.Models.Responses;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Responses;
using System;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Services
{
	/// <summary>
	/// This provides interfaces to the <see cref="EventStreamService" /> class.
	/// </summary>
	public interface IEventStreamService : IDisposable
	{
		/// <summary>
		/// Creates a new event stream asynchronously.
		/// </summary>
		/// <param name="request">The <see cref="EventStreamCreateRequest" /> instance.</param>
		/// <returns>Returns the <see cref="EventStreamCreateResponse" /> instance.</returns>
		Task<EventStreamCreateResponse> CreateEventStreamAsync(EventStreamCreateRequest request);

		/// <summary>
		/// Creates employee info asynchronously.
		/// </summary>
		/// <param name="request">The <see cref="EmployeeInfoCreateRequest" /> instance.</param>
		/// <returns>Returns the <see cref="EmployeeInfoCreateResponse" /> instance.</returns>
		Task<EmployeeInfoCreateResponse> CreateEmployeeInfoAsync(EmployeeInfoCreateRequest request);

		/// <summary>
		/// Creates country
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		Task<CountryCreateResponse> CreateCountryAsync(CountryCreateRequest request);

		/// <summary>
		/// Create Journal Voucher
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		Task<JournalVoucherCreateResponse> CreateJournalVoucherAsync(JournalVoucherCreateRequest request);
	}
}