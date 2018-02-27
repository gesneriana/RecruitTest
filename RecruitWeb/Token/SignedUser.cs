using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecruitWeb.Token
{
    /// <summary>
    /// 登录的用户, 将用户登录凭证保存在缓存中, 比如 redis 和 memorycache
    /// </summary>
    public class SignedUser
    {
        /// <summary>
        /// jwt签名凭证, 作为缓存的key
        /// </summary>
        public string user_token { get; set; }

        /// <summary>
        /// 手机号, 对应唯一的一个用户
        /// </summary>
        public string user_phone { get; set; }

        /// <summary>
        /// 用户声明属性
        /// </summary>
        public List<Claim> user_claims { get; set; }


    }
}
