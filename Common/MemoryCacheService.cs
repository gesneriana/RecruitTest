using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 缓存帮助类, 如果想要使用分布式缓存, 可以使用redis
    /// </summary>
    public static class MemoryCacheService
    {

        static IOptions<MemoryCacheOptions> cacheOptions = new MemoryCacheOptions();


        static MemoryCache cache = new MemoryCache(cacheOptions);

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetCacheValue<T>(string key) where T : class
        {
            T val = null;
            if (key != null && cache.TryGetValue(key, out val))
            {
                return val;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 添加缓存内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetChacheValue(string key, object value, double hours = 1)
        {
            if (key != null)
            {
                cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(hours)
                });
            }
        }
    }
}
