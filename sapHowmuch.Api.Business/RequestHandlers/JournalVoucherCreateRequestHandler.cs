using AutoMapper;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Business.Models.Requests;
using sapHowmuch.Api.Infrastructure.Models.Requests;
using sapHowmuch.Api.Infrastructure.RequestHandlers;

namespace sapHowmuch.Api.Business.RequestHandlers
{
	public class JournalVoucherCreateRequestHandler : BaseRequestHandler<JournalVoucherCreateRequest, JournalVoucherCreatedEvent>
	{
		protected override JournalVoucherCreatedEvent OnCreatingEvent(BaseRequest request)
		{
			var @event = Mapper.Map<JournalVoucherCreatedEvent>(request as JournalVoucherCreateRequest);

			return @event;
		}
	}
}