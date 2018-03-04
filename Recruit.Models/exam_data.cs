using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recruit.Models
{
    /// <summary>
    /// 试题内容
    /// </summary>
    public class exam_data
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [MaxLength(60)]
        public string id { get; set; } = UUID.getUUID();

        /// <summary>
        /// 岗位名称的id, 外键
        /// </summary>
        [Required, MaxLength(60)]
        public string job_id { get; set; }

        /// <summary>
        /// 用户id, 外键
        /// </summary>
        [Required, MaxLength(60)]
        public string user_id { get; set; }

        /// <summary>
        /// 试题类型, cq 选择题, eq 笔试题
        /// </summary>
        [Required, MaxLength(2)]
        public string exam_type { get; set; }

        /// <summary>
        /// 试题内容
        /// </summary>
        [Required, MaxLength(200)]
        public string exam_content { get; set; }

        /// <summary>
        /// 选择题的参考答案
        /// </summary>
        [Required, MaxLength(4)]
        public string exam_cq_anwser { get; set; } = string.Empty;

        /// <summary>
        /// 笔试题参考答案
        /// </summary>
        [Required, MaxLength(200)]
        public string exam_eq_answer { get; set; } = string.Empty;

        /// <summary>
        /// A 选项的内容
        /// </summary>
        [Required, MaxLength(50)]
        public string anwser_a { get; set; }

        /// <summary>
        /// B 选项的内容
        /// </summary>
        [Required, MaxLength(50)]
        public string anwser_b { get; set; }

        /// <summary>
        /// C 选项的内容
        /// </summary>
        [Required, MaxLength(50)]
        public string anwser_c { get; set; }

        /// <summary>
        /// D 选项的内容
        /// </summary>
        [Required, MaxLength(50)]
        public string anwser_d { get; set; }
    }
}
