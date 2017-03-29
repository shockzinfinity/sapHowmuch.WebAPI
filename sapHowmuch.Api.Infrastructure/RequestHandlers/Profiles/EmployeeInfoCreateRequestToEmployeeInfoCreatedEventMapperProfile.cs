using AutoMapper;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models.Requests;

namespace sapHowmuch.Api.Infrastructure.RequestHandlers.Profiles
{
	public class EmployeeInfoCreateRequestToEmployeeInfoCreatedEventMapperProfile : Profile
	{
		public EmployeeInfoCreateRequestToEmployeeInfoCreatedEventMapperProfile()
		{
			CreateMap<EmployeeInfoCreateRequest, EmployeeInfoCreatedEvent>()
				.ForMember(dest => dest.EventStream, opt => opt.MapFrom(src => src.StreamId))
				.ForMember(dest => dest.ExtEmpno, opt => opt.MapFrom(src => src.ExtEmpno))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
				.ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
				.ForMember(dest => dest.TermDate, opt => opt.MapFrom(src => src.TermDate))
				.ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
				.ForMember(dest => dest.Dept, opt => opt.MapFrom(src => src.Dept))
				.ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
				.ForMember(dest => dest.HomeCountr, opt => opt.MapFrom(src => src.HomeCountr))
				.ForMember(dest => dest.BrthCountr, opt => opt.MapFrom(src => src.BrthCountr))
				.ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
				.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
				.ForMember(dest => dest.HomeTel, opt => opt.MapFrom(src => src.HomeTel))
				.ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Mobile))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
				.ForMember(dest => dest.HomeStreet, opt => opt.MapFrom(src => src.HomeStreet))
				.ForMember(dest => dest.HomeZip, opt => opt.MapFrom(src => src.HomeZip))
				.ForMember(dest => dest.MartStatus, opt => opt.MapFrom(src => src.MartStatus));
		}
	}
}