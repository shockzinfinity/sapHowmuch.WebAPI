using System.ComponentModel;

namespace sapHowmuch.Api.Common.Enums
{
	public enum DateTimeInterval
	{
		Year,
		Month,
		Day,
		Hour,
		Minute,
		Second,
		MiliSecond
	}

	/// <summary>
	/// Hash Type enum
	/// </summary>
	public enum HashType
	{
		HMAC, HMACMD5, HMACSHA1, HMACSHA256, HMACSHA384, HMACSHA512,
		MACTripleDES, MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512
	}

	public enum B1DITransactionType
	{
		[Description("")]
		UNKNOWN = 0,

		[Description("A")]
		Add = 1,

		[Description("U")]
		Update = 2,

		[Description("D")]
		Delete = 3,

		[Description("C")]
		Cancel = 4,

		[Description("L")]
		Close = 5
	}
}