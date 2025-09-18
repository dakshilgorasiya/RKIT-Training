CREATE DATABASE  IF NOT EXISTS `student_db_copy` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `student_db_copy`;
-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: student_db_copy
-- ------------------------------------------------------
-- Server version	8.0.43

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
-- Temporary view structure for view `studentcourseview`
--

DROP TABLE IF EXISTS `studentcourseview`;
/*!50001 DROP VIEW IF EXISTS `studentcourseview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `studentcourseview` AS SELECT 
 1 AS `T01F01`,
 1 AS `T01F02`,
 1 AS `T02F02`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `t01`
--

DROP TABLE IF EXISTS `t01`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t01` (
  `T01F01` int NOT NULL,
  `T01F02` varchar(50) NOT NULL,
  `T01F03` int NOT NULL,
  `T01F04` enum('MALE','FEMALE','OTHER') DEFAULT NULL,
  `T01F05` int DEFAULT NULL,
  `T01F06` varchar(100) NOT NULL,
  PRIMARY KEY (`T01F01`),
  UNIQUE KEY `INDEX_EMAIL` (`T01F06`),
  KEY `T01F05_FK` (`T01F05`),
  CONSTRAINT `T01F05_FK` FOREIGN KEY (`T01F05`) REFERENCES `t02` (`T02F01`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t01`
--

LOCK TABLES `t01` WRITE;
/*!40000 ALTER TABLE `t01` DISABLE KEYS */;
INSERT INTO `t01` VALUES (1,'Alice Johnson',21,'FEMALE',101,'alice@gmail.com'),(3,'Charlie Brown',20,'MALE',102,'charlie@gmail.com'),(4,'Diana Prince',23,'FEMALE',103,'diana@gmail.om'),(5,'Eve Adams',21,'FEMALE',102,'eve@gmail.com'),(6,'Bob Prince',23,'MALE',NULL,'bobp@gmail.com');
/*!40000 ALTER TABLE `t01` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `AFTER_STUDENT_DELETE` AFTER DELETE ON `t01` FOR EACH ROW BEGIN
	INSERT INTO T04(T04F01, T04F02, T04F03, T04F04, T04F05) VALUES
    (OLD.T01F01, OLD.T01F02, OLD.T01F03, OLD.T01F04, OLD.T01F06);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `t02`
--

DROP TABLE IF EXISTS `t02`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t02` (
  `T02F01` int NOT NULL AUTO_INCREMENT,
  `T02F02` varchar(50) NOT NULL,
  `T02F03` int NOT NULL,
  PRIMARY KEY (`T02F01`)
) ENGINE=InnoDB AUTO_INCREMENT=205 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t02`
--

LOCK TABLES `t02` WRITE;
/*!40000 ALTER TABLE `t02` DISABLE KEYS */;
INSERT INTO `t02` VALUES (101,'Computer Science',4),(102,'Business Administration',3),(103,'Data Analytics',1),(104,'MACHINE LEARNING',2),(105,'WEB DEVELOPMENT',2),(201,'COA',4),(202,'OS',3),(203,'PYTHON',1),(204,'Backend development',4);
/*!40000 ALTER TABLE `t02` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t03`
--

DROP TABLE IF EXISTS `t03`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t03` (
  `T03F01` int NOT NULL,
  `T03F02` int DEFAULT NULL,
  `T03F03` varchar(50) NOT NULL,
  `T03F04` decimal(5,2) NOT NULL,
  PRIMARY KEY (`T03F01`),
  KEY `T03F02_FK` (`T03F02`),
  CONSTRAINT `T03F02_FK` FOREIGN KEY (`T03F02`) REFERENCES `t01` (`T01F01`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t03`
--

LOCK TABLES `t03` WRITE;
/*!40000 ALTER TABLE `t03` DISABLE KEYS */;
INSERT INTO `t03` VALUES (3,3,'PYTHON',76.00),(4,4,'TENSORFLOW',95.00),(5,5,'COA',88.00),(8,3,'COA',76.00),(9,4,'ACCOUNTS',95.00),(10,5,'OS',88.00);
/*!40000 ALTER TABLE `t03` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t04`
--

DROP TABLE IF EXISTS `t04`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t04` (
  `T04F01` int NOT NULL,
  `T04F02` varchar(30) NOT NULL,
  `T04F03` int NOT NULL,
  `T04F04` enum('MALE','FEMALE','OTHER') NOT NULL,
  `T04F05` varchar(100) NOT NULL,
  `T04F06` date DEFAULT (curdate())
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t04`
--

LOCK TABLES `t04` WRITE;
/*!40000 ALTER TABLE `t04` DISABLE KEYS */;
INSERT INTO `t04` VALUES (2,'Bob Smith',22,'MALE','bob@gmail.com','2025-09-13');
/*!40000 ALTER TABLE `t04` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'student_db_copy'
--

--
-- Dumping routines for database 'student_db_copy'
--
/*!50003 DROP FUNCTION IF EXISTS `CALCULATE_GRADE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CALCULATE_GRADE`(p_marks DECIMAL(5,2)) RETURNS char(1) CHARSET utf8mb4
    DETERMINISTIC
BEGIN
	DECLARE v_grade CHAR(1);
    
	IF p_marks >= 80 THEN
		SET v_grade = 'A';
	ELSEIF p_marks >=  60 THEN
		SET v_grade = 'B';
	ELSEIF p_marks >= 40 THEN
		SET v_grade = 'C';
	ELSE
		SET v_grade = 'F';
	END IF;
    
    RETURN v_grade;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GET_STUDENT_ENROLLED_IN_COURSE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GET_STUDENT_ENROLLED_IN_COURSE`(IN p_course_name VARCHAR(50))
BEGIN
	SELECT
		T01F01,
        T01F02
	FROM 
		T01
        INNER JOIN T02 ON T01F05 = T02F01
	WHERE
		T02F02 = p_course_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `studentcourseview`
--

/*!50001 DROP VIEW IF EXISTS `studentcourseview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `studentcourseview` AS select `t01`.`T01F01` AS `T01F01`,`t01`.`T01F02` AS `T01F02`,`t02`.`T02F02` AS `T02F02` from (`t01` join `t02` on((`t01`.`T01F05` = `t02`.`T02F01`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-15 10:52:06
