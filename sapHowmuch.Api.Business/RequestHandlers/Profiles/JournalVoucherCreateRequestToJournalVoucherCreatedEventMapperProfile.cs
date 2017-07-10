using AutoMapper;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Business.Models.Requests;

namespace sapHowmuch.Api.Business.RequestHandlers.Profiles
{
	public class JournalVoucherCreateRequestToJournalVoucherCreatedEventMapperProfile : Profile
	{
		public JournalVoucherCreateRequestToJournalVoucherCreatedEventMapperProfile()
		{
			CreateMap<JournalVoucherCreateRequest, JournalVoucherCreatedEvent>()
				.ForMember(dest => dest.EventStream, opt => opt.MapFrom(src => src.StreamId))
				.ForMember(dest => dest.Entries, opt => opt.MapFrom(src => src.Entries));
		}
	}
}