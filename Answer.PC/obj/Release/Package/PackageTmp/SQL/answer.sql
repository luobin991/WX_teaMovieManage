/*
Navicat MySQL Data Transfer

Source Server         : mySql150
Source Server Version : 50520
Source Host           : 192.168.0.150:3306
Source Database       : answer

Target Server Type    : MYSQL
Target Server Version : 50520
File Encoding         : 65001

Date: 2018-07-18 10:43:23
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `sys_authorize`
-- ----------------------------
DROP TABLE IF EXISTS `sys_authorize`;
CREATE TABLE `sys_authorize` (
  `authorizeId` varchar(50) NOT NULL COMMENT '授权功能主键',
  `objectType` int(11) DEFAULT NULL COMMENT '对象分类:1-角色2-用户',
  `objectId` varchar(50) DEFAULT NULL COMMENT '对象主键',
  `itemType` int(11) DEFAULT NULL COMMENT '项目类型:1-菜单2-按钮3-视图',
  `itemId` varchar(50) DEFAULT NULL COMMENT '项目主键',
  `createDate` timestamp NULL DEFAULT NULL,
  `createUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`authorizeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_authorize
-- ----------------------------
INSERT INTO `sys_authorize` VALUES ('010091fd-034c-42ff-b859-fd681713c006', '2', '7', '1', '11', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('04b03ab4-5a2e-4689-ae4c-cb9ab091a0c7', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '2', 'f6aac01a-2cc9-4814-9d52-7b1f1614c58a', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('082481a9-8bd7-4421-b8ba-077f958b7b64', '2', '7', '1', '0ea191fd-2862-4524-a7a2-42bfe18baca3', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('1a864872-b654-4ac9-9043-be77e953f20b', '2', '7', '2', '31d78cfd-13fc-418d-a420-05b6e85e4742', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('1d3e38b6-c7c5-4967-92d8-ab15749f03e6', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '1', '10', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('2f6ebe74-9bfd-44ac-9053-b305d5c31664', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '1', '12', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('5b0c0d7f-e809-488e-a477-217a37c996e0', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '1', '4', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('6c7200c5-91de-445b-af18-607f83402824', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '1', '3', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('72070e83-33c0-4ef9-8e49-6814fcd86b14', '2', '7', '1', 'fa9d682d-2b85-478d-a175-efbf7ce22d01', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('73da5ddf-4503-4e21-a211-5124d6142d79', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '1', 'c4389fba-6be4-4f5a-94cf-ed7e17867cc2', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('886568a4-1dcd-415e-9d32-52181750410e', '2', '7', '1', '10', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('8dbfec7f-b7ba-4dfa-afd1-35a476e2d129', '2', '7', '1', 'c4389fba-6be4-4f5a-94cf-ed7e17867cc2', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('a0702d74-2897-48c5-a9a7-ee0e06f13d46', '2', '7', '1', '952eb09b-7eb9-4044-b425-b64a26ec0c75', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('c92675e0-e345-4295-9cc2-555eade963e9', '2', '7', '3', '', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('d2918c51-79bd-44cb-a3e4-68d5c6c7babf', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '1', 'fa9d682d-2b85-478d-a175-efbf7ce22d01', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('d859067d-7a96-494d-8a9e-988537751459', '2', '7', '2', 'b7e143b8-36b3-4905-9b9e-5e9cfa6e0cb1', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('e3dcb646-715a-4807-aa6e-92b432993143', '2', '7', '2', '42ca3d6d-4826-4338-8ef4-93f1e73641c6', '2018-01-26 17:48:15', '1');
INSERT INTO `sys_authorize` VALUES ('ed8f0f6a-20c9-4f80-838f-78bbf3015013', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '1', '5', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('f7d73a02-2aa4-404c-bdf9-ce5c38ce4a1b', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '3', 'ac599fcf-7d8c-4571-bf61-a5c204756171', '2017-11-30 16:43:38', '1');
INSERT INTO `sys_authorize` VALUES ('f9150273-c7d4-4663-8f48-0a33baf9c95a', '2', '7', '1', '13', '2018-01-26 17:48:15', '1');

-- ----------------------------
-- Table structure for `sys_daysum_diamond`
-- ----------------------------
DROP TABLE IF EXISTS `sys_daysum_diamond`;
CREATE TABLE `sys_daysum_diamond` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` int(11) DEFAULT '0' COMMENT '类别：1个人，2俱乐部',
  `typeId` int(11) DEFAULT '0' COMMENT '对象Id',
  `diamond` int(11) DEFAULT '0' COMMENT '钻石数量',
  `diamondType` int(11) DEFAULT '0' COMMENT '钻石类型:1消耗',
  `createTime` timestamp NULL DEFAULT NULL COMMENT '创建时间',
  `playSZ` int(11) DEFAULT NULL COMMENT '上庄消耗钻石数',
  `playGD` int(11) DEFAULT NULL COMMENT '固定消耗钻石数',
  `playZY` int(11) DEFAULT NULL COMMENT '自由消耗钻石数',
  `playMP` int(11) DEFAULT NULL COMMENT '明牌消耗钻石数',
  `playTB` int(11) DEFAULT NULL COMMENT '通比消耗钻石数',
  `playLZ` int(11) DEFAULT NULL COMMENT '轮庄消耗钻石数',
  `play10` int(11) DEFAULT NULL COMMENT '10局消耗钻石数',
  `play20` int(11) DEFAULT NULL COMMENT '20局消耗钻石数',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_daysum_diamond
-- ----------------------------
INSERT INTO `sys_daysum_diamond` VALUES ('1', '1', '10000000', '18', '1', '2018-03-28 23:59:59', '18', '0', '0', '0', '0', '0', '12', '6');
INSERT INTO `sys_daysum_diamond` VALUES ('2', '1', '22182522', '6', '1', '2018-03-28 23:59:59', '0', '0', '0', '6', '0', '0', '0', '6');
INSERT INTO `sys_daysum_diamond` VALUES ('3', '1', '78049446', '6', '1', '2018-03-28 23:59:59', '0', '0', '0', '6', '0', '0', '6', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('4', '1', '89898105', '6', '1', '2018-03-28 23:59:59', '6', '0', '0', '0', '0', '0', '6', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('5', '1', '28460785', '6', '1', '2018-03-30 23:59:59', '0', '0', '0', '6', '0', '0', '0', '6');
INSERT INTO `sys_daysum_diamond` VALUES ('6', '1', '31727272', '18', '1', '2018-03-30 23:59:59', '0', '0', '0', '18', '0', '0', '0', '18');
INSERT INTO `sys_daysum_diamond` VALUES ('7', '1', '73932371', '24', '1', '2018-04-02 23:59:59', '0', '0', '0', '24', '0', '0', '0', '24');
INSERT INTO `sys_daysum_diamond` VALUES ('8', '1', '47360510', '6', '1', '2018-04-03 23:59:59', '6', '0', '0', '0', '0', '0', '6', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('9', '1', '53208166', '6', '1', '2018-04-03 23:59:59', '6', '0', '0', '0', '0', '0', '6', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('10', '1', '55912270', '12', '1', '2018-04-03 23:59:59', '6', '0', '0', '6', '0', '0', '12', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('11', '1', '73932371', '36', '1', '2018-04-03 23:59:59', '0', '0', '0', '36', '0', '0', '0', '36');
INSERT INTO `sys_daysum_diamond` VALUES ('12', '1', '72620880', '6', '1', '2018-04-08 23:59:59', '6', '0', '0', '0', '0', '0', '6', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('13', '1', '73932371', '24', '1', '2018-04-08 23:59:59', '0', '0', '0', '24', '0', '0', '0', '24');
INSERT INTO `sys_daysum_diamond` VALUES ('14', '1', '72620880', '24', '1', '2018-04-09 23:59:59', '24', '0', '0', '0', '0', '0', '24', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('15', '1', '73932371', '36', '1', '2018-04-09 23:59:59', '6', '0', '0', '30', '0', '0', '0', '36');
INSERT INTO `sys_daysum_diamond` VALUES ('16', '1', '10000000', '6', '1', '2018-04-10 23:59:59', '6', '0', '0', '0', '0', '0', '6', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('17', '1', '72620880', '6', '1', '2018-04-10 23:59:59', '6', '0', '0', '0', '0', '0', '6', '0');
INSERT INTO `sys_daysum_diamond` VALUES ('18', '1', '73932371', '24', '1', '2018-04-10 23:59:59', '0', '0', '0', '24', '0', '0', '0', '24');

-- ----------------------------
-- Table structure for `sys_log`
-- ----------------------------
DROP TABLE IF EXISTS `sys_log`;
CREATE TABLE `sys_log` (
  `F_LogId` varchar(50) NOT NULL,
  `F_CategoryId` int(4) DEFAULT NULL COMMENT '分类Id 1-登陆2-访问3-操作4-异常',
  `F_OperateUserId` varchar(50) DEFAULT NULL COMMENT '操作用户Id',
  `F_OperateTime` datetime DEFAULT NULL COMMENT '操作时间',
  `F_OperateAccount` varchar(50) DEFAULT NULL COMMENT '操作用户',
  `F_OperateTypeId` varchar(50) DEFAULT NULL COMMENT '操作类型Id',
  `F_OperateType` varchar(50) DEFAULT NULL COMMENT '操作类型',
  `F_Module` varchar(50) DEFAULT NULL COMMENT '系统功能',
  `F_IPAddress` varchar(50) DEFAULT NULL COMMENT 'IP地址',
  `F_Host` varchar(50) DEFAULT NULL COMMENT '主机',
  `F_Browser` varchar(50) DEFAULT NULL COMMENT '浏览器',
  `F_ExecuteResult` int(4) DEFAULT NULL COMMENT '执行结果状态',
  `F_ExecuteResultJson` varchar(2000) DEFAULT NULL COMMENT '执行结果信息',
  `F_DeleteMark` bigint(2) DEFAULT NULL COMMENT '删除标记',
  PRIMARY KEY (`F_LogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_log
-- ----------------------------
INSERT INTO `sys_log` VALUES ('0004e7bb-e8e5-4c1d-8557-1f2526e3289d', '4', 'API USER', '2018-07-13 14:26:00', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('002b21a9-4f0d-48aa-8bbd-2f87d11a5e83', '4', '1', '2018-07-02 15:05:27', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('00a4b981-c281-40d5-b37b-482e4be345e1', '2', '1', '2018-07-16 10:41:11', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('0319c31a-be26-429d-8da7-ea914bb67417', '4', 'API USER', '2018-06-29 11:17:54', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetTeaList\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('05b9c838-0503-41c9-8f32-b735801b9d9f', '2', '1', '2018-07-16 15:25:49', 'admin(超级管理员)', '3', '访问', '订单管理', '127.0.0.1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('06429d8b-e592-4fab-b64e-e6c459d068c9', '4', 'API USER', '2018-07-17 18:44:16', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetOrderPage&body=%7B%22pageIndex%22%3A1%7D\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('066b6bf3-9918-49b3-8a78-94c22b6b0db5', '3', '1', '2018-07-12 16:45:43', 'admin(超级管理员)', '7', '修改', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '248e8a53-cddd-4eba-b7d5-0ec235817a9b', '0');
INSERT INTO `sys_log` VALUES ('06e58432-9aee-4436-b3a1-69651beebe0c', '4', 'API USER', '2018-06-29 14:30:08', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetTeaList\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('06f5df8b-a2e2-45f6-b84a-46725ea88e31', '4', 'API USER', '2018-07-13 12:28:17', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('08b28a02-019f-4323-b80e-4ba748bf4643', '2', '1', '2018-07-16 14:40:19', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('099639ca-7125-40af-a4e7-494547e4011f', '4', 'API USER', '2018-07-13 15:16:44', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未能加载文件或程序集“Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed”或它的某一个依赖项。找到的程序集清单定义与程序集引用不匹配。 (异常来自 HRESULT:0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('0e04293e-4024-4372-b3e8-e66c97557667', '4', '1', '2018-07-13 14:54:28', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22keyword%22%3A%22%22%2C%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856960\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('0e123a84-9083-4ac2-b26c-6b91bf49239b', '4', '1', '2018-07-02 10:25:34', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530497209366\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('0e77215a-07f0-43c3-88a8-6bf6085decca', '4', 'API USER', '2018-07-13 14:26:11', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：JSONHelper.JSONToObject(): 数组的反序列化不支持类型“System.String”。\r\n', '0');
INSERT INTO `sys_log` VALUES ('0e8e062d-dc64-4c82-98b8-5e2fac34e26c', '4', '1', '2018-07-16 15:24:41', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725881106\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('0ffe864e-3d08-47ea-8fba-09b815e7c78d', '2', '1', '2018-07-16 14:43:08', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('1105dd49-cee3-4e56-9470-a45f81ad8403', '4', '1', '2018-06-29 18:47:31', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=0&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530269223385\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('13332b62-426d-4b32-87fb-34c1b706d211', '2', '1', '2018-07-16 11:59:05', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('13a02f45-fd05-42a0-88d8-ba1d4c9d7194', '2', '1', '2018-06-29 16:00:01', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('13b8e81a-84b2-448e-9106-e842eb1f731b', '4', 'API USER', '2018-06-29 15:00:09', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('162dddc4-2bfd-4eff-b1f3-75d45fd63c85', '2', '1', '2018-07-18 10:43:02', 'admin(超级管理员)', '3', '访问', '角色管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Role/Index', '0');
INSERT INTO `sys_log` VALUES ('1655469f-8cb2-44fd-a53a-9b98e5038edc', '4', 'API USER', '2018-06-15 12:21:14', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('17dd7be3-6b94-4673-8619-16e42830b2a0', '2', '1', '2018-07-16 14:39:57', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('1859ac1e-d619-4fa0-b7ea-78e0460e262e', '4', '1', '2018-07-02 15:05:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('1893839a-59f0-4fa9-ade9-779604994bb6', '2', '1', '2018-07-16 15:44:22', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('1bcd3748-42c5-432f-b99d-4d769905a59d', '4', '1', '2018-07-13 14:54:17', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856953\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('1c479f4d-c5d1-46c7-8eb2-a1a1ae6afccc', '4', '1', '2018-06-13 12:07:39', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/BindTea_Lable?fid=13\r\nMessage：未找到视图“8”或其母版视图，或没有视图引擎支持搜索的位置。搜索了以下位置: \r\n~/Areas/Goods/Views/Tea/8.aspx\r\n~/Areas/Goods/Views/Tea/8.ascx\r\n~/Areas/Goods/Views/Shared/8.aspx\r\n~/Areas/Goods/Views/Shared/8.ascx\r\n~/Views/Tea/8.aspx\r\n~/Views/Tea/8.ascx\r\n~/Views/Shared/8.aspx\r\n~/Views/Shared/8.ascx\r\n~/Areas/Goods/Views/Tea/8.cshtml\r\n~/Areas/Goods/Views/Tea/8.vbhtml\r\n~/Areas/Goods/Views/Shared/8.cshtml\r\n~/Areas/Goods/Views/Shared/8.vbhtml\r\n~/Views/Tea/8.cshtml\r\n~/Views/Tea/8.vbhtml\r\n~/Views/Shared/8.cshtml\r\n~/Views/Shared/8.vbhtml\r\n', '0');
INSERT INTO `sys_log` VALUES ('1dfda6b7-0feb-48ae-a334-4e1dced229f3', '2', '1', '2018-07-16 11:27:17', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('22db9ad7-d15e-4193-a161-d468c42a03c3', '2', '1', '2018-07-16 15:11:42', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('22e0ba84-a9ce-4db9-8a7e-ffc1134888f4', '2', '1', '2018-07-16 10:40:41', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('24ccd1f5-82db-486b-ae0c-1fb727164fff', '2', '1', '2018-07-16 11:57:32', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('273b9643-c4ee-46f4-a798-ce93ea6af6ec', '4', 'API USER', '2018-07-13 15:13:01', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('28daf34d-0f51-4524-a7c8-2e494010e969', '4', 'API USER', '2018-07-13 16:43:10', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'index,GoodsName,GoodsInfoStr,Price,num,SumPrice,createTime)\r\n                   \' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('295da6cb-f08b-48ae-8437-f33a65ca4e1a', '4', 'API USER', '2018-07-13 15:00:39', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未能加载文件或程序集“Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed”或它的某一个依赖项。找到的程序集清单定义与程序集引用不匹配。 (异常来自 HRESULT:0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('2a2e912f-1849-45f5-a149-fc1bb8262607', '4', '1', '2018-07-13 14:54:20', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%223%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856955\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('2a396fa5-0f3d-43b5-824a-cd5c47adcdbb', '2', '1', '2018-07-13 14:54:50', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('2a39ac16-c0f9-44a1-b068-b5e33b0aaa35', '4', 'API USER', '2018-07-13 10:48:35', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('2aabbf02-f2be-4d3e-bbd7-66af2593bb94', '4', '1', '2018-07-02 15:05:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('2b358976-5960-4c48-9f55-64ed96eab687', '2', '1', '2018-07-16 14:43:20', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('2b486440-f7ab-4c1e-9736-16583586c3e6', '4', 'API USER', '2018-07-13 15:18:30', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：JSONHelper.JSONToObject(): 无法将类型为“System.String”的对象转换为类型“System.String[]”\r\n', '0');
INSERT INTO `sys_log` VALUES ('31526103-c310-4bb9-8360-3004db20140f', '2', '1', '2018-07-16 11:20:31', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('32e03bdc-3c09-402d-88e6-642074ca8594', '4', 'API USER', '2018-07-13 16:41:37', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('33143ffd-7805-4405-a55b-64a710b2825d', '4', '1', '2018-06-29 18:47:31', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=0&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530269223385\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('335d83e3-4862-4345-b82f-9d0a7a9809eb', '2', '1', '2018-07-16 11:59:26', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('3466fb51-6dbc-412d-b378-c01516167b56', '4', '1', '2018-07-16 15:24:00', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?id=4&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725840841\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'orderid = 4  ORDER BY id desc\' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('3590652d-bf94-4fc4-84dd-dec3ffb0f17b', '4', '1', '2018-06-29 15:59:52', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：Packets larger than max_allowed_packet are not allowed.\r\n', '0');
INSERT INTO `sys_log` VALUES ('39a48869-7c0f-4954-8007-100191dfbfe8', '2', '1', '2018-07-18 10:42:59', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('3c4825df-cb6e-4ea9-a8ac-900315825aac', '4', 'API USER', '2018-07-12 18:14:11', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('3df5670d-bc93-4ef0-8d35-b40861f683c2', '4', '1', '2018-06-29 17:42:58', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=10&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530263673637\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('3e22b329-c560-4746-95e2-1c1496cfdf98', '2', '1', '2018-07-13 14:54:16', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('3e95fb3c-edc7-49a5-8ed7-2687a81dd05e', '4', '1', '2018-07-13 14:54:22', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856959\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('3ea798aa-33a8-42ad-8d25-8847810f6a6a', '4', '1', '2018-06-29 16:19:13', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：Packets larger than max_allowed_packet are not allowed.\r\n', '0');
INSERT INTO `sys_log` VALUES ('402a7b68-99be-49c1-8656-478b597f5984', '2', '1', '2018-07-16 11:54:09', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('40b18c56-b706-47c5-9eb7-18a526a1e0b1', '4', 'API USER', '2018-07-13 16:39:41', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('40b8320e-98d9-4ac2-9ede-8e9e64f1d7f7', '4', 'API USER', '2018-07-13 12:16:52', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('4118a3db-c8f2-459c-8286-a89b5752b7f6', '2', '1', '2018-07-16 16:53:20', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('415174a5-b873-4b8a-9a7c-0b212f20c39f', '4', '1', '2018-07-16 15:24:41', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725881106\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('41d31eac-50cd-4ff6-8286-a4c4f9bfbc08', '4', '1', '2018-07-16 15:25:51', 'admin(超级管理员)', '9', '异常', '', '127.0.0.1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725951468\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('4239096f-4ff9-4702-a517-6cab8d510513', '4', '1', '2018-07-02 10:25:33', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=13&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530497209365\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('42c085c7-6817-4bef-9d5f-1e421307b9ff', '4', '1', '2018-07-02 10:26:39', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/ShopManage/Shop/SaveShopInfo\r\nMessage：Packets larger than max_allowed_packet are not allowed.\r\n', '0');
INSERT INTO `sys_log` VALUES ('446bae17-54d9-4c4d-875c-e85604eaf806', '4', 'API USER', '2018-06-29 11:18:14', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetTeaList\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('44a5a2e3-1b8f-47d7-a96a-8af0c97a103f', '4', '1', '2018-07-16 15:35:57', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?id=4&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531726546146\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'orderid = 4  ORDER BY id desc\' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('4522b00b-4f00-4f9f-8485-703583e4c5c8', '4', '1', '2018-07-16 15:27:10', 'admin(超级管理员)', '9', '异常', '', '127.0.0.1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531726029188\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('46f93f3a-2d24-41a0-9088-4433f7498fb2', '2', '1', '2018-07-16 10:38:14', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('473a6361-5a9e-49f0-818c-c89ab0296250', '4', 'API USER', '2018-07-13 16:37:25', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('47dfad2c-2d84-4ece-8360-5cdd37ff34e3', '4', '1', '2018-07-13 14:54:17', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856954\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('48380083-d4dc-46ac-b219-11023d6ff37d', '2', '1', '2018-07-16 14:40:36', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('49fb6316-a19a-4f68-8f88-152f87d0f2d0', '4', '1', '2018-07-13 14:54:52', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%222%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890960\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('4ae26b74-c516-4a38-b492-3838985027d7', '4', '1', '2018-07-02 15:05:17', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('4b82fee8-a6ea-4867-a8d5-0b06268120e9', '2', '1', '2018-07-16 14:41:03', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('4d223243-06ad-477c-8531-221d254f1f6d', '2', '1', '2018-07-18 10:42:50', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('503346d2-03cc-4ca0-8490-1aa2901484d7', '4', '1', '2018-07-13 14:54:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%223%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856957\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('5094f62d-8b0b-46e3-a0e5-8819360057ae', '2', '1', '2018-06-14 16:59:43', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('50c97b17-d313-43d3-96ab-d6665e21cda8', '4', 'API USER', '2018-07-13 14:28:35', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：JSONHelper.JSONToObject(): 数组的反序列化不支持类型“System.String”。\r\n', '0');
INSERT INTO `sys_log` VALUES ('514cb559-9920-45cc-97c3-d96bce25af9c', '4', '1', '2018-07-02 15:05:27', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('51b916d4-dcba-490d-8c8f-30a812badca1', '4', '1', '2018-06-13 12:07:39', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/BindTea_Lable?fid=13\r\nMessage：未找到视图“8”或其母版视图，或没有视图引擎支持搜索的位置。搜索了以下位置: \r\n~/Areas/Goods/Views/Tea/8.aspx\r\n~/Areas/Goods/Views/Tea/8.ascx\r\n~/Areas/Goods/Views/Shared/8.aspx\r\n~/Areas/Goods/Views/Shared/8.ascx\r\n~/Views/Tea/8.aspx\r\n~/Views/Tea/8.ascx\r\n~/Views/Shared/8.aspx\r\n~/Views/Shared/8.ascx\r\n~/Areas/Goods/Views/Tea/8.cshtml\r\n~/Areas/Goods/Views/Tea/8.vbhtml\r\n~/Areas/Goods/Views/Shared/8.cshtml\r\n~/Areas/Goods/Views/Shared/8.vbhtml\r\n~/Views/Tea/8.cshtml\r\n~/Views/Tea/8.vbhtml\r\n~/Views/Shared/8.cshtml\r\n~/Views/Shared/8.vbhtml\r\n', '0');
INSERT INTO `sys_log` VALUES ('51fe71ad-19cd-4408-ac92-35e998936c84', '4', 'API USER', '2018-07-17 18:39:52', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetOrderPage&body=%7B%22pageIndex%22%3A1%7D\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('54919683-1d8f-4ed4-a782-02ffb0211e63', '4', 'API USER', '2018-06-14 16:57:12', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('55ef5a58-3131-4b8b-9c2b-d01bf350d026', '4', '1', '2018-07-02 15:05:16', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('5691b727-ccd5-4d30-85fe-244759d259c4', '2', '1', '2018-07-16 10:38:14', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('572c4f02-fd05-4d56-b509-168f310f6869', '2', '1', '2018-07-16 10:40:41', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('573af382-1398-4753-882d-d1bcaaa54b1b', '4', 'API USER', '2018-06-29 11:16:31', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetTeaList\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('577ddc09-12ad-4506-8da7-e081d1a53594', '4', 'API USER', '2018-07-13 15:14:18', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：JSONHelper.JSONToObject(): 无效的 JSON 基元: object。\r\n', '0');
INSERT INTO `sys_log` VALUES ('57eec04a-88e7-4d1a-9a9a-bb93aacb3e27', '4', '1', '2018-06-29 10:30:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530239411080\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('5843fc29-12b4-4a91-ba1e-6fc5460a1ce2', '4', '1', '2018-07-13 14:54:22', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856959\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('59408a1b-7426-493e-b071-b0d2fcb6fd79', '4', '1', '2018-07-13 14:54:53', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%223%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890961\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('59bd821f-76fe-49e0-b027-324c8192f1e7', '2', '1', '2018-07-12 16:45:03', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('5b0458ba-a255-4f5b-a59b-f10a15d17fef', '4', '1', '2018-07-16 15:24:00', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?id=4&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725840841\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'orderid = 4  ORDER BY id desc\' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('5b0c2651-63bd-4986-83f4-fdd38fd68c5d', '4', 'API USER', '2018-07-13 14:59:53', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未能加载文件或程序集“Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed”或它的某一个依赖项。找到的程序集清单定义与程序集引用不匹配。 (异常来自 HRESULT:0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('5dc8d5e4-9652-4ca9-9398-242865ae60e3', '4', 'API USER', '2018-06-14 16:57:48', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetNoticeImgs\r\nMessage：无法找到指定文件。\r\n', '0');
INSERT INTO `sys_log` VALUES ('5de754d8-fdd4-4fb4-a117-06b34560d0e0', '4', 'API USER', '2018-07-13 15:02:30', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：JSONHelper.JSONToObject(): 无法将类型为“System.String”的对象转换为类型“System.String[]”\r\n', '0');
INSERT INTO `sys_log` VALUES ('5e4a20d7-9200-425e-9c00-6bad048c3709', '4', '1', '2018-06-29 17:43:50', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=0&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530263673638\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('5e652954-d448-4eed-b30d-aa7e04a7ab75', '2', '1', '2018-07-12 16:44:58', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('60178dab-5161-4c66-be8d-b5375bbbba0f', '4', '1', '2018-06-29 10:30:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530239411080\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('60cb01f3-3724-4d05-8b62-eba04a8ad8c3', '4', '1', '2018-07-13 14:54:53', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890962\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('61282a6f-ef49-4d88-a495-ad5568176ad4', '4', '1', '2018-06-29 17:43:50', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=0&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530263673638\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('61484045-1071-491c-959e-a1436a8a26f8', '2', '1', '2018-07-12 16:45:46', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('616ace00-7b41-48e1-95d2-cbc3d1280571', '4', 'API USER', '2018-07-13 15:07:24', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：Error reading JObject from JsonReader. Current JsonReader item is not an object: StartArray. Path \'\', line 1, position 1.\r\n', '0');
INSERT INTO `sys_log` VALUES ('619e0177-de9d-4adf-933f-f056b479cbf4', '4', 'API USER', '2018-07-13 16:41:47', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：Data too long for column \'orderUserPhone\' at row 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('6252fdc1-08e1-446f-b6d5-1e810038a2ee', '4', '1', '2018-07-02 10:25:33', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=13&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530497209365\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('639f50ba-631a-4970-99e8-6496d3d9c21f', '4', 'API USER', '2018-07-13 15:13:04', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：JSONHelper.JSONToObject(): 无效的 JSON 基元: object。\r\n', '0');
INSERT INTO `sys_log` VALUES ('650c17b4-0ac1-4d66-9b15-a773dafa5778', '4', 'API USER', '2018-07-13 15:16:11', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('66ac590d-5c71-4a44-820d-82d5a290217f', '2', '1', '2018-07-16 11:59:21', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('6804d362-97c0-469e-92e3-3c8d61282d5f', '4', 'API USER', '2018-07-13 17:21:34', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：无法将类型为“DapperRow”的对象强制转换为类型“System.IConvertible”。\r\n', '0');
INSERT INTO `sys_log` VALUES ('681d0611-a38f-4f73-9308-95aa05276733', '2', '1', '2018-07-18 10:43:00', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('6a06f256-92a9-43ca-8836-8a35bdf09925', '2', '1', '2018-07-16 14:39:36', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('6a73e118-5c54-4c17-8764-50e5903ad458', '4', '1', '2018-07-13 14:54:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856956\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('6a784746-433b-45f5-a561-6b676828c1d5', '4', 'API USER', '2018-07-16 16:50:54', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('6c448557-004c-492d-adf9-22f157a16700', '2', '1', '2018-06-29 11:20:42', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('6d2eb108-3137-47f1-b399-22a01e6c3080', '1', '1', '2018-07-16 10:40:59', 'admin(超级管理员)', '1', '登录', '', '::1', 'localhost', 'Chrome_65.0', '1', '退出系统', '0');
INSERT INTO `sys_log` VALUES ('6e2d1f39-362b-4ea0-96e6-32ba2e87bb24', '2', '1', '2018-07-17 18:35:31', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('6e9d8a3c-5178-43b9-b226-f871d364fc26', '4', 'API USER', '2018-07-13 16:48:40', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('70ff038c-1e44-4c14-93b4-f663438f2651', '4', '1', '2018-07-16 15:27:11', 'admin(超级管理员)', '9', '异常', '', '127.0.0.1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531726029188\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('72d1a8fe-f93d-4e01-b859-eb25753e11ee', '4', '1', '2018-07-13 14:54:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%223%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856957\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('7304d666-50d4-4e81-9af2-f27b39d28fac', '2', '1', '2018-07-18 10:43:00', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('7599ad35-d535-4a72-8945-7f07c9ef2e54', '2', '1', '2018-07-12 16:43:38', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('75e0f616-4c66-4fb9-9a16-d1b36d9d390c', '2', '1', '2018-07-16 15:24:39', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('77f4e072-c434-4fdb-a514-496bceaab527', '4', '1', '2018-06-29 18:47:15', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530269223384\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('78255eeb-582d-4442-b33b-d72cbc020049', '4', '1', '2018-07-16 15:23:25', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725805289\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('7b5ef305-4bca-41cd-8eef-ba14a431d345', '4', 'API USER', '2018-07-18 09:53:53', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetOrderPage&body=%7B%22pageIndex%22%3A1%7D\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('7bd35d45-cef9-4191-acec-5434a7d70811', '2', '1', '2018-07-16 11:57:55', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('7e56737e-5a91-4b9d-8b32-f35f06b602ea', '4', '1', '2018-07-02 15:18:10', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=13&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530513806853\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('7fc70ebf-ec51-4f6f-a6bd-cec8b98579a6', '2', '1', '2018-07-16 15:41:59', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('831a6568-79b7-423e-aaea-c83f43d2ec4e', '4', '1', '2018-07-16 16:59:40', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531731578811\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('838c7685-96e3-4dcc-b399-f838abbb1d15', '4', 'API USER', '2018-07-13 12:13:56', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('8498c55c-a7e9-460e-840a-d9b040f3454a', '4', '1', '2018-07-02 15:06:41', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('84b5d857-215b-484f-aa02-779170066595', '2', '1', '2018-07-16 11:58:50', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('86cfbebd-49a2-48d5-8c88-e439a0259355', '4', 'API USER', '2018-07-13 15:16:15', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未能加载文件或程序集“Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed”或它的某一个依赖项。找到的程序集清单定义与程序集引用不匹配。 (异常来自 HRESULT:0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('8af0633b-14b8-44fe-9e7b-cb65eeaaf232', '2', '1', '2018-06-29 18:47:34', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('8b6fd04e-a2a1-4b64-a85a-6cd6f60773bb', '4', '1', '2018-07-02 15:18:10', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=13&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530513806853\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('8c9d6228-54ef-4516-86b4-c7e28cca459a', '2', '1', '2018-07-12 16:45:03', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('8d42af8d-adca-4712-a41d-e82b9a0340e8', '4', 'API USER', '2018-07-16 16:53:54', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('8d5a176c-896d-4b49-bb54-22a3c797bed6', '4', '1', '2018-07-16 15:26:09', 'admin(超级管理员)', '9', '异常', '', '127.0.0.1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725969196\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('8f67bdf0-a86c-463c-a5e7-4a07aceb395b', '4', '1', '2018-07-13 14:54:28', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22keyword%22%3A%22%22%2C%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856960\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('908ff339-ddec-4867-945a-a35c283caeb3', '2', '1', '2018-07-16 16:51:22', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('918e044b-735c-454b-a7a2-de2912dbf852', '4', 'API USER', '2018-07-13 16:46:04', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'index,GoodsName,GoodsInfoStr,Price,num,SumPrice,createTime)\r\n                   \' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('93894d8b-6b04-4d7e-8a48-12eab28411f2', '4', '1', '2018-07-13 14:54:53', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%223%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890961\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('95835d19-9537-430d-a669-f287729c6d5b', '2', '1', '2018-07-16 15:13:20', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('966ef6ad-a6df-42d8-87fd-40216fb0036f', '4', 'API USER', '2018-07-13 15:00:36', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未能加载文件或程序集“Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed”或它的某一个依赖项。找到的程序集清单定义与程序集引用不匹配。 (异常来自 HRESULT:0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('97769e36-c958-45f3-b2ea-985fb4be0f0c', '2', '1', '2018-07-17 15:28:17', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('98580545-28ad-43f0-b1c2-9acd31657feb', '2', '1', '2018-07-13 15:02:52', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('998c7d15-7358-4f0f-a3f3-b9d875554a68', '4', 'API USER', '2018-06-29 14:58:17', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetTeaList\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('99dbad51-75bb-4b13-84b2-3dd34adc5ed4', '4', '1', '2018-07-16 16:59:48', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531731578813\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('9b2038b6-b7eb-4ebd-bf9f-0d83aac61046', '4', '1', '2018-07-02 10:26:39', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/ShopManage/Shop/SaveShopInfo\r\nMessage：Packets larger than max_allowed_packet are not allowed.\r\n', '0');
INSERT INTO `sys_log` VALUES ('9c5daa7f-0cb1-4e4f-8761-1a5dff21c1bc', '4', '1', '2018-07-16 16:59:48', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531731578813\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('9fcac044-80c6-40e4-86d1-420a2523985a', '2', '1', '2018-07-13 14:29:02', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('a0deecc2-e4f1-4902-a065-4da1f37f46c5', '4', 'API USER', '2018-06-14 16:59:03', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetNoticeImgs&body=\r\nMessage：无法找到指定文件。\r\n', '0');
INSERT INTO `sys_log` VALUES ('a2b168c3-533d-4019-893d-f5758ccd9bf9', '4', 'API USER', '2018-07-17 18:40:47', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetOrderPage&body=%7B%22pageIndex%22%3A1%7D\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('a2bbdfe1-c29d-4116-997c-96e41e092b52', '4', 'API USER', '2018-06-15 12:08:42', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('a2e63f38-8a76-4e15-9736-bbd2d666f69a', '4', 'API USER', '2018-07-02 11:57:51', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('a3ccb50c-b673-47ba-94d4-852d6b67fcf1', '1', '1', '2018-07-16 10:41:35', 'admin(超级管理员)', '1', '登录', '', '::1', 'localhost', 'Chrome_65.0', '1', '退出系统', '0');
INSERT INTO `sys_log` VALUES ('a57c177c-ff31-46e2-b6d7-c6154409d19e', '4', '1', '2018-07-16 15:26:09', 'admin(超级管理员)', '9', '异常', '', '127.0.0.1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725969196\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('a5c79623-cf3b-45c0-bea8-137431948259', '2', '1', '2018-07-16 11:58:27', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('a606a154-5d47-40a2-9550-8d38736cf52f', '4', '1', '2018-07-13 14:54:17', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856953\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('a60abbc6-3df1-4680-aae7-8c882e9af97a', '2', '1', '2018-07-16 11:19:39', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('a6321b9e-ba7f-4569-b24c-da54debe2dde', '2', '1', '2018-07-02 14:47:09', 'admin(超级管理员)', '3', '访问', '日志记录', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：//Log/Index', '0');
INSERT INTO `sys_log` VALUES ('a6828b80-5fdd-47fb-9302-eca33accfad5', '4', '1', '2018-07-13 14:54:54', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22keyword%22%3A%22%22%2C%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890963\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('a73755e6-3631-47c4-9473-890a314fbab5', '4', '1', '2018-07-16 15:35:56', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?id=4&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531726546146\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'orderid = 4  ORDER BY id desc\' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('a84a738b-bf22-465a-9470-d12d19beb67c', '2', '1', '2018-07-16 10:41:11', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('a877152e-a8a7-4f87-b8c3-a320729a35b2', '4', 'API USER', '2018-07-13 15:16:40', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未能加载文件或程序集“Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed”或它的某一个依赖项。找到的程序集清单定义与程序集引用不匹配。 (异常来自 HRESULT:0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('aa79851e-0be7-4910-b934-6ce44f945b3b', '4', 'API USER', '2018-07-13 14:28:29', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('ab535e61-5a77-4c9e-955d-f646d98019ed', '4', 'API USER', '2018-07-13 15:02:20', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('ac13daf9-be78-4828-8508-58f97553f935', '4', 'API USER', '2018-06-14 17:00:57', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetNoticeImgs&body=\r\nMessage：无法找到指定文件。\r\n', '0');
INSERT INTO `sys_log` VALUES ('ace11428-2c78-4800-ad07-0b2e7f004ae4', '4', 'API USER', '2018-07-13 15:18:27', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('ad366fa7-a9fa-4e4c-885f-3f02cb4c0e4c', '2', '1', '2018-07-12 16:45:46', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('ad92940d-c85b-4166-a4fc-68b4782b65f9', '2', '1', '2018-07-16 12:08:34', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('ae29494a-fe3f-423c-a9d2-d063bf915563', '4', '1', '2018-07-13 14:54:22', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%222%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856958\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('b0678e41-1c6c-4fef-bdd8-488f609dad5d', '2', '1', '2018-07-02 11:05:57', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('b0ad2be7-8647-410f-9836-5ae041fd4a07', '2', '1', '2018-07-16 15:09:22', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('b0cbc08b-08a5-492c-bfff-b16e8061f761', '2', '1', '2018-07-16 15:13:54', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('b165a724-0821-4335-a36e-a175fc3c1bf5', '2', '1', '2018-07-16 15:12:44', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('b18418da-cba0-42fe-b8ed-3f260a72e6ff', '4', 'API USER', '2018-07-13 17:21:22', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('b1f958e5-7fa9-4255-9504-fa32ae453d4a', '4', 'API USER', '2018-07-13 17:24:19', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('b352deb4-b674-4ea1-82e6-b6859877da54', '2', '1', '2018-07-18 10:42:57', 'admin(超级管理员)', '3', '访问', '系统用户', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/SysUser/Index', '0');
INSERT INTO `sys_log` VALUES ('b38d5896-f22d-43ac-81f5-d6e729050b00', '2', '1', '2018-07-16 14:55:46', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('b42b4ebe-630c-4c99-8000-eefadb3dcf47', '4', '1', '2018-07-13 14:54:51', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890959\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('b6e7d883-92e0-4c04-be9a-beab6ba8f9c4', '2', '1', '2018-07-16 15:14:07', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('bb6c0665-a90f-4bab-8e70-b1be14157d18', '2', '1', '2018-07-16 11:50:15', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('bc527109-92a2-410a-ac01-3320ccdd56cd', '4', 'API USER', '2018-06-29 11:20:10', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetTeaList\r\nMessage：使用 JSON JavaScriptSerializer 进行序列化或反序列化时出错。字符串的长度超过了为 maxJsonLength 属性设置的值。\r\n', '0');
INSERT INTO `sys_log` VALUES ('bcccb65e-b445-4d81-b1ae-257bb5e6e355', '4', 'API USER', '2018-06-29 11:21:43', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetTeaList\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('bd3cd6d8-e336-4183-8296-f91165d1dc70', '4', 'API USER', '2018-07-13 16:50:24', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'index,GoodsName,GoodsInfoStr,Price,num,SumPrice,createTime)\r\n                   \' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('bd428df4-81d1-4a0d-93f5-e0b819b37869', '4', '1', '2018-07-13 14:54:52', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%222%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890960\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('c0f062f8-5ea7-4277-9a3d-59e100b0fdd0', '2', '1', '2018-07-02 11:05:57', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('c3e1ca5f-3975-4379-a9de-20708b7d0041', '4', '1', '2018-07-02 11:26:37', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/ShopManage/Shop/SaveShopInfo\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('c424d756-e857-4b6b-9c5f-beb2732e6720', '4', '1', '2018-07-13 14:54:53', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890962\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('c5c9a3f7-13c4-42f7-a7b1-5bd42ff107c3', '4', 'API USER', '2018-06-29 11:19:41', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('c813d8eb-eb5d-474d-83da-dc8bf0eddb4b', '4', '1', '2018-07-02 10:25:34', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530497209366\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('c925ea83-e61f-45bd-b502-452ec8d129ce', '4', '1', '2018-06-29 17:42:57', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=10&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530263673637\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('ca63d293-ad1c-41ed-8cb6-3e868ba04620', '2', '1', '2018-07-16 11:57:11', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('caafa260-0425-4c16-a199-97751805306a', '3', '1', '2018-07-16 10:40:53', 'admin(超级管理员)', '7', '修改', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '248e8a53-cddd-4eba-b7d5-0ec235817a9b', '0');
INSERT INTO `sys_log` VALUES ('cada93ad-6948-492b-bed1-482dbffcb4c5', '4', 'API USER', '2018-06-14 17:06:31', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('cae2d70f-8477-4006-9bc2-42e0578fdf62', '2', '1', '2018-07-16 15:01:46', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('caffc772-bfd1-40b1-b30b-0ebd5ac3856f', '4', 'API USER', '2018-07-13 14:59:49', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('ce75f355-d673-47f6-961e-500227d04bd7', '4', '1', '2018-06-29 16:19:13', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：Packets larger than max_allowed_packet are not allowed.\r\n', '0');
INSERT INTO `sys_log` VALUES ('cf16626c-a7eb-4204-a299-265e22edf75e', '4', 'API USER', '2018-07-13 15:30:26', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('d0ba6708-b826-4ed3-b9c3-b84c6a6c522d', '4', '1', '2018-07-13 14:54:22', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%222%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856958\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('d3970da5-7a0a-4521-966d-365ad4167ecb', '2', '1', '2018-07-16 15:05:47', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('d5aef63c-51c8-4994-8387-fe78f084be6f', '4', '1', '2018-07-16 15:25:51', 'admin(超级管理员)', '9', '异常', '', '127.0.0.1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725951468\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('d5d3f028-4a8a-4c19-9de5-60834eebf3b3', '4', 'API USER', '2018-07-17 18:40:05', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetOrderPage&body=%7B%22pageIndex%22%3A1%7D\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('d6cdc981-7319-4b4d-b561-57cafe6a303b', '4', 'API USER', '2018-07-13 16:37:42', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('d8a76f0c-d431-4deb-a91d-97ee2e043237', '4', '1', '2018-07-13 14:54:20', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%223%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856955\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('db3d58e0-380f-4bd3-9b49-fac5d7284b53', '4', '1', '2018-07-13 14:54:17', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856954\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('dde6f3c2-67b5-4343-9cb9-f48a4dd62d67', '4', '1', '2018-07-02 11:26:37', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/ShopManage/Shop/SaveShopInfo\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('de74477f-a4e8-41ff-b9f9-ae21b818b1a1', '4', '1', '2018-07-16 15:23:25', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Order/Order/GetOrderDetail?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531725805289\r\nMessage：对于“Answer.PC.Areas.Order.Controllers.OrderController”中方法“System.Web.Mvc.ActionResult GetOrderDetail(System.String, Int32)”的不可以为 null 的类型“System.Int32”的参数“id”，参数字典包含一个 null 项。可选参数必须为引用类型、可以为 null 的类型或声明为可选参数。\r\n参数名: parameters\r\n', '0');
INSERT INTO `sys_log` VALUES ('dec005d5-8eca-42e2-b4c9-33670626714b', '4', 'API USER', '2018-07-13 16:56:58', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('dfe674fb-9492-4c95-bb8f-ce2d3f871e52', '2', '1', '2018-07-16 15:22:44', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('e11a6385-fc70-423c-a4fb-c4ef120734d8', '4', '1', '2018-06-29 18:47:15', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1530269223384\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('e1b1786c-353d-4746-9bce-3cd5b4445872', '2', '1', '2018-07-16 10:42:17', 'admin(超级管理员)', '3', '访问', '系统用户', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/SysUser/Index', '0');
INSERT INTO `sys_log` VALUES ('e26b4ac4-f755-47ca-a240-c520fce2d007', '4', '1', '2018-07-16 16:59:40', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/GetGoodsPage?pid=14&keyword=&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22id%22%2C%22sord%22%3A%22desc%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531731578811\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \')\' at line 2\r\n', '0');
INSERT INTO `sys_log` VALUES ('e2c9eadd-17c2-4244-85fb-61ef8136f8cc', '2', '1', '2018-07-16 15:45:58', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('e401c83f-d35c-4ef6-8f58-0f781e4e9e27', '4', 'API USER', '2018-07-13 12:17:01', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：JSONHelper.JSONToObject(): 无效的 JSON 基元: object。\r\n', '0');
INSERT INTO `sys_log` VALUES ('e4fa55ce-6085-4420-85c0-fcf0c3331f69', '4', '1', '2018-07-13 14:54:54', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22keyword%22%3A%22%22%2C%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890963\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('e521d91a-9998-48b0-ae0d-85e25a563297', '4', '1', '2018-06-29 15:59:52', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：Packets larger than max_allowed_packet are not allowed.\r\n', '0');
INSERT INTO `sys_log` VALUES ('e735bc9f-dd2a-4d83-aaa4-20b1e525aa11', '4', 'API USER', '2018-07-13 14:53:56', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：未能加载文件或程序集“Newtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed”或它的某一个依赖项。找到的程序集清单定义与程序集引用不匹配。 (异常来自 HRESULT:0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('e75a862d-d1d9-4414-9471-38a1e3f40b6a', '4', 'API USER', '2018-07-13 14:53:49', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('e7bb8d2c-cf0b-49d4-87ab-be9412cb64c5', '2', '1', '2018-07-16 15:13:29', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('e96f6587-9409-4025-8219-08e8c2b84f6a', '4', '1', '2018-07-13 14:54:21', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%224%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464856956\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('e9a21e3e-4578-47f0-af1b-4bd86bf6fb1b', '2', '1', '2018-07-12 16:44:58', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');
INSERT INTO `sys_log` VALUES ('ea8214a2-a6e2-4185-83d6-08e5f2e2b89c', '3', '1', '2018-07-16 10:41:25', 'admin(超级管理员)', '7', '修改', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '248e8a53-cddd-4eba-b7d5-0ec235817a9b', '0');
INSERT INTO `sys_log` VALUES ('ef713761-b77c-4510-b81d-93a0dbbfcc12', '4', 'API USER', '2018-07-16 15:54:20', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('efe255a7-2f48-454f-8699-fc012b75266b', '4', 'API USER', '2018-06-14 16:59:21', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetNoticeImgs&body=\r\nMessage：无法找到指定文件。\r\n', '0');
INSERT INTO `sys_log` VALUES ('f01826c0-4849-4c42-9e82-4e1579cbb66f', '4', 'API USER', '2018-07-13 15:08:43', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：Error reading JObject from JsonReader. Current JsonReader item is not an object: StartArray. Path \'\', line 1, position 1.\r\n', '0');
INSERT INTO `sys_log` VALUES ('f14263b2-d6af-482c-8da3-c2622b5ac086', '4', 'API USER', '2018-07-13 17:32:52', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('f4491caa-a8bc-4df1-81b5-1ff353deccdf', '4', 'API USER', '2018-07-17 18:42:16', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetOrderPage&body=%7B%22pageIndex%22%3A1%7D\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('f7cb3845-fd81-4f59-8593-5866d59aad0f', '2', '1', '2018-07-16 11:58:55', 'admin(超级管理员)', '3', '访问', '订单管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/Order/Order/Index', '0');
INSERT INTO `sys_log` VALUES ('f94deb10-7d7f-4e8d-8a7c-0a24c278e6ee', '4', '1', '2018-07-02 15:06:41', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Goods/Tea/SaveGoodsTea\r\nMessage：未将对象引用设置到对象的实例。\r\n', '0');
INSERT INTO `sys_log` VALUES ('fa43d9d3-e550-437e-887f-0354b8d28b97', '4', 'API USER', '2018-07-13 16:45:56', 'API USER', '9', '异常', '', '', null, null, '0', 'API :: 登录失败,网络异常===请求在此上下文中不可用', '0');
INSERT INTO `sys_log` VALUES ('fb5b1b4d-31f9-4ee1-ba34-a0feadbfbee2', '3', '1', '2018-07-12 16:44:19', 'admin(超级管理员)', '5', '新增', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '248e8a53-cddd-4eba-b7d5-0ec235817a9b', '0');
INSERT INTO `sys_log` VALUES ('fc09ae42-5621-498d-9071-0a8e77012e51', '4', 'API USER', '2018-07-17 15:33:38', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/GetData?functionname=GetOrderPage\r\nMessage：值不能为 null。\r\n参数名: s\r\n', '0');
INSERT INTO `sys_log` VALUES ('fce659ca-da44-46ee-9c62-21b88410cb1a', '4', 'API USER', '2018-07-13 16:46:48', 'API USER', '9', '异常', '', '::1', null, null, '0', 'Url：/api/Main/PostData\r\nMessage：You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near \'index,GoodsName,GoodsInfoStr,Price,num,SumPrice,createTime)\r\n                   \' at line 1\r\n', '0');
INSERT INTO `sys_log` VALUES ('fe695488-2274-4e84-82a6-63056a35db89', '4', '1', '2018-07-13 14:54:51', 'admin(超级管理员)', '9', '异常', '', '::1', 'localhost', 'Chrome_65.0', '0', 'Url：/Log/GetPageList?queryJson=%7B%22CategoryId%22%3A%221%22%2C%22StartTime%22%3A%222018-07-07+00%3A00%3A00%22%2C%22EndTime%22%3A%222018-07-13+23%3A59%3A59%22%7D&pagination=%7B%22rows%22%3A50%2C%22page%22%3A1%2C%22sidx%22%3A%22F_OperateTime%22%2C%22sord%22%3A%22ASC%22%2C%22records%22%3A0%2C%22total%22%3A0%7D&_=1531464890959\r\nMessage：Could not load file or assembly \'Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed\' or one of its dependencies. The located assembly\'s manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)\r\n', '0');
INSERT INTO `sys_log` VALUES ('ff60b119-0304-4eb4-91d9-d5fbce3a7ab0', '2', '1', '2018-07-12 16:43:38', 'admin(超级管理员)', '3', '访问', '功能管理', '::1', 'localhost', 'Chrome_65.0', '1', '访问地址：/SystemModule/Module/Index', '0');

-- ----------------------------
-- Table structure for `sys_menu`
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu` (
  `F_ModuleId` varchar(50) NOT NULL COMMENT '功能主键',
  `F_ParentId` varchar(50) NOT NULL DEFAULT '' COMMENT '父级主键',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_Icon` varchar(50) DEFAULT NULL COMMENT '图标',
  `F_UrlAddress` varchar(200) DEFAULT NULL COMMENT '导航地址',
  `F_Target` varchar(20) DEFAULT NULL COMMENT '导航目标',
  `F_IsMenu` int(11) NOT NULL DEFAULT '1' COMMENT '菜单选项',
  `F_AllowExpand` int(11) DEFAULT '1' COMMENT '允许展开',
  `F_IsPublic` int(11) DEFAULT '1' COMMENT '是否公开',
  `F_AllowEdit` int(11) DEFAULT '1' COMMENT '允许编辑',
  `F_AllowDelete` int(11) DEFAULT '1' COMMENT '允许删除',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` int(11) NOT NULL DEFAULT '0' COMMENT '删除标记',
  `F_EnabledMark` int(11) NOT NULL DEFAULT '1' COMMENT '有效标志',
  `F_Description` varchar(200) DEFAULT NULL COMMENT '备注',
  `F_CreateDate` timestamp NULL DEFAULT NULL COMMENT '创建日期',
  `F_CreateUserId` varchar(50) DEFAULT NULL COMMENT '创建用户主键',
  `F_CreateUserName` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `F_ModifyDate` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改日期',
  `F_ModifyUserId` varchar(50) DEFAULT NULL COMMENT '修改用户主键',
  `F_ModifyUserName` varchar(50) DEFAULT NULL COMMENT '修改用户',
  PRIMARY KEY (`F_ModuleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统功能表';

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES ('1', '0', 'SysManage', '用户管理', 'fa fa-vcard', '', 'expand', '1', '1', '1', null, null, '2', '0', '0', '', null, null, null, '2018-05-22 17:24:47', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('10', '0', 'SystemManage', '系统管理', 'fa fa-cogs', '', 'expand', '1', '1', '1', null, null, '5', '0', '1', '', null, null, null, '2018-03-27 17:48:07', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('11', '10', 'SystemUser', '系统用户', 'fa fa-user-o', '/SystemModule/SysUser/Index', 'iframe', '1', '1', '1', null, null, '1', '0', '1', '', null, null, null, '2018-01-26 16:48:23', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('12', '10', 'RoleManage', '角色管理', 'fa fa-users', '/SystemModule/Role/Index', 'iframe', '1', '1', '1', null, null, '2', '0', '1', '', null, null, null, '2018-01-26 17:20:58', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('13', '10', 'MenuManage', '功能管理', 'fa fa-th-large', '/SystemModule/Module/Index', 'iframe', '1', '1', '1', null, null, '3', '0', '1', '', null, null, null, '2018-01-26 17:22:39', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('2', '1', 'UserManage', '玩家信息', 'fa fa-user', '/User/User/Index', 'iframe', '1', '1', '1', null, null, '1', '0', '1', '', null, null, null, '2018-03-28 14:44:34', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('248e8a53-cddd-4eba-b7d5-0ec235817a9b', '0', 'OrderManage', '订单管理', 'fa fa-legal', 'Order/Order/Index', 'iframe', '1', '1', '0', null, null, '3', '0', '1', '', '2018-07-12 16:44:20', '1', 'admin', '2018-07-16 10:41:25', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('2cdeb781-d715-4566-9533-755eaa32d20f', '10', 'LogManage', '日志记录', 'fa fa-file-text-o', '/Log/Index', 'iframe', '1', '1', '1', null, null, '4', '0', '1', '', '2017-12-04 15:25:14', '1', 'admin', '2018-03-27 17:48:57', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('5b09e0de-3ca4-4a48-a57d-669143ce8725', 'cd93b467-216a-4779-88e3-afb62f409bf2', 'shopInfo', '店铺信息', '', 'ShopManage/Shop/Index', 'iframe', '1', '0', '0', null, null, '1', '0', '1', '', '2018-05-21 14:55:13', '1', 'admin', null, null, null);
INSERT INTO `sys_menu` VALUES ('b709d913-9741-4de6-bdec-95996eae054a', '0', 'GoodsManage', '商品管理', 'fa fa-coffee', '', 'expand', '1', '1', '0', null, null, '2', '0', '1', '', '2018-05-24 14:47:56', '1', 'admin', '2018-05-24 14:56:34', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('c52d7927-1f1e-430c-9c3f-1daf24ad24ee', 'b709d913-9741-4de6-bdec-95996eae054a', 'TeaList', 'TEA', 'fa fa-glass', '/Goods/Tea/Index', 'iframe', '1', '1', '0', null, null, '1', '0', '1', '', '2018-05-24 14:52:55', '1', 'admin', null, null, null);
INSERT INTO `sys_menu` VALUES ('cd93b467-216a-4779-88e3-afb62f409bf2', '0', 'ShopManage', '店铺管理', 'fa fa-shopping-basket', '', 'expand', '1', '1', '0', null, null, '1', '0', '1', 'Shop', '2018-05-21 14:53:17', '1', 'admin', '2018-05-24 14:56:29', '1', 'admin');
INSERT INTO `sys_menu` VALUES ('cec987db-64a3-45dc-8df4-de60d3868013', '0', 'ConfigManage', '配置管理', 'fa fa-yelp', '', 'expand', '1', '1', '0', null, null, '3', '0', '1', '', '2018-05-24 14:59:01', '1', 'admin', null, null, null);
INSERT INTO `sys_menu` VALUES ('e5ff39c5-9e17-4e09-b4ca-f83fe83a896f', 'cec987db-64a3-45dc-8df4-de60d3868013', 'goodsLable', '商品标签', 'fa fa-gear', '/ConfigManage/GoodsLable/index', 'iframe', '1', '0', '0', null, null, '1', '0', '1', '', '2018-05-24 15:01:04', '1', 'admin', null, null, null);

-- ----------------------------
-- Table structure for `sys_modulebutton`
-- ----------------------------
DROP TABLE IF EXISTS `sys_modulebutton`;
CREATE TABLE `sys_modulebutton` (
  `ModuleButtonId` varchar(50) NOT NULL,
  `ModuleId` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Icon` varchar(50) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `ActionAddress` varchar(200) DEFAULT NULL COMMENT 'Action地址',
  `SortCode` int(11) DEFAULT NULL,
  PRIMARY KEY (`ModuleButtonId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_modulebutton
-- ----------------------------
INSERT INTO `sys_modulebutton` VALUES ('06adcc26-e3ba-4379-9762-be5ecfa51f7a', '12', '0', null, 'll_ipfilter', 'IP过滤', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('0dd6f3d6-c1cf-44d5-be0c-81d639f33903', '13', '0', null, 'll_add', '新增', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('1149f16b-9b0d-4469-a3db-475ae262de4b', '11', '0', null, 'll_add', '新增', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('12a40a10-b2ce-4e47-bdcb-ee572e81c0d2', '11', '0', null, 'll_authorize', '功能授权', '', '4');
INSERT INTO `sys_modulebutton` VALUES ('1f32a65a-9cc6-4975-8447-4f70e5908f08', '12', '0', null, 'll_memberlook', '查看成员', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('2cd625a9-974f-4d8f-8d77-579def3dfc81', '12', '0', null, 'll_memberadd', '添加成员', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('31d78cfd-13fc-418d-a420-05b6e85e4742', '11', '0', null, 'll_resetpassword', '重置密码', '', '3');
INSERT INTO `sys_modulebutton` VALUES ('42ca3d6d-4826-4338-8ef4-93f1e73641c6', '11', '0', null, 'll_disabled', '禁用用户', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('42dd09ea-dd3d-4798-ac6b-4fa2473233f4', '2', '0', null, 'll_playlog', '查询ID/战绩', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('4c7a7f84-ba1e-4d33-9f90-559cc3887d2b', '2cdeb781-d715-4566-9533-755eaa32d20f', '0', null, 'lr_detail', '详细', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('4f54cc5a-cd93-48ae-94a1-d59080dfe3bb', '12', '0', null, 'll_timefilter', '时段过滤', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('536a84dd-f7e9-4f04-852f-dcd447144b8a', '13', '0', null, 'll_edit', '编辑', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('5959ed9d-f67c-427b-9f7e-dc15a1b0e19e', '12', '0', null, 'll_delete', '删除', '', '3');
INSERT INTO `sys_modulebutton` VALUES ('662e4c58-3682-4554-ad01-ec2db7d22a7b', '2', '0', null, 'll_upagent', '直升代理', '', '6');
INSERT INTO `sys_modulebutton` VALUES ('6c38b578-8e30-4edd-8060-ec81e0bd60dc', '2', '0', null, 'll_sendmsg', '消息发送', '', '5');
INSERT INTO `sys_modulebutton` VALUES ('7b1c06b1-d8d9-4acb-b128-b5330637e7b9', '12', '0', null, 'll_add', '新增', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('8b85e6eb-4422-4671-a28f-f4f937ee0944', '2cdeb781-d715-4566-9533-755eaa32d20f', '0', null, 'lr_export', '导出', '', '3');
INSERT INTO `sys_modulebutton` VALUES ('91a8930f-6342-4464-adad-59456b88cf5e', '8', '0', null, 'll_edit', '编辑', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('9b824961-f01c-43e2-8732-51d212ff0dfd', '2', '0', null, 'll_chargebuckle', '充/扣房卡', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('b51dbeba-197b-4c05-a3ee-f2324ffc815f', '12', '0', null, 'll_more', '更多', '', '4');
INSERT INTO `sys_modulebutton` VALUES ('b7e143b8-36b3-4905-9b9e-5e9cfa6e0cb1', '11', '0', null, 'll_enabled', '启用账户', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('c9efba15-07c1-4bd5-b958-bd26fc5c38a6', '2cdeb781-d715-4566-9533-755eaa32d20f', '0', null, 'lr_removelog', '清空', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('d2126900-eadb-4b2e-8d1b-81d53f2b79fb', '13', '0', null, 'll_delete', '删除', '', '3');
INSERT INTO `sys_modulebutton` VALUES ('de56dc0e-4b19-4469-9664-a996e7edacbd', '12', '0', null, 'll_appfilter', '访问过滤', '', '5');
INSERT INTO `sys_modulebutton` VALUES ('e2f436e0-a8b2-4e7f-ad8c-5f60a518ae96', '2', '0', null, 'll_more', '更多', '', '3');
INSERT INTO `sys_modulebutton` VALUES ('e3fa8f79-d2d4-47b4-abb5-b49d972950ac', '2', '0', null, 'll_disabled', '禁用账户', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('e9faac4e-a38c-4a8f-8845-1a0e9e62f4fb', '11', '0', null, 'll_more', '更多', '', '2');
INSERT INTO `sys_modulebutton` VALUES ('f6aac01a-2cc9-4814-9d52-7b1f1614c58a', 'c4389fba-6be4-4f5a-94cf-ed7e17867cc2', '0', null, 'add', 'ADD', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('f7f9a8f6-74f1-448e-934e-bcaa3d288f46', '12', '0', null, 'll_authorize', '功能授权', '', '3');
INSERT INTO `sys_modulebutton` VALUES ('f9e40e88-c8a7-4ca3-a915-16d22425a75c', '2', '0', null, 'll_enabled', '启用账户', '', '1');
INSERT INTO `sys_modulebutton` VALUES ('fdae1d73-7245-402e-87cc-540c27618a0c', '12', '0', null, 'll_edit', '编辑', '', '2');

-- ----------------------------
-- Table structure for `sys_modulecolumn`
-- ----------------------------
DROP TABLE IF EXISTS `sys_modulecolumn`;
CREATE TABLE `sys_modulecolumn` (
  `ModuleColumnId` varchar(50) NOT NULL,
  `ModuleId` varchar(50) DEFAULT NULL COMMENT '功能主键',
  `ParentId` varchar(50) DEFAULT NULL COMMENT '父级主键',
  `EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `Description` varchar(200) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`ModuleColumnId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_modulecolumn
-- ----------------------------
INSERT INTO `sys_modulecolumn` VALUES ('ac599fcf-7d8c-4571-bf61-a5c204756171', 'c4389fba-6be4-4f5a-94cf-ed7e17867cc2', null, 'id', 'ID', '1', '');

-- ----------------------------
-- Table structure for `sys_role`
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role` (
  `F_RoleId` varchar(50) NOT NULL,
  `F_Category` varchar(50) DEFAULT NULL COMMENT '分类',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '角色编码',
  `F_FullName` varchar(50) DEFAULT NULL,
  `F_SortCode` int(4) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` int(2) DEFAULT NULL COMMENT '删除标记',
  `F_EnabledMark` int(2) DEFAULT NULL COMMENT '有效标志',
  `F_Description` varchar(200) DEFAULT NULL,
  `F_CreateDate` datetime DEFAULT NULL COMMENT '创建日期',
  `F_CreateUserId` varchar(50) DEFAULT NULL,
  `F_CreateUserName` varchar(50) DEFAULT NULL,
  `F_ModifyDate` datetime DEFAULT NULL,
  `F_ModifyUserId` varchar(50) DEFAULT NULL,
  `F_ModifyUserName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`F_RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES ('0bfa66b9-ee43-4b8e-bb06-776a105990e7', null, 'czc', 'zczc111', '12', '0', '1', 'czcx 12', '2017-12-01 10:28:26', '1', '超级管理员', '2017-12-15 18:26:18', '1', '超级管理员');
INSERT INTO `sys_role` VALUES ('6c05893c-4725-4b90-a76a-cdbb6a1a8aab', null, 'sdsd', '测试五组', '5', '0', '1', '测试五组', '2017-12-01 10:28:14', '1', '超级管理员', '2017-12-15 16:46:02', '1', '超级管理员');
INSERT INTO `sys_role` VALUES ('8fce6f97-7988-4101-bb24-f0a65180652f', null, 'A000002', '测试人员三组', '3', '0', '1', '测试人员三组', '2017-12-01 10:23:37', '1', '超级管理员', '2018-05-22 17:05:54', '1', '超级管理员');
INSERT INTO `sys_role` VALUES ('b0e30c51-20a4-4713-b083-386cdad4fbe5', null, 'TestRole_1', '测试人员一组', null, '0', '1', '测试人员一组 测试人员一组 测试人员一组', null, null, null, '2017-11-30 16:39:06', '1', '超级管理员');
INSERT INTO `sys_role` VALUES ('f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', null, 'A000001', '测试人员二组', '1', '0', '1', '测试', '2017-11-29 15:18:48', '1', '超级管理员', '2017-12-15 16:45:54', '1', '超级管理员');

-- ----------------------------
-- Table structure for `sys_user`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '模块名称',
  `UserName` varchar(50) NOT NULL COMMENT '用户名称',
  `UserPassWord` varchar(200) NOT NULL COMMENT '用户密码',
  `UserNickName` varchar(50) DEFAULT '' COMMENT '用户昵称',
  `UserType` int(11) NOT NULL DEFAULT '1007001' COMMENT '用户类型(1007001:超级管理员；1007002:普通管理员)',
  `RegistIP` varchar(20) DEFAULT '' COMMENT '注册IP地址',
  `Valid` int(11) NOT NULL DEFAULT '1008001' COMMENT '是否有效(1008002:注销; 1008001:正常)',
  `LoginDate` timestamp NULL DEFAULT NULL COMMENT '登录时间',
  `LoginIP` varchar(20) DEFAULT '' COMMENT '登录IP地址',
  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `ModifyDate` timestamp NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='系统用户表';

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('1', 'admin', '4297f44b13955235245b2497399d7a93', '超级管理员', '1007001', '192.168.0.220', '1008001', '2018-07-18 10:34:01', '::1', '2017-06-06 18:36:30', '2018-03-26 12:09:28');
INSERT INTO `sys_user` VALUES ('2', 'leo', '96E79218965EB72C92A549DD5A330112', '超级管理员', '1007001', '', '1008001', '2017-09-13 17:25:29', '43.231.229.178', '2017-08-05 17:21:06', '2017-08-05 17:59:38');
INSERT INTO `sys_user` VALUES ('3', 'test', '46315D1D58CAE3D8DF137CD2AD9C4A70', 'test', '1007002', '::1', '1008001', '2017-10-12 16:57:54', '::1', '2017-10-12 16:04:06', '2017-10-12 17:08:25');
INSERT INTO `sys_user` VALUES ('4', '12345', '78C916856366CC0449A9CC18E70CF0E5', 'kljl', '1007002', '192.168.0.131', '1008001', '2017-11-01 18:09:58', '192.168.0.131', '2017-11-01 18:07:27', null);
INSERT INTO `sys_user` VALUES ('5', 'X', '3151FFD8CDA6B5ADB790C48FAD1BFEAF', 'A', '1007002', '192.168.0.131', '1008001', '2017-11-02 11:28:18', '192.168.0.131', '2017-11-01 18:12:00', '2017-11-02 11:28:04');
INSERT INTO `sys_user` VALUES ('6', 'Z', '11BFF823811F31CEFA6D66F2E3B5454F', 'z', '1007002', '::1', '1008001', '2017-11-02 10:34:00', '::1', '2017-11-02 10:27:41', '2017-11-02 11:27:21');

-- ----------------------------
-- Table structure for `sys_userrelation`
-- ----------------------------
DROP TABLE IF EXISTS `sys_userrelation`;
CREATE TABLE `sys_userrelation` (
  `F_UserRelationId` varchar(50) NOT NULL,
  `F_UserId` varchar(50) DEFAULT NULL COMMENT '用户主键',
  `F_Category` int(4) DEFAULT NULL COMMENT '分类:1-角色2-岗位',
  `F_ObjectId` varchar(50) DEFAULT NULL COMMENT '对象主键',
  `F_CreateDate` datetime DEFAULT NULL,
  `F_CreateUserId` varchar(50) DEFAULT NULL,
  `F_CreateUserName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`F_UserRelationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_userrelation
-- ----------------------------
INSERT INTO `sys_userrelation` VALUES ('4012517e-adc2-4687-9a66-8a5bb5da2285', '3', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '2017-11-29 18:32:05', '1', '超级管理员');
INSERT INTO `sys_userrelation` VALUES ('4c754dad-d2d1-4a20-89fb-f09fb78a7c03', '7', '1', 'f8284ed8-666e-4df5-9eb0-7ed8c3a4d333', '2017-11-29 18:32:05', '1', '超级管理员');

-- ----------------------------
-- Table structure for `t_goods`
-- ----------------------------
DROP TABLE IF EXISTS `t_goods`;
CREATE TABLE `t_goods` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parentID` int(11) NOT NULL COMMENT 'Label ID',
  `img` longtext NOT NULL,
  `GoodsName` varchar(255) NOT NULL,
  `Price` decimal(4,2) NOT NULL DEFAULT '0.00',
  `status` tinyint(1) NOT NULL DEFAULT '1' COMMENT '状态',
  `GoodsInfo` varchar(255) DEFAULT NULL,
  `updateTime` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `createTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_goods
-- ----------------------------
INSERT INTO `t_goods` VALUES ('2', '10', '/820d7716adff4498a8f930a5d43b5289.Jpeg', '燕麦奶茶', '23.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 14:55:55', '2018-05-28 15:51:26');
INSERT INTO `t_goods` VALUES ('3', '12', '/b9509c37794441439aab019029e5ddbc.Jpeg', '红 野 仙 踪', '22.00', '1', '茶和浓缩咖啡的搭配听起来有点违和，但确实是好喝的', '2018-07-02 10:25:18', '2018-05-28 16:41:57');
INSERT INTO `t_goods` VALUES ('8', '11', '/6a11575c48984873a514dad951cc5069.Jpeg', '解忧答案茶', '17.00', '1', '白桃乌龙霜降（其实啥茶不重要）', '2018-07-02 10:25:11', '2018-06-01 11:32:09');
INSERT INTO `t_goods` VALUES ('9', '11', '/8c05197c5a38437eba369ae937b79623.Jpeg', 'CoCo 都可', '25.00', '1', '奶霜草莓果茶+珍珠+椰果+去冰+无糖', '2018-07-02 10:25:00', '2018-06-01 11:33:35');
INSERT INTO `t_goods` VALUES ('10', '10', '/d9e4ae54f91646bbb660c7116bc3e3ff.Jpeg', '快 乐 柠 檬', '19.00', '1', '蛋糕忌廉珍珠奶茶+曲奇+小芋圆+半塘', '2018-07-02 11:04:29', '2018-06-01 11:34:24');
INSERT INTO `t_goods` VALUES ('11', '12', '/7d58d559981b4e5fbc91af995bdca6f7.Jpeg', '铁观音珍珠奶茶', '22.00', '1', '顺着这些网红奶茶的风，星巴克的隐藏菜单又一次被拿了出来，其实早在去年阿反就实测了一波星巴克的网红菜单', '2018-07-02 10:07:16', '2018-06-01 11:36:09');
INSERT INTO `t_goods` VALUES ('12', '11', '/850c204418d74ff1b7b01731608adb05.Jpeg', '熊猫奶盖红茶', '25.00', '1', '抹茶和浓缩咖啡的搭配听起来有点违和，但确实是好喝的。', '2018-06-29 17:13:26', '2018-06-01 11:36:53');
INSERT INTO `t_goods` VALUES ('13', '11', '/dc34ef0606714c16a7f0d080b1903c07.Jpeg', '白桃乌龙霜降', '21.00', '1', '星巴克的隐藏菜单又一次被拿了出来，其实早在去年阿反就实测了一波星巴克的网红菜单，下面这个彩蛋送给你们', '2018-07-02 10:25:29', '2018-06-01 11:37:15');
INSERT INTO `t_goods` VALUES ('14', '10', '/d4a29238025f4217b26bd01b7cdc7d42.Jpeg', '霸气芝士草莓', '15.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:01', '2018-07-02 14:57:00');
INSERT INTO `t_goods` VALUES ('15', '10', '/ad68dc06e97148ab872979ed8976dbe5.Jpeg', '霸气芝士芒果', '13.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:06', '2018-07-02 14:58:24');
INSERT INTO `t_goods` VALUES ('17', '10', '/8b260347afa04003acc1c84d818b4f40.Jpeg', '霸气橙子', '16.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:10', '2018-07-02 15:04:13');
INSERT INTO `t_goods` VALUES ('18', '12', '2261e55a247145c584e25de3fd37f97c.Jpeg', '四季春茶', '12.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:14', '2018-07-02 15:16:39');
INSERT INTO `t_goods` VALUES ('19', '13', 'c10a0056bbfc463dad53a56ef108f713.Jpeg', '芝士樱花清茶', '21.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:19', '2018-07-02 15:20:06');
INSERT INTO `t_goods` VALUES ('20', '13', '1691854b515b4c8ba8d5cab27c31d223.Jpeg', '芝士乌龙', '32.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:22', '2018-07-02 15:20:30');
INSERT INTO `t_goods` VALUES ('21', '13', '58834b6dc6d943d6998a9d32f9ff595f.Jpeg', '芝士脆珠红玉', '21.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:28', '2018-07-02 15:20:47');
INSERT INTO `t_goods` VALUES ('22', '13', '9c2e4eef5eb849d997f3888e28fcb6b6.Jpeg', '芝士金凤茶王', '25.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:32', '2018-07-02 15:21:03');
INSERT INTO `t_goods` VALUES ('23', '13', '4ec3ee452c0049b181626d65b5ec9e45.Jpeg', '芝士静冈抹茶', '20.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:37', '2018-07-02 15:21:19');
INSERT INTO `t_goods` VALUES ('24', '13', '2fa415ceb4bb49f690b72c69709c305b.Jpeg', '芝士青雾', '26.00', '1', '酸酸甜甜的新鲜草莓遇上高品质的茉莉毛尖原叶茶，搅打均匀后，手摇去除多余的泡沫，最后再倒上顺滑轻薄的芝士奶盖~', '2018-07-02 15:23:40', '2018-07-02 15:21:38');
INSERT INTO `t_goods` VALUES ('25', '14', 'ea27e27d15504a3fb2da556aea9689de.Jpeg', '单位一', '10.00', '1', '随便写写', '2018-07-16 17:02:10', '2018-07-16 17:00:47');
INSERT INTO `t_goods` VALUES ('26', '14', 'f0d18f12dac54903b084db7e76df9c16.Jpeg', '单位二', '20.00', '1', '随便写写', '2018-07-16 17:02:07', '2018-07-16 17:01:12');
INSERT INTO `t_goods` VALUES ('27', '14', 'a5582b4bdae644beaa5ffb46fba6d492.Jpeg', '单位三', '30.00', '1', '随便写写', '2018-07-16 17:02:03', '2018-07-16 17:01:29');

-- ----------------------------
-- Table structure for `t_lable`
-- ----------------------------
DROP TABLE IF EXISTS `t_lable`;
CREATE TABLE `t_lable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `typeid` int(11) NOT NULL,
  `lableName` varchar(255) NOT NULL,
  `updateTime` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `createTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_lable
-- ----------------------------
INSERT INTO `t_lable` VALUES ('1', '1', '口味', '2018-05-25 18:06:00', '2018-05-24 19:08:21');
INSERT INTO `t_lable` VALUES ('2', '1', '温度', '2018-05-25 11:36:36', '2018-05-24 19:08:57');
INSERT INTO `t_lable` VALUES ('3', '1', '糖度', '2018-05-25 12:27:13', '2018-05-25 12:27:05');
INSERT INTO `t_lable` VALUES ('4', '1', '规格', '2018-05-25 12:27:15', '2018-05-25 12:27:08');
INSERT INTO `t_lable` VALUES ('5', '1', '字母', '2018-05-25 17:20:04', '2018-05-25 12:27:10');
INSERT INTO `t_lable` VALUES ('6', '1', '颜色', '2018-05-26 12:41:37', '2018-05-25 14:47:12');
INSERT INTO `t_lable` VALUES ('8', '1', '消费对象', null, '2018-05-26 12:40:31');
INSERT INTO `t_lable` VALUES ('10', '2', '满杯水果', null, '2018-05-26 12:55:53');
INSERT INTO `t_lable` VALUES ('11', '2', '混合茶', null, '2018-05-26 12:58:23');
INSERT INTO `t_lable` VALUES ('12', '2', '纯茶', '2018-05-26 15:19:23', '2018-05-26 14:58:45');
INSERT INTO `t_lable` VALUES ('13', '2', '甜品', '2018-05-28 17:17:09', '2018-05-26 15:20:06');
INSERT INTO `t_lable` VALUES ('14', '2', '补差价', '2018-05-26 16:20:07', '2018-05-26 15:20:57');

-- ----------------------------
-- Table structure for `t_labledetail`
-- ----------------------------
DROP TABLE IF EXISTS `t_labledetail`;
CREATE TABLE `t_labledetail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parentID` int(11) NOT NULL,
  `lable` varchar(255) NOT NULL,
  `updateTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  `createTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_labledetail
-- ----------------------------
INSERT INTO `t_labledetail` VALUES ('1', '1', '标准[推荐]', '2018-07-11 17:52:59', '2018-05-24 19:09:26');
INSERT INTO `t_labledetail` VALUES ('2', '1', '咸', '2018-05-24 19:09:47', '2018-05-24 19:09:50');
INSERT INTO `t_labledetail` VALUES ('3', '1', '淡淡的', '2018-05-24 19:10:15', '2018-05-24 19:10:18');
INSERT INTO `t_labledetail` VALUES ('5', '2', '标准[推荐]', '2018-07-11 17:52:36', '2018-05-24 19:11:06');
INSERT INTO `t_labledetail` VALUES ('6', '2', '少冰', '2018-05-24 19:11:24', '2018-05-24 19:11:27');
INSERT INTO `t_labledetail` VALUES ('7', '2', '去冰', '2018-05-24 19:11:50', '2018-05-24 19:11:53');
INSERT INTO `t_labledetail` VALUES ('8', '5', 'A', '2018-05-25 17:10:57', '2018-05-25 17:07:17');
INSERT INTO `t_labledetail` VALUES ('9', '5', 'B', '2018-05-25 17:10:55', '2018-05-25 17:09:49');
INSERT INTO `t_labledetail` VALUES ('10', '5', 'C', '2018-05-25 17:14:01', '2018-05-25 17:10:29');
INSERT INTO `t_labledetail` VALUES ('11', '5', 'D', '2018-05-25 17:17:37', '2018-05-25 17:15:55');
INSERT INTO `t_labledetail` VALUES ('14', '4', '大杯', '2018-05-25 17:22:05', '2018-05-25 17:22:05');
INSERT INTO `t_labledetail` VALUES ('15', '4', '中杯', '2018-05-25 17:23:14', '2018-05-25 17:23:14');
INSERT INTO `t_labledetail` VALUES ('16', '5', 'E', '2018-05-25 17:30:38', '2018-05-25 17:30:38');
INSERT INTO `t_labledetail` VALUES ('17', '6', 'RED', '2018-05-25 17:58:48', '2018-05-25 17:50:01');
INSERT INTO `t_labledetail` VALUES ('18', '3', '标准[推荐]', '2018-05-25 17:57:31', '2018-05-25 17:57:31');
INSERT INTO `t_labledetail` VALUES ('19', '3', '少糖', '2018-05-25 17:57:40', '2018-05-25 17:57:40');
INSERT INTO `t_labledetail` VALUES ('20', '3', '少少糖', '2018-05-25 17:57:48', '2018-05-25 17:57:48');
INSERT INTO `t_labledetail` VALUES ('21', '3', '不另外加糖', '2018-05-25 17:58:00', '2018-05-25 17:58:00');
INSERT INTO `t_labledetail` VALUES ('22', '6', 'BLUE', '2018-05-25 17:58:58', '2018-05-25 17:58:58');
INSERT INTO `t_labledetail` VALUES ('23', '6', 'PINK', '2018-05-25 17:59:14', '2018-05-25 17:59:14');
INSERT INTO `t_labledetail` VALUES ('24', '2', '热的', '2018-07-11 17:52:32', '2018-05-25 17:59:49');
INSERT INTO `t_labledetail` VALUES ('25', '1', '甜', '2018-07-11 17:53:07', '2018-05-25 18:00:24');
INSERT INTO `t_labledetail` VALUES ('26', '5', 'F', '2018-05-26 12:39:57', '2018-05-26 12:39:57');
INSERT INTO `t_labledetail` VALUES ('27', '8', '男士', '2018-05-26 12:40:56', '2018-05-26 12:40:56');
INSERT INTO `t_labledetail` VALUES ('28', '8', '女生', '2018-07-11 17:53:23', '2018-07-11 17:53:23');
INSERT INTO `t_labledetail` VALUES ('29', '8', '小孩', '2018-07-11 17:53:28', '2018-07-11 17:53:28');
INSERT INTO `t_labledetail` VALUES ('30', '8', '老人', '2018-07-11 17:53:35', '2018-07-11 17:53:35');

-- ----------------------------
-- Table structure for `t_order`
-- ----------------------------
DROP TABLE IF EXISTS `t_order`;
CREATE TABLE `t_order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderNum` varchar(32) DEFAULT NULL COMMENT '订单号',
  `tradingNum` varchar(32) DEFAULT NULL COMMENT '交易单号',
  `merchantCode` varchar(32) DEFAULT NULL COMMENT '商户单号',
  `orderTime` timestamp NULL DEFAULT NULL COMMENT '下单时间',
  `orderStatus` varchar(4) DEFAULT NULL COMMENT '订单状态',
  `orderNumber` int(4) DEFAULT NULL COMMENT '订单数量',
  `orderSumPrice` int(8) DEFAULT NULL COMMENT '订单总价',
  `orderUser` varchar(32) DEFAULT NULL COMMENT '订单用户ID',
  `orderUserName` varchar(32) DEFAULT NULL COMMENT '订单用户名',
  `orderUserPhone` varchar(32) DEFAULT NULL COMMENT '订单用户电话',
  `orderUserAdder` varchar(100) DEFAULT NULL COMMENT '订单用户地址',
  `isOutside` tinyint(1) DEFAULT '0' COMMENT '是否外送',
  `createTime` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_order
-- ----------------------------
INSERT INTO `t_order` VALUES ('1', '7fe67fe0a73a4a018d79ac2c6672346e', '636671008162388007', 'CNL636671008162388007', '2018-07-13 17:46:56', '待取', '3', '46', 'orderUser', 'orderUserName', 'orderUserPhone', 'orderUserAdder', '0', '2018-07-13 17:46:56');
INSERT INTO `t_order` VALUES ('2', '9ac9afec9d1448fb99e0873d87ededf8', '636671012197408007', 'CNL636671012197408007', '2018-07-13 17:53:39', '待取', '2', '31', 'orderUser', 'orderUserName', 'orderUserPhone', 'orderUserAdder', '0', '2018-07-13 17:53:39');
INSERT INTO `t_order` VALUES ('3', '89116d07eea04b4091469ea5bee28432', '636671012823628007', 'CNL636671012823628007', '2018-07-13 17:54:42', '待取', '3', '43', 'orderUser', 'orderUserName', 'orderUserPhone', 'orderUserAdder', '0', '2018-07-13 17:54:42');
INSERT INTO `t_order` VALUES ('4', 'a46300852960477a81aa79222ad310d2', '636671014366068007', 'CNL636671014366068007', '2018-07-13 17:57:16', '待取', '4', '100', 'orderUser', 'orderUserName', 'orderUserPhone', 'orderUserAdder', '0', '2018-07-13 17:57:16');
INSERT INTO `t_order` VALUES ('5', 'acda041021b648119828fc2024901f07', '636671015951568007', 'CNL636671015951568007', '2018-07-13 17:59:55', '待取', '6', '88', 'orderUser', 'orderUserName', 'orderUserPhone', 'orderUserAdder', '0', '2018-07-13 17:59:55');
INSERT INTO `t_order` VALUES ('6', '64be2174b27c49e7a3557b170dc1dfc3', '636673566851170000', 'CNL636673566851170000', '2018-07-16 16:51:25', '待取', '2', '31', 'orderUser', 'orderUserName', 'orderUserPhone', 'orderUserAdder', '0', '2018-07-16 16:51:25');
INSERT INTO `t_order` VALUES ('7', '3a8e79e0b6c74baabe7cfa906aa012e9', '636673567937200000', 'CNL636673567937200000', '2018-07-16 16:53:13', '待取', '1', '15', 'orderUser', 'orderUserName', 'orderUserPhone', 'orderUserAdder', '0', '2018-07-16 16:53:13');
INSERT INTO `t_order` VALUES ('8', 'cce8fd76c83943ff83421acd2aef79f1', '636673568603030000', 'CNL636673568603040000', '2018-07-16 16:54:20', '待取', '1', '21', '1', 'L BiN', '', '广东省深圳市南山区学府路30号', '0', '2018-07-16 16:54:20');
INSERT INTO `t_order` VALUES ('9', 'fb87692cebd946b3af4fe06a88f79c16', '636674402605890000', 'CNL636674402605890000', '2018-07-17 16:04:20', '待取', '3', '45', '1', 'L BiN', '', '广东省深圳市南山区学府路30号', '0', '2018-07-17 16:04:20');
INSERT INTO `t_order` VALUES ('10', 'f46794b342904d90a8b7b12099eafae7', '636674444343370000', 'CNL636674444343370000', '2018-07-17 17:13:54', '待取', '3', '64', '1', 'L BiN', '', '广东省深圳市南山区学府路30号', '0', '2018-07-17 17:13:54');
INSERT INTO `t_order` VALUES ('11', '0a42b9884e3c49ee913c3824ba16b7df', '636674445102780000', 'CNL636674445102780000', '2018-07-17 17:15:10', '待取', '3', '60', '1', 'L BiN', '', '广东省深圳市南山区学府路30号', '0', '2018-07-17 17:15:10');
INSERT INTO `t_order` VALUES ('12', '1c52706f1a3e459190918e4ddea60cd1', '636674493129530000', 'CNL636674493129530000', '2018-07-17 18:35:12', '待取', '1', '20', '1', null, '', '广东省深圳市南山区学府路30号', '0', '2018-07-17 18:35:12');
INSERT INTO `t_order` VALUES ('13', '986d471654c243dda4033940d99bca9a', '636675068611110000', 'CNL636675068611110000', '2018-07-18 10:34:21', '待取', '2', '30', '1', 'LUO B.', '', '广东省深圳市南山区学府路30号', '0', '2018-07-18 10:34:21');

-- ----------------------------
-- Table structure for `t_orderdetail`
-- ----------------------------
DROP TABLE IF EXISTS `t_orderdetail`;
CREATE TABLE `t_orderdetail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderid` int(11) DEFAULT NULL COMMENT '属于T_Order ID',
  `details` int(11) DEFAULT NULL COMMENT '属于那个菜单类下标  ',
  `rightIndex` int(11) DEFAULT NULL COMMENT '菜单类下菜单下标',
  `GoodsName` varchar(255) DEFAULT NULL COMMENT '订单名',
  `GoodsInfoStr` varchar(255) DEFAULT NULL COMMENT '订单说明',
  `Price` int(11) DEFAULT NULL COMMENT '单价',
  `num` int(11) DEFAULT NULL COMMENT '数量',
  `SumPrice` int(11) DEFAULT NULL COMMENT '总价',
  `createTime` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_orderdetail
-- ----------------------------
INSERT INTO `t_orderdetail` VALUES ('1', '1', '0', '1', '霸气芝士草莓', '', '15', '2', '30', '2018-07-13 17:47:01');
INSERT INTO `t_orderdetail` VALUES ('2', '1', '0', '2', '霸气橙子', '', '16', '1', '16', '2018-07-13 17:47:01');
INSERT INTO `t_orderdetail` VALUES ('3', '2', '0', '1', '霸气芝士草莓', '', '15', '1', '15', '2018-07-13 17:53:39');
INSERT INTO `t_orderdetail` VALUES ('4', '2', '0', '2', '霸气橙子', '', '16', '1', '16', '2018-07-13 17:53:39');
INSERT INTO `t_orderdetail` VALUES ('5', '3', '0', '1', '霸气芝士草莓', '', '15', '2', '30', '2018-07-13 17:54:42');
INSERT INTO `t_orderdetail` VALUES ('6', '3', '0', '0', '霸气芝士芒果', '标准[推荐],热的,标准[推荐],大杯', '13', '1', '13', '2018-07-13 17:54:42');
INSERT INTO `t_orderdetail` VALUES ('7', '4', '1', '2', 'CoCo 都可', '', '25', '2', '50', '2018-07-13 17:57:16');
INSERT INTO `t_orderdetail` VALUES ('8', '4', '1', '3', '熊猫奶盖红茶', '', '25', '2', '50', '2018-07-13 17:57:16');
INSERT INTO `t_orderdetail` VALUES ('9', '5', '0', '0', '霸气芝士芒果', '标准[推荐],热的,少少糖,大杯', '13', '1', '13', '2018-07-13 17:59:55');
INSERT INTO `t_orderdetail` VALUES ('10', '5', '0', '0', '霸气芝士芒果', '标准[推荐],热的,少糖,大杯', '13', '1', '13', '2018-07-13 17:59:55');
INSERT INTO `t_orderdetail` VALUES ('11', '5', '0', '1', '霸气芝士草莓', '', '15', '2', '30', '2018-07-13 17:59:55');
INSERT INTO `t_orderdetail` VALUES ('12', '5', '0', '2', '霸气橙子', '', '16', '2', '32', '2018-07-13 17:59:55');
INSERT INTO `t_orderdetail` VALUES ('13', '6', '0', '1', '霸气芝士草莓', '', '15', '1', '15', '2018-07-16 16:51:25');
INSERT INTO `t_orderdetail` VALUES ('14', '6', '0', '2', '霸气橙子', '', '16', '1', '16', '2018-07-16 16:51:25');
INSERT INTO `t_orderdetail` VALUES ('15', '7', '0', '1', '霸气芝士草莓', '', '15', '1', '15', '2018-07-16 16:53:13');
INSERT INTO `t_orderdetail` VALUES ('16', '8', '1', '1', '白桃乌龙霜降', '标准[推荐],大杯,F,RED', '21', '1', '21', '2018-07-16 16:54:20');
INSERT INTO `t_orderdetail` VALUES ('17', '9', '0', '2', '霸气橙子', '', '16', '2', '32', '2018-07-17 16:04:20');
INSERT INTO `t_orderdetail` VALUES ('18', '9', '0', '0', '霸气芝士芒果', '标准[推荐],标准[推荐],少少糖,大杯', '13', '1', '13', '2018-07-17 16:04:20');
INSERT INTO `t_orderdetail` VALUES ('19', '10', '2', '2', '铁观音珍珠奶茶', '标准[推荐],大杯,PINK', '22', '2', '44', '2018-07-17 17:13:54');
INSERT INTO `t_orderdetail` VALUES ('20', '10', '3', '0', '芝士静冈抹茶', '标准[推荐],标准[推荐],大杯', '20', '1', '20', '2018-07-17 17:13:54');
INSERT INTO `t_orderdetail` VALUES ('21', '11', '4', '0', '单位一', '', '10', '1', '10', '2018-07-17 17:15:10');
INSERT INTO `t_orderdetail` VALUES ('22', '11', '4', '1', '单位二', '', '20', '1', '20', '2018-07-17 17:15:10');
INSERT INTO `t_orderdetail` VALUES ('23', '11', '4', '2', '单位三', '', '30', '1', '30', '2018-07-17 17:15:10');
INSERT INTO `t_orderdetail` VALUES ('24', '12', '3', '0', '芝士静冈抹茶', '标准[推荐],少少糖,中杯', '20', '1', '20', '2018-07-17 18:35:13');
INSERT INTO `t_orderdetail` VALUES ('25', '13', '0', '1', '霸气芝士草莓', '', '15', '2', '30', '2018-07-18 10:34:21');

-- ----------------------------
-- Table structure for `t_relate`
-- ----------------------------
DROP TABLE IF EXISTS `t_relate`;
CREATE TABLE `t_relate` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `relateType` int(11) NOT NULL COMMENT '关系类型',
  `fromID` int(11) NOT NULL COMMENT '来源表ID',
  `toID` int(11) NOT NULL COMMENT '目标ID',
  `createUserID` int(11) NOT NULL COMMENT '创建者ID',
  `createTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_relate
-- ----------------------------
INSERT INTO `t_relate` VALUES ('4', '1', '13', '6', '1', '2018-06-13 15:14:03');
INSERT INTO `t_relate` VALUES ('5', '1', '13', '5', '1', '2018-06-13 15:14:03');
INSERT INTO `t_relate` VALUES ('6', '1', '13', '4', '1', '2018-06-13 15:14:03');
INSERT INTO `t_relate` VALUES ('7', '1', '13', '3', '1', '2018-06-13 15:14:03');
INSERT INTO `t_relate` VALUES ('8', '1', '11', '6', '1', '2018-06-13 15:47:39');
INSERT INTO `t_relate` VALUES ('9', '1', '11', '4', '1', '2018-06-13 15:47:39');
INSERT INTO `t_relate` VALUES ('10', '1', '11', '3', '1', '2018-06-13 15:47:39');
INSERT INTO `t_relate` VALUES ('11', '1', '18', '8', '1', '2018-07-02 15:16:58');
INSERT INTO `t_relate` VALUES ('12', '1', '18', '5', '1', '2018-07-02 15:16:58');
INSERT INTO `t_relate` VALUES ('13', '1', '18', '2', '1', '2018-07-02 15:16:58');
INSERT INTO `t_relate` VALUES ('14', '1', '18', '1', '1', '2018-07-02 15:16:58');
INSERT INTO `t_relate` VALUES ('15', '1', '24', '6', '1', '2018-07-03 11:00:36');
INSERT INTO `t_relate` VALUES ('16', '1', '24', '4', '1', '2018-07-03 11:00:36');
INSERT INTO `t_relate` VALUES ('17', '1', '24', '3', '1', '2018-07-03 11:00:36');
INSERT INTO `t_relate` VALUES ('18', '1', '24', '2', '1', '2018-07-03 11:00:36');
INSERT INTO `t_relate` VALUES ('19', '1', '24', '1', '1', '2018-07-03 11:00:36');
INSERT INTO `t_relate` VALUES ('20', '1', '15', '4', '1', '2018-07-03 11:02:01');
INSERT INTO `t_relate` VALUES ('21', '1', '15', '3', '1', '2018-07-03 11:02:01');
INSERT INTO `t_relate` VALUES ('22', '1', '15', '2', '1', '2018-07-03 11:02:01');
INSERT INTO `t_relate` VALUES ('23', '1', '15', '1', '1', '2018-07-03 11:02:01');
INSERT INTO `t_relate` VALUES ('24', '1', '23', '4', '1', '2018-07-12 15:15:12');
INSERT INTO `t_relate` VALUES ('25', '1', '23', '3', '1', '2018-07-12 15:15:12');
INSERT INTO `t_relate` VALUES ('26', '1', '23', '2', '1', '2018-07-12 15:15:12');
INSERT INTO `t_relate` VALUES ('27', '1', '22', '4', '1', '2018-07-12 15:15:22');
INSERT INTO `t_relate` VALUES ('28', '1', '22', '3', '1', '2018-07-12 15:15:22');
INSERT INTO `t_relate` VALUES ('29', '1', '22', '2', '1', '2018-07-12 15:15:22');

-- ----------------------------
-- Table structure for `t_shopinfo`
-- ----------------------------
DROP TABLE IF EXISTS `t_shopinfo`;
CREATE TABLE `t_shopinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `logo` longtext,
  `shopName` varchar(255) DEFAULT NULL,
  `shopPhone` varchar(255) DEFAULT NULL,
  `shopAddress` varchar(255) DEFAULT NULL,
  `shopCo_ordinate` varchar(255) DEFAULT NULL COMMENT '坐标',
  `shopInfo` varchar(255) DEFAULT NULL COMMENT '商家简介',
  `updateTime` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `createTime` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_shopinfo
-- ----------------------------
INSERT INTO `t_shopinfo` VALUES ('1', '/1931fdebaf384ec5856826563bcd8bc2.Jpeg', 'Answer', '13323137669', '滨海大道66号188', '22.430071,114.145203', 'ABCD - EFGH -', '2018-07-02 11:31:01', '2018-05-22 17:18:52');

-- ----------------------------
-- Table structure for `t_user`
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `userId` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `phoneNum` bigint(11) DEFAULT NULL COMMENT '玩家登陆时的手机号',
  `wxId` varchar(64) DEFAULT NULL COMMENT '微信的Id',
  `sex` tinyint(2) NOT NULL COMMENT '微信性别',
  `nickName` varchar(64) NOT NULL COMMENT '微信昵称',
  `headImgUrl` varchar(255) NOT NULL COMMENT '微信头像url',
  `loginAddress` varchar(255) DEFAULT NULL COMMENT '最新登录的地理位置',
  `registerIp` varchar(255) DEFAULT NULL COMMENT '最新登录的Ip',
  `loginIp` varchar(255) DEFAULT NULL,
  `diamond` int(11) unsigned NOT NULL DEFAULT '0' COMMENT '玩家在游戏内的钻石',
  `roundNum` int(11) NOT NULL DEFAULT '0' COMMENT '已玩局数',
  `registerTime` datetime NOT NULL COMMENT '注册时间',
  `loginTime` datetime NOT NULL COMMENT '最后的更新时间',
  `sessionId` varchar(64) DEFAULT '' COMMENT '用于自动登录时使用',
  `isFrozen` tinyint(2) NOT NULL DEFAULT '0' COMMENT '是否冻结，0-未冻结 1-冻结',
  `inviteCode` int(11) DEFAULT '0' COMMENT '推广码,代理模式下，玩家的上级玩家的邀请码,邀请码为玩家的id',
  `tableNum` varchar(10) DEFAULT NULL COMMENT '保存玩家的进入房间信息，用于处理玩家掉线后再次登录提示玩家“牌局结束”',
  `isProxy` tinyint(1) NOT NULL DEFAULT '0' COMMENT '是否代理',
  `applyClubCount` int(11) DEFAULT '0' COMMENT '正在申请加入俱乐部的数量（没有得到具体答复）',
  `clubCount` int(11) DEFAULT '0' COMMENT '已经加入俱乐部的数量（和正在申请的一起<=5）',
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=10438 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('10209', null, '124', '0', '我以为。', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '116.30.221.252', '116.30.221.252', '20', '0', '2018-03-14 16:15:54', '2018-03-14 17:26:21', 'ijNJWhMglpC42zwG13cMTcefCrbyyIUW', '0', '0', null, '1', '0', '2');
INSERT INTO `t_user` VALUES ('10210', null, '12', '0', 'A__留不住', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.33.242', '113.92.33.242', '17', '1', '2018-03-14 16:16:00', '2018-03-23 15:52:33', 'OOTON2kNvbRpkgkTDgxWJFFuF8ngtqUq', '0', '0', null, '1', '0', '1');
INSERT INTO `t_user` VALUES ('10211', null, '13242955991', '0', 'B__心结i', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.52.254', '113.116.52.254', '20', '8', '2018-03-14 17:04:52', '2018-03-22 15:18:42', 'SdWpN6WZdniJggMZ6E9NS7pc6SY4A4TK', '0', '10210', null, '1', '0', '2');
INSERT INTO `t_user` VALUES ('10212', null, '123', '0', 'C__幼稚完', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.35.168', '10', '0', '2018-03-15 10:28:46', '2018-03-19 17:24:24', 'eQQEk73Dszx6jopJZ20hqdztbOcgrnMn', '0', '10211', null, '1', '0', '0');
INSERT INTO `t_user` VALUES ('10213', null, '10010', '0', 'D__笑我痴', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.52.254', '113.116.52.254', '20', '9', '2018-03-15 10:40:00', '2018-03-21 14:26:17', 'blBWrdu6TEu7vXLXXgk8ewVNwrLVlcRJ', '0', '10212', null, '1', '0', '3');
INSERT INTO `t_user` VALUES ('10214', null, '10011', '0', '用情浅', 'https://ss0.bdstatic.com/6ONWsjip0QIZ8tyhnq/it/u=3618554304,2887917621&fm=77&w_h=121_75&cs=2820658166,1330608299', '广东省深圳市', null, '113.116.53.143', '20', '1', '2018-03-15 10:40:33', '2018-03-16 10:57:28', 'DQkSIeZgcGi2RI4iPsGaIIEqi3VtWsJJ', '0', '0', null, '1', '0', '0');
INSERT INTO `t_user` VALUES ('10215', null, '', '0', '落魄人', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.35.94', '20', '0', '2018-03-15 16:50:49', '2018-03-22 17:26:35', '07fgS2KTHq92Ah8F3TsZPxjiJybpod6j', '0', '0', null, '1', '0', '1');
INSERT INTO `t_user` VALUES ('10216', null, '10', '0', '难再遇', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.116.52.254', '20', '5', '2018-03-16 09:46:37', '2018-03-21 17:56:47', 'vpg16uXVNGXhxHb67SORlIc1foVoquQG', '0', '0', null, '0', '0', '3');
INSERT INTO `t_user` VALUES ('10217', null, '11', '0', '奈我何', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.33.242', '20', '1', '2018-03-16 09:51:48', '2018-03-23 15:52:26', 'Qo6qe0mXo9gSOZCiodxmPc4jZ0vmPjQO', '0', '0', null, '1', '0', '1');
INSERT INTO `t_user` VALUES ('10218', null, '15', '0', '笑我痴', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.35.213', '20', '0', '2018-03-16 10:14:22', '2018-03-16 10:31:35', 'D1hjRVpElSFBghohDyOQgtVB1i6Hoq0X', '0', '0', null, '1', '0', '2');
INSERT INTO `t_user` VALUES ('10219', null, '21', '0', '十年醒', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.35.213', '5', '17', '2018-03-16 10:42:59', '2018-03-16 11:50:30', 'GIy0csyVyUgCkPbQJE8VhaYsbkHhVTxZ', '0', '0', null, '0', '0', '5');
INSERT INTO `t_user` VALUES ('10220', null, '10012', '0', '柠檬酸ゞ', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '0', '2018-03-16 10:46:42', '2018-03-16 16:47:58', 'wHT6Mr4WRiYXrALRoChF883ul7TPffid', '0', '10214', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10221', null, '13242955992', '0', '离又弃', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '8', '2018-03-16 11:39:20', '2018-03-16 11:40:05', 'MPP6N9UdmJOlkLLelJt9d4GQtAuU3zfR', '0', '10214', '906605', '0', '0', '2');
INSERT INTO `t_user` VALUES ('10222', null, '9651', '0', '彼得潘√', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.35.213', '113.92.35.213', '20', '8', '2018-03-16 11:39:42', '2018-03-16 11:39:42', 'JYgCwIEVGQ0zCjg1Fg3FO9iT83GIB41U', '0', '10214', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10223', null, '15070619449', '0', '憎厌她', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.116.53.143', '20', '4', '2018-03-16 11:39:55', '2018-03-16 11:44:24', 'O0rjq6mmKpBuwfWnPEaBpkhjAimOrCTG', '0', '10214', '184042', '0', '0', '2');
INSERT INTO `t_user` VALUES ('10224', null, '132429559456', '0', '梦中梦i', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '11', '14', '2018-03-16 11:40:27', '2018-03-16 11:58:12', '9Ha2jAMhNtqQ2myWfbwBZ0WIwMG3JQgT', '0', '0', '515626', '0', '0', '3');
INSERT INTO `t_user` VALUES ('10225', null, '13825203', '0', '溺深海', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '0', '2018-03-16 11:41:44', '2018-03-16 11:41:44', 'wviS4HycAdc8KpI9gwiq3dCiS0Rraqgt', '0', '10214', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10226', null, '13825203413', '0', '来生缘', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '未知国家 未', '113.92.35.213', '113.92.35.213', '20', '4', '2018-03-16 11:41:49', '2018-03-16 15:50:15', 'VIbPs7J6dMG3RHBT3ALzGhJcXSbzAGoH', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10227', null, '10086', '0', '闷着i', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '4', '2018-03-16 12:03:32', '2018-03-16 12:03:32', 'DhezAKFIeOS8Uq1OMBMoSS46JAL9k4op', '0', '10214', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10228', null, '13242', '0', '当笑谈', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.35.213', '113.92.35.213', '20', '2', '2018-03-16 12:14:04', '2018-03-16 12:14:04', 'pJZKVoza4uoDpuvigT9GNjoyf2CROBnD', '0', '10214', '515626', '0', '0', '1');
INSERT INTO `t_user` VALUES ('10229', null, '160', '0', '十年醒', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.35.168', '17', '0', '2018-03-16 12:48:20', '2018-03-19 17:20:52', '1Q60zNBUuSzlrT57b6Hqyyh0ScDsYV3r', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10230', null, '852', '0', '讨你欢', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '0', '2018-03-16 12:56:52', '2018-03-16 12:56:52', 'txp0AVEkvCgJuN4V1GrnKupjRqqXME68', '0', '10214', null, '1', '0', '0');
INSERT INTO `t_user` VALUES ('10231', null, '1204', '0', '匹诺曹', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '0', '2018-03-16 13:01:12', '2018-03-16 13:01:12', 'YSwXI0ZaVo9cVoVmcO4qP9PQzQskdmUC', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10232', null, '120325', '0', '再不见', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '0', '2018-03-16 13:02:19', '2018-03-16 13:02:19', 'q4x2so4bykeXsQezMECHLjVFkfkaMLTR', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10233', null, '9936', '0', '太遗憾', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.116.53.143', '20', '0', '2018-03-16 14:02:29', '2018-03-16 14:03:56', 'xN2UUkejYPIJHQNlSB22LINWNZ74CtV9', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10234', null, '120', '0', '庆祝寂寞。', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.52.254', '113.116.52.254', '2', '0', '2018-03-16 14:07:49', '2018-03-21 10:50:34', 'Ep15xrzd3pd6UxihZzycQZMtJuTWLtr0', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10235', null, '99681', '0', '旧人序', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.116.53.143', '20', '0', '2018-03-16 14:08:48', '2018-03-16 14:10:20', '8TEdJJYWO6tEHLqsZZHP4Sj7L3HmHzLA', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10236', null, '99682', '0', '来生缘', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '0', '2018-03-16 14:10:25', '2018-03-20 16:23:53', 'kEcNgYRn34whUeILxLhBLahOLxhFs0Pk', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10237', null, '13242954561', '0', '歪腻', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.35.213', '113.92.35.213', '20', '0', '2018-03-16 15:42:18', '2018-03-16 15:42:18', '6m2Yn0GqhGgx53gdJLDsNP4efy3G2B2C', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10238', null, '601', '0', '强颜欢笑。', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.35.213', '17', '1', '2018-03-16 16:46:00', '2018-03-16 18:10:40', '4j1R2gghShxSVB7LGLoMe7bAoqKzHpvc', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10239', null, '602', '0', '走太远', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.143', '113.116.53.143', '20', '1', '2018-03-16 16:46:19', '2018-03-16 16:46:19', 'zKHzUrtkbUkU6Ggk0B1z20x1FPTmN5d3', '1', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10240', null, '132429559913', '0', '路过人。', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '未知国家 未', '113.92.35.168', '113.92.35.168', '20', '0', '2018-03-19 15:25:35', '2018-03-19 15:25:35', '2Jma8LXbqmc1Pjdpud0622JtMpq4Q6FV', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10241', null, '236', '0', '走太远', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.35.168', '113.92.35.168', '20', '0', '2018-03-19 16:53:36', '2018-03-19 16:53:36', 'EimNoR7xmKxYgEWR2X4OWeon8sUVhFT1', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10242', null, '164', '0', '闷着i', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.35.168', '113.92.35.168', '20', '0', '2018-03-19 17:20:48', '2018-03-19 17:20:48', 'YNOeTtMepaSaInCirNqYrh4xbUqeGnde', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10243', null, '121', '0', '笑忘书', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '', '', '', '20', '0', '2018-03-19 17:23:28', '2018-03-19 17:23:28', 'eIN42ekPInMfXYjpV2eBEa1HeXzGfGlo', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10244', null, '211', '0', '别再拖', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '', '', '', '20', '0', '2018-03-19 17:29:44', '2018-03-19 17:29:44', 'wIwdVfIhrlPazvd6rtSeHeelx2lej0nS', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10245', null, '968', '0', '未轻叹', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '', '', '', '20', '0', '2018-03-19 17:31:34', '2018-03-19 17:31:34', 'yuNmtHhAJrKlDHemGCvhElsMRnlktjs1', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10246', null, '99', '0', '你的笑', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.35.94', '113.92.35.94', '20', '0', '2018-03-19 17:32:26', '2018-03-22 15:12:18', 'yeqrvd46Y07TzcMaVv3KaAMz8DI6qB8A', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10247', null, '9905', '0', '维她命', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.35.168', '113.92.35.168', '20', '0', '2018-03-19 17:34:04', '2018-03-19 17:35:57', '94GiSkmOEKBeeczrCVqsHSOvFWzyhLV0', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10248', null, '9005', '0', '疯人愿', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.35.168', '20', '0', '2018-03-19 17:37:25', '2018-03-19 17:37:29', 'jXsfEARcRsbxNieo7upysTLgt7gK2XhN', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10249', null, '9006', '0', '笑忘书', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '17', '1', '2018-03-19 17:37:38', '2018-03-20 12:11:56', 'qnt0LqcL4vCa4UPdlTRCB8FoBpRjkez2', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10250', null, '9008', '0', '马蹄疾', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '1', '2018-03-19 17:40:22', '2018-03-20 12:11:51', 'jtL60UhtYADzBZ4NusshpAqLYMG3JYm7', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10251', null, '10121', '0', '无心魔i', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '0', '2018-03-20 10:55:04', '2018-03-20 10:55:04', 'nQVJhWIkGbgOxsR0Y4SEx7BdrWBSgfDf', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10252', null, '6001', '0', '溺深海', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '0', '2018-03-20 12:13:42', '2018-03-20 12:13:42', 'JGCdom2rBaqwoQ0EokZSB13pp2iYqo1k', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10253', null, '10015', '0', '别再拖', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.92.32.70', '20', '0', '2018-03-20 12:15:55', '2018-03-20 15:30:12', 'J3OxvHRFnNMcGjLzDO2jk7PR6VlDdL7l', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10254', null, '10016', '0', '暖心人', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '0', '2018-03-20 15:30:22', '2018-03-20 17:59:37', 'nAzhoprktiDDD7kGaHvirS1s76UV8IXO', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10255', null, '10017', '0', '心如筝', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '0', '2018-03-20 15:59:15', '2018-03-20 17:59:54', 'CcoWtr7EmyEeqj0g7R1OWEjD434Ps5D0', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10256', null, '8001', '0', '醉梦中', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', null, '113.116.53.105', '20', '0', '2018-03-20 16:43:35', '2018-03-20 17:41:40', 'C6vcYsSNldOjf1hBpw7hRvKeiZe4mae0', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10257', null, '8002', '0', '羽化尘。', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '0', '2018-03-20 16:43:46', '2018-03-20 18:02:04', 'VBPiCEUkaQ09cqZijIdDCSTaVyf6JZrN', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10258', null, '121121', '0', '青凋牧', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.53.105', '113.116.53.105', '20', '0', '2018-03-20 17:59:31', '2018-03-20 17:59:31', 'NFGmE1ipyJO1tiYEKf9E7wkYHTmadtbV', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10259', null, '10002', '0', '盗梦者。', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.32.70', '113.92.32.70', '20', '0', '2018-03-20 18:11:58', '2018-03-20 18:13:25', 'NFKF2vVwkfcUGf7pE3SgqbSL1db3actG', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10260', null, '10003', '0', '柠檬酸ゞ', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.32.70', '113.92.32.70', '20', '0', '2018-03-20 18:13:29', '2018-03-20 18:13:29', 'wYtGP4dVjkztQkRMYScbqqaNWCPb3nhM', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10261', null, '116', '0', '幼稚完', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.52.254', '113.116.52.254', '17', '1', '2018-03-21 10:50:59', '2018-03-21 10:50:59', '5aq2ylJkE3cpqZtNNgdCtodSULMr1ZNf', '0', '0', '436640', '0', '0', '1');
INSERT INTO `t_user` VALUES ('10262', null, '117', '0', '- 尘世美', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.116.52.254', '113.116.52.254', '20', '1', '2018-03-21 10:56:34', '2018-03-21 11:51:59', 'GHPshOywwMPjyPEZvAp6ffud7CUFiMNe', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10263', null, '13751010016', '0', '青春爱最大。', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.33.242', '113.92.33.242', '20', '0', '2018-03-21 12:05:49', '2018-03-23 10:27:26', '2pFC7DnmX2ymlph4a6H6MNJYFVnnzbvj', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10264', null, '132429559916', '0', '你走开', 'http://img0.imgtn.bdimg.com/it/u=634660919,3123148903&fm=27&gp=0.jpg', '广东省深圳市', '113.92.33.242', '113.92.33.242', '20', '0', '2018-03-22 15:18:44', '2018-03-23 15:21:11', 'ziC3v4E8vicaIRo8r60AqB5DFUtZbaSL', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10265', '13418675297', null, '0', '游客10265', '', '广东省深圳市', null, '113.92.34.107', '20', '4', '2018-03-23 17:05:59', '2018-03-27 17:34:14', 'ldd9axiBAMCc3PctCkoSPryuQ4Sy8a30', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10266', '13266814898', null, '0', '迅雷会员007', '', '广东省深圳市', null, '113.92.33.190', '1984', '279', '2018-03-23 17:06:23', '2018-04-04 18:21:25', '4yjwGlXvgHEjM0wM1QWRx7zeJTLSq72a', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10267', '13088888888', null, '0', '游客10267', '', '广东省深圳市', null, '116.30.223.134', '20', '4', '2018-03-23 17:16:22', '2018-04-23 11:57:02', 'pHuWPE4oe8fvDG4DiPhugFUEE4Z6wJIb', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10268', '13000000000', null, '0', '我王住你家隔', '', '广东省深圳市', null, '121.35.102.240', '19999937', '400', '2018-03-23 17:30:39', '2018-05-18 13:07:36', 'bU6VeKllcEMCRSNAg0JLYRcpb7URvnVt', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10269', '13000000001', null, '0', '游客10269', '', '广东省深圳市', null, '121.35.102.240', '19', '10', '2018-03-23 17:33:03', '2018-05-18 13:11:40', 'eey3zwWt89BoNUCUGAmP5N4qsnB1pmF3', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10270', '13699885989', null, '0', '游客10270', '', '广东省深圳市', '116.30.222.26', '116.30.222.26', '20', '0', '2018-03-26 10:20:23', '2018-03-26 10:20:58', 'klUS62KOqmYScNyzguLn0YlYBZDDXLpE', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10271', '15924265856', null, '0', '游客10271', '', '广东省深圳市', '116.30.222.26', '116.30.222.26', '20', '0', '2018-03-26 10:57:56', '2018-03-26 10:59:33', 'S6r5LjN6JvAOZWMCwiYY1AW0fJJ5ScRN', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10272', '15822200202', null, '0', '游客10272', '', '广东省深圳市', '116.30.222.26', '116.30.222.26', '20', '0', '2018-03-26 11:28:07', '2018-03-26 11:28:25', 'DFbYzPtBLDnMI5L11LIUpBUKz1MIUjQS', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10273', '13000000008', null, '0', '游客10273', '', '广东省深圳市', null, '113.92.32.221', '20', '10', '2018-03-26 11:28:43', '2018-05-03 18:35:36', 'rbU4qpXSU4ByX7WKPIhUJ32Za09CS1LG', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10274', '13000000003', null, '0', '一一一一一一一将', '', '广东省深圳市', null, '121.35.102.240', '14', '81', '2018-03-26 11:30:02', '2018-05-18 13:18:39', 'MUJjJ9QgwbSGgCH3q0hOIBlsZAlMNy7C', '0', '0', '326967', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10275', '13000000009', null, '0', 'qrq', '', '广东省深圳市', null, '113.92.32.221', '24', '0', '2018-03-26 11:33:15', '2018-05-03 18:13:51', 'RMYzMX940M3AOBOpCfrxuea58LIgyNKq', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10276', '13333333333', null, '0', '游客10276', '', '广东省深圳市', null, '113.92.35.123', '20', '0', '2018-03-26 11:41:12', '2018-03-26 11:43:06', 'GwVYY1S4SUCsePtVPcHijjku1I5nwEGJ', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10277', '13888888888', null, '0', '游客10277', '', '广东省深圳市', null, '113.92.35.123', '20', '10', '2018-03-26 11:42:06', '2018-03-26 17:37:38', 'bHd5ZRlUtaylYtk20LmNyHY4pPz9IcBt', '0', '0', '282877', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10278', '13333333337', null, '0', '游客10278', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 11:43:11', '2018-03-26 11:44:01', 'Q4uc3AWuIH3SCDxConoC7YS9ZUZv1z2a', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10279', '13000000006', null, '0', '大龙vs金富', '', '广东省深圳市', null, '121.35.102.229', '19999766', '252', '2018-03-26 11:48:26', '2018-05-10 12:14:41', '8BE6XMtSz4geWUXfhd4yOCAT1W79m4dr', '0', '0', null, '0', '0', '5');
INSERT INTO `t_user` VALUES ('10280', '13000000065', null, '0', '游客10280', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 11:50:33', '2018-03-26 11:50:46', 'u63JF1kgjsek7osviPSbrwa0ihUaVLmJ', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10281', '13000000898', null, '0', '游客10281', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 11:54:20', '2018-03-26 11:54:20', 'eDWe7E7anBoeNoYasl7HARkjhaSoFWTd', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10282', '13333333335', null, '0', '游客10282', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 11:55:32', '2018-03-26 11:59:09', 'gSTs9qpoxWr3xUVt7eCCBIvnGDhQbEZZ', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10283', '13000000677', null, '0', '游客10283', '', '广东省深圳市', '116.30.222.26', '116.30.222.26', '20', '0', '2018-03-26 14:51:19', '2018-03-26 15:54:36', 'oR9E8vkU3xS4SLsHbXHca733BJRBbuQ3', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10284', '13010000000', null, '0', '游客10284', '', '广东省深圳市', '116.30.222.26', '116.30.222.26', '20', '0', '2018-03-26 15:22:55', '2018-03-26 15:23:20', 'VZkBsQH2TnvxqUsBdWfRHOCZNykXq1Rw', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10285', '13000000565', null, '0', '游客10285', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 17:26:47', '2018-03-26 17:36:33', 'DAI8b41YhbrcUaHzWuDxomNVSLMtm2KY', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10286', '13200000000', null, '0', '游客10286', '', '广东省深圳市', null, '116.30.220.189', '10', '67', '2018-03-26 17:27:30', '2018-04-09 16:51:08', 'Z2OwzU1ddxY9uHipiNqcoyLjmBWYsETV', '0', '10286', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10287', '13600000000', null, '0', '游客10287', '', '广东省深圳市', null, '116.30.220.189', '1', '199', '2018-03-26 17:30:41', '2018-03-29 11:49:17', 'q3dCeiAyFZ6V2WfmOCYTcvfMDmnfeeT3', '0', '10306', '334229', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10288', '13100000000', null, '0', '游客10288', '', '广东省深圳市', null, '113.92.35.123', '20', '10', '2018-03-26 17:31:51', '2018-03-26 17:38:38', 'ACiPHztN9dIo2awDhLrNDamo8AA0K7m6', '0', '0', '282877', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10289', '13111111111', null, '0', '游客10289', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '10', '2018-03-26 17:33:23', '2018-03-26 17:34:26', '8q6FYiQP5l4Pt6wjj8bFWk3wETlPt754', '0', '0', '282877', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10290', '13266666666', null, '0', '扛把子', '', '广东省深圳市', null, '113.92.32.153', '15', '76', '2018-03-26 17:48:37', '2018-04-04 14:22:34', 'F03ACk9NVZ3TcHjs4FRRVZBaeTohhj5r', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10291', '13242955991', null, '0', '信不信我打你', '', '广东省深圳市', null, '113.92.32.221', '19999905', '1647', '2018-03-26 18:10:15', '2018-05-03 18:18:56', 'TFHZLp2uGBSd8blye26OULMQ3Gr8H93O', '0', '0', null, '1', '0', '2');
INSERT INTO `t_user` VALUES ('10292', '13200000001', null, '0', '游客10292', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '17', '31', '2018-03-26 18:25:43', '2018-03-29 16:57:42', 'IssmO8V0ht6FO2mr0xaTgeLDSq7c6Bt8', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10293', '13200000003', null, '0', '游客10293', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 18:27:29', '2018-03-26 18:27:29', 'TWnY9jUSyfSd3qc6LbwDlAULElzDVw35', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10294', '13900000000', null, '0', '游客10294', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 18:30:05', '2018-03-26 18:30:05', 'Ks2sgjNHVaYfFOJygWyYm6DvncCWoMpf', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10295', '13800000000', null, '0', '游客10295', '', '广东省深圳市', '113.92.35.123', '113.92.35.123', '20', '0', '2018-03-26 18:30:49', '2018-03-26 18:30:49', 'jhaFxxQqXHzve9H81YVHxr7KapewHr9A', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10296', '13899999999', null, '0', '游客10296', '', '广东省深圳市', '113.116.52.172', '113.116.52.172', '20', '0', '2018-03-27 10:00:05', '2018-03-27 10:21:03', '6caoWMpfQZJOYufO9TUqWmAMvQTvrNLP', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10297', '14825252525', null, '0', '游客10297', '', '广东省深圳市', '113.116.52.172', '113.116.52.172', '20', '0', '2018-03-27 10:26:22', '2018-03-27 10:26:22', 'q8Zm1tvTkGeMx4fAWOfa23DciKLlVboU', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10298', '13323244242', null, '0', '游客10298', '', '广东省深圳市', '113.92.34.107', '113.92.34.107', '20', '0', '2018-03-27 14:30:26', '2018-03-27 14:46:22', 'OG75iFfFaSEwgiVmDzd9QjlI1D1ETgQS', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10299', '13268868558', null, '0', '游客10299', '', '广东省深圳市', '113.92.34.107', '113.92.34.107', '20', '0', '2018-03-27 14:31:18', '2018-03-27 14:46:22', 'ZUMPPBPCB03bUPUKnmDLzqg0ZmcIZDgO', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10300', '13212122121', null, '0', '游客10300', '', '广东省深圳市', '113.92.34.107', '113.92.34.107', '20', '0', '2018-03-27 14:33:32', '2018-03-27 14:46:18', 'XBU1cDkxEYUOMpYk8RdHcWUPkF7d2KTf', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10301', '13266814899', null, '0', '游客1022', '', '广东省深圳市', null, '116.30.220.189', '11', '53', '2018-03-27 14:36:43', '2018-03-30 15:12:14', 'p4KWwpLway4rB75v0u5itDRjKmjEMroi', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10302', '13266815578', null, '0', '游客10302', '', '广东省深圳市', '113.116.52.172', '113.116.52.172', '20', '0', '2018-03-27 15:38:02', '2018-03-27 15:38:02', 'YHw4xs1hGnfM0b7YiuvT9bLAOY9Hz9Ay', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10303', '14785858585', null, '0', '戚继光', '', '广东省深圳市', null, '113.92.35.232', '16', '182', '2018-03-27 15:54:24', '2018-03-30 14:35:31', '4OApd029or30aq12vt3LT1H0Ly5WN694', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10304', '15070619449', null, '0', '满江红', '', '广东省深圳市', null, '113.92.32.221', '19999766', '1723', '2018-03-27 15:54:32', '2018-05-03 18:29:04', 'Np4BhU5raRVurvq87RxUQggZJJdaP0Ka', '0', '0', null, '1', '0', '1');
INSERT INTO `t_user` VALUES ('10305', '13307712493', null, '0', 'K车售票员', '', '广东省深圳市', null, '113.92.34.148', '19999763', '1612', '2018-03-27 15:56:26', '2018-04-25 12:37:15', 'Wz1Th0K9w1rO9ZPDB9pBCXyWBxUeJpT1', '0', '0', null, '1', '0', '3');
INSERT INTO `t_user` VALUES ('10306', '13000000454', null, '0', '大郎', '', '广东省深圳市', '113.92.34.107', '113.92.34.107', '1996', '284', '2018-03-27 16:07:24', '2018-03-29 14:41:10', 'YLVkDKtfqx6luETQCV1iohsoEFUYZkjT', '0', '10287', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10307', '13223113311', null, '0', '游客10307', '', '广东省深圳市', '113.92.34.107', '113.92.34.107', '20', '0', '2018-03-27 16:23:14', '2018-03-27 16:23:14', 'lAXiTJG5a3LQhvyGNyci2omHWLDlPDBg', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10308', '13664655665', null, '0', '游客10308', '', '广东省深圳市', '113.92.34.107', '113.92.34.107', '20', '0', '2018-03-27 17:19:56', '2018-03-27 17:19:56', 'rudTTT5nbEJyuSSbaq3wzwMrkH1c5Hbo', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10309', '13266656565', null, '0', '游客10309', '', '广东省深圳市', '113.116.52.172', '113.116.52.172', '17', '3', '2018-03-27 17:30:58', '2018-03-27 17:30:58', 'rvP9a3OehLxHYWsp0lZ1n9hPqNy02qTL', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10310', '13265656564', null, '0', '游客10310', '', '广东省深圳市', '113.116.52.172', '113.116.52.172', '20', '1', '2018-03-27 17:32:08', '2018-03-27 17:32:08', 'HuXqJnmQjq4qMgY7Zu7TQaxMdOgDokE9', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10311', '13666666666', null, '0', '游客10311', '', '广东省深圳市', null, '113.92.34.148', '17', '2', '2018-03-27 18:19:20', '2018-04-25 11:52:17', 'V6vKK6FZXFmxvdaW2Ewst6ANf8JVtXRm', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10312', '13855555222', null, '0', '游客10312', '', '广东省深圳市', '113.116.52.172', '113.116.52.172', '14', '11', '2018-03-28 10:52:29', '2018-03-29 10:46:59', 'TBsdsdBeOZYTSsZ0xNT5ePl72b8CBCJP', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10313', '13242955994', null, '0', '游客10313', '', '广东省深圳市', '113.92.34.107', '113.92.34.107', '20', '2', '2018-03-28 16:21:38', '2018-04-25 12:39:02', 'UplP3axMWhurgoacUwTCvAU13jZpY3vz', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10314', '13588885858', null, '0', '游客10314', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '20', '11', '2018-03-29 10:47:17', '2018-03-29 11:20:50', 'ZIelbw4if0QoSqIDYIS4vP0P2Rkc1DrB', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10315', '15014141414', null, '0', '游客10315', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '0', '2018-03-29 11:23:16', '2018-03-29 11:23:39', 'kSq56wNpbxXav0frdBGeqZnJuwBoZKij', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10316', '18102020202', null, '0', '游客10316', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '0', '2018-03-29 11:24:34', '2018-03-29 11:24:49', '4wSSXeyfAJHJWdkXsVt7MilU3VnFeSVb', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10317', '18411111111', null, '0', '游客10317', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '18', '2018-03-29 11:25:15', '2018-03-29 11:25:29', 'FHBIDiFasbhDt6PQTThNJLKIVYpApFze', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10318', '18023232323', null, '0', '游客10318', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '14', '18', '2018-03-29 11:25:51', '2018-03-30 14:31:46', 'g0eaOoJubOZ5O6BVLWoyvfZwRoMkwLid', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10319', '13400000000', null, '0', '游客10319', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '18', '20', '2018-03-29 11:53:30', '2018-03-29 11:53:30', 'KIaOiTzI2YRARU4HM99NZiPlOdAjhjqS', '0', '0', '334229', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10320', '13000561251', null, '0', '游客10320', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '17', '22', '2018-03-29 11:58:57', '2018-03-30 12:05:46', 'CaFEknZ5L8mxNGiiV1jMqy6t0O5L4FSa', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10321', '13222222221', null, '0', 'wwwwwwww', '', '广东省深圳市', null, '113.92.35.232', '9000000', '46', '2018-03-29 12:00:34', '2018-03-29 16:23:52', 'wC6Gu5fZww08998wABaaa8jT1iGBuskP', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10322', '13000006666', null, '0', '游客10322', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '0', '2018-03-29 12:02:09', '2018-03-29 12:02:09', 'DUASa7lRqHy5JtUcYOqsbxvytL2xnnpr', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10323', '13800000025', null, '0', '游客10323', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '18', '5', '2018-03-29 12:14:13', '2018-03-29 12:14:13', 'yNZOyftXMiwzdlQ7sbwXcBN6UHp6sOQj', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10324', '13999999999', null, '0', '游客10324', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '19', '4', '2018-03-29 12:14:23', '2018-03-29 12:14:23', 'B95MJr1l56xCcssBM1cjucfXXMqomvnB', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10325', '13312222221', null, '0', '游客10325', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '19', '1', '2018-03-29 12:18:10', '2018-03-29 12:18:10', 'ugmqBwXZ2HMv8ZgsJ28TiDfAS57BndZY', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10326', '13659464623', null, '0', '游客10326', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '1999999994', '21', '2018-03-29 14:41:51', '2018-03-29 14:51:41', '4VPoBOmbBXNWpg9XeqKGGDs1ws1y4CGd', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10327', '13666666685', null, '0', '游客10327', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '17', '10', '2018-03-29 15:18:30', '2018-03-29 15:21:25', 'ujjrW6mfAC0XQxOqavN80eCOEBxwPNXx', '0', '0', '990331', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10328', '13622211133', null, '0', '夜', '', '广东省深圳市', null, '116.30.220.189', '77', '72', '2018-03-29 17:03:08', '2018-04-02 11:58:54', 'k9nwyVfaDl66StrPeXk8D1nzz6McIx6l', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10329', '13626130018', null, '0', '常山赵子龙', '', '广东省深圳市', null, '116.30.220.189', '2002194', '97', '2018-03-29 18:09:46', '2018-04-02 15:43:24', '2YvJVEqIqTd1L6jI3ut9uUXmr82AL8Rb', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10330', '13002300000', null, '0', '游客10330', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '20', '2018-03-29 18:09:56', '2018-03-29 18:09:56', 'GHq8YFrS0f7CI89raB7rqs0cAgePo669', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10331', '13000000005', null, '0', '游客10331', '', '广东省深圳市', null, '113.92.34.173', '20', '1', '2018-03-30 11:47:09', '2018-04-12 11:49:54', '4BsTl9hxOLKjpAv86sladV3pJ8tIYdmw', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10332', '13222222222', null, '0', '游客10332', '', '广东省深圳市', null, '113.92.32.216', '20', '5', '2018-03-30 12:09:44', '2018-04-19 16:58:44', 'UBDr5uDa86J2ZCRefk2xcplOxib1Nsxe', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10333', '13131313131', null, '0', '凉冰冰', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '40', '24', '2018-03-30 14:50:32', '2018-03-30 15:52:41', 'jLioKXunugk2U5nT0tg2xoxzi0HMJu6L', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10334', '13225612582', null, '0', '游客10334', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '0', '2018-03-30 14:59:43', '2018-03-30 14:59:43', 'UTYYyhhsPrAtMfSXoXkBC4CpvWe49CfS', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10335', '18412121212', null, '0', '游客10335', '', '广东省深圳市', '113.92.35.232', '113.92.35.232', '20', '0', '2018-03-30 15:10:49', '2018-03-30 15:10:49', 'T7UoWxZEaa30tJnY3DQ8U2AjhRRHOmM0', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10336', '18699999115', null, '0', '东方不败', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '50', '0', '2018-03-30 15:11:07', '2018-03-30 15:30:37', '9CZeU9E6FtwLdXtDE2Cq11jcc9ZHLETT', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10337', '13662613007', null, '0', '总有刁民想害朕', '', '广东省深圳市', null, '116.30.223.134', '19999769', '1371', '2018-03-30 15:12:26', '2018-04-25 12:45:22', 'die17UVdqGaHSeTvuvtjeOqCiv7lN60U', '0', '0', null, '1', '1', '1');
INSERT INTO `t_user` VALUES ('10338', '18946825135', null, '0', '西王', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '28', '0', '2018-03-30 15:30:56', '2018-04-02 11:37:46', 'cH10SuRyMIQYztQt6NM02xGYa4smy4CO', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10339', '13655555555', null, '0', '头号玩家', '', '广东省深圳市', null, '116.30.222.108', '19999839', '1426', '2018-03-30 16:04:49', '2018-04-25 12:43:56', 'ofqRAqKDwQAAJLa4kyxgKiscM56mPkzX', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10340', '13232323333', null, '0', '游客10340', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '10', '2018-03-30 16:24:20', '2018-03-30 16:27:50', '0EZVCUCI8nqdjpsmR5oyzaawkRsVk9kY', '0', '0', '867799', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10341', '13000220212', null, '0', '桥', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '40', '3', '2018-03-30 16:28:28', '2018-03-30 17:02:31', 'w6s3WLEoeUqeNKUR8XulJOJ8YdqjLehL', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10342', '13114145312', null, '0', '大哥', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '42', '0', '2018-03-30 16:34:00', '2018-03-30 16:34:00', 'ZB7I7qhZVDRabWVvJrPsE8Ziy3lqF7Qf', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10343', '13000000023', null, '0', '泊', '', '广东省深圳市', '116.30.220.189', '116.30.220.189', '20', '0', '2018-03-30 17:38:33', '2018-03-30 17:38:33', 'hkBd1z0IDswiJqQLz7BWMex0lt5DiHv3', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10344', '13895696585', null, '0', '游客10344', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-02 11:38:02', '2018-04-02 11:38:06', 'ECQXqPxAI3ClDlmdnubV1aahflOMZlTm', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10345', '13265655665', null, '0', '游客10345', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-02 11:43:03', '2018-04-02 11:43:03', 'SvkPeeStGC9eqLeSGQfnOpsfH5NUYuRU', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10346', '13266856464', null, '0', '鸣人大大大大大大', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '17', '10', '2018-04-02 11:54:49', '2018-04-03 16:03:38', 'tj7WeRp9GAh0HYdykaZPKrfFlhGkrEWh', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10347', '15922225555', null, '0', '游客10347', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-02 15:07:23', '2018-04-02 15:07:23', 'AY0h4hrztNPzH6AUt0n0Q9k29d1nVk9R', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10348', '15102020202', null, '0', '游客10348', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-02 15:08:16', '2018-04-03 10:08:45', 'rEDZWXYlTScjQBs8dxdl7ASlXTrc4R7D', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10349', '13000000007', null, '0', '佐助', '', '广东省深圳市', null, '113.92.32.221', '5', '52', '2018-04-02 15:21:06', '2018-05-03 18:31:11', 'tAYReENvZXa4DnJLyNRYsyyeJRSfF68P', '0', '0', null, '0', '0', '3');
INSERT INTO `t_user` VALUES ('10350', '13265656556', null, '0', '游客10350', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-02 16:20:42', '2018-04-02 16:30:37', 'ap5jmzpqtMYYnkMJOYCMFilQ6DVxecJt', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10351', '13859568656', null, '0', '游客10351', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-02 16:31:01', '2018-04-02 16:31:13', 'VfZTl3GlJH5sWzxJS4QA5MhLFtyVgALE', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10352', '13845245787', null, '0', '游客10352', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-02 18:11:16', '2018-04-03 10:41:58', 'OLL1xgDgFrJgD5fb3PFJB4o3SFnRoKMy', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10353', '15414142151', null, '0', '游客10353', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-02 18:27:23', '2018-04-03 09:47:03', 'xb6LHqGYwei4ZupzrLayddBADm2ohU3Q', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10354', '13000000002', null, '0', '游客10354', '', '广东省深圳市', null, '121.35.102.240', '11', '40', '2018-04-03 09:38:41', '2018-05-18 15:10:18', 'sihil2KZuffqhN4xsGk02kMjPyCCuzHs', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10355', '13662613006', null, '0', '游客10355', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 10:05:42', '2018-04-03 10:05:42', 'LHsCpgAdbnrCCrRrca4oKEx8vT0LFnSd', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10356', '18102321235', null, '0', '难玩今宵', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 10:41:11', '2018-04-03 11:02:43', 'oKjTV3aeGUUv49trRki9qkjA16vOvbyA', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10357', '18620203010', null, '0', '我就是我', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 10:41:24', '2018-04-03 11:01:38', 'mKm5Ie8pqGBh9xmZXET9pbBwlrgspbsN', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10358', '18703212320', null, '0', '万一', '', '未知', '0.0.0.0', '0.0.0.0', '70', '0', '2018-04-03 11:03:04', '2018-04-03 11:03:04', 'dPzzoU8sgZdBPBvWboiUTxREia2Cnc9F', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10359', '15302020202', null, '0', '群主火85', '', '未知', '0.0.0.0', '0.0.0.0', '30', '0', '2018-04-03 11:03:16', '2018-04-03 12:04:33', 'ZUbHN4OfTj3bojgWUl6PARz5PGUiX1h2', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10360', '15366696969', null, '0', '游客10360', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 12:05:02', '2018-04-03 12:05:02', 'zPpFhokT16CkI0kSzibaURD533klI4Oz', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10361', '18014785236', null, '0', '游客10361', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 12:05:31', '2018-04-03 14:17:35', '7zhLhFIzR261nxLJFy2ztNPSSmxQ5jmQ', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10362', '15811111111', null, '0', '游客10362', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 14:42:23', '2018-04-03 14:42:52', 'S1FkAeGQcEDKblsVXUIh2HnCOiPEkl4B', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10363', '15815649865', null, '0', '游客10363', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 14:43:57', '2018-04-03 14:43:57', 'T3EOxHqHP8gYcfcUtkYmPFEhaKYxDQNL', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10364', '15848961351', null, '0', '游客10364', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 14:44:09', '2018-04-03 14:44:52', 'bUYOGOO2Zebl4ws5XsphnFvWWEeOI3UP', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10365', '15615659979', null, '0', '游客10365', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 14:45:52', '2018-04-03 14:45:52', '2ocHRo25KXJ4iAnDgPJ2HmWSdi8fdipl', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10366', '13758757857', null, '0', '游客10366', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 14:46:02', '2018-04-03 14:46:02', 'g7hDmzvBwNreNP8kWNDpN5p4HaWhtywA', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10367', '13878587725', null, '0', '游客103671', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 14:46:11', '2018-04-03 16:18:54', 'V2xpmTnGwSRJi8mx7fnxbQUhVNlrJv8l', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10368', '13055656565', null, '0', '游客10368', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 15:38:13', '2018-04-03 15:38:13', '61IvrirdMkQluqR6Y1OrZF00wJYR1JfI', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10369', '13087678675', null, '0', '游客10369', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 15:40:56', '2018-04-03 17:13:22', 'jTein6OlPByYgE3whM57mJQuGpTACgop', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10370', '13014895418', null, '0', '游客有课有课有课', '', '未知', '0.0.0.0', '0.0.0.0', '20', '0', '2018-04-03 16:04:47', '2018-04-03 16:04:47', 'V7Zw5L9XDM2vvgszHPGXf9piaNSaex0U', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10371', '13057070785', null, '0', '游客10371', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-04 10:53:01', '2018-04-08 17:31:05', 'Nv1OlqfZQNVnti6H2TmYDiIUy5u9hkaW', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10372', '15377784575', null, '0', '游客10372', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-04 14:49:25', '2018-04-09 14:08:39', 'oGpW9HJbBOO2axVCYr5M8MOET7nwwk7C', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10373', '15200201012', null, '0', '游客10373', '', '广东省深圳市', '116.30.222.232', '116.30.222.232', '17', '0', '2018-04-04 16:18:47', '2018-04-04 17:30:26', 'ovCnhUwytsm0YetohoX3hqGkDD78mFpZ', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10374', '13043453453', null, '0', '游客10374', '', '广东省深圳市', '113.92.32.87', '113.92.32.87', '20', '0', '2018-04-08 10:31:44', '2018-04-25 10:50:21', 'dSyUCl6TUPHGP7Kn2ofUqyiudHGWHHjb', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10375', '13322112211', null, '0', '游客10375', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '20', '0', '2018-04-08 16:13:43', '2018-04-08 16:13:43', '8G3ueKqsCYSpLIoQ6h76kTvmdpgVmgvN', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10376', '13048541368', null, '0', '游客10376', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '20', '0', '2018-04-08 17:04:56', '2018-04-08 17:05:55', 'QOpoWum78C65pgRWCjT0i6s27sMZ8ziC', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10377', '13078578578', null, '0', '游客10377', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '20', '0', '2018-04-08 17:06:20', '2018-04-08 17:06:20', '9muX5iXNSdZABbJXnOuwyMErVXsj8raF', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10378', '13075678755', null, '0', '游客10378', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '20020', '0', '2018-04-08 17:06:28', '2018-04-08 17:08:14', 'O8DjNgYrib1xDUm4k2s9ZnBoOxj2EtDX', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10379', '13078678578', null, '0', '游客10379', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '17', '0', '2018-04-08 17:08:28', '2018-04-08 17:31:04', 'CQmgNVAoRI7KK7QighAvu1NlxKk6RTtP', '0', '0', null, '1', '0', '1');
INSERT INTO `t_user` VALUES ('10380', '13011111111', null, '0', '七称1', '', '广东省深圳市', null, '116.30.221.52', '2', '47', '2018-04-08 17:36:39', '2018-04-18 15:14:48', 'uFxniuBW2LRKKEtmn8v8Gyqyw9s5kM2t', '0', '0', null, '1', '0', '2');
INSERT INTO `t_user` VALUES ('10381', '13011111112', null, '0', '玩家昵称七个字', '', '广东省深圳市', null, '113.92.32.98', '20', '49', '2018-04-08 17:37:21', '2018-04-14 17:06:34', 'HBVluB2mpCKvFWDPFk61YVdslKQNEg6z', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10382', '13011111113', null, '0', '玩家名字七个字', '', '广东省深圳市', null, '113.92.34.173', '20', '21', '2018-04-09 09:50:20', '2018-04-10 18:03:02', 'p8qkxv5IhfOiSOuCGhzTishRIlCyn6Py', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10383', '15925145632', null, '0', '游客10383', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-09 12:25:30', '2018-04-09 12:29:06', '0YnRkWrsIBJMaPh4kGidqVhkj8CayqHw', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10384', '15230231452', null, '0', '游客10384', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '17', '0', '2018-04-09 14:09:05', '2018-04-10 09:57:28', 'KKzpkU0EfDdZTr9z6e8iLHmDRIgyRJyo', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10385', '18422635125', null, '0', '游客10385', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '20', '0', '2018-04-09 14:09:21', '2018-04-09 14:09:21', 'oPrJBdfpTP7VbOPQQxqJETbEr7kvgPLb', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10386', '15341998568', null, '0', '游客10386', '', '广东省深圳市', '113.92.32.4', '113.92.32.4', '20', '0', '2018-04-09 14:24:25', '2018-04-09 14:28:57', '0f3Jwh53Be4JAnq0zIpU5mU15Dh8Juoh', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10387', '15303030302', null, '0', '游客10387', '', '未知国家 未', '113.92.32.4', '113.92.32.4', '20', '0', '2018-04-09 14:35:05', '2018-04-09 14:35:16', 'TzfWoYrZXTF1zKcjRPWB9iK0QpW4OjhA', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10388', '15412332123', null, '0', '游客10388', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-09 14:36:05', '2018-04-09 14:36:43', 'cGbxZWMuKxXwUxhUUBa3vbKRQM539OR3', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10389', '15787878787', null, '0', '游客10389', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-09 14:37:07', '2018-04-09 14:41:19', '4eCeVwgaOjeD1wnkLf4lQqJa6FwxUtvy', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10390', '13623232323', null, '0', '干翻大B哥1', '', '广东省深圳市', null, '113.92.32.37', '19999835', '34', '2018-04-09 16:12:31', '2018-04-20 16:35:39', 'EmTmz85PHy2SP2sHJlh6mk47EdkbrCvQ', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10391', '13232323233', null, '0', '游客10391', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '18', '5', '2018-04-09 16:47:56', '2018-04-09 18:23:13', 'hQ85vZSHttDiGBV9LykyJJslyhf6tbdr', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10392', '13623231111', null, '0', '游客10392', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-09 16:53:10', '2018-04-09 16:53:10', 'daLrRvSP7leHyQzMePVUkz3K1hyNAwf5', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10393', '13523232323', null, '0', '游客10393', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-09 16:54:41', '2018-04-09 16:54:41', 'SbhnK9DdRjsRYpsev05ZQGnAUhbxC3yy', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10394', '15014215145', null, '0', '游客10394', '', '广东省深圳市', '116.30.223.125', '116.30.223.125', '20', '0', '2018-04-10 09:58:26', '2018-04-11 10:52:45', 'CwBB1Dgye2jW0pH90BUifxRQE4eJrFPU', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10395', '13654646464', null, '0', '游客10395', '', '广东省深圳市', '113.92.34.173', '113.92.34.173', '20', '0', '2018-04-10 15:40:23', '2018-04-10 16:31:37', 'H92k53wG8tLe7qtfWW1u4jnI3a08Gq7u', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10396', '13253203232', null, '0', '坤哥', '', '广东省深圳市', '116.30.222.189', '116.30.222.189', '20', '0', '2018-04-10 17:04:40', '2018-04-10 17:04:40', 'HHl0sPbHRwS4x0rBv3qAIyyjtJIJJwUC', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10397', '15347475698', null, '0', '游龙戏凤', '', '广东省深圳市', '116.30.222.189', '116.30.222.189', '20', '0', '2018-04-11 10:53:07', '2018-04-11 11:52:58', 'YFpfCBqCLp92YEmfxgIuL7rQ3KXVLRld', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10398', '13011111115', null, '0', '123', '', '广东省深圳市', null, '113.92.33.98', '20', '0', '2018-04-11 12:05:18', '2018-04-19 15:59:49', 'aXedydMXuUVNmrTzryPNYHA4N5yeG4rL', '0', '0', null, '1', '0', '1');
INSERT INTO `t_user` VALUES ('10399', '15869696666', null, '0', 'rtg', '', '广东省深圳市', '116.30.222.189', '116.30.222.189', '2', '23', '2018-04-11 15:47:21', '2018-04-12 09:54:49', 'lY4FThMgMZoOCVBMQ8gTcYBVA1qJDlx9', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10400', '15011111111', null, '0', '游客名字七个字111', '', '广东省深圳市', '116.30.222.189', '116.30.222.189', '20', '0', '2018-04-11 17:01:14', '2018-04-11 18:10:51', '9S8O6VohMf646CLkz5u8LYhv7Rj6bAYB', '0', '0', null, '1', '0', '0');
INSERT INTO `t_user` VALUES ('10401', '13869652696', null, '0', '游客10401', '', '广东省深圳市', '113.92.34.173', '113.92.34.173', '20', '23', '2018-04-12 09:55:18', '2018-04-12 09:55:18', 'M9GwAeWrmelsnPQFht3oyFxcqHPvpJC2', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10402', '13000000004', null, '0', '游客10402', '', '广东省深圳市', null, '116.30.221.153', '20', '0', '2018-04-12 11:49:41', '2018-04-13 10:13:47', 'k2TA7W62lwg22aOn7H7zIwsPARZO0WI9', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10403', '15499986633', null, '0', '游客10403', '', '广东省深圳市', '116.30.221.153', '116.30.221.153', '20', '0', '2018-04-12 16:42:43', '2018-04-12 17:29:38', '1e1Zeq58HG2hQzEKm5YCBCbdl6GUDs3C', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10404', '13242955998', null, '0', '游客10404', '', '未知地址', '113.92.32.216', '113.92.32.216', '20', '0', '2018-04-13 10:40:19', '2018-04-13 10:40:47', 'ltrwJJwvTDNEes79psSAd8O1hp3aeSJj', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10405', '13056323652', null, '0', '游客10405', '', '广东省深圳市', '113.92.32.216', '113.92.32.216', '20', '0', '2018-04-13 10:47:04', '2018-04-13 10:51:26', 'PJz3RtTXX8mYrKrnCP4zgAYuHQktxUtc', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10406', '18699999999', null, '0', '游客10406', '', '广东省深圳市', '113.92.32.216', '113.92.32.216', '20', '0', '2018-04-13 10:49:55', '2018-04-13 14:12:43', 'EKZ617DCp1HPKzLjLxrUwDODe9gdnnFH', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10407', '15055541112', null, '0', '游客10407', '', '广东省深圳市', '113.92.32.216', '113.92.32.216', '20', '0', '2018-04-13 10:50:33', '2018-04-13 10:50:33', 'fHAVN2jBgTeV0riF3yOwY1XXAle8Be9d', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10408', '13662646434', null, '0', '游客10408', '', '广东省深圳市', '113.92.32.216', '113.92.32.216', '20', '0', '2018-04-13 10:51:30', '2018-04-13 10:54:59', 'UC7uqGxoAzSFszkxzJ7SmTs4BWRFSq3S', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10409', '15200001200', null, '0', '游客10409', '', '广东省深圳市', '116.30.221.153', '116.30.221.153', '20', '0', '2018-04-13 17:52:45', '2018-04-14 11:14:34', 'mkamrSrOIK1PaubknLQi32DPPphX0hCw', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10410', '15962333333', null, '0', '游客10410', '', '广东省深圳市', '116.30.221.153', '116.30.221.153', '20', '0', '2018-04-13 17:53:16', '2018-04-13 17:53:16', 'OYHyMLn7PAEkFVEErOEBkAuHF2hEh2z9', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10411', '15321022222', null, '0', '游客10411', '', '广东省深圳市', '113.92.32.216', '113.92.32.216', '20', '0', '2018-04-14 11:16:55', '2018-04-14 11:16:55', 'goGCHkTpRp3isqHdULPdoycjdy9PPGk4', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10412', '13689985566', null, '0', '游客10412', '', '广东省深圳市', '116.30.221.153', '116.30.221.153', '20', '0', '2018-04-14 12:06:15', '2018-04-14 12:22:45', 'EasDyzENgMwJOnJzwShoaO45hcOTlifB', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10413', '13023699999', null, '0', '游客10413', '', '广东省深圳市', '116.30.221.153', '116.30.221.153', '20', '0', '2018-04-14 14:08:39', '2018-04-14 14:39:05', 'uq5Oa19PEZsEJ49pCDzkzdeGUvSWNLeo', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10414', '13203699999', null, '0', '游客10414', '', '广东省深圳市', '113.92.32.216', '113.92.32.216', '20', '0', '2018-04-14 14:40:15', '2018-04-14 14:59:25', 'cRqf6Xj8g1WnYghwDGyJslLqZ2aa9tBw', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10415', '18647854777', null, '0', '游客10415', '', '广东省深圳市', '113.92.32.98', '113.92.32.98', '20', '0', '2018-04-14 14:59:40', '2018-04-14 15:00:08', '0EQ5jnkVqQCi4M1GR9muRZwoCeupqRR0', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10416', '15333333333', null, '0', '游客10416', '', '广东省深圳市', '116.30.221.52', '116.30.221.52', '20', '0', '2018-04-14 16:33:30', '2018-04-14 16:33:30', 'NWsXaNSTVvs4ncb3WQZGTfhStSmbfjL6', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10417', '15302699999', null, '0', '大王叫', '', '广东省深圳市', '116.30.221.52', '116.30.221.52', '20', '0', '2018-04-16 11:11:11', '2018-04-16 15:32:12', 'wE0QuAGAmBrsWWAyGsuLFjHW4bOhMm2d', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10418', '15896337777', null, '0', '游客10418', '', '广东省深圳市', '113.92.32.98', '113.92.32.98', '20', '0', '2018-04-16 14:11:19', '2018-04-16 14:11:19', 'yqA4LXOXTcKzMkHc9FiYeukibFdyHfmC', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10419', '15230147889', null, '0', '游客10419', '', '广东省深圳市', '116.30.222.108', '116.30.222.108', '20', '10', '2018-04-19 10:41:14', '2018-04-19 11:37:44', 'ihAFthzOoRiWOMqVJlAbk9Uv7qrHaYns', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10420', '13594155555', null, '0', '游客10420', '', '广东省深圳市', '113.92.33.98', '113.92.33.98', '20', '0', '2018-04-19 15:47:32', '2018-04-19 15:54:07', 'APRnM4DNG0EosVYMO4NAqObRA0ZGpv3Y', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10421', '13855551111', null, '0', '游客10421', '', '广东省深圳市', null, '116.30.222.108', '20', '0', '2018-04-19 15:52:44', '2018-04-20 10:01:49', 'KT7e2qgvzRy6rbpJ3Z6y38KeFvsXZmJi', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10422', '13544119987', null, '0', '游客10422', '', '广东省深圳市', '113.92.33.98', '113.92.33.98', '20', '0', '2018-04-19 18:00:47', '2018-04-20 09:52:06', 'lyQwpDQncufBpMrUHrNeo9IvwnZLk3GP', '0', '0', null, '0', '0', '2');
INSERT INTO `t_user` VALUES ('10423', '15844444444', null, '0', '游客10423', '', '广东省深圳市', '113.92.33.98', '113.92.33.98', '20', '0', '2018-04-19 18:02:28', '2018-04-19 18:02:28', 'JgwWaiOhn40CNOnAaoG7pvcuSFqfEHK1', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10424', '15422222222', null, '0', '游客10424', '', '广东省深圳市', null, '116.30.223.134', '20', '0', '2018-04-23 10:04:15', '2018-04-23 10:17:06', 'BExAEt8esBaV7lRukno9ruXGNanGrhev', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10425', '15324699999', null, '0', '游客10425', '', '广东省深圳市', '116.30.223.239', '116.30.223.239', '20', '0', '2018-04-24 09:51:51', '2018-04-24 09:51:51', 'QxMQcrW7OjLezA1K5qk7bi1JcdX0kweL', '0', '0', null, '0', '0', '1');
INSERT INTO `t_user` VALUES ('10426', '15322411111', null, '0', '游客10426', '', '广东省深圳市', '113.92.34.148', '113.92.34.148', '17', '6', '2018-04-25 11:14:06', '2018-04-25 11:14:06', 'WSyGXXyxuqKJ3hiz0Eso90vTpIw9oD2U', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10427', '15244477777', null, '0', '游客10427', '', '广东省深圳市', '113.92.34.148', '113.92.34.148', '20', '6', '2018-04-25 11:14:25', '2018-04-25 11:14:25', 'EMtd2sE1rpiSvkMC8CIv6PUbI2WC56M4', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10428', '15666999999', null, '0', '游客10428', '', '广东省深圳市', '116.30.223.239', '116.30.223.239', '17', '3', '2018-04-25 11:32:17', '2018-04-25 11:32:17', 'FtWtFtxF4J7QrAL4B1R4YsoDnVQoRQec', '0', '0', '833528', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10429', '15588888888', null, '0', '游客10429', '', '广东省深圳市', '116.30.223.239', '116.30.223.239', '20', '3', '2018-04-25 11:32:29', '2018-04-25 11:32:29', 'YiYRESOCcv5HVHj4UCnFqGxtOOcctkqK', '0', '0', '833528', '0', '0', '0');
INSERT INTO `t_user` VALUES ('10430', '13477777777', null, '0', '游客10430', '', '广东省深圳市', '113.92.34.148', '113.92.34.148', '20', '2', '2018-04-25 11:52:28', '2018-04-25 11:52:28', 'xGlUo96uxPc3IikIxeiQTTin1DLN7CKn', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10431', '15996666666', null, '0', '游客10431', '', '广东省深圳市', '113.92.34.148', '113.92.34.148', '5', '4', '2018-04-25 12:08:45', '2018-04-25 12:08:45', 'DHKiIUfRR0xlbie2gj1C5KQe6fOhdxub', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10432', '15220000222', null, '0', '游客10432', '', '广东省深圳市', '113.92.34.148', '113.92.34.148', '20', '4', '2018-04-25 12:09:11', '2018-04-25 12:09:11', 'UEOMkWrky3bNEEeuyrz40zLqQksF4Qwo', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10433', '13011111114', null, '0', '游客10433', '', '广东省深圳市', '116.30.223.239', '116.30.223.239', '20', '0', '2018-04-25 17:38:41', '2018-04-25 17:38:41', 'M03qCzibRzhMPEflrD5M39hgnIrmSlcj', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10434', '15111111111', null, '0', '游客10434', '', '广东省深圳市', '113.92.32.221', '113.92.32.221', '8', '0', '2018-05-03 16:03:14', '2018-05-03 16:15:54', 'X5i8EXEBMBUUCFQQpGdawkpI4R4ttO7Z', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10435', '15477777777', null, '0', '游客10435', '', '广东省深圳市', '113.92.32.221', '113.92.32.221', '17', '0', '2018-05-03 16:03:24', '2018-05-03 16:36:52', 'M7geonJFWZOMGzEiHkOWmdOAEVn1hQi4', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10436', '15000000003', null, '0', '游客10436', '', '广东省深圳市', '113.92.32.221', '113.92.32.221', '14', '0', '2018-05-03 18:17:18', '2018-05-03 18:27:49', 'EknBhfyku1aqTN6G50fPB4SH8Zi9R7cu', '0', '0', null, '0', '0', '0');
INSERT INTO `t_user` VALUES ('10437', '15222222222', null, '0', '游客10437', '', '广东省深圳市', '113.92.32.221', '113.92.32.221', '14', '0', '2018-05-03 18:17:52', '2018-05-03 18:17:52', 'r9QD2TOzjzmjz2hxS9Z6F1fWY5Xw6SKg', '0', '0', null, '0', '0', '0');

-- ----------------------------
-- Procedure structure for `Pro_AddClud_daysum_diamond`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_AddClud_daysum_diamond`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_AddClud_daysum_diamond`()
begin
		declare _baseD bigint default 6;						#房主支付钻石的基数
		declare _AAD bigint default 2;						  #AA支付钻石的基数
		declare _clubId int default 0;
		declare _diamondSum bigint default 0;					#钻石总数

		declare _playSZ bigint default 0;					#牛牛上庄钻石总数
		declare _playGD bigint default 0;					#固定庄家钻石总数
		declare _playZY bigint default 0;					#自由抢庄钻石总数
		declare _playMP bigint default 0;					#明牌抢庄钻石总数
		declare _playTB bigint default 0;					#通比牛牛钻石总数
		declare _playLZ bigint default 0;				  #通比牛牛钻石总数

		declare _play10 bigint default 0;					#10局钻石总数
		declare _play20 bigint default 0;					#20局钻石总数

	 	#创建结束标志变量  
		declare done int default false;

		declare _startDate varchar(50) default CONCAT(DATE_SUB(DATE_SUB(CURDATE(),interval 0 day), interval 1 day),' 00:00:00');	#当前时间前一天 开始
		declare _endDate varchar(50) default CONCAT(DATE_SUB(CURDATE(), interval 1 day),' 23:59:59');		#当前时间前一天 结束

		#创建游标
 		declare cur cursor for SELECT clubId  from t_game_log where clubId > 0  and createTime between _startDate and _endDate  GROUP BY clubId;
	
		#指定游标循环结束时的返回值
		declare continue handler for not found set done = TRUE; 

		#打开游标  
		open cur;  
		#开始循环游标里的数据  
		read_loop:loop 
		#根据游标当前指向的一条数据  
		fetch cur into _clubId;
		if done then  
				leave read_loop;    #跳出游标循环  
		end if;  

				SELECT (count(*)* _baseD) into _diamondSum from t_game_log where clubId = _clubId AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playSZ from t_game_log where clubId = _clubId AND bankerMode =1 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playGD from t_game_log where clubId = _clubId AND bankerMode =2 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playZY from t_game_log where clubId = _clubId AND bankerMode =3 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playMP from t_game_log where clubId = _clubId AND bankerMode =4 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playTB from t_game_log where clubId = _clubId AND bankerMode =5 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _playLZ from t_game_log where clubId = _clubId AND bankerMode =6 AND createTime between _startDate and _endDate;

				SELECT (count(*)* _baseD) into _play10 from t_game_log where clubId = _clubId AND roundTotal =10 AND createTime between _startDate and _endDate;
				SELECT (count(*)* _baseD) into _play20 from t_game_log where clubId = _clubId AND roundTotal =20 AND createTime between _startDate and _endDate;


				#diamondType钻石类型:1消耗
				#type类别：1个人，2俱乐部
				INSERT INTO sys_daysum_diamond(type,typeId,diamond,diamondType,createTime,playSZ,playGD,playZY,playMP,playTB,playLZ,play10,play20)
				VALUES(1,_clubId,_diamondSum,1,_endDate,_playSZ,_playGD,_playZY,_playMP,_playTB,_playLZ,_play10,_play20);

		#结束游标循环  
		end loop;
		#关闭游标  
		close cur;





end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_AddOnlineTaurus`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_AddOnlineTaurus`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_AddOnlineTaurus`()
begin

insert into t_online_taurus (onlineCount,gameType,updateTime) VALUES((CEIL(RAND() * 51) + 99),1,NOW());

end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_AddStatisticsDayReport`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_AddStatisticsDayReport`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_AddStatisticsDayReport`()
begin

		declare _startdate varchar(19) default date_format(date_sub(curdate(),interval 1 day),'%Y-%m-%d 00:00:00');
		declare _enddate varchar(19) default date_format(date_sub(curdate(),interval 1 day),'%Y-%m-%d 23:59:59');
		declare _userNumber bigint default 0;  -- 有效人数
		declare _roomNumber bigint default 0;	-- 开房数
		declare _roundNumber bigint default 0; -- 开盘局数

		-- SELECT * from  t_statistics_day_report;

		-- 有效人数
		SELECT count(distinct(userid)) into _userNumber FROM (
			SELECT distinct player1 as userid  FROM t_game_round_log where updateTime between _startDate and _endDate
				union 
			SELECT distinct player2 as userid  FROM t_game_round_log where updateTime between _startDate and _endDate
				union 
			SELECT distinct player3 as userid  FROM t_game_round_log where updateTime between _startDate and _endDate
				union 
			SELECT distinct player4 as userid  FROM t_game_round_log where updateTime between _startDate and _endDate
				union 
			SELECT distinct player5 as userid  FROM t_game_round_log where updateTime between _startDate and _endDate
				union 
			SELECT distinct player6 as userid  FROM t_game_round_log where updateTime between _startDate and _endDate
		) as TB_gameUser;

		-- 开房数
		SELECT count(distinct(roomNum)) into _roomNumber FROM t_game_round_log where updateTime between _startDate and _endDate;
		-- 开盘局数
		SELECT count(distinct(roundIndex)) into _roundNumber FROM t_game_round_log where updateTime between _startDate and _endDate;

		INSERT INTO t_statistics_day_report (userNumber,roomNumber,roundNumber,createTime) VALUES (_userNumber,_roomNumber,_roundNumber,NOW());
	
end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_AddStatistics_newuser`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_AddStatistics_newuser`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_AddStatistics_newuser`()
begin

		declare _startdate varchar(19) default date_format(date_sub(curdate(),interval 1 day),'%Y-%m-%d 00:00:00');
		declare _enddate varchar(19) default date_format(date_sub(curdate(),interval 1 day),'%Y-%m-%d 23:59:59');
		declare _gametype bigint default 1;  -- 游戏类型：1牛牛
		declare _roomNumber bigint default 0;	-- 开房数
		declare _roundNumber bigint default 0; -- 开局数

		
		SELECT count(distinct(roomNum)) into _roomNumber FROM t_game_log where createTime  between _startDate and _endDate 
					 and roomOwnerId in (SELECT distinct(userId) FROM t_user where registerTime between _startDate and _endDate);

		
		SELECT count(distinct(roundIndex)) into _roundNumber from  t_game_round_log where updateTime between _startDate and _endDate
		 and ( 	 player1 in (SELECT distinct(userId) FROM t_user where registerTime between _startDate and _endDate) 
					or player2 in (SELECT distinct(userId) FROM t_user where registerTime between _startDate and _endDate) 
					or player3 in (SELECT distinct(userId) FROM t_user where registerTime between _startDate and _endDate) 
					or player4 in (SELECT distinct(userId) FROM t_user where registerTime between _startDate and _endDate) 
					or player5 in (SELECT distinct(userId) FROM t_user where registerTime between _startDate and _endDate) 
					or player6 in (SELECT distinct(userId) FROM t_user where registerTime between _startDate and _endDate) 
					);


	INSERT INTO t_statistics_newuserlog (gametype,roomNumber,roundNumber,createTime)VALUES (_gametype,_roomNumber,_roundNumber,NOW());
end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_AddUser`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_AddUser`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_AddUser`(
		/*
			创建人：刘晓博
			创建时间：2017-05-31
			功能描述：新增系统用户
			参数说明：（$UserName:用户名称，$UserPassWord:用户密码,$UserNickName:用户昵称，$UserType:用户类型,$RegistIP:注册IP,$Valid:用户状态,$NewId:新用户Id）
		*/
	in $UserName varchar(50),
	in $UserPassWord varchar(200),
	in $UserNickName varchar(50),
	in $UserType int,
	in $RegistIP varchar(50),
	in $Valid int,
	out $NewId int
)
begin 
		insert into sys_user(UserName,UserPassWord,UserNickName,UserType,RegistIP,Valid,CreateDate)
		values($UserName,$UserPassWord,$UserNickName,$UserType,$RegistIP,$Valid,NOW());
		set $NewId=@@identity;
end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_del_game_log`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_del_game_log`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Pro_del_game_log`()
BEGIN
delete from t_game_round_log where updateTime <= date_add(now(), interval -2 day); 
delete from t_game_log where updateTime <= date_add(now(), interval -2 day); 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_GetUserInfo`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_GetUserInfo`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_GetUserInfo`(
		/*
			创建人：刘晓博
			创建时间：2017-05-27
			功能描述：根据用户名称和密码获取管理员信息
			参数说明：（UName:用户名称，UPwd:用户密码）
		*/
		in UName varchar(20),
		in UPwd varchar(100)
)
begin  
		select * from sys_user where UserName=UName and UserPassWord=UPwd;
end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_GetUserInfoById`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_GetUserInfoById`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_GetUserInfoById`(
		/*
			创建人：刘晓博
			创建时间：2017-05-27
			功能描述：根据用户Id获取管理员信息
			参数说明：（UId:用户Id）
		*/
		in UId int
)
begin  
		select * from sys_user where Id=UId;
end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_UpdateUserLoginInfo`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_UpdateUserLoginInfo`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_UpdateUserLoginInfo`(
		/*
			创建人：刘晓博
			创建时间：2017-05-27
			功能描述：根据用户Id更新用户登录信息
			参数说明：（UId:用户Id，UIP:用户IP）
		*/
		in UId int,
		in UIP varchar(20)
)
begin  
		update sys_user set LoginDate=NOW(),LoginIP=UIP where Id=UId;
end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_UpdateUserPWd`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_UpdateUserPWd`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_UpdateUserPWd`(
		/*
			创建人：刘晓博
			创建时间：2017-05-27
			功能描述：根据用户Id更新密码
			参数说明：（UId:用户Id，PWd:用户密码）
		*/
		in UId int,
		in PWd varchar(100)
)
begin  
		update sys_user set ModifyDate=NOW(),UserPassWord=PWd where Id=UId;
end
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `Pro_UpdateUserValid`
-- ----------------------------
DROP PROCEDURE IF EXISTS `Pro_UpdateUserValid`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Pro_UpdateUserValid`(
		/*
			创建人：刘晓博
			创建时间：2017-05-27
			功能描述：根据用户Id更新状态
			参数说明：（UId:用户Id，VId:用户状态）
		*/
		in UId int,
		in VId int
)
begin  
		update sys_user set ModifyDate=NOW(),Valid=VId where Id=UId;
end
;;
DELIMITER ;

-- ----------------------------
-- Event structure for `ReportTable_Clud_daysum_diamond`
-- ----------------------------
DROP EVENT IF EXISTS `ReportTable_Clud_daysum_diamond`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` EVENT `ReportTable_Clud_daysum_diamond` ON SCHEDULE EVERY 1 DAY STARTS '2018-03-30 02:00:00' ON COMPLETION PRESERVE ENABLE DO begin
	call Pro_AddClud_daysum_diamond();
end
;;
DELIMITER ;

-- ----------------------------
-- Event structure for `ReportTable_VIP`
-- ----------------------------
DROP EVENT IF EXISTS `ReportTable_VIP`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` EVENT `ReportTable_VIP` ON SCHEDULE EVERY 1 DAY STARTS '2017-11-30 00:00:00' ON COMPLETION PRESERVE ENABLE COMMENT '删除两天之前的游戏记录、每天凌晨00:00执行' DO call Pro_del_game_log()
;;
DELIMITER ;
