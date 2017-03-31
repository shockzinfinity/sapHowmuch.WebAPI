using sapHowmuch.Api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Repositories
{
	public interface ISapQueryRepository : IDisposable
	{
		#region COA (Chart of Accounts)

		Task<IEnumerable<SapCoaEntity>> GetChartOfAccount();

		Task<SapCoaEntity> GetChartOfAccountBy(string code);

		#endregion COA (Chart of Accounts)

		#region Cost Center & Budget Center

		Task<IEnumerable<SapCostCenterEntity>> GetCostCenters(int dimCode);

		Task<SapCostCenterEntity> GetCostCenterBy(int dimCode, string prcCode);

		Task<IEnumerable<SapBudgetDepartmentEntity>> GetBudgetDepartments(int dimCode);

		Task<SapBudgetDepartmentEntity> GetBudgetDepartmentBy(int dimCode, string prcCode);

		#endregion Cost Center & Budget Center

		#region Employee, Employee Position, Employee Status, Country, Department

		Task<IEnumerable<SapEmployeeInfoEntity>> GetEmployees();

		Task<SapEmployeeInfoEntity> GetEmployeeBy(int id);

		Task<SapEmployeeInfoEntity> GetEmployeeBy(string name);

		Task<IEnumerable<SapCountryEntity>> GetCountries();

		Task<SapCountryEntity> GetCountrieBy(string code);

		Task<IEnumerable<SapEmployeePositionEntity>> GetEmployeePositions();

		Task<SapEmployeePositionEntity> GetEmployeePositionBy(int posId);

		Task<IEnumerable<SapEmployeeStatusEntity>> GetEmployeeStatuses();

		Task<SapEmployeeStatusEntity> GetEmployeeStatus(int statusId);

		Task<IEnumerable<SapDepartmentEntity>> GetDepartments();

		Task<SapDepartmentEntity> GetDepartmentBy(int code);

		#endregion Employee, Employee Position, Employee Status, Country, Department

		#region Business Partner

		Task<IEnumerable<SapBusinessPartnerEntity>> GetBuisnessPartners();

		Task<SapBusinessPartnerEntity> GetBusinessPartnerBy(string cardCode);

		#endregion Business Partner

		#region Item

		Task<IEnumerable<SapItemEntity>> GetItems();

		Task<SapItemEntity> GetItemBy(string itemCode);

		#endregion Item
	}
}