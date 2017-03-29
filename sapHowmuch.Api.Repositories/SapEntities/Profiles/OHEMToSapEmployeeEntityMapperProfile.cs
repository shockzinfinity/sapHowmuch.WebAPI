using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OHEMToSapEmployeeEntityMapperProfile : Profile
	{
		public OHEMToSapEmployeeEntityMapperProfile()
		{
			CreateMap<OHEM, SapEmployeeInfoEntity>()
				.ForMember(dest => dest.empId, opt => opt.MapFrom(src => src.empID))
				.ForMember(dest => dest.ExtEmpno, opt => opt.MapFrom(src => src.ExtEmpNo))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
				.ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.startDate))
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status))
				.ForMember(dest => dest.TermDate, opt => opt.MapFrom(src => src.termDate))
				.ForMember(dest => dest.Dept, opt => opt.MapFrom(src => src.dept))
				.ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.position))
				.ForMember(dest => dest.HomeCountr, opt => opt.MapFrom(src => src.homeCountr))
				.ForMember(dest => dest.BrthCountr, opt => opt.MapFrom(src => src.BirthPlace))
				.ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.sex))
				.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.birthDate))
				.ForMember(dest => dest.HomeTel, opt => opt.MapFrom(src => src.homeTel))
				.ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.mobile))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
				.ForMember(dest => dest.HomeStreet, opt => opt.MapFrom(src => src.homeStreet))
				.ForMember(dest => dest.StreetNoH, opt => opt.MapFrom(src => src.StreetNoH))
				.ForMember(dest => dest.HomeZip, opt => opt.MapFrom(src => src.homeZip))
				.ForMember(dest => dest.MartStatus, opt => opt.MapFrom(src => src.martStatus))
				.ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));
		}
	}
}