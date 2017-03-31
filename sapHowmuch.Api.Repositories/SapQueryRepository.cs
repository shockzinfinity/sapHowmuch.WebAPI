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

		public virtual async Task<IEnumerable<SapBusinessPartnerEntity>> GetBuisnessPartners()
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

		private async Task<IQueryable<TEntity>> GetAsync<TEntity>() where TEntity : class
		{
			return await Task.FromResult(this._context.Set<TEntity>()).ConfigureAwait(false);
		}

		private async Task<IQueryable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
		{
			return await Task.FromResult(this._context.Set<TEntity>().Where(filter)).ConfigureAwait(false);
		}
	}
}