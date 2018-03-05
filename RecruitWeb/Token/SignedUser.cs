using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecruitWeb.Token
{
    /// <summary>
    /// 登录的用户, 将用户登录凭证保存在缓存中, 比如 redis 和 memorycache
    /// 可以将此对象以同一个实例以不同的key 存储, user_uuid 和 guid
    /// 两次登录的时候, 更改 guid , 若 Token中的guid和登录的用户不同, 则被认为挤掉线了
    /// </summary>
    public class SignedUser
    {
        /// <summary>
        /// guid key, 相当于sessionid
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// 颁发token的UTC时间
        /// </summary>
        public DateTime utc_time { get; set; }

        /// <summary>
        /// jwt签名凭证, 作为缓存的key
        /// </summary>
        public string user_token { get; set; }

        /// <summary>
        /// 用户的主键 id, 对应唯一的一个用户
        /// </summary>
        public string user_uuid { get; set; }

        /// <summary>
        /// 颁发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 受众
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        ///  token 类型
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 有效期, 小时为单位
        /// </summary>
        public int Validity { get; set; }

        /// <summary>
        /// 用户声明的权限
        /// </summary>
        public List<Claim> user_claims { get; set; }


    }
}
