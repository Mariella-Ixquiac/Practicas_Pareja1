-- MySQL dump 10.13  Distrib 5.5.62, for Win64 (AMD64)
--
-- Host: localhost    Database: inventario
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.24-MariaDB

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
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientes` (
  `id_cliente` int(11) NOT NULL AUTO_INCREMENT,
  `nom_cliente` varchar(100) NOT NULL,
  `ape_cliente` varchar(100) NOT NULL,
  `nit` varchar(13) NOT NULL,
  `telefono_cliente` varchar(8) NOT NULL,
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'Marco','Sosa','345678890','54689098'),(3,'Juana','Kiki','12324435','24233244'),(4,'j','o','8','9');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS `compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compra` (
  `id_compra` int(11) NOT NULL AUTO_INCREMENT,
  `fec_compra` date NOT NULL,
  `precio_costo` varchar(10) NOT NULL,
  `unidades_compradas` int(11) NOT NULL,
  `id_proveedores` int(11) NOT NULL,
  `id_medicamento` int(11) NOT NULL,
  `total` double DEFAULT NULL,
  `precio_final` double DEFAULT NULL,
  `total_PC` double NOT NULL,
  PRIMARY KEY (`id_compra`),
  KEY `proveedores` (`id_proveedores`),
  KEY `index_med` (`id_medicamento`),
  CONSTRAINT `compra_ibfk_2` FOREIGN KEY (`id_proveedores`) REFERENCES `proveedores` (`id_proveedores`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `compra_ibfk_3` FOREIGN KEY (`id_medicamento`) REFERENCES `medicamento` (`id_med`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra`
--

LOCK TABLES `compra` WRITE;
/*!40000 ALTER TABLE `compra` DISABLE KEYS */;
/*!40000 ALTER TABLE `compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `login` (
  `id_login` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(50) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `pssw` varchar(30) NOT NULL,
  `id_rol` int(11) NOT NULL,
  PRIMARY KEY (`id_login`),
  KEY `ol` (`id_rol`),
  CONSTRAINT `login_ibfk_1` FOREIGN KEY (`id_rol`) REFERENCES `rol` (`id_rol`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES (2,'Juana Sosa','Admin1','123',1),(4,'Admin3','María','45',4),(5,'Admin1','Luisa','234',4),(6,'OP','Oliva Pereira','12345o',4);
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marca`
--

DROP TABLE IF EXISTS `marca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `marca` (
  `id_marca` int(11) NOT NULL AUTO_INCREMENT,
  `nom_marca` varchar(100) NOT NULL,
  `calificacion` varchar(1) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  PRIMARY KEY (`id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marca`
--

LOCK TABLES `marca` WRITE;
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
INSERT INTO `marca` VALUES (1,'Nutricia','5','2 calle 2-010 Zona 3 Guatemala, Guatemala.'),(3,'fr','2','d'),(4,'Juana','1','0 calle 2'),(5,'jjj','1','0 calle 2'),(7,'Junio','3','0 calle 3-080 Zona 2 salcaja.');
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicamento`
--

DROP TABLE IF EXISTS `medicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medicamento` (
  `id_med` int(11) NOT NULL AUTO_INCREMENT,
  `nom_med` varchar(100) NOT NULL,
  `receta` tinyint(1) NOT NULL,
  `Cantidad_existente` int(11) NOT NULL,
  `precauciones` varchar(200) NOT NULL,
  `descripcion` varchar(200) NOT NULL,
  `fec_caducidad` date NOT NULL,
  `presentacion` varchar(100) NOT NULL,
  `uni_medida` varchar(100) NOT NULL,
  `formula` varchar(200) NOT NULL,
  `dosis` varchar(100) NOT NULL,
  PRIMARY KEY (`id_med`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicamento`
--

LOCK TABLES `medicamento` WRITE;
/*!40000 ALTER TABLE `medicamento` DISABLE KEYS */;
INSERT INTO `medicamento` VALUES (2,'1',1,467,'1','1','2024-02-06','0','1','1','1'),(3,'1',0,13,'7','8','2022-09-01','3','4','5','6'),(4,'q',1,12,'werty','dsfgsgfd','2022-09-01','qwe','asd','lkjh','nbvc'),(5,'Hi',0,45,'jakncdjka','cnjdfkal','2022-09-05','r','d','jfioewñ','fnkjsñ'),(6,'yuiutj',1,34,'1','1','2024-02-06','0','1','1','1');
/*!40000 ALTER TABLE `medicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedores` (
  `id_proveedores` int(11) NOT NULL AUTO_INCREMENT,
  `nom_proveedores` varchar(100) NOT NULL,
  `telefono` varchar(8) NOT NULL,
  `id_marca` int(11) NOT NULL,
  PRIMARY KEY (`id_proveedores`),
  KEY `Marca` (`id_marca`),
  CONSTRAINT `proveedores_ibfk_1` FOREIGN KEY (`id_marca`) REFERENCES `marca` (`id_marca`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedores`
--

LOCK TABLES `proveedores` WRITE;
/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES (1,'Edgar Raúl Culajay','01726394',1),(3,'Marco Sosa','12345456',1),(4,'ser','12234354',4),(5,'kiki','98765432',7),(6,'gyr','08765453',3);
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rol` (
  `id_rol` int(11) NOT NULL AUTO_INCREMENT,
  `rol` varchar(20) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador.'),(4,'Empleado.');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venta` (
  `id_venta` int(11) NOT NULL AUTO_INCREMENT,
  `fec_venta` date NOT NULL,
  `unidades_vendidas` int(11) NOT NULL,
  `subtotal_venta` double DEFAULT NULL,
  `id_cliente` int(11) NOT NULL,
  `id_medicamento` int(11) NOT NULL,
  `id_compra` int(11) NOT NULL,
  PRIMARY KEY (`id_venta`),
  KEY `cliente_index` (`id_cliente`),
  KEY `index_med` (`id_medicamento`),
  KEY `index_compra` (`id_compra`),
  CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `venta_ibfk_3` FOREIGN KEY (`id_medicamento`) REFERENCES `medicamento` (`id_med`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'inventario'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-06 20:15:32
