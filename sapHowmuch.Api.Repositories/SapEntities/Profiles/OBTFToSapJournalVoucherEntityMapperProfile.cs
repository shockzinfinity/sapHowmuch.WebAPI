using AutoMapper;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Repositories.SapEntities.Profiles
{
	public class OBTFToSapJournalVoucherEntityMapperProfile : Profile
	{
		public OBTFToSapJournalVoucherEntityMapperProfile()
		{
			CreateMap<OBTF, SapJournalVoucherEntity>()
				.ForMember(dest => dest.BatchNum, opt => opt.MapFrom(src => src.BatchNum))
				.ForMember(dest => dest.TransId, opt => opt.MapFrom(src => src.TransId))
				.ForMember(dest => dest.BtfStatus, opt => opt.MapFrom(src => src.BtfStatus))
				.ForMember(dest => dest.TransType, opt => opt.MapFrom(src => src.TransType))
				.ForMember(dest => dest.BaseRef, opt => opt.MapFrom(src => src.BaseRef))
				.ForMember(dest => dest.RefDate, opt => opt.MapFrom(src => src.RefDate))
				.ForMember(dest => dest.Memo, opt => opt.MapFrom(src => src.Memo))
				.ForMember(dest => dest.LocTotal, opt => opt.MapFrom(src => src.LocTotal))
				.ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
				.ForMember(dest => dest.TaxDate, opt => opt.MapFrom(src => src.TaxDate))
				.ForMember(dest => dest.FinncPriod, opt => opt.MapFrom(src => src.FinncPriod))
				.ForMember(dest => dest.ObjType, opt => opt.MapFrom(src => src.ObjType))
				.ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
				.ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate));
		}
	}
}