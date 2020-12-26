using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class CacheController
    {
        public static CacheController controller = new CacheController();
        private ObjectCache cache = MemoryCache.Default;

        public bool SetCache(string key, object cacheObj) 
        {
            return cache.Add(key, cacheObj, DateTimeOffset.Now.AddDays(100.0));
        }

        public object GetCache(string key) 
        {
            return cache.Get(key);
        }
    }
}
