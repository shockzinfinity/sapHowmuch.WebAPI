using AutoMapper;
using sapHowmuch.Api.Common.Interfaces;
using sapHowmuch.Api.Infrastructure.Models;
using sapHowmuch.Api.Repositories.SapEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Repositories
{
	public class SapQueryRepository : ISapQueryRepository
	{
		private readonly IDbContextFactory _contextFactory;
		private SapDbContext _context;

		/// <summary>
		/// Initialises a new instance of the <see cref="SapQueryRepository" /> class.
		/// </summary>
		/// <param name="contextFactory"><c>DbContextFactory</c> instance.</param>
		public SapQueryRepository(IDbContextFactory contextFactory)
		{
			if (contextFactory == null)
			{
				throw new ArgumentNullException(nameof(contextFactory));
			}

			this._contextFactory = contextFactory;

			if (_contextFactory.DbContextType != typeof(SapDbContext))
			{
				throw new InvalidOperationException("This repository needs SapDbContext");
			}

			this._context = this._contextFactory.Context as SapDbContext;
		}

		private bool _disposed;

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing,
		/// or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (_disposed)
			{
				return;
			}

			this._disposed = true;
		}

		#region COA (Chart of Accounts)

		public virtual async Task<IEnumerable<SapCoaEntity>> GetChartOfAccount()
		{
			var query = await GetAsync<OACT>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OACT>, IEnumerable<SapCoaEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapCoaEntity> GetChartOfAccountBy(string code)
		{
			var query = await GetAsync<OACT>(a => a.AcctCode.Equals(code));

			return await Task.FromResult(Mapper.Map<OACT, SapCoaEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		#endregion COA (Chart of Accounts)

		#region Cost Center & Budget Center

		public virtual async Task<IEnumerable<SapCostCenterEntity>> GetCostCenters(int dimCode)
		{
			// NOTE: Sap 측에서 사전 Dim code 가 정의되어야 함.
			// e.g. DimCode = 1 이 코스트센터
			// DimCode = 2 가 예산부서
			// 사전에 정의가 필요함
			var query = await GetAsync<OPRC>(p => p.DimCode.HasValue && p.DimCode == dimCode);

			return await Task.FromResult(Mapper.Map<IEnumerable<OPRC>, IEnumerable<SapCostCenterEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapCostCenterEntity> GetCostCenterBy(int dimCode, string prcCode)
		{
			var query = await GetAsync<OPRC>(p => p.DimCode.HasValue && p.DimCode == dimCode && p.PrcCode.Equals(prcCode));

			return await Task.FromResult(Mapper.Map<OPRC, SapCostCenterEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		public virtual async Task<IEnumerable<SapBudgetDepartmentEntity>> GetBudgetDepartments(int dimCode)
		{
			// NOTE: Sap 측에서 사전 Dim code 가 정의되어야 함.
			// e.g. DimCode = 1 이 코스트센터
			// DimCode = 2 가 예산부서
			// 사전에 정의가 필요함
			var query = await GetAsync<OPRC>(p => p.DimCode.HasValue && p.DimCode == dimCode);

			return await Task.FromResult(Mapper.Map<IEnumerable<OPRC>, IEnumerable<SapBudgetDepartmentEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapBudgetDepartmentEntity> GetBudgetDepartmentBy(int dimCode, string prcCode)
		{
			var query = await GetAsync<OPRC>(p => p.DimCode.HasValue && p.DimCode == dimCode && p.PrcCode.Equals(prcCode));

			return await Task.FromResult(Mapper.Map<OPRC, SapBudgetDepartmentEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		#endregion Cost Center & Budget Center

		#region Employee, Employee Position, Employee Status, Country, Department

		public virtual async Task<IEnumerable<SapEmployeeInfoEntity>> GetEmployees()
		{
			var query = await GetAsync<OHEM>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OHEM>, IEnumerable<SapEmployeeInfoEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapEmployeeInfoEntity> GetEmployeeBy(int id)
		{
			var query = await GetAsync<OHEM>(x => x.empID == id);

			return await Task.FromResult(Mapper.Map<OHEM, SapEmployeeInfoEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		public virtual async Task<SapEmployeeInfoEntity> GetEmployeeBy(string name)
		{
			var query = await GetAsync<OHEM>(x => string.Concat(x.lastName, x.firstName).Equals(name));

			return await Task.FromResult(Mapper.Map<OHEM, SapEmployeeInfoEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		public virtual async Task<IEnumerable<SapCountryEntity>> GetCountries()
		{
			var query = await GetAsync<OCRY>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OCRY>, IEnumerable<SapCountryEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapCountryEntity> GetCountrieBy(string code)
		{
			var query = await GetAsync<OCRY>(c => c.Code.Equals(code));

			return await Task.FromResult(Mapper.Map<OCRY, SapCountryEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		public virtual async Task<IEnumerable<SapEmployeePositionEntity>> GetEmployeePositions()
		{
			var query = await GetAsync<OHPS>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OHPS>, IEnumerable<SapEmployeePositionEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapEmployeePositionEntity> GetEmployeePositionBy(int posId)
		{
			var query = await GetAsync<OHPS>(x => x.posID == posId);

			return await Task.FromResult(Mapper.Map<OHPS, SapEmployeePositionEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		public virtual async Task<IEnumerable<SapEmployeeStatusEntity>> GetEmployeeStatuses()
		{
			var query = await GetAsync<OHST>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OHST>, IEnumerable<SapEmployeeStatusEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapEmployeeStatusEntity> GetEmployeeStatus(int statusId)
		{
			var query = await GetAsync<OHST>(x => x.statusID == statusId);

			return await Task.FromResult(Mapper.Map<OHST, SapEmployeeStatusEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		public virtual async Task<IEnumerable<SapDepartmentEntity>> GetDepartments()
		{
			var query = await GetAsync<OUDP>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OUDP>, IEnumerable<SapDepartmentEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapDepartmentEntity> GetDepartmentBy(int code)
		{
			var query = await GetAsync<OUDP>();

			return await Task.FromResult(Mapper.Map<OUDP, SapDepartmentEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		#endregion Employee, Employee Position, Employee Status, Country, Department

		#region Business Partner

		public virtual async Task<IEnumerable<SapBusinessPartnerEntity>> GetBusinessPartners()
		{
			var query = await GetAsync<OCRD>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OCRD>, IEnumerable<SapBusinessPartnerEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapBusinessPartnerEntity> GetBusinessPartnerBy(string cardCode)
		{
			var query = await GetAsync<OCRD>(b => b.CardCode.Equals(cardCode));

			return await Task.FromResult(Mapper.Map<OCRD, SapBusinessPartnerEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		#endregion Business Partner

		#region Item

		public virtual async Task<IEnumerable<SapItemEntity>> GetItems()
		{
			var query = await GetAsync<OITM>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OITM>, IEnumerable<SapItemEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapItemEntity> GetItemBy(string itemCode)
		{
			var query = await GetAsync<OITM>(i => i.ItemCode.Equals(itemCode));

			return await Task.FromResult(Mapper.Map<OITM, SapItemEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		#endregion Item

		#region Dimension

		public virtual async Task<IEnumerable<SapDimensionEntity>> GetDimensions()
		{
			var query = await GetAsync<ODIM>();

			return await Task.FromResult(Mapper.Map<IEnumerable<ODIM>, IEnumerable<SapDimensionEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapDimensionEntity> GetDimensionBy(int code)
		{
			var query = await GetAsync<ODIM>(d => d.DimCode == code);

			return await Task.FromResult(Mapper.Map<ODIM, SapDimensionEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		#endregion Dimension

		#region Vat Group

		public virtual async Task<IEnumerable<SapVatGroupEntity>> GetVatGroups()
		{
			var query = await GetAsync<OVTG>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OVTG>, IEnumerable<SapVatGroupEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		public virtual async Task<SapVatGroupEntity> GetVatGroupBy(string vatCode)
		{
			var query = await GetAsync<OVTG>(v => v.Code.Equals(vatCode));

			return await Task.FromResult(Mapper.Map<OVTG, SapVatGroupEntity>(query.SingleOrDefault())).ConfigureAwait(false);
		}

		#endregion Vat Group

		#region Journal Voucher

		/// <summary>
		/// 분개장 리스트
		/// </summary>
		/// <returns></returns>
		public virtual async Task<IEnumerable<SapJournalVouchersListEntity>> GetJournalVouchersLists()
		{
			var query = await GetAsync<OBTD>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OBTD>, IEnumerable<SapJournalVouchersListEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		/// <summary>
		/// 분개장
		/// </summary>
		/// <param name="batchNum"></param>
		/// <returns></returns>
		public virtual async Task<SapJournalVouchersListEntity> GetJournalVouchersListBy(int batchNum)
		{
			// TODO: 쿼리 성능 향상, 하위 라인에 대한 쿼리를 하나로 만들 필요가 있다.
			var query = await GetAsync<OBTD>(b => b.BatchNum == batchNum);
			var elementsQuery = await GetAsync<OBTF>(e => e.BatchNum == batchNum);

			SapJournalVouchersListEntity entity = Mapper.Map<OBTD, SapJournalVouchersListEntity>(query.SingleOrDefault());

			if (entity != null)
			{
				IEnumerable<SapJournalVoucherEntity> elements = Mapper.Map<IEnumerable<OBTF>, IEnumerable<SapJournalVoucherEntity>>(elementsQuery.AsEnumerable());
				entity.Elements = elements.ToList();

				if (entity.Elements.Count() > 0)
				{
					foreach (var element in entity.Elements)
					{
						var lineQuery = await GetAsync<BTF1>(l => l.TransId == element.TransId);
						IEnumerable<SapJournalVoucherLineEntity> lines = Mapper.Map<IEnumerable<BTF1>, IEnumerable<SapJournalVoucherLineEntity>>(lineQuery.AsEnumerable());

						element.Lines = lines.ToList();
					}
				}
			}

			return await Task.FromResult(entity).ConfigureAwait(false);
		}

		public virtual async Task<SapJournalVouchersListEntity> GetJournalVouchersListBy(Guid streamId)
		{
			#region for test 2017-07-07

			// NOTE: streamId를 분개의 적요에 임시로 기록한 상태
			var query = await GetAsync<OBTF>(j => j.Memo == streamId.ToString());

			var listQuery = await GetAsync<OBTD>(l => l.BatchNum == query.FirstOrDefault().BatchNum);

			return await Task.FromResult(Mapper.Map<OBTD, SapJournalVouchersListEntity>(listQuery.FirstOrDefault())).ConfigureAwait(false);

			#endregion
		}

		/// <summary>
		/// 분개장 요소 리스트
		/// </summary>
		/// <returns></returns>
		public virtual async Task<IEnumerable<SapJournalVoucherEntity>> GetJournalVouchers()
		{
			var query = await GetAsync<OBTF>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OBTF>, IEnumerable<SapJournalVoucherEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		/// <summary>
		/// 분개장 요소
		/// </summary>
		/// <param name="transId"></param>
		/// <returns></returns>
		public virtual async Task<SapJournalVoucherEntity> GetJournalVoucherBy(int transId)
		{
			// TODO: 쿼리 성능 향상, 하위 라인에 대한 쿼리를 하나로 만들 필요가 있다.
			var query = await GetAsync<OBTF>(h => h.TransId == transId);
			var lineQuery = await GetAsync<BTF1>(b => b.TransId == transId);

			SapJournalVoucherEntity entity = Mapper.Map<OBTF, SapJournalVoucherEntity>(query.SingleOrDefault());

			if (entity != null)
			{
				IEnumerable<SapJournalVoucherLineEntity> lines = Mapper.Map<IEnumerable<BTF1>, IEnumerable<SapJournalVoucherLineEntity>>(lineQuery.AsEnumerable());

				entity.Lines = lines.ToList();
			}

			return await Task.FromResult(entity).ConfigureAwait(false);
		}

		/// <summary>
		/// 분개장 요소 라인
		/// </summary>
		/// <returns></returns>
		public virtual async Task<IEnumerable<SapJournalVoucherLineEntity>> GetJournalVoucherLines(int transId)
		{
			var query = await GetAsync<BTF1>(l => l.TransId == transId);

			return await Task.FromResult(Mapper.Map<IEnumerable<BTF1>, IEnumerable<SapJournalVoucherLineEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		#endregion Journal Voucher

		#region Journal Entry

		/// <summary>
		/// 분개 리스트
		/// </summary>
		/// <returns></returns>
		public virtual async Task<IEnumerable<SapJournalEntryEntity>> GetJournalEntries()
		{
			var query = await GetAsync<OJDT>();

			return await Task.FromResult(Mapper.Map<IEnumerable<OJDT>, IEnumerable<SapJournalEntryEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		/// <summary>
		/// 분개
		/// </summary>
		/// <param name="transId"></param>
		/// <returns></returns>
		public virtual async Task<SapJournalEntryEntity> GetJournalEntryBy(int transId)
		{
			// TODO: 쿼리 성능 향상, 하위 라인에 대한 쿼리를 하나로 만들 필요가 있다.
			var query = await GetAsync<OJDT>(h => h.TransId == transId);
			var lineQuery = await GetAsync<JDT1>(l => l.TransId == transId);

			SapJournalEntryEntity entity = Mapper.Map<OJDT, SapJournalEntryEntity>(query.SingleOrDefault());

			if (entity != null)
			{
				IEnumerable<SapJournalEntryLineEntity> lines = Mapper.Map<IEnumerable<JDT1>, IEnumerable<SapJournalEntryLineEntity>>(lineQuery.AsEnumerable());
				entity.Lines = lines.ToList();
			}

			return await Task.FromResult(entity).ConfigureAwait(false);
		}

		/// <summary>
		/// 분개 라인
		/// </summary>
		/// <returns></returns>
		public virtual async Task<IEnumerable<SapJournalEntryLineEntity>> GetJournalEntryLines(int transId)
		{
			var query = await GetAsync<JDT1>();

			return await Task.FromResult(Mapper.Map<IEnumerable<JDT1>, IEnumerable<SapJournalEntryLineEntity>>(query.AsEnumerable())).ConfigureAwait(false);
		}

		#endregion Journal Entry

		#region private methods

		private async Task<IQueryable<TEntity>> GetAsync<TEntity>() where TEntity : class
		{
			return await Task.FromResult(this._context.Set<TEntity>()).ConfigureAwait(false);
		}

		private async Task<IQueryable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
		{
			return await Task.FromResult(this._context.Set<TEntity>().Where(filter)).ConfigureAwait(false);
		}

		#endregion private methods
	}
}