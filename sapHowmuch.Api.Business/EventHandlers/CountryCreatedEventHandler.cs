using AutoMapper;
using Newtonsoft.Json;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Common.Extensions;
using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.EventHandlers;
using sapHowmuch.Api.Infrastructure.Events;
using sapHowmuch.Api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Business.EventHandlers
{
	public class CountryCreatedEventHandler : BaseEventHandler<CountryCreatedEvent>
	{
		private readonly IBaseRepository<EventStream> _eventRepository;
		private readonly string _eventType;

		public CountryCreatedEventHandler(IBaseRepository<EventStream> eventRepository)
		{
			if (eventRepository == null)
			{
				throw new ArgumentNullException(nameof(eventRepository));
			}

			this._eventRepository = eventRepository;
			this._eventType = typeof(CountryCreatedEvent).FullName;
		}

		protected override async Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId)
		{
			var streams = await this._eventRepository
				.Get()
				.Where(p => p.EventType.Equals(this._eventType, StringComparison.InvariantCultureIgnoreCase))
				.OrderByDescending(p => p.Sequence)
				.ToListAsync();

			var events = streams.Select(p => JsonConvert.DeserializeObject<CountryCreatedEvent>(p.EventBody));

			return events;
		}

		protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
		{
			var @event = (ev as CountryCreatedEvent);
			var stream = Mapper.Map<EventStream>(@event);

			this._eventRepository.Add(stream);

			SAPbobsCOM.CountriesService countriesService = null;
			SAPbobsCOM.CountryParams countryParams = null;
			SAPbobsCOM.Country country = null;

			try
			{
				countriesService = SapCompany.DICompany.GetCompanyService().GetBusinessService(SAPbobsCOM.ServiceTypes.CountriesService) as SAPbobsCOM.CountriesService;
				country = countriesService.GetDataInterface(SAPbobsCOM.CountriesServiceDataInterfaces.csCountry) as SAPbobsCOM.Country;

				country.Code = @event.CountryCode;
				country.Name = @event.CountryName;
				country.AddressFormat = 1;

				countryParams = countriesService.AddCountry(country);

				if (countryParams.Code != country.Code)
				{
					return await Task.FromResult(false);
				}
			}
			catch (Exception ex)
			{
				if (countriesService != null) ComObjectHelper.ReleaseComObject(countriesService);
				if (country != null) ComObjectHelper.ReleaseComObject(country);
				if (countryParams != null) ComObjectHelper.ReleaseComObject(countryParams);

				throw ex;
			}
			finally
			{
				if (countriesService != null) ComObjectHelper.ReleaseComObject(countriesService);
				if (country != null) ComObjectHelper.ReleaseComObject(country);
				if (countryParams != null) ComObjectHelper.ReleaseComObject(countryParams);
			}

			return await Task.FromResult(true);
		}
	}
}