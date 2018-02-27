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
            // 数据库表名和字段名不能写死, 因为可能会在后面重构阶段更改
            dbContext.Database.ExecuteSqlCommand(string.Format("alter table {0} add constraint unique_RecruitUser_nickname unique ({1});", nameof(recruit_user), nameof(recruit_user.nickname)));
            dbContext.Database.ExecuteSqlCommand(string.Format("alter table {0} add constraint unique_RecruitUser_phone unique ({1});", nameof(recruit_user), nameof(recruit_user.phone)));
            dbContext.Database.ExecuteSqlCommand(string.Format("alter table {0} add constraint unique_RecruitUser_email unique ({1});", nameof(recruit_user), nameof(recruit_user.email)));

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 初始化用户数据
        /// </summary>
        /// <returns></returns>
        public async Task InitDatabaseData()
        {
            dbContext.recruit_user.Add(new recruit_user() { nickname = "asuna", uname = "江郎才尽", cardno = "42112719941208", email = "s694060865@gmail.com", phone = "17666293366", role = "user", pwd = Sha1.getSha1String("asuna" + "angel.") });
            dbContext.recruit_user.Add(new recruit_user() { nickname = "才众电脑", uname = "才众电脑", email = "s694060865@163.com", phone = "17665271050", role = "company", pwd = Sha1.getSha1String("才众电脑" + "kotori.") });

            await dbContext.SaveChangesAsync();
        }
    }
}
