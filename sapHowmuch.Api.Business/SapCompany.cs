using SAPbobsCOM;
using sapHowmuch.Api.Common.Helpers;
using System;
using System.Configuration;

namespace sapHowmuch.Api.Business
{
	public sealed partial class SapCompany
	{
		private static Company _company;
		public static Company DICompany { get { return _company; } }
		public static bool IsDiConnected => _company != null && _company.Connected;

		public SapCompany()
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
			_company.language = BoSuppLangs.ln_Korean_Kr;
			_company.DbServerType = (BoDataServerTypes)Enum.Parse(typeof(BoDataServerTypes), dbType);
			_company.LicenseServer = licenseServer;
			_company.Server = server;
			_company.DbUserName = dbUserName;
			_company.DbPassword = dbPassword;
			_company.CompanyDB = companyDb;
			_company.UserName = companyUsername;
			_company.Password = companyPassword;

			try
			{
				result = _company.Connect();
			}
			catch (Exception ex)
			{
				sapHowmuchLogger.Error($"SAP Business One DI company connection error: {ex.Message}");
				throw ex;
			}

			if (result != 0)
			{
				int errorCode;
				string errorString;
				_company.GetLastError(out errorCode, out errorString);

				sapHowmuchLogger.Error($"Company connection failed: ErrorCode: {errorCode}, ErrorMessage: {errorString}");
				throw new ApplicationException($"Error Code: {errorCode}{Environment.NewLine}Error Message: {errorString}");
			}

			sapHowmuchLogger.Info($"SAP Business One Company connected: '{server}', '{companyDb}', '{companyUsername}'");
		}
	}
}