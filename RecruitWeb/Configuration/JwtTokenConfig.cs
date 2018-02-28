using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitWeb.Configuration
{
    /// <summary>
    /// jwtToken的相关配置， 添加到依赖注入中
    /// </summary>
    public class JwtTokenConfig
    {
        /// <summary>
        /// 私钥
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 颁发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 受众
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// token 类型
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 有效期, 小时为单位
        /// </summary>
        public int Validity { get; set; }
    }
}
