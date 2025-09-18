-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: employee_payroll
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
-- Temporary view structure for view `employee_salary_summary`
--

DROP TABLE IF EXISTS `employee_salary_summary`;
/*!50001 DROP VIEW IF EXISTS `employee_salary_summary`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `employee_salary_summary` AS SELECT 
 1 AS `T01F01`,
 1 AS `T01F02`,
 1 AS `T02F02`,
 1 AS `T01F04`,
 1 AS `COALESCE(SUM(T03F03), 0)`,
 1 AS `COUNT(T03F03)`*/;
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
  `T01F03` int DEFAULT NULL,
  `T01F04` decimal(8,2) NOT NULL,
  PRIMARY KEY (`T01F01`),
  KEY `FK_T01F03` (`T01F03`),
  CONSTRAINT `FK_T01F03` FOREIGN KEY (`T01F03`) REFERENCES `t02` (`T02F01`),
  CONSTRAINT `CHECK_T01F04` CHECK ((`T01F04` > 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t01`
--

LOCK TABLES `t01` WRITE;
/*!40000 ALTER TABLE `t01` DISABLE KEYS */;
INSERT INTO `t01` VALUES (101,'Alice',2,90000.00),(102,'Bob',2,80000.00),(103,'Charlie',3,75000.00),(104,'David',1,60000.00),(105,'Eve',4,85000.00),(106,'Frank',NULL,50000.00),(107,'Grace',2,95000.00);
/*!40000 ALTER TABLE `t01` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t02`
--

DROP TABLE IF EXISTS `t02`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t02` (
  `T02F01` int NOT NULL,
  `T02F02` varchar(50) NOT NULL,
  PRIMARY KEY (`T02F01`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t02`
--

LOCK TABLES `t02` WRITE;
/*!40000 ALTER TABLE `t02` DISABLE KEYS */;
INSERT INTO `t02` VALUES (1,'Human Resources'),(2,'Engineering'),(3,'Sales'),(4,'Marketing'),(5,'Finance');
/*!40000 ALTER TABLE `t02` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t03`
--

DROP TABLE IF EXISTS `t03`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t03` (
  `T03F01` int DEFAULT NULL,
  `T03F02` date DEFAULT (curdate()),
  `T03F03` decimal(8,2) NOT NULL,
  KEY `FK_T03F01` (`T03F01`),
  CONSTRAINT `FK_T03F01` FOREIGN KEY (`T03F01`) REFERENCES `t01` (`T01F01`),
  CONSTRAINT `CHECK_T03F03` CHECK ((`T03F03` > 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t03`
--

LOCK TABLES `t03` WRITE;
/*!40000 ALTER TABLE `t03` DISABLE KEYS */;
INSERT INTO `t03` VALUES (101,'2024-01-01',90000.00),(101,'2024-02-01',90000.00),(101,'2024-03-01',90000.00),(102,'2024-01-01',80000.00),(102,'2024-02-01',80000.00),(103,'2024-01-01',75000.00),(104,'2024-01-01',60000.00),(104,'2024-02-01',60000.00),(107,'2024-03-01',95000.00),(101,'2024-04-01',90000.00);
/*!40000 ALTER TABLE `t03` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `AFTER_SALARY_INSERT` AFTER INSERT ON `t03` FOR EACH ROW BEGIN
	INSERT INTO T04(T04F01, T04F03) VALUES
    (NEW.T03F01, NEW.T03F03);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `t04`
--

DROP TABLE IF EXISTS `t04`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t04` (
  `T04F01` int DEFAULT NULL,
  `T04F02` timestamp NULL DEFAULT (now()),
  `T04F03` decimal(8,2) NOT NULL,
  KEY `FK_T04F01` (`T04F01`),
  CONSTRAINT `FK_T04F01` FOREIGN KEY (`T04F01`) REFERENCES `t01` (`T01F01`),
  CONSTRAINT `CHECK_T04F03` CHECK ((`T04F03` > 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t04`
--

LOCK TABLES `t04` WRITE;
/*!40000 ALTER TABLE `t04` DISABLE KEYS */;
INSERT INTO `t04` VALUES (101,'2025-09-13 10:54:52',90000.00);
/*!40000 ALTER TABLE `t04` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'employee_payroll'
--

--
-- Dumping routines for database 'employee_payroll'
--
/*!50003 DROP PROCEDURE IF EXISTS `CALCULATE_YEARLY_SALARY` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CALCULATE_YEARLY_SALARY`(p_employee_id INT)
BEGIN
    SELECT 
		T01F04 * 12
	FROM
		T01 
	WHERE 
		T01F01 = p_employee_id 
	LIMIT 
		1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `employee_salary_summary`
--

/*!50001 DROP VIEW IF EXISTS `employee_salary_summary`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `employee_salary_summary` AS select `t01`.`T01F01` AS `T01F01`,`t01`.`T01F02` AS `T01F02`,`t02`.`T02F02` AS `T02F02`,`t01`.`T01F04` AS `T01F04`,coalesce(sum(`t03`.`T03F03`),0) AS `COALESCE(SUM(T03F03), 0)`,count(`t03`.`T03F03`) AS `COUNT(T03F03)` from ((`t01` left join `t02` on((`t01`.`T01F03` = `t02`.`T02F01`))) left join `t03` on((`t01`.`T01F01` = `t03`.`T03F01`))) group by `t01`.`T01F01`,`t01`.`T01F02`,`t02`.`T02F02`,`t01`.`T01F04` */;
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

-- Dump completed on 2025-09-13 16:40:50
