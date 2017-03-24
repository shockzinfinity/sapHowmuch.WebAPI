using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sapHowmuch.Api.Common.Extensions
{
	public static class CollectionExtensions
	{
		public static Dictionary<K, V> HashtableToDictionary<K, V>(this Hashtable table)
		{
			return table.Cast<DictionaryEntry>().ToDictionary(x => (K)x.Key, x => (V)x.Value);
		}
	}
}