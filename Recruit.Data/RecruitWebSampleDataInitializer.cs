using Common;
using Microsoft.EntityFrameworkCore;
using Recruit.Models;
using System.Threading.Tasks;
using System;

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
            dbContext.recruit_user.Add(new recruit_user()
            {
                uuid = "88D5811FB2B0A610-8eb9d0eb-45ad-4b6c-93eb-e8ca2c6581d9",
                nickname = "asuna",
                uname = "江郎才尽",
                birthday = "42112719941208",
                email = "s694060865@gmail.com",
                phone = "17666293366",
                auth_role = "user",
                pwd = Sha1.getSha1String("angel.")
            });

            dbContext.recruit_user.Add(new recruit_user()
            {
                uuid = "88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e",
                nickname = "才众电脑",
                uname = "才众电脑",
                email = "s694060865@163.com",
                phone = "17665271050",
                auth_role = "company",
                pwd = Sha1.getSha1String("kotori.")
            });


            dbContext.job_type.Add(new job_type()
            {
                uuid = "88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2",
                addtime = DateTime.Parse("2018-03-04 12:14:15.481948"),
                job_name = ".net core工程师",
                user_id = "88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e",
                is_enabled = true
            });
            dbContext.job_type.Add(new job_type()
            {
                uuid = "88D581B754874D9C-b4ca7587-aa39-437c-a68e-31ae318177ae",
                addtime = DateTime.Parse("2018-03-04 18:04:33.994484"),
                job_name = "前端工程师",
                user_id = "88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e",
                is_enabled = true
            });

            dbContext.exam_data.Add(new exam_data()
            {
                id = "88D581EF020FFF5C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0",
                anwser_a = ".net core",
                anwser_b = "mono",
                anwser_c = ".net standard",
                anwser_d = ".net framework",
                exam_content = ".net core, mono , .net standard , .net framework那个才是标准库",
                exam_cq_anwser = "C",
                exam_eq_answer = string.Empty,
                exam_type = "cq",
                job_id = "88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2",
                user_id = "88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e",
                addtime = DateTime.Parse("2018-03-05 01:00:37.746661")
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
