using SAPbobsCOM;
using System;
using System.Configuration;

namespace sapHowmuch.Api.Business
{
	public static class SapCompany
	{
		private static Company _company;
		public static Company DICompany { get { return _company; } }

		static SapCompany()
		{
			ConnectToCompany();
		}

		private static void ConnectToCompany()
		{
			if (_company != null)
			{
				if (_company.Connected)
				{
					// disconnect
					_company.Disconnect();
				}
			}

			string licenseServer = ConfigurationManager.AppSettings["sapLicenseServer"];
			string server = ConfigurationManager.AppSettings["sapServer"];
			string dbType = ConfigurationManager.AppSettings["sapDbType"];
			string companyDb = ConfigurationManager.AppSettings["sapCompanyDb"];
			string dbUserName = ConfigurationManager.AppSettings["sapDbUsername"];
			string dbPassword = ConfigurationManager.AppSettings["sapDbPassword"];
			string companyUsername = ConfigurationManager.AppSettings["sapCompanyUser"];
			string companyPassword = ConfigurationManager.AppSettings["sapCompanyPassword"];

			int result;

			// TODO: Rx 적용 (SAP Business One DI API 의 alive 여부에 대해)
			_company = new Company();

			_company.UseTrusted = false;
			_company.language = BoSuppLangs.ln_Korean_Kr; // TODO: 추후 파라미터 화

			// NOTE: 현재 DI API BoDataServerTypes 에 MSSQL2014 가 적용이 되지 않은 상태이므로, 일단 연결을 위해서만 추가한 구문
			if (dbType == "dst_MSSQL2014")
			{
				_company.DbServerType = (BoDataServerTypes)8;
			}
			else
			{
				_company.DbServerType = (BoDataServerTypes)Enum.Parse(typeof(BoDataServerTypes), dbType);
			}

			_company.LicenseServer = licenseServer;
			_company.Server = server;
			_company.DbUserName = dbUserName;
			_company.DbPassword = dbPassword;
			_company.CompanyDB = companyDb;
			_company.UserName = companyUsername;
			_company.Password = companyPassword;

			try
			{
				// TODO: 9.2 와 9.1 DI API 테스트에 무리가 있음.
				// fix 한 이후 테스트 되어야 함.
				// 9.1 로 일단 진행 2017-03-30
				result = _company.Connect();
			}
			catch (Exception ex)
			{
				throw;
			}

			if (result != 0)
			{
				int errorCode;
				string errorString;
				_company.GetLastError(out errorCode, out errorString);

				throw new ApplicationException(string.Format("Error Code: {0}\nError Message: {1}", errorCode, errorString));
			}
		}
	}
}