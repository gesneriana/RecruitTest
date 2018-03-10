using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Common;

namespace Recruit.Models
{
    /// <summary>
    /// 用户测试题的评分
    /// </summary>
    public class user_score
    {
        /// <summary>
        /// 主键, 初始化自动设置默认值
        /// </summary>
        [Key, MaxLength(60)]
        public string id { get; set; } = UUID.getUUID();

        /// <summary>
        /// 面试的岗位 id , 岗位id -> 测试题列表
        /// </summary>
        [Required, MaxLength(60)]
        public string job_id { get; set; }

        /// <summary>
        /// 测试题的用户
        /// </summary>
        [Required, MaxLength(60)]
        public string user_id { get; set; }

        /// <summary>
        /// 选择题的分数
        /// </summary>
        public int cq_score { get; set; }

        /// <summary>
        /// 笔试题的分数
        /// </summary>
        public int eq_score { get; set; }

        [MaxLength(8)]
        public string invitation_code { get; set; } = string.Empty;

        /// <summary>
        /// 添加时间, 默认为当前时间
        /// </summary>
        public DateTime addtime { get; set; } = DateTime.Now;
    }
}
