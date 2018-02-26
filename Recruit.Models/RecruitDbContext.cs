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
        /// 用户实体类, 初始化的时候应该创建唯一索引, create unique index ix_RecruitUser_nickname on RecruitUser (nickname)
        /// </summary>
        public DbSet<RecruitUser> RecruitUser { get; set; }
    }
}
