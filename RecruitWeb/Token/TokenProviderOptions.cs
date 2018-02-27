using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitWeb.Token
{
    public class TokenProviderOptions
    {
        /// <summary>
        /// 请求路径
        /// </summary>
        public string Path { get; set; } = "/Api/Token";

        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 受众
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 过期时间, web 设置为一天, app可以设置为长期有效
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(60 * 24);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
