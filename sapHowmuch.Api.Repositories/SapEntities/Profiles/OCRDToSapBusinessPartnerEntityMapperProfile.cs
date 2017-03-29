using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OCRDToSapBusinessPartnerEntityMapperProfile : Profile
	{
		public OCRDToSapBusinessPartnerEntityMapperProfile()
		{
			CreateMap<OCRD, SapBusinessPartnerEntity>()
				.ForMember(dest => dest.CardCode, opt => opt.MapFrom(src => src.CardCode))
				.ForMember(dest => dest.CardName, opt => opt.MapFrom(src => src.CardName))
				.ForMember(dest => dest.CardType, opt => opt.MapFrom(src => src.CardType));
		}
	}
}