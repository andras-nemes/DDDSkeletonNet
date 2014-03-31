using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace DDDSkeletonNET.Infrastructure.Common.Caching
{
	public class SystemRuntimeCacheStorage : ICacheStorage
	{
		public void Remove(string key)
		{
			ObjectCache cache = MemoryCache.Default;
			cache.Remove(key);
		}

		public void Store(string key, object data)
		{
			ObjectCache cache = MemoryCache.Default;
			cache.Add(key, data, null);
		}

		public void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration)
		{
			ObjectCache cache = MemoryCache.Default;
			var policy = new CacheItemPolicy
			{
				AbsoluteExpiration = absoluteExpiration,
				SlidingExpiration = slidingExpiration
			};

			if (cache.Contains(key))
			{
				cache.Remove(key);
			}

			cache.Add(key, data, policy);
		}

		public T Retrieve<T>(string key)
		{
			ObjectCache cache = MemoryCache.Default;
			return cache.Contains(key) ? (T)cache[key] : default(T);
		}

		public void Store(string key, object data, TimeSpan slidingExpiration)
		{
			ObjectCache cache = MemoryCache.Default;
			var policy = new CacheItemPolicy
			{
				SlidingExpiration = slidingExpiration
			};

			if (cache.Contains(key))
			{
				cache.Remove(key);
			}

			cache.Add(key, data, policy);
		}
	}
}
