using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OUDPToSapDepartmentEntityMapperProfile : Profile
	{
		public OUDPToSapDepartmentEntityMapperProfile()
		{
			CreateMap<OUDP, SapDepartmentEntity>()
				.ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Father, opt => opt.MapFrom(src => src.Father))
				.ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks));
		}
	}
}