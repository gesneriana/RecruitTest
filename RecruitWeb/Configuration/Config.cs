using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitWeb.Configuration
{
    /// <summary>
    /// 在任意位置获取 配置文件的工具类，
    /// 如果可以通过依赖注入获取则不建议使用这个方式
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 配置管理器，在 startup.cs中注入的
        /// </summary>
        public static IConfiguration configuration { get; set; }

        /// <summary>
        /// 内存缓存
        /// </summary>
        public static IMemoryCache cache { get; set; }
    }
}
