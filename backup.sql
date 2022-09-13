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
) ENGINE=MyISAM AUTO_INCREMENT=53 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_raws`
--

LOCK TABLES `attendance_raws` WRITE;
/*!40000 ALTER TABLE `attendance_raws` DISABLE KEYS */;
INSERT INTO `attendance_raws` VALUES (1,'500038','2022-09-12 23:14:32',1,1,1),(52,'500038','2022-09-12 23:14:36',1,1,3),(51,'2215','2022-09-12 23:14:32',4,1,1),(50,'2215','2022-09-12 23:14:32',4,1,1),(49,'2214','2022-09-12 23:14:32',3,1,1),(48,'2213','2022-09-12 23:14:32',2,1,1);
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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
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
INSERT INTO `devices` VALUES (1,'Ground','Ground Floor','10.1.1.1',3306,1,'2022-09-11 19:39:27','2022-09-13 19:27:08',NULL),(2,'NewDevide','SecondFloor','1234',4370,1,'2022-09-12 00:27:19','2022-09-12 01:07:58',NULL),(3,'Ground2','Near CR','10110101',4370,1,'2022-09-12 00:28:34',NULL,'2022-09-12 01:07:41');
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
) ENGINE=MyISAM AUTO_INCREMENT=76 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dtr_days`
--

LOCK TABLES `dtr_days` WRITE;
/*!40000 ALTER TABLE `dtr_days` DISABLE KEYS */;
INSERT INTO `dtr_days` VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(19),(20),(21),(22),(23),(24),(25),(26),(27),(28),(29),(30),(31);
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
  PRIMARY KEY (`id`),
  UNIQUE KEY `Unique_emp_date` (`employee_id`,`date`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dtr_records`
--

LOCK TABLES `dtr_records` WRITE;
/*!40000 ALTER TABLE `dtr_records` DISABLE KEYS */;
INSERT INTO `dtr_records` VALUES (2,1,'2022-09-12','23:14:36',NULL,NULL,NULL),(3,2,'2022-09-12','23:14:36',NULL,NULL,NULL),(4,3,'2022-09-12','23:14:32',NULL,NULL,NULL),(5,4,'2022-09-12','23:14:32',NULL,NULL,NULL);
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
  `att_sched_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `bio_id_UNIQUE` (`bio_id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'p1000168','500038','JOSEPH','DINOY','AGUILAR','',1,'2022-09-11 21:28:17',NULL,NULL,3),(2,' ','2213','','','','',1,'2022-09-13 23:32:19',NULL,NULL,1),(3,' ','2214','','','','',1,'2022-09-13 23:34:16',NULL,NULL,1),(4,'','2215','','','','',1,'2022-09-13 23:42:31',NULL,NULL,1);
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
/*!50003 SET character_set_client  = utf8mb4 */ ;;
/*!50003 SET character_set_results = utf8mb4 */ ;;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `EVT_ATT_RAW_PROCESS` ON SCHEDULE EVERY 1 SECOND STARTS '2022-09-14 06:09:48' ON COMPLETION NOT PRESERVE DISABLE DO BEGIN
     CALL spEVT_ATT_RAW_PROCESS();
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
/*!50003 DROP FUNCTION IF EXISTS `checkDTR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `checkDTR`(_EmpID INT, _DateTime DATETIME, _AttSchedID INT ) RETURNS varchar(20) CHARSET latin1
BEGIN
	#AM-IN
    #AM-OUT
    #PM-IN
    #PM-OUT
RETURN 'AM-IN';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
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
/*!50003 DROP PROCEDURE IF EXISTS `spEVT_ATT_RAW_PROCESS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEVT_ATT_RAW_PROCESS`()
EVENT_LEAVE:
BEGIN

		DECLARE _BioID VARCHAR(50);
        DECLARE _RawID INT;
        DECLARE _DateTime DATETIME;
        
        #EMPLOYEE
        DECLARE _EmpID INT;
        DECLARE _CheckDTR VARCHAR(20);
        DECLARE _AttSchedID INT;
        
        
        #DTR DATE
        DECLARE _DtrDateID INT;
        
        
        SELECT  id, bio_id, date_time, employee_id INTO  _RawID, _BioID, _DateTime, _EmpID FROM attendance_raws WHERE is_processed = 0 order by date_time ASC;
		IF(_RawID IS NULL)THEN
			IF EXISTS(SELECT * FROM information_schema.EVENTS WHERE EVENT_NAME='EVT_ATT_RAW_PROCESS' AND EVENT_SCHEMA='dtr_attendance')THEN
				ALTER EVENT EVT_ATT_RAW_PROCESS DISABLE;
            END IF;
			LEAVE EVENT_LEAVE;
        END IF;
        
        SELECT IFNULL(_EmpID, id), IFNULL(att_sched_id,1)  INTO _EmpID, _AttSchedID FROM employees WHERE bio_id = _BioID;
        
        IF(_EmpID IS NULL)THEN
			#CREATE EMPTY EMPLOYEE
            INSERT INTO employees(bio_id, att_sched_id, is_active, employee_id, first_name, middle_name, last_name, hired_date, created_at)
				VALUES(_BioID, 1, 1,'', '', '', '', '', NOW() );
            SET _EmpID = last_insert_id();
            SET _AttSchedID = 1;
        END IF;
        
        
        UPDATE attendance_raws SET is_processed = 1, employee_id=_EmpID, att_sched_id = _AttSchedID WHERE id = _RawID;
        
        SET _CheckDTR = checkDTR(_EmpID, _DateTime);
        
        #ADDING LOGIN DATE IF NOT EXISTS
        SELECT id INTO _DtrDateID FROM dtr_records WHERE employee_id = _EmpID AND DATE(`date`) = DATE(_DateTime);
        IF(_DtrDateID IS NULL)THEN
			INSERT INTO dtr_records(employee_id, `date`) VALUES(_EmpID, DATE(_DateTime));
            SET _DtrDateID = last_insert_id();
        END IF;
        
        IF(_CheckDTR = 'AM-IN')THEN
			UPDATE dtr_records SET am_in = TIME(_DateTime) WHERE id = _DtrDateID;
        ELSEIF(_CheckDTR='AM-OUT')THEN
			UPDATE dtr_records SET am_out = TIME(_DateTime) WHERE id = _DtrDateID;        
        ELSEIF(_CheckDTR='PM-IN')THEN
			UPDATE dtr_records SET pm_in = TIME(_DateTime) WHERE id = _DtrDateID;        
        ELSEIF(_CheckDTR='PM-OUT')THEN
			UPDATE dtr_records SET pm_out = TIME(_DateTime) WHERE id = _DtrDateID;        
        END IF;

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

-- Dump completed on 2022-09-14  6:13:38
