using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruit.Models
{
    public class RecruitDbContext : DbContext
    {

        public RecruitDbContext(DbContextOptions<RecruitDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 模型映射绑定
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 用户实体类, 初始化的时候应该创建唯一键
        /// </summary>
        public DbSet<recruit_user> recruit_user { get; set; }

        /// <summary>
        /// 岗位类型, 不同的类型对应不同的实体
        /// </summary>
        public DbSet<job_type> job_type { get; set; }

        /// <summary>
        /// 试题数据, 以及参考答案
        /// </summary>
        public DbSet<exam_data> exam_data { get; set; }

        /// <summary>
        /// 用户测试题 分数记录
        /// </summary>
        public DbSet<user_score> user_score { get; set; }

        /// <summary>
        /// 用户填写的测试题答案
        /// </summary>
        public DbSet<user_answer> user_answer { get; set; }
    }
}
