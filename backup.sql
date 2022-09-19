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
  `check_dtr_id` int(11) DEFAULT NULL,
  `device_id` int(11) DEFAULT NULL,
  `is_manual` int(11) DEFAULT NULL,
  `in_out` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=76 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_raws`
--

LOCK TABLES `attendance_raws` WRITE;
/*!40000 ALTER TABLE `attendance_raws` DISABLE KEYS */;
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
  `am_in` time NOT NULL,
  `am_out` time NOT NULL,
  `pm_in` time NOT NULL,
  `pm_out` time NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_scheds`
--

LOCK TABLES `attendance_scheds` WRITE;
/*!40000 ALTER TABLE `attendance_scheds` DISABLE KEYS */;
INSERT INTO `attendance_scheds` VALUES (1,'default','08:00:00','12:00:00','13:00:00','17:00:00',NULL,NULL,NULL);
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
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dtr_records`
--

LOCK TABLES `dtr_records` WRITE;
/*!40000 ALTER TABLE `dtr_records` DISABLE KEYS */;
INSERT INTO `dtr_records` VALUES (2,1,'2022-09-12',NULL,NULL,'23:14:32','23:14:35'),(3,2,'2022-09-12','23:14:32',NULL,'23:14:32',NULL),(4,3,'2022-09-12','23:14:32',NULL,NULL,NULL),(5,4,'2022-09-12','23:14:32','23:14:32',NULL,NULL),(6,0,'2022-09-12','23:14:32',NULL,NULL,NULL),(7,1,'2022-09-13',NULL,NULL,'12:45:00',NULL),(8,2,'2022-09-13',NULL,NULL,'12:45:00','16:45:00'),(9,5,'2022-01-01',NULL,NULL,NULL,NULL),(10,6,'2022-01-01',NULL,NULL,NULL,NULL),(11,1,'2022-09-01','00:00:00',NULL,NULL,NULL);
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
) ENGINE=MyISAM AUTO_INCREMENT=230 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (10,'070967106','070967106','Christina','','Cuevas','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(8,'4107372','4107372','Norgelito','P','Sitoy','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(9,'403725','403725','Glenn','B','Tomaquin','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(7,'26820','26820','Ferdinand','A','Delos Reyes','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(11,'101178125','101178125','Bryan','C','Sinugbuhan','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(12,'121158171','121158171','Godofreda','S','Muit','2013-4-5',1,'2022-09-19 11:08:20',NULL,NULL,1),(13,'130470186','130470186','Nicolas','','Entrena','2014-2-11',1,'2022-09-19 11:08:20',NULL,NULL,1),(14,'80075843','80075843','Franquilina','T','Sampiano','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(15,'84075833','84075833','Necita','T','Limpangog','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(16,'2037571','2037571','Henry','W','Rapada','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(17,'88045818','88045818','Cornelia','I','Casquejo','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(18,'8801585','8801585','Nilo','B','Sumalinog','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(19,'880759','880759','Judith','B','Delos Reyes','2012-3-3',1,'2022-09-19 11:08:20',NULL,NULL,1),(20,'88126064','88126064','Carlita','A','Yburan','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(21,'89036154','89036154','Juditha','C','Tajanlangit','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(22,'101277105','101277105','Gresham','B','Aro','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(23,'90990107','90990107','Claire','A','Jumao-as','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(24,'92115963','92115963','Evilla','A','Wahing','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(25,'93036904','93036904','Josefina','S','Atoc','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(26,'93055911','93055911','Ronilo','M','Baguio','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(27,'94076230','94076230','Santiago Jr.','C','Jumao-as','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(28,'95076356','95076356','Julieta','G','Tampus','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(29,'97066152','97066152','Paulo','F','Tagsip','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(30,'97097044','97097044','Soripo','B','Singculan','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(31,'97116312','97116312','Grace','T','Berdon','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(32,'98017232','98017232','Rizalito','L','Ligan','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(33,'98047215','98047215','Arlene','P','Cabiso','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(34,'90763104','90763104','Joel','P','Baguio','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(35,'98087805','98087805','Alexander','D','Ator','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(36,'99086314','99086314','Roqueta','S','Caballes','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(37,'99097806','99097806','Leonides','A','Ator','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(38,'99116350','99116350','Nazario Jr.','P','Sumalinog','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(39,'2057247','2057247','Jaime','E','Sumagang','2013-1-7',1,'2022-09-19 11:08:20',NULL,NULL,1),(40,'90772103','90772103','Beverlito','G','Rizando','2013-1-7',1,'2022-09-19 11:08:20',NULL,NULL,1),(41,'91162124','91162124','Carlito Jeffrey','L','Yburan','2013-1-7',1,'2022-09-19 11:08:20',NULL,NULL,1),(42,'121081150','121081150','Marjorie','D','Orque','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(43,'120365153','120365153','Ma. Rebecca','B','Tajanlangit','2013-1-7',1,'2022-09-19 11:08:20',NULL,NULL,1),(44,'110377141','110377141','Joan','T','Degamo','2013-1-7',1,'2022-09-19 11:08:20',NULL,NULL,1),(45,'110680139','110680139','Melody Jane','W','Wahing','2013-1-7',1,'2022-09-19 11:08:20',NULL,NULL,1),(46,'6098377','6098377','Melody Joy','T','Arasan','2013-1-7',1,'2022-09-19 11:08:20',NULL,NULL,1),(47,'7047178','7047178','Isidro','S','Encallado','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(48,'130173175','130173175','Wyrlie','','Pacaldo','2013-4-5',1,'2022-09-19 11:08:20',NULL,NULL,1),(49,'70967101','70967101','Evangeline','L','Nuñez','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(50,'130363179','130363179','Victor Nilo','F','Coronel','2013-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(51,'140287191','140287191','Teresita','R','Pacaldo','2014-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(52,'131275185','131275185','Margie','C','Potot','2015-12-21',1,'2022-09-19 11:08:20',NULL,NULL,1),(53,'141274197','141274197','Mildred','R','Uy','2014-10-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(54,'89126101','89126101','Agnes','E','Arado','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(55,'4055867','4055867','Raul','N','Baguio','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(56,'5097310','5097310','Nancy','B','Baguio','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(57,'3067213','3067213','Jean','D','Bolaño','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(58,'3036717','3036717','Maria Venus','P','Cañaveral','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(59,'140196195','140196195','Camille Dimple','S','Go','2014-10-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(60,'90076123','90076123','Procesa Lilian','M','Guanzon','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(61,'110887134','110887134','Bigildis','L','Formentera','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(62,'117255','117255','Elgie','T','Tampus','2012-11-29',1,'2022-09-19 11:08:20',NULL,NULL,1),(63,'141089201','141089201','Perlito Jr.','B','Mahinay ','2015-2-3',1,'2022-09-19 11:08:20',NULL,NULL,1),(64,'150674203','150674203','Rowena','Z','Villanueva','2015-6-22',1,'2022-09-19 11:08:20',NULL,NULL,1),(65,'150492207','150492207','Merry Roshal','C','Auguis','2015-10-19',1,'2022-09-19 11:08:20',NULL,NULL,1),(66,'151075208','151075208','Wilson Jr.','J','Zafra','2015-10-19',1,'2022-09-19 11:08:20',NULL,NULL,1),(67,'88075902','88075902','Eduardo','','Aro','2015-12-21',1,'2022-09-19 11:08:20',NULL,NULL,1),(68,'211187471','211187471','Fatima','A','Pogoy','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(69,'201187468','201187468','Romeo','H','Pedere','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(70,'200596467','200596467','Ivamay','D','Bacalla','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(71,'200589466','200589466','Josie Marie','T','Bongcac','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(72,'200793465','200793465','Ryan','Y','Pagobo','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(73,'201079461','201079461','Jenny','G','Escoreal','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(74,'201071428','201071428','Randy','A','Tamala','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(75,'151167238','151167238','Arnold','E','Inoc','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(76,'170874295','170874295','Ronel','','Justol','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(77,'170882308','170882308','Ronald','A','Sanchez','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(78,'171266247','171266247','Rolando','D','Menguito','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(79,'18096','18096','Cresenciano','M','Inoc','-1-',1,'2022-09-19 11:08:20',NULL,NULL,1),(80,'160381245','160381245','Mario','I','Pogoy','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(81,'304347','304347','Guillerma','T','Gequillo','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(82,'62418','62418','Edgar','T','Jumao-as','-1-',1,'2022-09-19 11:08:20',NULL,NULL,1),(83,'190591391','190591391','Billy Jun','M','Baguio','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(84,'190386390','190386390','Rame','B','Turrefel','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(85,'190688416','190688416','Mary May','J','Ligan','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(86,'170176310','170176310','Geniebeth','S','Nuñez','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(87,'191190414','191190414','Jerry','G','Toñacao','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(88,'170691276','170691276','Charrise','E','Cabahug','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(89,'191097404','191097404','Nova Leah','F','Carbon','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(90,'191277402','191277402','Cenin Jr.','C','Esplana ','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(91,'190390401','190390401','Mark Robin','M','Pangatungan','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(92,'191298396','191298396','Christian','B','Escabas','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(93,'191192387','191192387','Mireille','M','Ramos','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(94,'170696298','170696298','Juanillo','','Nocena','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(95,'170178299','170178299','Eduardo','T','Macabudbud','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(96,'180380370','180380370','Jill Marie','J','Amores','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(97,'181193365','181193365','Matt Venzeill','G','Manayon','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(98,'180397354','180397354','Nessa','L','Orbeta','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(99,'120571148','120571148','Mario Rowel','O','Sinculan','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(100,'180587351','180587351','Reymond','A','Potolen','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(101,'170193309','170193309','Ivy Cholin','P','Sumagang','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(102,'171072335','171072335','Juliet','I','Monter','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(103,'170882348','170882348','Vicente Jr.','B','Sumalinog ','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(104,'171293336','171293336','Rogelio Jr.','','Tajanlangit','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(105,'170297337','170297337','Angel','S','Inting','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(106,'170779326','170779326','Jefferson','Y','Restauro','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(107,'170669325','170669325','Antonio','B','Salonoy','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(108,'170995315','170995315','Ritchie','T','Baguio','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(109,'170881311','170881311','Efren Jr.','B','Dico','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(110,'160778217','160778217','Pedro','A','Balansag','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(111,'161265222','161265222','Fe','R','Tiro','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(112,'160195226','160195226','Johnrel','A','Ngojo','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(113,'170362262','170362262','Lauron','N','Baguio','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(114,'160286254','160286254','Julian Randreiu','P','Legas','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(115,'131082193','131082193','Melanie','S','Degamo','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(116,'130178178','130178178','Randy','D','Marturillas','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(117,'121069156','121069156','Hellardo','M','Escabas','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(118,'160862212','160862212','Rogelio','P','Tajanlangit','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(119,'130488173','130488173','Ric','D','Barong','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(120,'160980210','160980210','Vincent','R','Benitez','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(121,'161292214','161292214','Dexter Jay','D','Crisostomo','2020-1-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(122,'210762489','210762489','Generosa','T','Urot','2020-12-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(123,'210357496','210357496','Braulio','P','Baguio','2020-12-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(124,'210961491','210961491','Florentina','T','Miano','2020-12-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(125,'210183501','210183501','Ronald','D','Marturillas','2020-12-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(126,'210383502','210383502','Naomi','M','Inoc','2020-12-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(127,'211196505','211196505','Hannah Jane','T','Tumulak','2020-12-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(128,'221282551','221282551','Mary Grace','M','Wiggill','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(129,'220568552','220568552','Alfred','B','Tajanlangit','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(130,'220755553','220755553','Nenet','C','Trasmil','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(131,'220877554','220877554','Quenie','C','Amodia','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(132,'221193556','221193556','Evangeline','T','Flores','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(133,'220577557','220577557','Elsie','Y','Malinao','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(134,'220476558','220476558','Rosalie','M','Singculan','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(135,'220863559','220863559','Solidad','S','Abay','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(136,'221080560','221080560','Liza','I','Pepito','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(137,'220979561','220979561','Margie','A','Cañete','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(138,'221098562','221098562','Amorlina','G','Amoren','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(139,'220995563','220995563','Carlyn','D','Bohol','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(140,'220780564','220780564','Susana','E','Blaza','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(141,'221073565','221073565','Rosalie','N','Sumalinog','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(142,'220874566','220874566','Rey','M','Mongas','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(143,'220669567','220669567','Emily','Q','Nuñez','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(144,'221172568','221172568','Erwin','D','Restauro','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(145,'221297569','221297569','Janine','T','Rendal','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(146,'220901570','220901570','Charlene','','Menguito','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(147,'221201571','221201571','Mary Rose','A','Ando','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(148,'220999572','220999572','Marian','M','Zaragoza','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(149,'221200573','221200573','Geberly','D','Oba-ob','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(150,'220888574','220888574','Winple','P','Menguito','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(151,'220397575','220397575','Cristel','T','Biongcog','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(152,'220702576','220702576','Jeseca','M','Bentulan','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(153,'221269578','221269578','George','B','Sumalinog','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(154,'220870579','220870579','Alex','M','Tampus','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(155,'220363580','220363580','Ma. Editha','G','Inoc','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(156,'220175581','220175581','Nora','T','Basaya','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(157,'220765582','220765582','Sancho','T','Villarin','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(158,'221296583','221296583','Clint Fernel','Q','Dumasapal','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(159,'220995584','220995584','Gerald','V','Maranga','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(160,'220673585','220673585','Arturo Jr.','C','Daro ','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(161,'221076586','221076586','Roque Jr.','G','Macan ','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(162,'220981587','220981587','Imee Marie','M','Villamor','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(163,'220778588','220778588','Melgrace','J','Mascardo','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(164,'220476589','220476589','Gutism','V','Bactol','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(165,'220190590','220190590','Artemio Jr.','L','Degamo ','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(166,'220173591','220173591','Edilin','D','Orito','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(167,'221079592','221079592','Jill','B','Baguio','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(168,'220683593','220683593','Marjun','','Baguio','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(169,'220478594','220478594','Oliver','P','Degamo','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(170,'221271595','221271595','Tom','T','Casquejo','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(171,'221069596','221069596','Danilo','D','Alindao','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(172,'221099597','221099597','Roger','A','Pacaldo','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(173,'220581598','220581598','Ronald','P','Aro','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(174,'220879599','220879599','Eric','R','Jamias','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(175,'220567600','220567600','Juan','C','Sumalinog','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(176,'220269601','220269601','Gerardo Jr.','A','Dinoy ','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(177,'220180602','220180602','Romel','Y','Pajaron','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(178,'220297603','220297603','Kristel Jane','J','Miano','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(179,'220689604','220689604','Francis Niño','M','Taneo','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(180,'221166605','221166605','Adriano Jr.','M','Tiro ','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(181,'220194606','220194606','Gian Carlo','N','Manayon','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(182,'220688607','220688607','June Jason','C','Maniscan','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(183,'221171608','221171608','Randino','D','Ando','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(184,'221197609','221197609','Goldwayne','T','Baje','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(185,'220886610','220886610','Kristian Smith','N','Sepra','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(186,'220658611','220658611','Sergio','','Yncierto','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(187,'221198612','221198612','Rodilyn','G','Taytay','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(188,'221298613','221298613','Maria Almarie','B','Dico','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(189,'221002614','221002614','Ana Liza','','Jadormeo','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(190,'220699615','220699615','John Rhiel Joshua','Q','Pedoche','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(191,'220199616','220199616','Angel','T','Inoc','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(192,'220192617','220192617','Raniza','L','Ando','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(193,'220701577','220701577','Jean Rey','O','Binarao','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(194,'220996619','220996619','Joselito Jr.','M','Baguio ','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(195,'221200620','221200620','Marvin','B','Nable','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(196,'220489621','220489621','Jesson','B','Tajanlangit','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(197,'220386622','220386622','Rumar','A','Casquejo','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(198,'220193623','220193623','Reslie','B','Fernandez','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(199,'220899624','220899624','Dion Carlo','J','Poliquit','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(200,'220997625','220997625','Jayramie','C','Bonio','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(201,'221199626','221199626','Germalyn','J','Ligan','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(202,'220598627','220598627','Angeluz','D','Wahing','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(203,'220691628','220691628','Moddy Ace','W','Wahing','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(204,'220791629','220791629','Rachel','G','Tajanlangit','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(205,'220277630','220277630','Rabin','M','Wahing','2019-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(206,'220877631','220877631','Racquel','A','Sombilon','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(207,'220498632','220498632','Geneva','T','Daugdaug','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(208,'220787633','220787633','Elma','S','Maquilang','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(209,'221198634','221198634','Mikee','P','Ando','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(210,'220468635','220468635','Vicente','D','Pogoy','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(211,'221181636','221181636','Michael','M','Dacua','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(212,'220470637','220470637','Joel','P','Ortega','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(213,'220384638','220384638','Mark Gavin','P','Doming','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(214,'220893639','220893639','Kim Ariel','D','Muit','2020-7-14',1,'2022-09-19 11:08:20',NULL,NULL,1),(215,'220978640','220978640','Dennis','T','Pacaldo','2020-7-14',1,'2022-09-19 11:08:20',NULL,NULL,1),(216,'220773641','220773641','Freddie','J','Baguio','2020-7-14',1,'2022-09-19 11:08:20',NULL,NULL,1),(217,'220566642','220566642','Fernando','T','Tampus','2020-7-14',1,'2022-09-19 11:08:20',NULL,NULL,1),(218,'221000618','221000618','Roger Bernard','S','Baguio','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(219,'160683211','160683211','Leonides Jr.','M','Concepcion','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(220,'210382538','210382538','Brendo','M','Sumagang','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(221,'220395548','220395548','Jay','A','Loca','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(222,'220477550','220477550','Noel','','Macan','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(223,'210772519','210772519','Ronald','S','Pogoy','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(224,'210799522','210799522','Harold Jay Mhor','','Yurong','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(225,'210200524','210200524','Kyle','C','Alcomendras','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(226,'211298520','211298520','Christian Bert','T','Masula','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(227,'210596536','210596536','Isagani','D','Varron','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(228,'220285-644','220285-644','Philip cesar','T','Nuñez jr.','2020-7-1',1,'2022-09-19 11:08:20',NULL,NULL,1),(229,'220285644','220285644','Philip cesar','T','Nuñez jr','2020-8-15',1,'2022-09-19 11:08:20',NULL,NULL,1);
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
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `EVT_ATT_RAW_PROCESS` ON SCHEDULE EVERY 1 SECOND STARTS '2022-09-18 21:45:14' ON COMPLETION NOT PRESERVE DISABLE DO BEGIN
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
CREATE DEFINER=`root`@`localhost` FUNCTION `checkDTR`(_EmpID INT, _DateTime DATETIME, _AttSchedID INT ) RETURNS int(11)
BEGIN
	#AM-IN = 1
    #AM-OUT = 2
    #PM-IN = 3
    #PM-OUT = 4
    DECLARE _GET_ID INT;
    DECLARE _AM_IN TIME;
    DECLARE _AM_OUT TIME;
    DECLARE _PM_IN TIME;
    DECLARE _PM_OUT TIME;
    
    DECLARE _TIME_TEST TIME;
    
    SET _TIME_TEST = TIME(_DateTime);
    
    SELECT id, am_in, am_out, pm_in, pm_out INTO _GET_ID,_AM_IN,_AM_OUT,_PM_IN,_PM_OUT   FROM attendance_scheds WHERE id = _AttSchedID;
    IF(_GET_ID IS NULL)THEN
		SELECT id, am_in, am_out, pm_in, pm_out INTO _GET_ID,_AM_IN,_AM_OUT,_PM_IN,_PM_OUT   FROM attendance_scheds WHERE id = 1;
	END IF;
    
    IF( _TIME_TEST BETWEEN ADDTIME( _AM_IN, -50*60) AND ADDTIME(_AM_IN, 50*60))THEN
		RETURN 1;
    ELSEIF( _TIME_TEST BETWEEN ADDTIME( _AM_OUT, -50*60) AND ADDTIME(_AM_OUT, 50*60) )THEN
		RETURN 2;
    ELSEIF( _TIME_TEST BETWEEN ADDTIME( _PM_IN, -50*60) AND ADDTIME(_PM_IN, 50*60) )THEN
		RETURN 3;
    ELSEIF( _TIME_TEST BETWEEN ADDTIME( _PM_OUT, -50*60) AND ADDTIME(_PM_OUT, 50*60) )THEN
		RETURN 4;
    END IF;
    
	RETURN 0;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `fnJSON_VALUE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `fnJSON_VALUE`(`_JsonSrc` LONGTEXT,`_JsonPoint` TEXT) RETURNS text CHARSET latin1
BEGIN
            RETURN JSON_UNQUOTE(JSON_EXTRACT(`_JsonSrc`,`_JsonPoint`));
        END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAddManualLog` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAddManualLog`(_EmployeeID INT, _DateTime DATE, _ScheduleID INT, _CheckID INT)
BEGIN

	DECLARE _BioID VARCHAR(50);
    DECLARE _DtrID INT;

	SELECT bio_id INTO _BioID FROM employees WHERE id = _EmployeeID;
    IF(_BioID IS NOT NULL) THEN
		INSERT INTO attendance_raws( is_manual, bio_id, date_time, employee_id, is_processed, check_dtr_id, att_sched_id)
					VALUES(1, _BioID, _DateTime, _EmployeeID, 1, _CheckID, _ScheduleID);
		
        SELECT id INTO _DtrID FROM dtr_records WHERE DATE(_DateTime) = `date` AND employee_id = _EmployeeID;
        
        #ADDING DTR RECORD IF NOT EXISTS
        IF(_DtrID IS NULL)THEN
			INSERT INTO dtr_records(employee_id, `date`) VALUES( _EmployeeID, DATE(_DateTime));
            SET _DtrID = last_insert_id();
        END IF;
		IF( _CheckID = 1 )THEN
			UPDATE dtr_records SET am_in = TIME(_DateTime) WHERE id = _DtrID;
        ELSEIF( _CheckID = 2 )THEN
			UPDATE dtr_records SET am_out = TIME(_DateTime) WHERE id = _DtrID;
        ELSEIF( _CheckID =3 )THEN
			UPDATE dtr_records SET pm_in = TIME(_DateTime) WHERE id = _DtrID;
        ELSEIF(_CheckID = 4)THEN			
			UPDATE dtr_records SET pm_out = TIME(_DateTime) WHERE id = _DtrID;
        END IF;
    END IF;



	#insert into attendance_raw

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
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAttendanceRawsCommand`(_ControllerName VARCHAR(50), _LoginID INT, _Json TEXT, _CommandType VARCHAR(20))
BEGIN
	
    DECLARE _Added INT;
    DECLARE _Existed INT;
    DECLARE _Count INT;
    DECLARE _Length INT;
    
    #TABLE 
    DECLARE _BioID VARCHAR(50);
    DECLARE _DateTime DATETIME;
    DECLARE _DeviceID INT;
    DECLARE _InOut INT;
    
    SET _Added = 0;
    SET _Existed = 0;
    
    DROP EVENT IF EXISTS EVT_ATT_RAW_PROCESS;
	SET _Length = JSON_LENGTH(_Json);
    SET _Count = 0;
    WHILE( _Count < _Length)DO
		SET _BioID = fnJSON_VALUE( _Json, CONCAT('$[', _Count, '].bio_id'));
        SET _DateTime = fnJSON_VALUE( _Json, CONCAT('$[', _Count, '].sign_time'));
        SET _InOut = fnJSON_VALUE( _Json, CONCAT('$[', _Count, '].in_out'));
        SET _DeviceID = fnJSON_VALUE( _Json, CONCAT('$[', _Count, '].device_id'));
        IF EXISTS( SELECT * FROM attendance_raws WHERE bio_id = _BioID AND date_time = _DateTime AND device_id =  _DeviceID )THEN
			SET _Existed = _Existed + 1;
		ELSE
			INSERT INTO attendance_raws( bio_id, date_time, is_processed, device_id, in_out) VALUES( _BioID, _DateTime, 0, _DeviceID, _InOut);
			SET _Added = _Added + 1;
        END IF;       
        
        
        SET _Count = _Count + 1;
    END WHILE;
    
    
    
    SELECT _Added as Added, _Existed as Existed;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spChangeSchedule` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spChangeSchedule`(_EmployeeID INT, _From DATETIME, _To DATETIME, _AttSchedID INT)
BEGIN
	DECLARE _FromDate DATE;
    DECLARE _ToDate DATE;
    SET _FromDate = DATE(_From);
    SET _ToDate = DATE(_To);
	#CLEAR DTR ATTENDANCE OF THE EMPLOYEE
    UPDATE dtr_records SET am_in = null, am_out = null, pm_in = null, pm_out = null WHERE employee_id = _EmployeeID AND (`date` BETWEEN _FromDate AND _ToDate ) AND id > 0;
    
    #RESET RAW LOGS OF THE EMPLOYEE
    UPDATE attendance_raws SET is_processed = 0, att_sched_id = _AttSchedID, check_dtr_id = null WHERE employee_id = _EmployeeID AND (DATE(date_time) BETWEEN _FromDate AND _ToDate ) AND id > 0;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spDtrReport` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spDtrReport`(_EmpID INT, _Year INT, _Month INT, _MaxDay INT)
BEGIN

	SELECT 
		DATE(CONCAT(_Year,'-',_Month,'-', A.day_no)) as `date`, 
        A.day_no, 
        B.am_in, 
        B.am_out, 
        B.pm_in, 
        B.pm_out, 
        '' as under_hour, 
        '' as under_min
    FROM 
		dtr_days AS A LEFT JOIN dtr_records AS B ON A.day_no = DAY(B.`date`) AND B.employee_id = _EmpID AND DATE( CONCAT(_Year,'-',_Month,'-', A.day_no) ) =  B.`date`
	WHERE A.day_no <= _MaxDay; 

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
        DECLARE _CheckDtrID VARCHAR(20);
        DECLARE _AttSchedID INT;
        
        DECLARE _IsManual INT; # IF MANUAL MEANS FORCE UPDATE
        
        
        #DTR DATE
        DECLARE _DtrDateID INT;
        
        
        SELECT 
			id, bio_id, date_time, employee_id, check_dtr_id,is_manual INTO  _RawID, _BioID, _DateTime, _EmpID, _CheckDtrID,_IsManual 
		FROM attendance_raws WHERE is_processed = 0  order by date_time ASC LIMIT 1;
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
        
        IF(_CheckDtrID IS NULL)THEN
			SET _CheckDtrID = checkDTR(_EmpID, _DateTime,_AttSchedID);
        END IF;
        
        #ADDING LOGIN DATE IF NOT EXISTS
        SELECT id INTO _DtrDateID FROM dtr_records WHERE employee_id = _EmpID AND DATE(`date`) = DATE(_DateTime) LIMIT 1;
        IF(_DtrDateID IS NULL)THEN
			INSERT INTO dtr_records(employee_id, `date`) VALUES(_EmpID, DATE(_DateTime));
            SET _DtrDateID = last_insert_id();
        END IF;
        
        IF(_IsManual = 1)THEN
			#AM-IN
			IF(_CheckDtrID = 1)THEN
				UPDATE dtr_records SET am_in = TIME(_DateTime) WHERE id = _DtrDateID;
			#AM-OUT
			ELSEIF(_CheckDtrID = 2)THEN
				UPDATE dtr_records SET am_out = TIME(_DateTime) WHERE id = _DtrDateID;        
			#PM-IN
			ELSEIF(_CheckDtrID = 3)THEN
				UPDATE dtr_records SET pm_in = TIME(_DateTime) WHERE id = _DtrDateID;        
			#PM-OUT
			ELSEIF(_CheckDtrID = 4)THEN
				UPDATE dtr_records SET pm_out = TIME(_DateTime) WHERE id = _DtrDateID;        
			END IF;
        ELSE
        
			#AM-IN
			IF(_CheckDtrID = 1)THEN
				#CASE CHOOSES THE EARLY
                UPDATE dtr_records SET am_in = CASE WHEN am_in IS NULL OR TIME(am_in) > TIME(_DateTime) THEN TIME(_DateTime) ELSE am_in END  WHERE id = _DtrDateID;
			#AM-OUT
			ELSEIF(_CheckDtrID = 2)THEN
				#CASE CHOOSES THE LATE
				UPDATE dtr_records SET am_out = CASE WHEN am_out IS NULL OR TIME(am_out) < TIME(_DateTime) THEN TIME(_DateTime) ELSE am_out END WHERE id = _DtrDateID;        
			#PM-IN
			ELSEIF(_CheckDtrID = 3)THEN
				UPDATE dtr_records SET pm_in = CASE WHEN pm_in IS NULL OR TIME(pm_in) > TIME(_DateTime) THEN TIME(_DateTime) ELSE pm_in END WHERE id = _DtrDateID;        
			#PM-OUT
			ELSEIF(_CheckDtrID = 4)THEN
				UPDATE dtr_records SET pm_out = CASE WHEN pm_out IS NULL OR TIME(pm_out) < TIME(_DateTime) THEN TIME(_DateTime) ELSE pm_out END WHERE id = _DtrDateID;        
			END IF;
			
        END IF;
        
        UPDATE 
			attendance_raws 
        SET 
			is_processed = 1,
            employee_id=_EmpID, 
            att_sched_id = _AttSchedID,
            check_dtr_id = _CheckDtrID
        WHERE id = _RawID;
        

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spSetAttRawCheck` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetAttRawCheck`( _AttendanceRawID INT, _CheckID INT )
_PROCLEAVE:
BEGIN
	#DECLARE _DateTime DATETIME;
    DECLARE _Date DATE;
    DECLARE _Time TIME;
    DECLARE _EmployeeID INT;
    DECLARE _DtrRecordID INT;
	DECLARE _PrevCheckID INT;

	#
	#UPDATE attendance_raws SET check_dtr_id = _CheckID WHERE id = _AttendanceRawID;
    
    SELECT  check_dtr_id, employee_id, DATE(date_time), TIME(date_time)  INTO  _PrevCheckID, _EmployeeID, _Date, _Time FROM attendance_raws WHERE id = _AttendanceRawID;
    UPDATE attendance_raws SET check_dtr_id = _CheckID WHERE id = _AttendanceRawID;
    IF(_Date IS NOT NULL)THEN
		SELECT id INTO _DtrRecordID FROM dtr_records WHERE employee_id = _EmployeeID AND _Date = `date` LIMIT 0,1;
	    
		IF( _DtrRecordID IS NULL)THEN
			IF(_CheckID = 1)THEN
				INSERT INTO dtr_records(employee_id, `date`, am_in) VALUES( _EmployeeID, _Date, _Time);
            ELSEIF( _CheckID = 2)THEN
				INSERT INTO dtr_records(employee_id, `date`, am_out) VALUES( _EmployeeID, _Date, _Time);
			ELSEIF( _CheckID = 3)THEN
				INSERT INTO dtr_records(employee_id, `date`, pm_in) VALUES( _EmployeeID, _Date, _Time);
            ELSEIF( _CheckID = 4)THEN
				INSERT INTO dtr_records(employee_id, `date`, pm_out) VALUES( _EmployeeID, _Date, _Time);            
            END IF;
        ELSE
			#CLEAR PREVIOUS INPUT
            IF(_PrevCheckID = 1)THEN
				UPDATE dtr_records SET am_in = null WHERE am_in = _Time AND id = _DtrRecordID;
			ELSEIF(_PrevCheckID = 2)THEN
				UPDATE dtr_records SET am_out = null WHERE  am_out = _Time AND  id = _DtrRecordID;
            ELSEIF(_PrevCheckID = 3)THEN
				UPDATE dtr_records SET pm_in = null WHERE  pm_in = _Time AND  id = _DtrRecordID;
            ELSEIF(_PrevCheckID = 4)THEN
				UPDATE dtr_records SET pm_out = null WHERE  pm_out = _Time AND id = _DtrRecordID;
            END IF;
        
			IF(_CheckID = 1)THEN
				UPDATE dtr_records SET am_in = _Time WHERE id = _DtrRecordID;
            ELSEIF( _CheckID = 2)THEN
				UPDATE dtr_records SET am_out = _Time WHERE id = _DtrRecordID;
			ELSEIF( _CheckID = 3)THEN
				UPDATE dtr_records SET pm_in = _Time WHERE id = _DtrRecordID;
            ELSEIF( _CheckID = 4)THEN
				UPDATE dtr_records SET pm_out = _Time WHERE id = _DtrRecordID;           
            END IF;
        END IF;
        
        
        
        
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

-- Dump completed on 2022-09-19 11:16:00
