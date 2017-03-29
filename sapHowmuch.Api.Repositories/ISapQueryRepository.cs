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

		#region Employee

		Task<IEnumerable<SapEmployeeInfoEntity>> GetEmployees();

		Task<SapEmployeeInfoEntity> GetEmployeeBy(int id);

		Task<SapEmployeeInfoEntity> GetEmployeeBy(string name);

		Task<IEnumerable<SapCountryEntity>> GetCountries();

		Task<SapCountryEntity> GetCountrieBy(string code);

		Task<SapEmployeePositionEntity> GetEmployeePositionBy(int posId);

		Task<SapEmployeeStatusEntity> GetEmployeeStatus(int statusId);

		#endregion Employee

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