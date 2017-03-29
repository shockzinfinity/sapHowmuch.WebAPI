using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OHSTToSapEmployeeStatusEntityMapperProfile : Profile
	{
		public OHSTToSapEmployeeStatusEntityMapperProfile()
		{
			CreateMap<OHST, SapEmployeeStatusEntity>()
				.ForMember(dest => dest.StatusID, opt => opt.MapFrom(src => src.statusID))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
				.ForMember(dest => dest.Descriptio, opt => opt.MapFrom(src => src.descriptio));
		}
	}
}