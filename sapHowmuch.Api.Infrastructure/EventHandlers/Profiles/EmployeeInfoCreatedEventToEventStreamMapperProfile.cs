using AutoMapper;
using Newtonsoft.Json;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Infrastructure.EventHandlers.Profiles
{
	public class EmployeeInfoCreatedEventToEventStreamMapperProfile : Profile
	{
		public EmployeeInfoCreatedEventToEventStreamMapperProfile()
		{
			CreateMap<EmployeeInfoCreatedEvent, EventStream>()
				.ForMember(dest => dest.StreamId, opt => opt.MapFrom(src => src.EventStream))
				.ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.GetType().FullName))
				.ForMember(dest => dest.EventBody, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src)))
				.ForMember(dest => dest.DateProjected, opt => opt.MapFrom(src => src.Projector.DateProjected))
				.ForMember(dest => dest.ProjectedBy, opt => opt.MapFrom(src => src.Projector.ProjectorId));
		}
	}
}