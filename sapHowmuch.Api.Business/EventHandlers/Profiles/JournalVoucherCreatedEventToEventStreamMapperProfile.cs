﻿using AutoMapper;
using Newtonsoft.Json;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Infrastructure.Models;

namespace sapHowmuch.Api.Business.EventHandlers.Profiles
{
	public class JournalVoucherCreatedEventToEventStreamMapperProfile : Profile
	{
		public JournalVoucherCreatedEventToEventStreamMapperProfile()
		{
			CreateMap<JournalVoucherCreatedEvent, EventStream>()
				.ForMember(dest => dest.StreamId, opt => opt.MapFrom(src => src.EventStream))
				.ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.GetType().FullName))
				.ForMember(dest => dest.EventBody, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src)))
				.ForMember(dest => dest.DateProjected, opt => opt.MapFrom(src => src.Projector.DateProjected))
				.ForMember(dest => dest.ProjectedBy, opt => opt.MapFrom(src => src.Projector.ProjectorId));
		}
	}
}