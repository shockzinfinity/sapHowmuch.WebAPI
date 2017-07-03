using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class ODIMToSapDimensionEntityMapperProfile : Profile
	{
		public ODIMToSapDimensionEntityMapperProfile()
		{
			CreateMap<ODIM, SapDimensionEntity>()
				.ForMember(dest => dest.DimCode, opt => opt.MapFrom(src => src.DimCode))
				.ForMember(dest => dest.DimName, opt => opt.MapFrom(src => src.DimName))
				.ForMember(dest => dest.DimActive, opt => opt.MapFrom(src => (src.DimActive == "Y") ? true : false))
				.ForMember(dest => dest.DimDescription, opt => opt.MapFrom(src => src.DimDesc));
		}
	}
}