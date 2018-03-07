/*
Navicat PGSQL Data Transfer

Source Server         : pgsql
Source Server Version : 100100
Source Host           : localhost:5432
Source Database       : RecruitData
Source Schema         : public

Target Server Type    : PGSQL
Target Server Version : 100100
File Encoding         : 65001

Date: 2018-03-05 17:20:05
*/


-- ----------------------------
-- Table structure for exam_data
-- ----------------------------
DROP TABLE IF EXISTS "public"."exam_data";
CREATE TABLE "public"."exam_data" (
"id" varchar(60) COLLATE "default" NOT NULL,
"addtime" timestamp(6) NOT NULL,
"anwser_a" varchar(50) COLLATE "default" NOT NULL,
"anwser_b" varchar(50) COLLATE "default" NOT NULL,
"anwser_c" varchar(50) COLLATE "default" NOT NULL,
"anwser_d" varchar(50) COLLATE "default" NOT NULL,
"exam_content" varchar(200) COLLATE "default" NOT NULL,
"exam_cq_anwser" varchar(4) COLLATE "default" NOT NULL,
"exam_eq_answer" varchar(200) COLLATE "default" NOT NULL,
"exam_type" varchar(2) COLLATE "default" NOT NULL,
"job_id" varchar(60) COLLATE "default" NOT NULL,
"user_id" varchar(60) COLLATE "default" NOT NULL,
"is_enabled" bool DEFAULT true NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of exam_data
-- ----------------------------
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D581EF020FFF5C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '2018-03-05 01:00:37.746661', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D5824196954636-1e02b9c8-c610-4565-94bc-9f300c6e225a', '2018-03-05 10:34:15.364365', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D5824199E6BF7B-e6bca42d-1d68-4c62-8cf0-5214b9a5176e', '2018-03-05 10:34:20.93149', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582419ABEA41C-62c521e0-1d43-42aa-93dd-b4367ee3c00b', '2018-03-05 10:34:22.346351', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582419B439FEF-f115db9e-6839-4fb2-b601-ba25466faa33', '2018-03-05 10:34:23.217873', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582419BAF0B61-061e7de7-5ffd-4449-8b84-ac875095f53f', '2018-03-05 10:34:23.921871', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582419C110C73-68a70b28-39dd-4dfa-8e00-fc10d1b3bfe4', '2018-03-05 10:34:24.564153', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582419C602530-9b09ff5e-d280-4a6a-ad5d-18d721ed4dd9', '2018-03-05 10:34:25.082506', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582419CC94DC8-f4f2f2de-2f37-46bb-a51f-1250599c8ad4', '2018-03-05 10:34:25.771674', '', '', '', '', '.net core与.net framework的反射有什么不同的地方', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D58242136C90BB-189f018d-0a9d-4d0f-afe9-594b4ac1bac1', '2018-03-05 10:37:44.812776', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D58242147B49CA-921c81da-30e1-4259-af42-3c997440cb82', '2018-03-05 10:37:46.586986', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D58242154D1F2D-3300237e-96fe-40df-b9ca-dd7108393a20', '2018-03-05 10:37:47.96216', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D5824215A15F49-15e17a61-d481-48a0-97c1-ca0fb41a5106', '2018-03-05 10:37:48.514293', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D5824215E3588A-ab4ec9f5-4a6b-4a40-9c2d-673b467ced5f', '2018-03-05 10:37:48.946662', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582421602F8EC-206b1f7f-7c57-40d6-ac46-1d40564a787e', '2018-03-05 10:37:49.153925', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D5824217FFEFCF-e0f40beb-239d-4ff4-84ba-23f3a3081c07', '2018-03-05 10:37:52.489473', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582421883E65C-d568ef56-7401-4b26-840a-6b0d32f02c4f', '2018-03-05 10:37:53.354306', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582422240794C-1b55ef1e-45b2-426d-80c8-bcb1c801464b', '2018-03-05 10:38:09.68964', '', '', '', '', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D58242233C1167-0316a566-3731-47a1-8619-2d1583c12e78', '2018-03-05 10:38:11.338487', '', '', '', '', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D58242244B1AFB-5005a8f1-2385-46f7-bfdf-c548aec1460c', '2018-03-05 10:38:13.114759', '', '', '', '', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', '', '.net core的反射精简了部分api, 而且提高了性能', 'eq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');
INSERT INTO "public"."exam_data" (id,addtime,anwser_a,anwser_b,anwser_c,anwser_d,exam_content,exam_cq_anwser,exam_eq_answer,exam_type,job_id,user_id,is_enabled) VALUES ('88D582422707C688-3f25d884-9ec2-4994-a302-3af5aded0999', '2018-03-05 10:38:17.706671', '.net framework', '.net core', 'mono', '差距不大,没有明显区别', '.net framework和 mono , .net core在web服务器开发领域哪个性能最好, 因为.net framework不能跨平台, 所以只考虑web api等关键技术的性能即可', 'A', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', 't');

-- ----------------------------
-- Table structure for job_type
-- ----------------------------
DROP TABLE IF EXISTS "public"."job_type";
CREATE TABLE "public"."job_type" (
"uuid" varchar(60) COLLATE "default" NOT NULL,
"addtime" timestamp(6) NOT NULL,
"is_enabled" bool NOT NULL,
"job_name" varchar(50) COLLATE "default" NOT NULL,
"user_id" varchar(60) COLLATE "default" NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of job_type
-- ----------------------------
INSERT INTO "public"."job_type" VALUES ('88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '2018-03-04 12:14:15.481948', 't', '.net core工程师', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');
INSERT INTO "public"."job_type" VALUES ('88D581B754874D9C-b4ca7587-aa39-437c-a68e-31ae318177ae', '2018-03-04 18:04:33.994484', 't', '前端工程师', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e');

-- ----------------------------
-- Table structure for recruit_user
-- ----------------------------
DROP TABLE IF EXISTS "public"."recruit_user";
CREATE TABLE "public"."recruit_user" (
"uuid" varchar(60) COLLATE "default" NOT NULL,
"addtime" timestamp(6) NOT NULL,
"auth_role" varchar(50) COLLATE "default",
"birthday" varchar(14) COLLATE "default",
"company_address" varchar(200) COLLATE "default",
"company_code" varchar(50) COLLATE "default",
"company_contact" varchar(50) COLLATE "default",
"company_name" varchar(50) COLLATE "default",
"email" varchar(50) COLLATE "default" NOT NULL,
"nickname" varchar(20) COLLATE "default" NOT NULL,
"phone" varchar(20) COLLATE "default" NOT NULL,
"pwd" varchar(200) COLLATE "default" NOT NULL,
"uname" varchar(20) COLLATE "default"
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of recruit_user
-- ----------------------------
INSERT INTO "public"."recruit_user" VALUES ('88D5811FB2B0A610-8eb9d0eb-45ad-4b6c-93eb-e8ca2c6581d9', '2018-03-05 10:12:13.730498', 'user', '42112719941208', '', '', '', '', 's694060865@gmail.com', 'asuna', '17666293366', 'BAC3D3E72B8767E72E31614555C9C369AAE832F0', '江郎才尽');
INSERT INTO "public"."recruit_user" VALUES ('88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 10:12:13.802008', 'company', '', '', '', '', '', 's694060865@163.com', '才众电脑', '17665271050', '041315C5385C02F3C3699218E9C2EEA7D18D4BE4', '才众电脑');

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table exam_data
-- ----------------------------
ALTER TABLE "public"."exam_data" ADD PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table job_type
-- ----------------------------
ALTER TABLE "public"."job_type" ADD PRIMARY KEY ("uuid");

-- ----------------------------
-- Uniques structure for table recruit_user
-- ----------------------------
ALTER TABLE "public"."recruit_user" ADD UNIQUE ("nickname");
ALTER TABLE "public"."recruit_user" ADD UNIQUE ("phone");
ALTER TABLE "public"."recruit_user" ADD UNIQUE ("email");

-- ----------------------------
-- Primary Key structure for table recruit_user
-- ----------------------------
ALTER TABLE "public"."recruit_user" ADD PRIMARY KEY ("uuid");


INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D5811FB2B0A610-8eb9d0eb-45ad-4b6c-93eb-e8ca2c6581d9', '2018-03-05 19:11:28.409758', 'user', '42112719941208', '', '', '', '', 's694060865@gmail.com', 'asuna', '17666293366', 'BAC3D3E72B8767E72E31614555C9C369AAE832F0', '江郎才尽');
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 19:11:28.428857', 'company', '', '深圳市盐田区', '1234567894648', 'www.fic.con.cn', '才众电脑', 's694060865@163.com', '才众电脑', '17665271050', '041315C5385C02F3C3699218E9C2EEA7D18D4BE4', '才众电脑');
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584461E17C8C9-924a8600-38fc-43c7-a721-845f29b4a46a', '2018-03-08 00:11:43.024569', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '131654464@qq.com', 'asuna123', '18612345678', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584462E6CE0DB-c8ed4479-dfb8-4fe8-adef-f680d2b6257f', '2018-03-08 00:12:10.425784', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '131641564@qq.com', 'asuna111', '18612345696', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584463A34ADFC-5e71fcbb-691c-4d67-b01e-e42ac6c66011', '2018-03-08 00:12:30.19014', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '4164141564@qq.com', 'asuna222', '18612695696', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D5844644A77117-6f617fb3-6965-43b0-ae43-12ed228472c0', '2018-03-08 00:12:47.71946', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '98751564@qq.com', 'asuna333', '18632695696', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584464E62F27B-3d988797-19da-4897-ac48-6651ec096ba6', '2018-03-08 00:13:04.047788', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '98759664@qq.com', 'asuna555', '18632695324', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584465DE0C377-7c4c5f6c-8fdf-4756-9b08-e9032255f53c', '2018-03-08 00:13:30.038163', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '456469664@qq.com', 'asuna777', '18632696987', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D5844668854511-7ef45679-9984-49eb-9638-ac21b30faa21', '2018-03-08 00:13:47.893489', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '459769664@qq.com', 'asuna888', '18632696665', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D5844683F4123D-113f2d9c-5145-48b3-9b23-4607a2856a51', '2018-03-08 00:14:33.918121', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '45963664@qq.com', 'asuna999', '18632678665', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D58446AFEB6D0D-fbe7f8ea-816f-460e-bc1e-87de2d6cab01', '2018-03-08 00:15:47.681213', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '45963321@qq.com', 'asuna21', '17612346589', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D58446BFB3BB68-417fdd0d-a5c6-4efb-9a65-df047241cdfd', '2018-03-08 00:16:14.159763', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '45966351@qq.com', 'asuna22', '17612346532', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D58446CE07DD9E-21e52257-f697-43dd-a289-f1c0503065f7', '2018-03-08 00:16:38.199242', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '45915661@qq.com', 'asuna56', '17623567891', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D58446E20104C4-e0c0f881-0b53-4991-bf8f-8b1222ee0221', '2018-03-08 00:17:11.708799', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '51655661@qq.com', 'asuna156', '17623567832', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D58446F209678E-d7da4523-3d9e-48a4-977e-116b06f12213', '2018-03-08 00:17:38.607311', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '536981661@qq.com', 'asuna362', '17623562832', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D58446FF29A166-500a3bd1-ac60-4f42-b9ed-86d535eb0d8e', '2018-03-08 00:18:00.628879', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '5341631561@qq.com', 'asuna39496', '17623596301', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D5844709FCA0E4-f2ab8b41-84bb-4e56-8b59-f1b948d81dc7', '2018-03-08 00:18:18.788893', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '53401561@qq.com', 'asuna3901', '17623506301', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584471632ED46-0f20efe9-80d9-4814-b2f3-165672a1d8a3', '2018-03-08 00:18:39.277406', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '53436861@qq.com', 'asuna025', '17623500101', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584472006DBD7-97fcbd9b-59f6-4179-9057-3c719b64fa72', '2018-03-08 00:18:55.765815', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '53431661@qq.com', 'asuna068', '17623555101', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D584472C9EE8F6-8e77b9be-80a1-4318-af5f-7bb5d37d5b62', '2018-03-08 00:19:16.894957', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '53987661@qq.com', 'asuna967', '17623695101', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
INSERT INTO "public"."recruit_user" ("uuid", "addtime", "auth_role", "birthday", "company_address", "company_code", "company_contact", "company_name", "email", "nickname", "phone", "pwd", "uname") VALUES ('88D58447389B703C-89c466c9-6a8f-47d8-a4f9-820f35293157', '2018-03-08 00:19:37.004868', 'company', NULL, '深圳市南山区', '466418566646', 'xx大厦', '寒武纪', '539898761@qq.com', 'asuna056', '17623693206', '7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL);
