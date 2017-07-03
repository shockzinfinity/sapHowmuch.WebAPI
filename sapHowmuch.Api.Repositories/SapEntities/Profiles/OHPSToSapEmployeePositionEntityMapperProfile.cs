using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OHPSToSapEmployeePositionEntityMapperProfile : Profile
	{
		public OHPSToSapEmployeePositionEntityMapperProfile()
		{
			CreateMap<OHPS, SapEmployeePositionEntity>()
				.ForMember(dest => dest.PosID, opt => opt.MapFrom(src => src.posID))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
				.ForMember(dest => dest.LocFields, opt => opt.MapFrom(src => src.LocFields))
				.ForMember(dest => dest.Descriptio, opt => opt.MapFrom(src => src.descriptio));
		}
	}
}