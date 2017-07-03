using sapHowmuch.Api.Infrastructure.Events;

namespace sapHowmuch.Api.Business.Events
{
	public class CountryCreatedEvent : BaseEvent
	{
		public override string Name => this.GetType().Name;

		public string CountryCode { get; set; }
		public string CountryName { get; set; }
	}
}