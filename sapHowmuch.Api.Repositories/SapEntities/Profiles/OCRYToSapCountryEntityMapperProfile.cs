using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OCRYToSapCountryEntityMapperProfile : Profile
	{
		public OCRYToSapCountryEntityMapperProfile()
		{
			CreateMap<OCRY, SapCountryEntity>()
				.ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.Code))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
		}
	}
}