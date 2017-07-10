using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OVTGToSapVatGroupEntityMapperProfile : Profile
	{
		public OVTGToSapVatGroupEntityMapperProfile()
		{
			CreateMap<OVTG, SapVatGroupEntity>()
				.ForMember(dest => dest.VatCode, opt => opt.MapFrom(src => src.Code))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
				.ForMember(dest => dest.ReportCode, opt => opt.MapFrom(src => src.ReportCode))
				.ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account));
		}
	}
}