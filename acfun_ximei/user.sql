/*
Navicat SQLite Data Transfer

Source Server         : acfun
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2015-04-05 23:46:43
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS "main"."user";
CREATE TABLE "user" (
"id"  INTEGER NOT NULL,
"userid"  INTEGER,
"username"  TEXT NOT NULL,
"userpassword"  TEXT NOT NULL,
"moni"  REAL,
PRIMARY KEY ("id")
);
