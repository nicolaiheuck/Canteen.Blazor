-- MariaDB dump 10.19  Distrib 10.9.8-MariaDB, for osx10.17 (x86_64)
--
-- Host: localhost    Database: DOOM
-- ------------------------------------------------------
-- Server version	10.9.8-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `DOOM`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `DOOM` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `DOOM`;

--
-- Table structure for table `Food_Allergies`
--

DROP TABLE IF EXISTS `Food_Allergies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Food_Allergies` (
  `AllergyID` int(11) NOT NULL AUTO_INCREMENT,
  `AllergyName` varchar(20) NOT NULL,
  PRIMARY KEY (`AllergyID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Food_Allergies`
--

LOCK TABLES `Food_Allergies` WRITE;
/*!40000 ALTER TABLE `Food_Allergies` DISABLE KEYS */;
INSERT INTO `Food_Allergies` VALUES
(1,'Gluten'),
(2,'Crustacean'),
(3,'Mollusca'),
(4,'Egg'),
(5,'Fish'),
(6,'Peanut'),
(7,'Soy'),
(8,'Milk'),
(9,'Nuts'),
(10,'Lupin'),
(11,'Celery'),
(12,'Mustard'),
(13,'Sesame'),
(14,'Sulphite');
/*!40000 ALTER TABLE `Food_Allergies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Food_Footprint`
--

DROP TABLE IF EXISTS `Food_Footprint`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Food_Footprint` (
  `FootprintID` int(11) NOT NULL AUTO_INCREMENT,
  `FootprintText` varchar(15) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`FootprintID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Food_Footprint`
--

LOCK TABLES `Food_Footprint` WRITE;
/*!40000 ALTER TABLE `Food_Footprint` DISABLE KEYS */;
INSERT INTO `Food_Footprint` VALUES
(1,'Lav'),
(2,'Medium'),
(3,'Høj');
/*!40000 ALTER TABLE `Food_Footprint` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `food_menu`
--

DROP TABLE IF EXISTS `food_menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `food_menu` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DishName` varchar(75) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Kcal` int(11) DEFAULT NULL,
  `Kj` int(11) DEFAULT round(`Kcal` * 4.184,0),
  `FootprintID` int(11) DEFAULT NULL,
  `Vegetarian` bit(1) NOT NULL DEFAULT b'0',
  `Vegan` bit(1) NOT NULL DEFAULT b'0',
  `Allergy_Gluten` int(11) NOT NULL DEFAULT 0,
  `Allergy_Crustacean` int(11) NOT NULL DEFAULT 0,
  `Allergy_Mollusca` int(11) NOT NULL DEFAULT 0,
  `Allergy_Egg` int(11) NOT NULL DEFAULT 0,
  `Allergy_Fish` int(11) NOT NULL DEFAULT 0,
  `Allergy_Peanut` int(11) NOT NULL DEFAULT 0,
  `Allergy_Soy` int(11) NOT NULL DEFAULT 0,
  `Allergy_Milk` int(11) NOT NULL DEFAULT 0,
  `Allergy_Nuts` int(11) NOT NULL DEFAULT 0,
  `Allergy_Lupin` int(11) NOT NULL DEFAULT 0,
  `Allergy_Celery` int(11) NOT NULL DEFAULT 0,
  `Allergy_Mustard` int(11) NOT NULL DEFAULT 0,
  `Allergy_Sesame` int(11) NOT NULL DEFAULT 0,
  `Allergy_Sulphite` int(11) NOT NULL DEFAULT 0,
  `WeekDay` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FootprintID` (`FootprintID`),
  CONSTRAINT `food_menu_ibfk_1` FOREIGN KEY (`FootprintID`) REFERENCES `Food_Footprint` (`FootprintID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `food_menu`
--

LOCK TABLES `food_menu` WRITE;
/*!40000 ALTER TABLE `food_menu` DISABLE KEYS */;
INSERT INTO `food_menu` VALUES
(1,'Test fisk mandag',500,2092,2,'\0','\0',0,0,0,0,1,0,0,0,0,0,0,0,0,0,1),
(2,'Test kød mandag',500,2092,3,'\0','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,1),
(3,'Test salat mandag',500,2092,1,'','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,1),
(4,'Test vegan mandag',300,1255,1,'','',0,0,0,0,0,0,0,0,0,0,1,0,0,0,1),
(5,'Test kød tirsdag',500,2092,3,'\0','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,2),
(6,'Test fisk tirsdag',500,2092,3,'\0','\0',0,0,0,0,1,0,0,0,0,0,0,0,0,0,2),
(7,'Test salat tirsdag',500,2092,1,'','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,2),
(8,'Test vegan tirsdag',300,1255,1,'','',0,0,0,0,0,0,0,0,0,0,1,0,0,0,2),
(9,'Test kød onsdag',500,2092,3,'\0','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,3),
(10,'Test fisk onsdag',500,2092,3,'\0','\0',0,0,0,0,1,0,0,0,0,0,0,0,0,0,3),
(11,'Test salat onsdag',500,2092,1,'','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,3),
(12,'Test vegan onsdag',300,1255,1,'','',0,0,0,0,0,0,0,0,0,0,1,0,0,0,3),
(13,'Test kød torsdag',500,2092,3,'\0','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,4),
(14,'Test fisk torsdag',500,2092,3,'\0','\0',0,0,0,0,1,0,0,0,0,0,0,0,0,0,4),
(15,'Test salat torsdag',500,2092,1,'','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,4),
(16,'Test vegan torsdag',300,1255,1,'','',0,0,0,0,0,0,0,0,0,0,1,0,0,0,4),
(17,'Test kød fredag',500,2092,3,'\0','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,5),
(18,'Test fisk fredag',500,2092,3,'\0','\0',0,0,0,0,1,0,0,0,0,0,0,0,0,0,5),
(19,'Test salat fredag',500,2092,1,'','\0',0,0,0,0,0,0,0,0,0,0,0,0,0,0,5),
(20,'Test vegan fredag',300,1255,1,'','',0,0,0,0,0,0,0,0,0,0,1,0,0,0,5);
/*!40000 ALTER TABLE `food_menu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-02 13:42:33
