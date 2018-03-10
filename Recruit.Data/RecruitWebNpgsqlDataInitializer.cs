﻿using Common;
using Microsoft.EntityFrameworkCore;
using Recruit.Models;
using System.Threading.Tasks;
using System;

namespace Recruit.Data
{

    /// <summary>
    /// DataBase初始化工具类, 比如创建索引, 添加几条测试数据等等. code first项目必须用的初始化类
    /// </summary>
    public class RecruitWebNpgsqlDataInitializer
    {
        private RecruitDbContext dbContext = null;

        public RecruitWebNpgsqlDataInitializer(RecruitDbContext ctx)
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
            dbContext.Database.ExecuteSqlCommand(
                @"INSERT INTO exam_data (id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES ('88D5824196954636-1e02b9c8-c610-4565-94bc-9f300c6e225a', '2018-03-05 10:34:15.364365', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D5824199E6BF7B-e6bca42d-1d68-4c62-8cf0-5214b9a5176e', '2018-03-05 10:34:20.93149', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582419ABEA41C-62c521e0-1d43-42aa-93dd-b4367ee3c00b', '2018-03-05 10:34:22.346351', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582419B439FEF-f115db9e-6839-4fb2-b601-ba25466faa33', '2018-03-05 10:34:23.217873', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582419BAF0B61-061e7de7-5ffd-4449-8b84-ac875095f53f', '2018-03-05 10:34:23.921871', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582419C110C73-68a70b28-39dd-4dfa-8e00-fc10d1b3bfe4', '2018-03-05 10:34:24.564153', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582419C602530-9b09ff5e-d280-4a6a-ad5d-18d721ed4dd9', '2018-03-05 10:34:25.082506', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582419CC94DC8-f4f2f2de-2f37-46bb-a51f-1250599c8ad4', '2018-03-05 10:34:25.771674', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D58242147B49CA-921c81da-30e1-4259-af42-3c997440cb82', '2018-03-05 10:37:46.586986', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582422240794C-1b55ef1e-45b2-426d-80c8-bcb1c801464b', '2018-03-05 10:38:09.68964', '', '', '', '', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D58242233C1167-0316a566-3731-47a1-8619-2d1583c12e78', '2018-03-05 10:38:11.338487', '', '', '', '', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D5824215A15F49-15e17a61-d481-48a0-97c1-ca0fb41a5106', '2018-03-05 10:37:48.514293', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D5824215E3588A-ab4ec9f5-4a6b-4a40-9c2d-673b467ced5f', '2018-03-05 10:37:48.946662', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582421602F8EC-206b1f7f-7c57-40d6-ac46-1d40564a787e', '2018-03-05 10:37:49.153925', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D581EF020FFF5C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '2018-03-05 01:00:37.746661', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D58242136C90BB-189f018d-0a9d-4d0f-afe9-594b4ac1bac1', '2018-03-05 10:37:44.812776', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582421883E65C-d568ef56-7401-4b26-840a-6b0d32f02c4f', '2018-03-05 10:37:53.354306', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D58242154D1F2D-3300237e-96fe-40df-b9ca-dd7108393a20', '2018-03-05 10:37:47.96216', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D5824217FFEFCF-e0f40beb-239d-4ff4-84ba-23f3a3081c07', '2018-03-05 10:37:52.489473', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D58242244B1AFB-5005a8f1-2385-46f7-bfdf-c548aec1460c', '2018-03-05 10:38:13.114759', '', '', '', '', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            INSERT INTO exam_data(id, addtime, anwser_a, anwser_b, anwser_c, anwser_d, exam_content, exam_cq_anwser, exam_eq_answer, exam_type, is_enabled, job_id, user_id) VALUES('88D582422707C688-3f25d884-9ec2-4994-a302-3af5aded0999', '2018-03-05 10:38:17.706671', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', 't', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
            ");

            dbContext.Database.ExecuteSqlCommand(@"INSERT INTO job_type (uuid, addtime, is_enabled, job_name, user_id) VALUES ('88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '2018-03-04 12:14:15.481948', 't', '.net core工程师', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
                INSERT INTO job_type (uuid, addtime, is_enabled, job_name, user_id) VALUES ('88D581B754874D9C-b4ca7587-aa39-437c-a68e-31ae318177ae', '2018-03-04 18:04:33.994484', 't', '前端工程师', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');");

            dbContext.Database.ExecuteSqlCommand(@"INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D5811FB2B0A610-8eb9d0eb-45ad-4b6c-93eb-e8ca2c6581d9', '2018-03-05 19:11:28.409758', 'user', '42112719941208', '', '', '', '', 's694060865@gmail.com', 'asuna', '17666293366', 'BAC3D3E72B8767E72E31614555C9C369AAE832F0', '江郎才尽');
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 19:11:28.428857', 'company', '', '深圳市盐田区', '1234567894648', 'www.666666.con', '某公司', 's694060865@163.com', '某公司', '17665271050', '041315C5385C02F3C3699218E9C2EEA7D18D4BE4', '某公司');
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584461E17C8C9-924a8600-38fc-43c7-a721-845f29b4a46a', '2018-03-08 00:11:43.024569', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '131654464@qq.com', 'asuna123', '18612345678', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584462E6CE0DB-c8ed4479-dfb8-4fe8-adef-f680d2b6257f', '2018-03-08 00:12:10.425784', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '131641564@qq.com', 'asuna111', '18612345696', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584463A34ADFC-5e71fcbb-691c-4d67-b01e-e42ac6c66011', '2018-03-08 00:12:30.19014', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '4164141564@qq.com', 'asuna222', '18612695696', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D5844644A77117-6f617fb3-6965-43b0-ae43-12ed228472c0', '2018-03-08 00:12:47.71946', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '98751564@qq.com', 'asuna333', '18632695696', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584464E62F27B-3d988797-19da-4897-ac48-6651ec096ba6', '2018-03-08 00:13:04.047788', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '98759664@qq.com', 'asuna555', '18632695324', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584465DE0C377-7c4c5f6c-8fdf-4756-9b08-e9032255f53c', '2018-03-08 00:13:30.038163', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '456469664@qq.com', 'asuna777', '18632696987', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D5844668854511-7ef45679-9984-49eb-9638-ac21b30faa21', '2018-03-08 00:13:47.893489', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '459769664@qq.com', 'asuna888', '18632696665', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D5844683F4123D-113f2d9c-5145-48b3-9b23-4607a2856a51', '2018-03-08 00:14:33.918121', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '45963664@qq.com', 'asuna999', '18632678665', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D58446AFEB6D0D-fbe7f8ea-816f-460e-bc1e-87de2d6cab01', '2018-03-08 00:15:47.681213', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '45963321@qq.com', 'asuna21', '17612346589', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D58446BFB3BB68-417fdd0d-a5c6-4efb-9a65-df047241cdfd', '2018-03-08 00:16:14.159763', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '45966351@qq.com', 'asuna22', '17612346532', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D58446CE07DD9E-21e52257-f697-43dd-a289-f1c0503065f7', '2018-03-08 00:16:38.199242', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '45915661@qq.com', 'asuna56', '17623567891', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D58446E20104C4-e0c0f881-0b53-4991-bf8f-8b1222ee0221', '2018-03-08 00:17:11.708799', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '51655661@qq.com', 'asuna156', '17623567832', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D58446F209678E-d7da4523-3d9e-48a4-977e-116b06f12213', '2018-03-08 00:17:38.607311', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '536981661@qq.com', 'asuna362', '17623562832', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D58446FF29A166-500a3bd1-ac60-4f42-b9ed-86d535eb0d8e', '2018-03-08 00:18:00.628879', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '5341631561@qq.com', 'asuna39496', '17623596301', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D5844709FCA0E4-f2ab8b41-84bb-4e56-8b59-f1b948d81dc7', '2018-03-08 00:18:18.788893', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '53401561@qq.com', 'asuna3901', '17623506301', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584471632ED46-0f20efe9-80d9-4814-b2f3-165672a1d8a3', '2018-03-08 00:18:39.277406', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '53436861@qq.com', 'asuna025', '17623500101', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584472006DBD7-97fcbd9b-59f6-4179-9057-3c719b64fa72', '2018-03-08 00:18:55.765815', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '53431661@qq.com', 'asuna068', '17623555101', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584472C9EE8F6-8e77b9be-80a1-4318-af5f-7bb5d37d5b62', '2018-03-08 00:19:16.894957', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '53987661@qq.com', 'asuna967', '17623695101', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D58447389B703C-89c466c9-6a8f-47d8-a4f9-820f35293157', '2018-03-08 00:19:37.004868', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '539898761@qq.com', 'asuna056', '17623693206', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO recruit_user (uuid, addtime, auth_role, birthday, company_address, company_code, company_contact, company_name, email, nickname, phone, pwd, uname) VALUES ('88D584474C2FDC80-af10ef62-6e0f-424c-ae45-ff3fc1247ad2', '2018-03-08 00:20:09.854316', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '不知名公司', '539893620@qq.com', 'asuna786', '17623630125', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);");

            dbContext.Database.ExecuteSqlCommand("INSERT INTO user_score (id, addtime, cq_score, eq_score, invitation_code, job_id, user_id) VALUES ('88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4', '2018-03-08 23:13:09.82926', '2', '0', '773C7690', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A610-8eb9d0eb-45ad-4b6c-93eb-e8ca2c6581d9');");

            dbContext.Database.ExecuteSqlCommand(@"INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7C02E8-e334fa21-636e-4912-89a8-9d434ddc6110', '2018-03-08 23:13:09.81564', 'B', '88D5824215A15F49-15e17a61-d481-48a0-97c1-ca0fb41a5106', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDF9F-67ce45a0-799f-49a4-97c9-9571d261617d', '2018-03-08 23:13:09.817431', '广泛的53', '88D582422240794C-1b55ef1e-45b2-426d-80c8-bcb1c801464b', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDF24-a13a8feb-00e4-4bf6-8db7-44740e4ed0e9', '2018-03-08 23:13:09.817416', '给对方53', '88D582419CC94DC8-f4f2f2de-2f37-46bb-a51f-1250599c8ad4', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDE6F-08261015-e25c-4576-9f81-f5a17084152b', '2018-03-08 23:13:09.817402', '鬼地方86过分的事22', '88D582419C602530-9b09ff5e-d280-4a6a-ad5d-18d721ed4dd9', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDD9A-c0884a86-3dc2-4cb4-a351-91453654d72f', '2018-03-08 23:13:09.817372', '泛光灯伤感的', '88D582419BAF0B61-061e7de7-5ffd-4449-8b84-ac875095f53f', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDD1F-4b00cfc1-2b71-437b-adbf-42362f42c675', '2018-03-08 23:13:09.817344', '大法官会飞的1', '88D582419B439FEF-f115db9e-6839-4fb2-b601-ba25466faa33', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDC93-8b337309-3c18-43bd-9795-ce3c560e264f', '2018-03-08 23:13:09.817317', '豆腐干该41', '88D582419ABEA41C-62c521e0-1d43-42aa-93dd-b4367ee3c00b', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDC24-2b64b685-037f-49f6-8218-867753c60340', '2018-03-08 23:13:09.817289', '跟对方各地方', '88D5824199E6BF7B-e6bca42d-1d68-4c62-8cf0-5214b9a5176e', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDBB1-4ec22a0d-8810-4c19-b08e-2873850f877b', '2018-03-08 23:13:09.817263', 'Westfield2', '88D58242233C1167-0316a566-3731-47a1-8619-2d1583c12e78', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDAFD-0137c9ae-7c1f-4a16-92d0-afce6dba0cca', '2018-03-08 23:13:09.817234', '给对方', '88D58242244B1AFB-5005a8f1-2385-46f7-bfdf-c548aec1460c', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDA8E-278fe8ea-7067-4b09-bba0-0cd2ff669eb2', '2018-03-08 23:13:09.817203', 'C', '88D582422707C688-3f25d884-9ec2-4994-a302-3af5aded0999', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CDA13-8ffbc8e6-adab-4689-a4d4-8e10f5d3f254', '2018-03-08 23:13:09.817159', 'B', '88D58242147B49CA-921c81da-30e1-4259-af42-3c997440cb82', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CD952-dfb3bc00-4c8f-473e-9a47-7c08390f1e66', '2018-03-08 23:13:09.817128', 'C', '88D5824217FFEFCF-e0f40beb-239d-4ff4-84ba-23f3a3081c07', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CD8C6-f111be3f-3b3a-4d5a-9735-0605180a62a4', '2018-03-08 23:13:09.817088', 'D', '88D58242154D1F2D-3300237e-96fe-40df-b9ca-dd7108393a20', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CD83F-36ef551a-2622-4c5a-b177-29e8d5a53bd9', '2018-03-08 23:13:09.817067', 'A', '88D582421883E65C-d568ef56-7401-4b26-840a-6b0d32f02c4f', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CD713-f52c955f-ce19-4ddd-b830-b1b22c9888a1', '2018-03-08 23:13:09.817047', 'A', '88D58242136C90BB-189f018d-0a9d-4d0f-afe9-594b4ac1bac1', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CCD4A-29a10d25-f5a7-4cf3-8bc2-92023d7982d7', '2018-03-08 23:13:09.817015', 'D', '88D581EF020FFF5C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CCC79-275fabe8-47b1-48b4-a1a2-c5a86ba75c62', '2018-03-08 23:13:09.816997', 'C', '88D582421602F8EC-206b1f7f-7c57-40d6-ac46-1d40564a787e', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CC675-ac4275c8-0cba-461e-9901-04927254e67e', '2018-03-08 23:13:09.816957', 'C', '88D5824215E3588A-ab4ec9f5-4a6b-4a40-9c2d-673b467ced5f', 'cq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');
INSERT INTO user_answer (id, addtime, exam_answer, exam_id, exam_type, user_score_id) VALUES ('88D585071A7CE060-ffd726f0-0905-4182-91ad-ad4586bf6b37', '2018-03-08 23:13:09.817451', '过分的广泛的5', '88D5824196954636-1e02b9c8-c610-4565-94bc-9f300c6e225a', 'eq', '88D585071A7A7921-60fbccb5-2923-47e5-8436-4616722878d4');");

            await dbContext.SaveChangesAsync();
        }
    }
}