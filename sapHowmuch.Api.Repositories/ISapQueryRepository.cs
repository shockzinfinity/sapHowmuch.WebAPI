using sapHowmuch.Api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sapHowmuch.Api.Repositories
{
	public interface ISapQueryRepository : IDisposable
	{
		#region COA (Chart of Accounts)

		/// <summary>
		/// 계정과목 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapCoaEntity>> GetChartOfAccount();

		/// <summary>
		/// 계정과목
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		Task<SapCoaEntity> GetChartOfAccountBy(string code);

		#endregion COA (Chart of Accounts)

		#region Cost Center & Budget Center

		/// <summary>
		/// 코스트센터 리스트
		/// </summary>
		/// <param name="dimCode"></param>
		/// <returns></returns>
		Task<IEnumerable<SapCostCenterEntity>> GetCostCenters(int dimCode);

		/// <summary>
		/// 코스트센터
		/// </summary>
		/// <param name="dimCode"></param>
		/// <param name="prcCode"></param>
		/// <returns></returns>
		Task<SapCostCenterEntity> GetCostCenterBy(int dimCode, string prcCode);

		/// <summary>
		/// 예산부서 리스트
		/// </summary>
		/// <param name="dimCode"></param>
		/// <returns></returns>
		Task<IEnumerable<SapBudgetDepartmentEntity>> GetBudgetDepartments(int dimCode);

		/// <summary>
		/// 예산부서
		/// </summary>
		/// <param name="dimCode"></param>
		/// <param name="prcCode"></param>
		/// <returns></returns>
		Task<SapBudgetDepartmentEntity> GetBudgetDepartmentBy(int dimCode, string prcCode);

		#endregion Cost Center & Budget Center

		#region Employee, Employee Position, Employee Status, Country, Department

		/// <summary>
		/// 근무자 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapEmployeeInfoEntity>> GetEmployees();

		/// <summary>
		/// 근무자
		/// </summary>
		/// <param name="id">empId</param>
		/// <returns></returns>
		Task<SapEmployeeInfoEntity> GetEmployeeBy(int id);

		/// <summary>
		/// 근무자
		/// </summary>
		/// <param name="name">이름</param>
		/// <returns></returns>
		Task<SapEmployeeInfoEntity> GetEmployeeBy(string name);

		/// <summary>
		/// 국가 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapCountryEntity>> GetCountries();

		/// <summary>
		/// 국가
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		Task<SapCountryEntity> GetCountrieBy(string code);

		/// <summary>
		/// 직위 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapEmployeePositionEntity>> GetEmployeePositions();

		/// <summary>
		/// 직위
		/// </summary>
		/// <param name="posId"></param>
		/// <returns></returns>
		Task<SapEmployeePositionEntity> GetEmployeePositionBy(int posId);

		/// <summary>
		/// 근무형태 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapEmployeeStatusEntity>> GetEmployeeStatuses();

		/// <summary>
		/// 근무형태
		/// </summary>
		/// <param name="statusId"></param>
		/// <returns></returns>
		Task<SapEmployeeStatusEntity> GetEmployeeStatus(int statusId);

		/// <summary>
		/// 부서 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapDepartmentEntity>> GetDepartments();

		/// <summary>
		/// 부서
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		Task<SapDepartmentEntity> GetDepartmentBy(int code);

		#endregion Employee, Employee Position, Employee Status, Country, Department

		#region Business Partner

		/// <summary>
		/// 거래처 (Business Partner) 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapBusinessPartnerEntity>> GetBuisnessPartners();

		/// <summary>
		/// 거래처 (Business Partner)
		/// </summary>
		/// <param name="cardCode"></param>
		/// <returns></returns>
		Task<SapBusinessPartnerEntity> GetBusinessPartnerBy(string cardCode);

		#endregion Business Partner

		#region Item

		/// <summary>
		/// 품목 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapItemEntity>> GetItems();

		/// <summary>
		/// 품목
		/// </summary>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		Task<SapItemEntity> GetItemBy(string itemCode);

		#endregion Item

		#region Dimension

		/// <summary>
		/// 차원 리스트
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<SapDimensionEntity>> GetDimensions();

		/// <summary>
		/// 차원
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		Task<SapDimensionEntity> GetDimensionBy(int code);

		#endregion Dimension
	}
}