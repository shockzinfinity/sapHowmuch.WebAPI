using AutoMapper;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.RequestHandlers;

namespace sapHowmuch.Api.Business.RequestHandlers
{
	/// <summary>
	/// This represents the request handler entity for employee info create.
	/// </summary>
	public class EmployeeInfoCreateRequestHandler : BaseRequestHandler<EmployeeInfoCreateRequest, EmployeeInfoCreatedEvent>
	{
		/// <summary>
		/// Called while creating the event from the request.
		/// </summary>
		/// <param name="request">Request instance.</param>
		/// <returns>Returns the event created.</returns>
		protected override EmployeeInfoCreatedEvent OnCreatingEvent(BaseRequest request)
		{
			var @event = Mapper.Map<EmployeeInfoCreatedEvent>(request as EmployeeInfoCreateRequest);

			return @event;
		}
	}
}