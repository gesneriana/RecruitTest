using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recruit.Models
{
    /// <summary>
    /// 用户的测试题答案
    /// </summary>
    public class user_answer
    {
        [Key]
        [MaxLength(60)]
        public string id { get; set; } = UUID.getUUID();

        /// <summary>
        /// 用户得分记录表的 id, user_score 外键
        /// </summary>
        [MaxLength(60), Required]
        public string user_score_id { get; set; }

        /// <summary>
        /// 测试题的id, 因为岗位可以添加测试题, 所以每条记录需要加上此外键, exam_data 的外键
        /// </summary>
        [MaxLength(60), Required]
        public string exam_id { get; set; }

        /// <summary>
        /// 试题类型
        /// </summary>
        [MaxLength(10), Required]
        public string exam_type { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        [Required, MaxLength(500)]
        public string exam_answer { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime addTime { get; set; } = DateTime.Now;
    }
}
