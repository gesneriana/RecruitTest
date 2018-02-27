using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public static class MemoryCacheExt
    {

        #region 获取缓存值
        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key">缓存的键</param>
        /// <returns>返回缓存的值</returns>
        public static T GetCacheValue<T>(this IMemoryCache cache, string key) where T : class
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
        #endregion




        #region 设置缓存值
        /// <summary>
        /// 设置缓存值, 如果是mobile使用的长期token, 建议存储到数据库中比较好
        /// </summary>
        /// <param name="key">缓存的键</param>
        /// <param name="value">缓存值</param>
        public static void SetChacheValue(this IMemoryCache cache, string key, object value, double hours = 1)
        {
            if (key != null)
            {
                var ent = cache.CreateEntry(key);
                ent.Value = value;
                ent.SlidingExpiration = TimeSpan.FromHours(hours);  // 滑动期限, 每次get set都会延长期限
            }
        }
        #endregion
    }
}
