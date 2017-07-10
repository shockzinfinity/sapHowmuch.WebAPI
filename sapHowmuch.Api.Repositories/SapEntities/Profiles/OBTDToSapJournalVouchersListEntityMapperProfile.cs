using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OBTDToSapJournalVouchersListEntityMapperProfile : Profile
	{
		public OBTDToSapJournalVouchersListEntityMapperProfile()
		{
			CreateMap<OBTD, SapJournalVouchersListEntity>()
				.ForMember(dest => dest.BatchNum, opt => opt.MapFrom(src => src.BatchNum))
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
				.ForMember(dest => dest.NumOfTrans, opt => opt.MapFrom(src => src.NumOfTrans))
				.ForMember(dest => dest.DateID, opt => opt.MapFrom(src => src.DateID));
		}
	}
}