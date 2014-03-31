using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDSkeletonNET.Infrastructure.Common.Caching
{
	public interface ICacheStorage
	{
		void Remove(string key);
		void Store(string key, object data);
		void Store(string key, object data, TimeSpan slidingExpiration);
		void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration);
		T Retrieve<T>(string key);
	}
}
