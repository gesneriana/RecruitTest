using Common;
using Microsoft.EntityFrameworkCore;
using Recruit.Models;
using System.Threading.Tasks;

namespace Recruit.Data
{

    /// <summary>
    /// DataBase初始化工具类, 比如创建索引, 添加几条测试数据等等. code first项目必须用的初始化类
    /// </summary>
    public class RecruitWebSampleDataInitializer
    {
        private RecruitDbContext dbContext = null;

        public RecruitWebSampleDataInitializer(RecruitDbContext ctx)
        {
            dbContext = ctx;
        }

        /// <summary>
        /// 初始化数据库的时候更改表结构,创建唯一键
        /// </summary>
        /// <returns></returns>
        public async Task InitTableSchema()
        {
            dbContext.Database.ExecuteSqlCommand("alter table \"RecruitUser\" add constraint unique_RecruitUser_nickname unique (nickname);");
            dbContext.Database.ExecuteSqlCommand("alter table \"RecruitUser\" add constraint unique_RecruitUser_phone unique (phone);");
            dbContext.Database.ExecuteSqlCommand("alter table \"RecruitUser\" add constraint unique_RecruitUser_email unique (email);");

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 初始化用户数据
        /// </summary>
        /// <returns></returns>
        public async Task InitDatabaseData()
        {
            dbContext.RecruitUser.Add(new RecruitUser() { nickname = "asuna", uname = "江郎才尽", cardno = "42112719941208", email = "s694060865@gmail.com", phone = "17666293366", role = "user", pwd = Sha1.getSha1String("asuna" + "angel.") });
            dbContext.RecruitUser.Add(new RecruitUser() { nickname = "才众电脑", uname = "才众电脑", email = "s694060865@163.com", phone = "17665271050", role = "company", pwd = Sha1.getSha1String("才众电脑" + "kotori.") });

            await dbContext.SaveChangesAsync();
        }
    }
}
