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
	/// <summary>
	/// This represents the processor entity for the <see cref="EmployeeInfoCreatedEvent" /> class.
	/// </summary>
	public class EmployeeInfoCreatedEventHandler : BaseEventHandler<EmployeeInfoCreatedEvent>
	{
		private readonly IBaseRepository<EventStream> _eventRepository;

		// TODO: 엔티티에 대한 리파지터리 전략 결정
		private readonly string _eventType;

		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeInfoCreatedEventHandler" /> class.
		/// </summary>
		/// <param name="eventRepository">event stream repository instance.</param>
		public EmployeeInfoCreatedEventHandler(IBaseRepository<EventStream> eventRepository)
		{
			if (eventRepository == null)
			{
				throw new ArgumentNullException(nameof(eventRepository));
			}

			this._eventRepository = eventRepository;

			this._eventType = typeof(EmployeeInfoCreatedEvent).FullName;
		}

		/// <summary>
		/// Called while loading events from the repository asynchronously.
		/// </summary>
		/// <param name="streamId">The stream id.</param>
		/// <returns>Returns the list of events.</returns>
		protected override async Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId)
		{
			var streams = await this._eventRepository
				.Get()
				.Where(p => p.EventType.Equals(this._eventType, StringComparison.InvariantCultureIgnoreCase))
				.OrderByDescending(p => p.Sequence)
				.ToListAsync();

			var events = streams.Select(p => JsonConvert.DeserializeObject<EmployeeInfoCreatedEvent>(p.EventBody));

			return events;
		}

		/// <summary>
		/// Called while processing the event asynchronously.
		/// </summary>
		/// <param name="ev">Event instance.</param>
		/// <returns>Returns <c>True</c>, if the given event has been processed; otherwise returns <c>False</c>.</returns>
		protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
		{
			var @event = (ev as EmployeeInfoCreatedEvent);
			var stream = Mapper.Map<EventStream>(@event);
			this._eventRepository.Add(stream);

			// TODO: SAP 쪽으로 DI Server 혹은 DI API 를 통해서 구체화 필요
			SAPbobsCOM.EmployeesInfo employeeInfo = null;

			try
			{
				employeeInfo = SapCompany.DICompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oEmployeesInfo) as SAPbobsCOM.EmployeesInfo;

				employeeInfo.ExternalEmployeeNumber = @event.ExtEmpno;
				employeeInfo.LastName = @event.LastName;
				employeeInfo.FirstName = @event.FirstName;

				if (@event.StartDate.HasValue)
					employeeInfo.StartDate = @event.StartDate.Value;

				if (@event.Status.HasValue)
					employeeInfo.StatusCode = @event.Status.Value;

				if (@event.TermDate.HasValue)
					employeeInfo.TerminationDate = @event.TermDate.Value;

				if (!string.IsNullOrWhiteSpace(@event.Active))
					employeeInfo.Active = @event.Active.ToSBOYesOrNo();

				if (@event.Dept.HasValue)
					employeeInfo.Department = @event.Dept.Value;

				employeeInfo.Position = @event.Position;
				employeeInfo.HomeCountry = @event.HomeCountr;
				employeeInfo.CountryOfBirth = @event.BrthCountr;

				if (!string.IsNullOrWhiteSpace(@event.Sex))
					employeeInfo.Gender = @event.Sex.ToSBOGenderType();

				if (@event.BirthDate.HasValue)
					employeeInfo.DateOfBirth = @event.BirthDate.Value;

				employeeInfo.HomePhone = @event.HomeTel;
				employeeInfo.MobilePhone = @event.Mobile;
				employeeInfo.eMail = @event.Email;
				employeeInfo.HomeStreet = @event.HomeStreet;
				employeeInfo.HomeZipCode = @event.HomeZip;

				if (!string.IsNullOrWhiteSpace(@event.MartStatus))
					employeeInfo.MartialStatus = @event.MartStatus.ToSBOMeritalStatus();

				// TODO: add 하는 오브젝트의 user field 에 event id 를 넣고,
				// end point 에서 쿼리 리파지터리를 통해
				// 해당 event id 에 해당하는 오브젝트의 id 를 받아오는 방법으로 키를 받도록 한다.

				int result = employeeInfo.Add();

				if (result != 0)
				{
					throw new Exception($"SBO Error code: {SapCompany.DICompany.GetLastErrorCode()}, Error description: {SapCompany.DICompany.GetLastErrorDescription()}");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (employeeInfo != null)
				{
					try
					{
						while (System.Runtime.InteropServices.Marshal.ReleaseComObject(employeeInfo) > 0) ;
					}
					catch
					{
					}
					finally
					{
						employeeInfo = null;
					}
				}
			}

			return await Task.FromResult(true);
		}
	}
}