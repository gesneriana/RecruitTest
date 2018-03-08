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

Date: 2018-03-08 20:27:44
*/


-- ----------------------------
-- Table structure for user_answer
-- ----------------------------
DROP TABLE IF EXISTS "public"."user_answer";
CREATE TABLE "public"."user_answer" (
"id" varchar(60) COLLATE "default" NOT NULL,
"user_id" varchar(60) COLLATE "default" NOT NULL,
"exam_data_id" varchar(60) COLLATE "default" NOT NULL,
"exam_type" varchar(10) COLLATE "default" NOT NULL,
"exam_answer" varchar(500) COLLATE "default" NOT NULL,
"addTime" timestamp(6) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of user_answer
-- ----------------------------

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table user_answer
-- ----------------------------
ALTER TABLE "public"."user_answer" ADD PRIMARY KEY ("id");
