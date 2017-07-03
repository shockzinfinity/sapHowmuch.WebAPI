using AutoMapper;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.RequestHandlers;

namespace sapHowmuch.Api.Business.RequestHandlers
{
	public class CountryCreateRequestHandler : BaseRequestHandler<CountryCreateRequest, CountryCreatedEvent>
	{
		protected override CountryCreatedEvent OnCreatingEvent(BaseRequest request)
		{
			var @event = Mapper.Map<CountryCreatedEvent>(request as CountryCreateRequest);

			return @event;
		}
	}
}