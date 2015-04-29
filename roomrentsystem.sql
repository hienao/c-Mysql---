-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 2015-04-18 07:04:43
-- 服务器版本： 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `roomrentsystem`
--

-- --------------------------------------------------------

--
-- 表的结构 `billsinf`
--

CREATE TABLE IF NOT EXISTS `billsinf` (
  `danhao` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `roomnum` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `predianbiao` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `dianbiao` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `preshuibiao` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `shuibiao` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `jine` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`danhao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- 转存表中的数据 `billsinf`
--

INSERT INTO `billsinf` (`danhao`, `roomnum`, `predianbiao`, `dianbiao`, `preshuibiao`, `shuibiao`, `jine`) VALUES
('1', '0001', '2', '8', '3', '6', '30'),
('2', '0001', '2', '4', '3', '9', '30'),
('3', 'E00001', '2', '4', '3', '9', '30');

-- --------------------------------------------------------

--
-- 表的结构 `caiwu`
--

CREATE TABLE IF NOT EXISTS `caiwu` (
  `bianhao` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `leixing` varchar(2) COLLATE utf8_unicode_ci NOT NULL,
  `jine` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `date` varchar(12) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`bianhao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- 转存表中的数据 `caiwu`
--

INSERT INTO `caiwu` (`bianhao`, `leixing`, `jine`, `date`) VALUES
('1', '收入', '1', '2015年4月18日'),
('2', '支出', '2', '2015年4月18日'),
('3', '收入', '3', '2015年4月18日'),
('4', '收入', '4', '2015年4月18日'),
('5', '支出', '10', '2015年4月23日');

-- --------------------------------------------------------

--
-- 表的结构 `manageruser`
--

CREATE TABLE IF NOT EXISTS `manageruser` (
  `user` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- 转存表中的数据 `manageruser`
--

INSERT INTO `manageruser` (`user`, `password`) VALUES
('111', '111'),
('admin', 'admin'),
('shiwentao', '123456'),
('test', '456'),
('test1', '123');

-- --------------------------------------------------------

--
-- 表的结构 `othersetting`
--

CREATE TABLE IF NOT EXISTS `othersetting` (
  `bianhao` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `shuiprice` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `dianprice` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `wangprice` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `wuyeprice` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `yue` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`bianhao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- 转存表中的数据 `othersetting`
--

INSERT INTO `othersetting` (`bianhao`, `shuiprice`, `dianprice`, `wangprice`, `wuyeprice`, `yue`) VALUES
('1', '4', '3', '100', '30', '1000');

-- --------------------------------------------------------

--
-- 表的结构 `roominf`
--

CREATE TABLE IF NOT EXISTS `roominf` (
  `num` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `weizhi` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `mingzi` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `zhonglei` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `mianji` varchar(11) COLLATE utf8_unicode_ci NOT NULL,
  `zhuangxiu` varchar(4) COLLATE utf8_unicode_ci NOT NULL,
  `sheshi` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `yongtu` varchar(4) COLLATE utf8_unicode_ci NOT NULL,
  `jiage` varchar(11) COLLATE utf8_unicode_ci NOT NULL,
  `zhuangtai` varchar(4) COLLATE utf8_unicode_ci NOT NULL,
  `beizhu` varchar(40) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- 转存表中的数据 `roominf`
--

INSERT INTO `roominf` (`num`, `weizhi`, `mingzi`, `zhonglei`, `mianji`, `zhuangxiu`, `sheshi`, `yongtu`, `jiage`, `zhuangtai`, `beizhu`) VALUES
('0001', '112', '111', '111', '111', '一般', '111', '住宿', '11', '已租', '111'),
('0002', '2', '2', '2', '2', '精', '2', '商用', '2', '未租', '22'),
('E00001', '西青区', '学生公寓24号楼', '一室', '10', '简', '风扇', '住宿', '1000', '已租', '无');

-- --------------------------------------------------------

--
-- 表的结构 `roomrent`
--

CREATE TABLE IF NOT EXISTS `roomrent` (
  `roomnum` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `sfznum` varchar(18) COLLATE utf8_unicode_ci NOT NULL,
  `starttime` varchar(12) COLLATE utf8_unicode_ci NOT NULL,
  `monthnum` varchar(4) COLLATE utf8_unicode_ci NOT NULL,
  `monthlyrent` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`roomnum`,`sfznum`),
  KEY `userinfyueshu` (`sfznum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- 转存表中的数据 `roomrent`
--

INSERT INTO `roomrent` (`roomnum`, `sfznum`, `starttime`, `monthnum`, `monthlyrent`) VALUES
('0002', '412724199210165830', '2015年4月17日', '1', '1');

-- --------------------------------------------------------

--
-- 表的结构 `userinf`
--

CREATE TABLE IF NOT EXISTS `userinf` (
  `sfzid` varchar(18) COLLATE utf8_unicode_ci NOT NULL,
  `username` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `xingbie` varchar(2) COLLATE utf8_unicode_ci NOT NULL,
  `dianhua` varchar(14) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`sfzid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- 转存表中的数据 `userinf`
--

INSERT INTO `userinf` (`sfzid`, `username`, `xingbie`, `dianhua`) VALUES
('412724199210164848', '王2', '女', '13820342676'),
('412724199210165830', '时文涛', '男', '13820355787'),
('412724199415184646', 'q1', '男', '13424214124');

--
-- 限制导出的表
--

--
-- 限制表 `roomrent`
--
ALTER TABLE `roomrent`
  ADD CONSTRAINT `roominfyueshu` FOREIGN KEY (`roomnum`) REFERENCES `roominf` (`num`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `userinfyueshu` FOREIGN KEY (`sfznum`) REFERENCES `userinf` (`sfzid`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
