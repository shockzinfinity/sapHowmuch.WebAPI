using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OPRCToSapBudgetDepartmentEntityMapperProfile : Profile
	{
		public OPRCToSapBudgetDepartmentEntityMapperProfile()
		{
			CreateMap<OPRC, SapBudgetDepartmentEntity>()
				.ForMember(dest => dest.PrcCode, opt => opt.MapFrom(src => src.PrcCode))
				.ForMember(dest => dest.PrcName, opt => opt.MapFrom(src => src.PrcName));
		}
	}
}