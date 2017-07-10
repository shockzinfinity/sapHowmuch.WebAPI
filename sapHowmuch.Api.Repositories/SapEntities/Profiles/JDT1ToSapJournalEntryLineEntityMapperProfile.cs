using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class JDT1ToSapJournalEntryLineEntityMapperProfile : Profile
	{
		public JDT1ToSapJournalEntryLineEntityMapperProfile()
		{
			CreateMap<JDT1, SapJournalEntryLineEntity>()
				.ForMember(dest => dest.TransId, opt => opt.MapFrom(src => src.TransId))
				.ForMember(dest => dest.Line_ID, opt => opt.MapFrom(src => src.Line_ID))
				.ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
				.ForMember(dest => dest.DebCred, opt => opt.MapFrom(src => src.DebCred))
				.ForMember(dest => dest.Debit, opt => opt.MapFrom(src => src.Debit))
				.ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
				.ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
				.ForMember(dest => dest.RefDate, opt => opt.MapFrom(src => src.RefDate))
				.ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
				.ForMember(dest => dest.ContraAct, opt => opt.MapFrom(src => src.ContraAct));
		}
	}
}