using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recruit.Models
{
    /// <summary>
    /// 管理员用户验证密码, 面试者仅判断身份证前面14位和姓名
    /// 用户类设计的比较简单, 等以后有空了可能会全部重构, 暂时时间匆忙
    /// 由于pgsql和mysql表名和字段区分大小写, 而且默认自动转换为小写, 所以更改命名规则为下划线
    /// </summary>
    public class recruit_user
    {
        /// <summary>
        /// 自定义的主键, 创建的时候有默认值, 不需要手动赋值
        /// </summary>
        [Key]
        public string uuid { get; set; } = UUID.getUUID();

        /// <summary>
        /// 昵称, 登录名, 唯一索引
        /// </summary>
        [Required, MaxLength(20), MinLength(2)]
        public string nickname { get; set; }


        /// <summary>
        /// 用户真实姓名, 面试者必填
        /// </summary>
        [MaxLength(20)]
        public string uname { get; set; } = string.Empty;

        /// <summary>
        /// 身份证号码前面14位, 面试者必填
        /// </summary>
        [MaxLength(14)]
        public string cardno { get; set; } = string.Empty;

        /// <summary>
        /// 密码, SHA2加密, 不可还原
        /// </summary>
        [Required, MaxLength(200)]
        public string pwd { get; set; }

        /// <summary>
        /// 手机号, 必填, 唯一索引
        /// </summary>
        [Phone]
        public string phone { get; set; } = string.Empty;

        /// <summary>
        /// 邮件, 必填, 唯一索引
        /// </summary>
        [EmailAddress]
        public string email { get; set; } = string.Empty;


        /// <summary>
        /// 组织机构代码, 全国统一社会信用代码, 公司的唯一标识, 因为不是必填的, 所以不能设置索引
        /// </summary>
        [MaxLength(50)]
        public string CompanyCode { get; set; } = string.Empty;

        /// <summary>
        /// 公司名称, 公司用户必填
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// 公司地址, 公司用户必填
        /// </summary>
        public string CompanyAddress { get; set; } = string.Empty;

        /// <summary>
        /// 公司联系方式,非必填
        /// </summary>
        public string CompanyContact { get; set; } = string.Empty;

        /// <summary>
        /// 权限, admin , user ,company , 
        /// 因为不想看见null, 所以都给了默认值, 这是强迫症, 
        /// </summary>
        public string role { get; set; } = string.Empty;

        /// <summary>
        /// 添加时间, 
        /// 这个本来是应该使用数据库的默认值 getdate(), 
        /// 但是为了使用code first, 降低数据库移植的复杂度所以使用程序的默认值, 
        /// 所以应用服务器的时间必须准确
        public DateTime addtime { get; set; } = DateTime.Now;
    }
}
