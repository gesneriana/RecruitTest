using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitWeb.Models.ViewModel
{

    /// <summary>
    /// 后台显示用户测试题数据的 模型
    /// </summary>
    public class user_score_info
    {
        /// <summary>
        /// user_score 表的id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 正确的测试题数量
        /// </summary>
        public int cq_score { get; set; }

        /// <summary>
        /// 笔试题的分数
        /// </summary>
        public int eq_score { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string uname { get; set; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public string invitation_code { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime addtime { get; set; }
    }
}
