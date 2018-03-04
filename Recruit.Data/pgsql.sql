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

Date: 2018-03-05 01:36:23
*/


-- ----------------------------
-- Table structure for exam_data
-- ----------------------------
DROP TABLE IF EXISTS "public"."exam_data";
CREATE TABLE "public"."exam_data" (
"id" varchar(60) COLLATE "default" NOT NULL,
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
"addtime" timestamp(6) DEFAULT now() NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of exam_data
-- ----------------------------
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFF5C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFF6C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFF7C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFF8C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFF9C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFFAC-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFFBC-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFFCC-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFFDC-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFFEC-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF020FFFFC-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0210000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0220000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0230000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0240000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0250000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0260000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0270000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0280000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF0290000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');
INSERT INTO "public"."exam_data" VALUES ('88D581EF02A0000C-a1a0bfbc-e1a1-419b-aef3-5cb8806113c0', '.net core', 'mono', '.net standard', '.net framework', '.net core, mono , .net standard , .net framework那个才是标准库', 'C', '', 'cq', '88D581866484CFAD-17e7a22a-8121-4ebe-942e-5943226ac0b2', '88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-05 01:00:37.746661');

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
INSERT INTO "public"."recruit_user" VALUES ('88D5811FB2B0A610-8eb9d0eb-45ad-4b6c-93eb-e8ca2c6581d9', '2018-03-04 22:32:35.518708', 'user', '42112719941208', '', '', '', '', 's694060865@gmail.com', 'asuna', '17666293366', 'BAC3D3E72B8767E72E31614555C9C369AAE832F0', '江郎才尽');
INSERT INTO "public"."recruit_user" VALUES ('88D5811FB2B0A617-25bdaf19-b3e6-4ade-a239-7ba60466732e', '2018-03-04 22:32:35.532411', 'company', '', '', '', '', '', 's694060865@163.com', '才众电脑', '17665271050', '041315C5385C02F3C3699218E9C2EEA7D18D4BE4', '才众电脑');

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
