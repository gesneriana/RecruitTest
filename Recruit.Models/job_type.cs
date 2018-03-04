using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recruit.Models
{

    /// <summary>
    /// 岗位类型
    /// </summary>
    public class job_type
    {
        /// <summary>
        /// 主键, 有默认值
        /// </summary>
        [Key]
        [MaxLength(60)]
        public string uuid { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        [Required, MaxLength(50)]
        public string job_name { get; set; }

        /// <summary>
        /// 用户id, 用户的主键
        /// </summary>
        [Required]
        [MaxLength(60)]
        public string user_id { get; set; }

        /// <summary>
        /// 是否可用, 默认为true
        /// </summary>
        public bool is_enabled{get;set;}=true;

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime addtime { get; set; }
    }
}
