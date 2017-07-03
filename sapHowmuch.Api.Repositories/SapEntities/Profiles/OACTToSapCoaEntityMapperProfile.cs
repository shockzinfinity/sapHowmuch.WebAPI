using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OACTToSapCoaEntityMapperProfile : Profile
	{
		public OACTToSapCoaEntityMapperProfile()
		{
			CreateMap<OACT, SapCoaEntity>()
				.ForMember(dest => dest.AcctCode, opt => opt.MapFrom(src => src.AcctCode))
				.ForMember(dest => dest.AcctName, opt => opt.MapFrom(src => src.AcctName))
				.ForMember(dest => dest.ActType, opt => opt.MapFrom(src => src.ActType))
				.ForMember(dest => dest.Levels, opt => opt.MapFrom(src => src.Levels))
				.ForMember(dest => dest.ValidFor, opt => opt.MapFrom(src => src.ValidFor))
				.ForMember(dest => dest.ActCurr, opt => opt.MapFrom(src => src.ActCurr))
				.ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
				.ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate));
		}
	}
}