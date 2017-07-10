using AutoMapper;
using Newtonsoft.Json;
using sapHowmuch.Api.Business.Events;
using sapHowmuch.Api.Common.Extensions;
using sapHowmuch.Api.Common.Helpers;
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
	public class JournalVoucherCreatedEventHandler : BaseEventHandler<JournalVoucherCreatedEvent>
	{
		private readonly IBaseRepository<EventStream> _eventRepository;
		private readonly string _eventType;

		public JournalVoucherCreatedEventHandler(IBaseRepository<EventStream> eventRepository)
		{
			if (eventRepository == null)
			{
				throw new ArgumentNullException(nameof(eventRepository));
			}

			this._eventRepository = eventRepository;
			this._eventType = typeof(JournalVoucherCreatedEvent).FullName;
		}

		protected override async Task<IEnumerable<BaseEvent>> OnLoadAsync(Guid streamId)
		{
			var streams = await this._eventRepository
				.Get()
				.Where(p => p.EventType.Equals(this._eventType, StringComparison.InvariantCultureIgnoreCase))
				.OrderByDescending(p => p.Sequence)
				.ToListAsync();

			var events = streams.Select(p => JsonConvert.DeserializeObject<JournalVoucherCreatedEvent>(p.EventBody));

			return events;
		}

		protected override async Task<bool> OnProcessingAsync(BaseEvent ev)
		{
			var @event = (ev as JournalVoucherCreatedEvent);
			var stream = Mapper.Map<EventStream>(@event);
			this._eventRepository.Add(stream);

			SAPbobsCOM.JournalVouchers voucher = null;

			try
			{
				if (@event.Entries.Count() > 0)
				{
					voucher = SapCompany.DICompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oJournalVouchers) as SAPbobsCOM.JournalVouchers;

					foreach (var entry in @event.Entries)
					{
						try
						{
							voucher.JournalEntries.ReferenceDate = entry.ReferenceDate;

							#region for test 2017-07-07

							//voucher.JournalEntries.Memo = entry.Memo;
							// NOTE: 임시 테스트를 위해 적요에 해당 steamId를 삽입 후 추후 조회에서 처리
							// TODO: 추후 유저필드 추가 후에 해당 필드로 변경필요
							voucher.JournalEntries.Memo = @event.EventStream.ToString();

							#endregion

							voucher.JournalEntries.DueDate = entry.DueDate;

							foreach (var entryLine in entry.Lines)
							{
								voucher.JournalEntries.Lines.AccountCode = entryLine.AccountCode;
								voucher.JournalEntries.Lines.Debit = Convert.ToDouble(entryLine.Debit);
								voucher.JournalEntries.Lines.Credit = Convert.ToDouble(entryLine.Credit);
								voucher.JournalEntries.Lines.DueDate = entryLine.DueDate;
								voucher.JournalEntries.Lines.ShortName = entryLine.ShortName;
								voucher.JournalEntries.Lines.LineMemo = entryLine.LineMemo;
								voucher.JournalEntries.Lines.BaseSum = Convert.ToDouble(entryLine.BaseSum);
								// TODO: 유저필드 셋팅

								voucher.JournalEntries.Lines.Add();
							}
						}
						catch (Exception ex)
						{
							sapHowmuchLogger.Error($"One or more Journal Entry is not valid");
							throw ex;
						}

						var entryResult = voucher.JournalEntries.Add();

						if (entryResult != 0)
						{
							sapHowmuchLogger.Error("전표 추가 에러"); // TODO: 예외 처리 조정
							throw new Exception($"SBO Error Code: {SapCompany.DICompany.GetLastErrorCode()}, Error Description: {SapCompany.DICompany.GetLastErrorDescription()}");
						}
					}
				}

				int result = voucher.Add();

				if (result != 0)
				{
					sapHowmuchLogger.Error("분개장 추가 에러"); // TODO: 예외 처리 조정
					throw new Exception($"SBO Error Code: {SapCompany.DICompany.GetLastErrorCode()}, Error Description: {SapCompany.DICompany.GetLastErrorDescription()}");
				}

				// NOTE: xml 파일로 저장하더라도, 실제적으로 해당 분개장 번호는 리턴되지 않음
				// streamId 를 특정 컬럼에 저장한다음
				// 추후 그 streamId로 조회해서 키값을 얻어와야 할 것으로 보임
				// 이 작업은 controller 단에서 처리하는 방향으로 결정

				//@event.VoucherListNumber = 0;
			}
			catch (Exception ex)
			{
				if (voucher != null) ComObjectHelper.ReleaseComObject(voucher);

				sapHowmuchLogger.Error($"Journal vourcher create failed: {ex.Message}");

				throw ex;
			}

			return await Task.FromResult(true);
		}
	}
}