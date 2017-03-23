using AutoMapper;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models.Requests;

namespace sapHowmuch.Api.Infrastructure.RequestHandlers.Profiles
{
	public class EventStreamCreateRequestToEventStreamCreatedEventMapperProfile : Profile
	{
		public EventStreamCreateRequestToEventStreamCreatedEventMapperProfile()
		{
			CreateMap<EventStreamCreateRequest, EventStreamCreatedEvent>()
					.ForMember(dest => dest.EventStream, opt => opt.MapFrom(src => src.StreamId));
		}
	}
}