using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OPRCToSapCostCenterEntityMapperProfile : Profile
	{
		public OPRCToSapCostCenterEntityMapperProfile()
		{
			CreateMap<OPRC, SapCostCenterEntity>()
				.ForMember(dest => dest.PrcCode, opt => opt.MapFrom(src => src.PrcCode))
				.ForMember(dest => dest.PrcName, opt => opt.MapFrom(src => src.PrcName));
		}
	}
}