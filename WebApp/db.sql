CREATE DATABASE  IF NOT EXISTS `demo` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `demo`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: demo
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `apiinsight`
--

DROP TABLE IF EXISTS `apiinsight`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `apiinsight` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `start` datetime DEFAULT NULL,
  `time` int(11) DEFAULT NULL,
  `application` varchar(200) DEFAULT NULL,
  `method` varchar(10) DEFAULT NULL,
  `protocol` varchar(10) DEFAULT NULL,
  `host` varchar(100) DEFAULT NULL,
  `port` int(11) DEFAULT NULL,
  `path` varchar(1000) DEFAULT NULL,
  `query` varchar(1000) DEFAULT NULL,
  `httpstatus` varchar(45) DEFAULT NULL,
  `authenticate` varchar(1000) DEFAULT NULL,
  `clientip` varchar(20) DEFAULT NULL,
  `serverip` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apiinsight`
--

LOCK TABLES `apiinsight` WRITE;
/*!40000 ALTER TABLE `apiinsight` DISABLE KEYS */;
INSERT INTO `apiinsight` VALUES (1,'2018-05-23 16:47:15',370,'WebApp','GET','HTTP/1.1','localhost',3364,'/favicon.ico','','200','','::1','::1'),(2,'2018-05-23 16:47:41',6771,'WebApp','GET','HTTP/1.1','localhost',3364,'/favicon.ico','','200','','::1','::1'),(3,'2018-05-23 16:47:47',2627,'WebApp','GET','HTTP/1.1','localhost',3364,'/pet','','200','','::1','::1');
/*!40000 ALTER TABLE `apiinsight` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `application` varchar(50) DEFAULT NULL,
  `logged` datetime DEFAULT NULL,
  `level` varchar(50) DEFAULT NULL,
  `message` varchar(8000) DEFAULT NULL,
  `logger` varchar(250) DEFAULT NULL,
  `callsite` varchar(512) DEFAULT NULL,
  `exception` varchar(8000) DEFAULT NULL,
  `ip` varchar(512) DEFAULT NULL,
  `user` varchar(512) DEFAULT NULL,
  `servername` varchar(512) DEFAULT NULL,
  `url` varchar(3000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
INSERT INTO `log` VALUES (1,'WebApp','2018-05-23 16:47:48','Info','information','WebApp.Controllers.PetController','WebApp.Controllers.PetController.Get(C:\\dotnetcore framework\\cheers\\WebApp\\Controllers\\PetController.cs:27)','','::1','','','localhost:3364/pet'),(2,'WebApp','2018-05-23 16:47:48','Fatal','critical','WebApp.Controllers.PetController','WebApp.Controllers.PetController.Get(C:\\dotnetcore framework\\cheers\\WebApp\\Controllers\\PetController.cs:30)','','::1','','','localhost:3364/pet'),(3,'WebApp','2018-05-23 16:47:48','Warn','warning','WebApp.Controllers.PetController','WebApp.Controllers.PetController.Get(C:\\dotnetcore framework\\cheers\\WebApp\\Controllers\\PetController.cs:31)','','::1','','','localhost:3364/pet'),(4,'WebApp','2018-05-23 16:47:48','Error','error','WebApp.Controllers.PetController','WebApp.Controllers.PetController.Get(C:\\dotnetcore framework\\cheers\\WebApp\\Controllers\\PetController.cs:32)','','::1','','','localhost:3364/pet');
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-23 18:05:53
