-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: dtr_attendance
-- ------------------------------------------------------
-- Server version	5.7.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `attendance_raws`
--

DROP TABLE IF EXISTS `attendance_raws`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `attendance_raws` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bio_id` varchar(45) NOT NULL,
  `date_time` datetime NOT NULL,
  `employee_id` int(11) DEFAULT NULL,
  `is_processed` tinyint(1) NOT NULL,
  `att_sched_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=48 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_raws`
--

LOCK TABLES `attendance_raws` WRITE;
/*!40000 ALTER TABLE `attendance_raws` DISABLE KEYS */;
INSERT INTO `attendance_raws` VALUES (1,'1','2022-09-12 23:14:32',NULL,0,NULL),(2,'1','2022-09-12 23:14:33',NULL,0,NULL),(3,'1','2022-09-12 23:14:34',NULL,0,NULL),(4,'1','2022-09-12 23:14:35',NULL,0,NULL),(5,'1','2022-09-12 23:14:36',NULL,0,NULL),(6,'1','2022-09-12 23:14:37',NULL,0,NULL),(7,'1','2022-09-12 23:14:38',NULL,0,NULL),(8,'1','2022-09-12 23:14:39',NULL,0,NULL),(9,'1','2022-09-12 23:14:40',NULL,0,NULL),(10,'1','2022-09-12 23:14:41',NULL,0,NULL),(11,'1','2022-09-12 23:14:42',NULL,0,NULL),(12,'1','2022-09-12 23:14:43',NULL,0,NULL),(13,'1','2022-09-12 23:14:44',NULL,0,NULL),(14,'1','2022-09-12 23:14:45',NULL,0,NULL),(15,'1','2022-09-12 23:14:46',NULL,0,NULL),(16,'1','2022-09-12 23:14:47',NULL,0,NULL),(17,'1','2022-09-12 23:14:48',NULL,0,NULL),(18,'1','2022-09-12 23:14:49',NULL,0,NULL),(19,'1','2022-09-12 23:14:50',NULL,0,NULL),(20,'1','2022-09-12 23:14:51',NULL,0,NULL),(21,'1','2022-09-12 23:14:52',NULL,0,NULL),(22,'1','2022-09-12 23:14:53',NULL,0,NULL),(23,'1','2022-09-12 23:14:54',NULL,0,NULL),(24,'1','2022-09-12 23:14:55',NULL,0,NULL),(25,'1','2022-09-12 23:14:56',NULL,0,NULL),(26,'1','2022-09-12 23:14:57',NULL,0,NULL),(27,'1','2022-09-12 23:14:58',NULL,0,NULL),(28,'1','2022-09-12 23:14:59',NULL,0,NULL),(29,'1','2022-09-12 23:15:00',NULL,0,NULL),(30,'1','2022-09-12 23:15:01',NULL,0,NULL),(31,'1','2022-09-12 23:15:02',NULL,0,NULL),(32,'1','2022-09-12 23:15:03',NULL,0,NULL),(33,'1','2022-09-12 23:15:04',NULL,0,NULL),(34,'1','2022-09-12 23:15:05',NULL,0,NULL),(35,'1','2022-09-12 23:15:06',NULL,0,NULL),(36,'1','2022-09-12 23:15:07',NULL,0,NULL),(37,'1','2022-09-12 23:15:08',NULL,0,NULL),(38,'1','2022-09-12 23:15:09',NULL,0,NULL),(39,'1','2022-09-12 23:15:10',NULL,0,NULL),(40,'1','2022-09-12 23:15:11',NULL,0,NULL),(41,'1','2022-09-12 23:15:12',NULL,0,NULL),(42,'1','2022-09-12 23:15:13',NULL,0,NULL),(43,'1','2022-09-12 23:15:14',NULL,0,NULL),(44,'1','2022-09-12 23:15:15',NULL,0,NULL),(45,'1','2022-09-12 23:15:16',NULL,0,NULL),(46,'1','2022-09-12 23:15:17',NULL,0,NULL),(47,'1','2022-09-12 23:15:18',NULL,0,NULL);
/*!40000 ALTER TABLE `attendance_raws` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance_scheds`
--

DROP TABLE IF EXISTS `attendance_scheds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `attendance_scheds` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `am_in` time DEFAULT NULL,
  `am_out` time DEFAULT NULL,
  `pm_in` time DEFAULT NULL,
  `pm_out` time DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_scheds`
--

LOCK TABLES `attendance_scheds` WRITE;
/*!40000 ALTER TABLE `attendance_scheds` DISABLE KEYS */;
INSERT INTO `attendance_scheds` VALUES (1,'default','08:00:00','12:00:00','13:00:00','05:00:00'),(2,'0817','08:00:00','12:00:00','13:00:00','05:00:00'),(3,'2005','01:00:00','05:00:00','20:00:00','00:00:00');
/*!40000 ALTER TABLE `attendance_scheds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devices`
--

DROP TABLE IF EXISTS `devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devices` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `location` varchar(45) DEFAULT NULL,
  `ip_address` varchar(45) DEFAULT NULL,
  `port` int(11) DEFAULT NULL,
  `is_active` tinyint(1) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devices`
--

LOCK TABLES `devices` WRITE;
/*!40000 ALTER TABLE `devices` DISABLE KEYS */;
INSERT INTO `devices` VALUES (1,'Ground','Ground Floor','10.1.1.1',3306,0,'2022-09-11 19:39:27','2022-09-12 01:07:54',NULL),(2,'NewDevide','SecondFloor','1234',4370,1,'2022-09-12 00:27:19','2022-09-12 01:07:58',NULL),(3,'Ground2','Near CR','10110101',4370,1,'2022-09-12 00:28:34',NULL,'2022-09-12 01:07:41');
/*!40000 ALTER TABLE `devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dtr_days`
--

DROP TABLE IF EXISTS `dtr_days`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dtr_days` (
  `day_no` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`day_no`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dtr_days`
--

LOCK TABLES `dtr_days` WRITE;
/*!40000 ALTER TABLE `dtr_days` DISABLE KEYS */;
/*!40000 ALTER TABLE `dtr_days` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dtr_records`
--

DROP TABLE IF EXISTS `dtr_records`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dtr_records` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `am_in` varchar(10) DEFAULT NULL,
  `am_out` varchar(10) DEFAULT NULL,
  `pm_in` varchar(10) DEFAULT NULL,
  `pm_out` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dtr_records`
--

LOCK TABLES `dtr_records` WRITE;
/*!40000 ALTER TABLE `dtr_records` DISABLE KEYS */;
/*!40000 ALTER TABLE `dtr_records` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee_scheds`
--

DROP TABLE IF EXISTS `employee_scheds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee_scheds` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_id` int(11) NOT NULL,
  `schedule_id` int(11) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee_scheds`
--

LOCK TABLES `employee_scheds` WRITE;
/*!40000 ALTER TABLE `employee_scheds` DISABLE KEYS */;
/*!40000 ALTER TABLE `employee_scheds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_id` varchar(45) DEFAULT NULL,
  `bio_id` varchar(45) NOT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `middle_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `hired_date` varchar(45) DEFAULT NULL,
  `is_active` tinyint(1) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `bio_id_UNIQUE` (`bio_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'p1000168','500038','JOSEPH','DINOY','AGUILAR','',1,'2022-09-11 21:28:17',NULL,NULL);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dtr_attendance'
--
/*!50106 SET @save_time_zone= @@TIME_ZONE */ ;
/*!50106 DROP EVENT IF EXISTS `EVT_ATT_RAW_PROCESS` */;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = latin1 */ ;;
/*!50003 SET character_set_results = latin1 */ ;;
/*!50003 SET collation_connection  = latin1_swedish_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `EVT_ATT_RAW_PROCESS` ON SCHEDULE EVERY 1 SECOND STARTS '2022-09-13 00:25:14' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
		/*
        DECLARE v INTEGER;
        DECLARE CONTINUE HANDLER FOR SQLEXCEPTION BEGIN END;

        SET v = 0;

        WHILE v < 5 DO
          INSERT INTO t1 VALUES (0);
          UPDATE t2 SET s1 = s1 + 1;
          SET v = v + 1;
        END WHILE;
        */
        #INSERT INTO dtr_attendance.attendance_raws(bio_id,date_time, is_processed) VALUES(1, NOW(),0);
END */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
DELIMITER ;
/*!50106 SET TIME_ZONE= @save_time_zone */ ;

--
-- Dumping routines for database 'dtr_attendance'
--
/*!50003 DROP PROCEDURE IF EXISTS `spAttendanceRawsCommand` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAttendanceRawsCommand`(_ControllerName VARCHAR(255), _LoginID INT, _Json LONGTEXT, _CommandType VARCHAR(20))
BEGIN
	
    
    DROP EVENT IF EXISTS EVT_ATT_RAW_PROCESS;


	#LOOP HERE
	#INSERT INTO attendance_raws if not exists
    
    
    
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-13  6:28:37
