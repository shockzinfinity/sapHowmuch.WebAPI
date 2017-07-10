using System.Collections.Generic;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public class ValidIssuers : AbstractAudience<string>
	{
		public override IEnumerator<string> GetEnumerator()
		{
			foreach (var issuer in Audiences())
			{
				// NOTE: ValidIssuers 를 쓸 경우, 현재는 Secret 을 반환하게 되어 있으나, Audience 별 Issuer 를 다르게 가져갈 경우, 해당 모델에 Issuer 프로퍼티를 추가하고, 그 프로퍼티를 반환하게 할 필요가 있다.
				yield return issuer.Secret;
			}
		}
	}
}