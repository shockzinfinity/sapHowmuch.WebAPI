using AutoMapper;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Business.Models.Requests;

namespace sapHowmuch.Api.Business.RequestHandlers.Profiles
{
	public class CountryCreateRequestToCountryCreatedEventMapperProfile : Profile
	{
		public CountryCreateRequestToCountryCreatedEventMapperProfile()
		{
			CreateMap<CountryCreateRequest, CountryCreatedEvent>()
				.ForMember(dest => dest.EventStream, opt => opt.MapFrom(src => src.StreamId))
				.ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.Code))
				.ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Name));
		}
	}
}