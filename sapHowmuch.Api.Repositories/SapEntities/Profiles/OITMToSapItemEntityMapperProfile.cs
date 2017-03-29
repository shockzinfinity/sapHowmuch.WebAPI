using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OITMToSapItemEntityMapperProfile : Profile
	{
		public OITMToSapItemEntityMapperProfile()
		{
			CreateMap<OITM, SapItemEntity>()
				.ForMember(dest => dest.ItemCode, opt => opt.MapFrom(src => src.ItemCode))
				.ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
				.ForMember(dest => dest.ItemGroup, opt => opt.MapFrom(src => src.ItmsGrpCod));
		}
	}
}