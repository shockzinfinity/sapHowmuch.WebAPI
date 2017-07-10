using System;
using System.Collections;
using System.Collections.Generic;

namespace sapHowmuch.Api.Web.Infrastructure
{
	public abstract class AbstractAudience<T> : IEnumerable<T>
	{
		public Func<IEnumerable<Client>> Audiences { get; set; }

		public abstract IEnumerator<T> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}