-- MariaDB dump 10.19  Distrib 10.4.28-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: seguridad
-- ------------------------------------------------------
-- Server version	10.4.28-MariaDB

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
-- Table structure for table `aplicacion`
--

DROP TABLE IF EXISTS `aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aplicacion` (
  `idaplicacion` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(80) DEFAULT NULL COMMENT 'TRIAL',
  `password` varchar(80) DEFAULT NULL COMMENT 'TRIAL',
  `urlinicio` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `xappid` varchar(80) DEFAULT NULL COMMENT 'TRIAL',
  `jwtkey` varchar(80) DEFAULT NULL COMMENT 'TRIAL',
  `jwtexpirationtime` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idaplicacion`)
) ENGINE=InnoDB AUTO_INCREMENT=10017 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aplicacion`
--

LOCK TABLES `aplicacion` WRITE;
/*!40000 ALTER TABLE `aplicacion` DISABLE KEYS */;
INSERT INTO `aplicacion` VALUES (10014,'SEGURIDAD THREEBITS','8867D9A814621270A8D427','http://localhost/ThreeBits.Security.Portal/','8F5DFB8E347D2050848978982EC2','C8DDDBC80BB080553856FECBA3B06519',900,1),(10015,'SCHOOL CONTROL','8867D9A814621270A8D427','http://localhost/ThreeBits.School.Portal/','8F5DFB8E347D2050848978982EC3','C8DDDBC80BB080553856FECBA3B06519',900,1),(10016,'SIS SANFEL','8867D9A814621270A8D427','http://localhost/ThreeBits.Sanfel.Portal/','8F5DFB8E347D2050848978982EC4','C8DDDBC80BB080553856FECBA3B06519',900,1);
/*!40000 ALTER TABLE `aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `audit_contacto`
--

DROP TABLE IF EXISTS `audit_contacto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `audit_contacto` (
  `idcontactoaudit` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idoperacionaudit` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `idcontacto` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idusuario` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idtipocontacto` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `valor` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `fechaalta` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activocontacto` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  `idusermodifica` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idappmodifica` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `fechatransaccion` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idcontactoaudit`),
  KEY `fk_auditcontacto_ref_catoperaudit` (`idoperacionaudit`),
  CONSTRAINT `fk_auditcontacto_ref_catoperaudit` FOREIGN KEY (`idoperacionaudit`) REFERENCES `cat_operacionaudit` (`idoperacionaudit`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audit_contacto`
--

LOCK TABLES `audit_contacto` WRITE;
/*!40000 ALTER TABLE `audit_contacto` DISABLE KEYS */;
/*!40000 ALTER TABLE `audit_contacto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `audit_domicilio`
--

DROP TABLE IF EXISTS `audit_domicilio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `audit_domicilio` (
  `iddomicilioaudit` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idoperacionaudit` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `iddomicilio` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idusuario` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `calle` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `numext` varchar(20) DEFAULT NULL COMMENT 'TRIAL',
  `numint` varchar(20) DEFAULT NULL COMMENT 'TRIAL',
  `idestado` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `estado` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `idmun` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `municipio` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `idcolonia` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `colonia` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `cp` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `fechaalta` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activodom` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  `idusermodifica` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idappmodifica` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `fechatransaccion` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`iddomicilioaudit`),
  KEY `fk_auditdom_ref_catoperaudit` (`idoperacionaudit`),
  CONSTRAINT `fk_auditdom_ref_catoperaudit` FOREIGN KEY (`idoperacionaudit`) REFERENCES `cat_operacionaudit` (`idoperacionaudit`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audit_domicilio`
--

LOCK TABLES `audit_domicilio` WRITE;
/*!40000 ALTER TABLE `audit_domicilio` DISABLE KEYS */;
/*!40000 ALTER TABLE `audit_domicilio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `audit_usuarios`
--

DROP TABLE IF EXISTS `audit_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `audit_usuarios` (
  `idusuarioaudit` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idoperacionaudit` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `idusuario` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idaplicacion` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idsexo` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `idtipopersona` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `idestadocivil` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `idarea` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `idtipousuario` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `idusuarioapp` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `apaterno` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `amaterno` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `nombre` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `fechanacconst` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `usuario` varchar(500) DEFAULT NULL COMMENT 'TRIAL',
  `password` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `rutafotoperfil` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `fechaalta` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activousr` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  `idusermodifica` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idappmodifica` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `fechatransaccion` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idusuarioaudit`),
  KEY `fk_auditusuarios_ref_aplicacion` (`idaplicacion`),
  KEY `fk_auditusuarios_ref_catoperaudit` (`idoperacionaudit`),
  CONSTRAINT `fk_auditusuarios_ref_aplicacion` FOREIGN KEY (`idaplicacion`) REFERENCES `aplicacion` (`idaplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_auditusuarios_ref_catoperaudit` FOREIGN KEY (`idoperacionaudit`) REFERENCES `cat_operacionaudit` (`idoperacionaudit`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audit_usuarios`
--

LOCK TABLES `audit_usuarios` WRITE;
/*!40000 ALTER TABLE `audit_usuarios` DISABLE KEYS */;
INSERT INTO `audit_usuarios` VALUES (2,1,1,10014,'1','1','1','1','1','1','1','1','1','2025-01-07 00:00:00.000','1','1','1','0000-00-00 00:00:00.000',1,1,10014,'2025-02-07 08:47:12.998',1),(3,1,1,10014,'1','1','1','1','1','1','1','1','1','2025-01-07 00:00:00.000','1','1','1','0000-00-00 00:00:00.000',1,1,10014,'2025-02-07 08:53:20.163',1),(4,1,1,10014,'1','1','1','1','1','1','1','1','1','2025-01-07 00:00:00.000','1','1','1','2025-02-05 00:00:00.000',1,1,10014,'2025-02-07 08:57:53.273',1),(5,1,10073,10015,'FEMENINO','FISICA','CASADO(A)','SISTEMAS','Cliente','10072','MARTINEZ','ZAMUDIO','JULIO CESAR','2025-03-11 18:31:09.240','sysmngr','8B539B85236B3245F1837C912AC1','profile.png','2025-03-11 12:45:23.685',1,10073,10015,'2025-03-11 12:45:23.730',1);
/*!40000 ALTER TABLE `audit_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_area`
--

DROP TABLE IF EXISTS `cat_area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_area` (
  `idarea` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idarea`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_area`
--

LOCK TABLES `cat_area` WRITE;
/*!40000 ALTER TABLE `cat_area` DISABLE KEYS */;
INSERT INTO `cat_area` VALUES (1,'SISTEMAS',1);
/*!40000 ALTER TABLE `cat_area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_estaciones`
--

DROP TABLE IF EXISTS `cat_estaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_estaciones` (
  `idestacion` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `desripcion` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idestacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_estaciones`
--

LOCK TABLES `cat_estaciones` WRITE;
/*!40000 ALTER TABLE `cat_estaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `cat_estaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_estadocivil`
--

DROP TABLE IF EXISTS `cat_estadocivil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_estadocivil` (
  `idestadocivil` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idestadocivil`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_estadocivil`
--

LOCK TABLES `cat_estadocivil` WRITE;
/*!40000 ALTER TABLE `cat_estadocivil` DISABLE KEYS */;
INSERT INTO `cat_estadocivil` VALUES (1,'CASADO(A)',1),(2,'DIVORCIADO(A)',1),(3,'SOLTERO',1),(4,'UNIÓN LIBRE',1),(5,'VIUDO(A)',1);
/*!40000 ALTER TABLE `cat_estadocivil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_grals`
--

DROP TABLE IF EXISTS `cat_grals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_grals` (
  `idcatgral` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `nombretabla` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `idtabla` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `descripciontabla` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `idfiltro` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idcatgral`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_grals`
--

LOCK TABLES `cat_grals` WRITE;
/*!40000 ALTER TABLE `cat_grals` DISABLE KEYS */;
/*!40000 ALTER TABLE `cat_grals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_operacionaudit`
--

DROP TABLE IF EXISTS `cat_operacionaudit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_operacionaudit` (
  `idoperacionaudit` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idoperacionaudit`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_operacionaudit`
--

LOCK TABLES `cat_operacionaudit` WRITE;
/*!40000 ALTER TABLE `cat_operacionaudit` DISABLE KEYS */;
INSERT INTO `cat_operacionaudit` VALUES (1,'INSERT',1),(2,'UPDATE',1),(3,'DELETE',1);
/*!40000 ALTER TABLE `cat_operacionaudit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_sexo`
--

DROP TABLE IF EXISTS `cat_sexo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_sexo` (
  `idsexo` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idsexo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_sexo`
--

LOCK TABLES `cat_sexo` WRITE;
/*!40000 ALTER TABLE `cat_sexo` DISABLE KEYS */;
INSERT INTO `cat_sexo` VALUES (1,'FEMENINO',1),(2,'MASCULINO',1);
/*!40000 ALTER TABLE `cat_sexo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_tipocontacto`
--

DROP TABLE IF EXISTS `cat_tipocontacto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_tipocontacto` (
  `idtipocontacto` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idtipocontacto`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_tipocontacto`
--

LOCK TABLES `cat_tipocontacto` WRITE;
/*!40000 ALTER TABLE `cat_tipocontacto` DISABLE KEYS */;
INSERT INTO `cat_tipocontacto` VALUES (1,'TELÉFONO PRINCIPAL',1),(2,'TELÉFONO SECUNDARIO',1),(3,'CORREO ELECTRÓNICO',1),(4,'FACEBOOK',1);
/*!40000 ALTER TABLE `cat_tipocontacto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_tipopersona`
--

DROP TABLE IF EXISTS `cat_tipopersona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_tipopersona` (
  `idtipopersona` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idtipopersona`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_tipopersona`
--

LOCK TABLES `cat_tipopersona` WRITE;
/*!40000 ALTER TABLE `cat_tipopersona` DISABLE KEYS */;
INSERT INTO `cat_tipopersona` VALUES (1,'FISICA',1),(2,'MORAL',1);
/*!40000 ALTER TABLE `cat_tipopersona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_tipopersonal`
--

DROP TABLE IF EXISTS `cat_tipopersonal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_tipopersonal` (
  `idtipopersonal` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idtipopersonal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_tipopersonal`
--

LOCK TABLES `cat_tipopersonal` WRITE;
/*!40000 ALTER TABLE `cat_tipopersonal` DISABLE KEYS */;
/*!40000 ALTER TABLE `cat_tipopersonal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cat_tipousuario`
--

DROP TABLE IF EXISTS `cat_tipousuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cat_tipousuario` (
  `idtipousuario` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idtipousuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cat_tipousuario`
--

LOCK TABLES `cat_tipousuario` WRITE;
/*!40000 ALTER TABLE `cat_tipousuario` DISABLE KEYS */;
INSERT INTO `cat_tipousuario` VALUES (1,'Cliente',1);
/*!40000 ALTER TABLE `cat_tipousuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `catgenerales`
--

DROP TABLE IF EXISTS `catgenerales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `catgenerales` (
  `idcatgenerales` int(11) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `nombrecatalogo` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `idcatalogo` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `descripcion` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `filtro` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idcatgenerales`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `catgenerales`
--

LOCK TABLES `catgenerales` WRITE;
/*!40000 ALTER TABLE `catgenerales` DISABLE KEYS */;
INSERT INTO `catgenerales` VALUES (1,'VWCATTABLASCATALOGOS','IDTABLE','NAME',NULL,1),(2,'CATGENERALES','IDCATGENERALES','NOMBRECATALOGO',NULL,1),(3,'CAT_AREA','IDAREA','DESCRIPCION',NULL,1),(4,'CAT_ESTACIONES','IDESTACION','DESCRIPCION',NULL,1),(5,'CAT_ESTADOCIVIL','IDESTADOCIVIL','DESCRIPCION',NULL,1),(8,'CAT_SEXO','IDSEXO','DESCRIPCION',NULL,1),(9,'CAT_TIPOCONTACTO','IDTIPOCONTACTO','DESCRIPCION',NULL,1),(10,'CAT_TIPOPERSONA','IDTIPOPERSONA','DESCRIPCION',NULL,1),(11,'CAT_TIPOUSUARIO','IDTIPOUSUARIO','DESCRIPCION',NULL,1),(13,'APLICACION','IDAPLICACION','DESCRIPCION',NULL,1),(14,'roles','IDROL','DESCRIPCION','IDAPLICACION',1);
/*!40000 ALTER TABLE `catgenerales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `configapp`
--

DROP TABLE IF EXISTS `configapp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `configapp` (
  `idconfigapp` int(11) NOT NULL COMMENT 'TRIAL',
  `descripcion` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `valor` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idconfigapp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configapp`
--

LOCK TABLES `configapp` WRITE;
/*!40000 ALTER TABLE `configapp` DISABLE KEYS */;
INSERT INTO `configapp` VALUES (1,'SQLCONNEXIONSTRING','Provider=SQLOLEDB;Server=192.168.10.102\\SQLEXPRESS;Database=Seguridad;Uid=Seguridad; Pwd=S3gur1d4d*',1);
/*!40000 ALTER TABLE `configapp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contacto`
--

DROP TABLE IF EXISTS `contacto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contacto` (
  `idcontacto` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idusuario` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idtipocontacto` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `valor` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `fechaalta` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idcontacto`),
  KEY `fk_contacto_ref_cattipocontacto` (`idtipocontacto`),
  KEY `fk_contacto_ref_usuarios` (`idusuario`),
  CONSTRAINT `fk_contacto_ref_cattipocontacto` FOREIGN KEY (`idtipocontacto`) REFERENCES `cat_tipocontacto` (`idtipocontacto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_contacto_ref_usuarios` FOREIGN KEY (`idusuario`) REFERENCES `usuarios` (`idusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=20116 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contacto`
--

LOCK TABLES `contacto` WRITE;
/*!40000 ALTER TABLE `contacto` DISABLE KEYS */;
INSERT INTO `contacto` VALUES (20114,10072,1,'123456','2016-01-12 11:50:01.000',1),(20115,10072,3,'TEST@TEST.COM','2016-01-12 11:50:01.000',1);
/*!40000 ALTER TABLE `contacto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `domicilio`
--

DROP TABLE IF EXISTS `domicilio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `domicilio` (
  `iddomicilio` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idusuario` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `calle` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `numext` varchar(20) DEFAULT NULL COMMENT 'TRIAL',
  `numint` varchar(20) DEFAULT NULL COMMENT 'TRIAL',
  `idestado` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `estado` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `idmun` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `municipio` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `idcolonia` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `colonia` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `cp` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `fechaalta` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`iddomicilio`),
  KEY `fk_domicilio_ref_usuarios` (`idusuario`),
  CONSTRAINT `fk_domicilio_ref_usuarios` FOREIGN KEY (`idusuario`) REFERENCES `usuarios` (`idusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10018 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `domicilio`
--

LOCK TABLES `domicilio` WRITE;
/*!40000 ALTER TABLE `domicilio` DISABLE KEYS */;
INSERT INTO `domicilio` VALUES (10016,10072,'1','1','1','09','Distrito Federal','15','Cuauhtémoc','947','Roma Norte','06700','2016-01-12 11:47:50.000',1),(10017,10073,'ALDAMA','27','2','1','CDMX','1','IZTAPALAPA','1','LAS PEÑAS','09750','2025-03-11 12:45:23.733',1);
/*!40000 ALTER TABLE `domicilio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estacionesxapp`
--

DROP TABLE IF EXISTS `estacionesxapp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estacionesxapp` (
  `idestacionxapp` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idaplicacion` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idestacion` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idestacionxapp`),
  KEY `fk_estacionesxapp_ref_cat_estaciones` (`idestacion`),
  KEY `fk_estacionxapp_ref_aplicacion` (`idaplicacion`),
  CONSTRAINT `fk_estacionesxapp_ref_cat_estaciones` FOREIGN KEY (`idestacion`) REFERENCES `cat_estaciones` (`idestacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_estacionxapp_ref_aplicacion` FOREIGN KEY (`idaplicacion`) REFERENCES `aplicacion` (`idaplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estacionesxapp`
--

LOCK TABLES `estacionesxapp` WRITE;
/*!40000 ALTER TABLE `estacionesxapp` DISABLE KEYS */;
/*!40000 ALTER TABLE `estacionesxapp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logerror`
--

DROP TABLE IF EXISTS `logerror`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logerror` (
  `idlogerror` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idaplicacion` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `vchmensaje` varchar(450) DEFAULT NULL COMMENT 'TRIAL',
  `vchhostname` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `vchip` varchar(40) DEFAULT NULL COMMENT 'TRIAL',
  `vchstacktrace` varchar(500) DEFAULT NULL COMMENT 'TRIAL',
  `dtfechaerror` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `vchusuario` varchar(40) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idlogerror`),
  KEY `fk_logerror_ref_aplicacion` (`idaplicacion`),
  CONSTRAINT `fk_logerror_ref_aplicacion` FOREIGN KEY (`idaplicacion`) REFERENCES `aplicacion` (`idaplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logerror`
--

LOCK TABLES `logerror` WRITE;
/*!40000 ALTER TABLE `logerror` DISABLE KEYS */;
INSERT INTO `logerror` VALUES (1,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.2.126','GetUsuarioFull at offset 2712 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\Visual Studio 2017\\Projects\\3BWebApi\\ThreeBits.Data\\User\\UsersDA.cs:124:17\r\n','2019-04-02 15:40:33.610','',1),(2,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.2.126','GetUsuarioFull at offset 2594 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\Visual Studio 2017\\Projects\\3BWebApi\\ThreeBits.Data\\User\\UsersDA.cs:124:17\r\n','2019-04-04 10:03:15.070','',1),(3,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.2.126','GetUsuarioFull at offset 2594 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\Visual Studio 2017\\Projects\\3BWebApi\\ThreeBits.Data\\User\\UsersDA.cs:124:17\r\n','2019-04-04 10:06:01.950','',1),(4,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.2.126','GetUsuarioFull at offset 2594 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\Visual Studio 2017\\Projects\\3BWebApi\\ThreeBits.Data\\User\\UsersDA.cs:124:17\r\n','2019-04-04 10:08:48.123','',1),(5,10014,'Error: The result of a query cannot be enumerated more than once. En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.2.126','GetUsuarioFull at offset 399 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\Visual Studio 2017\\Projects\\3BWebApi\\ThreeBits.Data\\User\\UsersDA.cs:98:35\r\n','2019-04-04 10:13:43.063','',1),(6,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.2.126','GetUsuarioFull at offset 2594 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\Visual Studio 2017\\Projects\\3BWebApi\\ThreeBits.Data\\User\\UsersDA.cs:124:17\r\n','2019-04-04 10:17:02.733','',1),(7,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.2.126','GetUsuarioFull at offset 2712 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\Visual Studio 2017\\Projects\\3BWebApi\\ThreeBits.Data\\User\\UsersDA.cs:124:17\r\n','2019-04-10 12:03:02.343','',1),(8,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','10.212.134.107','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-08-17 01:37:25.800','',1),(9,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','10.212.134.107','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-08-17 01:38:05.633','',1),(10,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-13 19:51:03.197','',1),(11,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-13 19:52:48.487','',1),(12,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-13 19:53:49.697','',1),(13,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-13 20:10:06.157','',1),(14,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-13 20:12:31.110','',1),(15,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-13 20:13:54.407','',1),(16,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 09:26:56.663','',1),(17,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 12:20:11.717','',1),(18,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 12:24:03.897','',1),(19,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 12:29:27.683','',1),(20,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 13:17:14.713','',1),(21,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 13:19:36.163','',1),(22,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 13:47:38.063','',1),(23,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 14:02:16.747','',1),(24,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 14:02:20.203','',1),(25,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 14:02:22.277','',1),(26,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 14:02:25.150','',1),(27,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 14:02:25.787','',1),(28,10014,'Error: EL USUARIO NO SE A SIDO DADO DE ALTO O NO TIENE PERMISOS En El Metodo: GetUsuarioFull','JULIOCESAR-PC','192.168.100.10','GetUsuarioFull at offset 2600 in file:line:column C:\\Users\\JULIO CESAR\\Documents\\GitHub\\ThreeBits.Core\\ThreeBits.Data\\Security\\User\\UsersDA.cs:124:17\r\n','2021-10-14 17:23:03.610','',1),(37,10015,'Error: Object reference not set to an instance of an object. En El Metodo: checkUsrXApp','JULIOCESAR-PC','192.168.0.4','checkUsrXApp at offset 315 in file:line:column H:\\Projectos2022\\THREEBITSCORENUEVO\\ThreeBits.Services\\Security\\User\\UserServiceDA.cs:618:5\r\n','2025-03-11 12:39:05.594','',1),(38,10015,'Error: PROCEDURE seguridad.spFront_AuditDomicilio does not exist En El Metodo: addUsuario','JULIOCESAR-PC','192.168.0.4','addUsuario at offset 7036 in file:line:column H:\\Projectos2022\\THREEBITSCORENUEVO\\ThreeBits.Services\\Security\\User\\UserServiceDA.cs:110:8\r\n','2025-03-11 12:45:23.931','',1);
/*!40000 ALTER TABLE `logerror` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisosxelementosobjeto`
--

DROP TABLE IF EXISTS `permisosxelementosobjeto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permisosxelementosobjeto` (
  `idelementosxobj` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idpermisosobj` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `elemento` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `tooltip` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idelementosxobj`),
  KEY `fk_permisosxobj_ref_permisoelemxobjs` (`idpermisosobj`),
  CONSTRAINT `fk_permisosxobj_ref_permisoelemxobjs` FOREIGN KEY (`idpermisosobj`) REFERENCES `permisoxobjetos` (`idpermisosobj`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisosxelementosobjeto`
--

LOCK TABLES `permisosxelementosobjeto` WRITE;
/*!40000 ALTER TABLE `permisosxelementosobjeto` DISABLE KEYS */;
/*!40000 ALTER TABLE `permisosxelementosobjeto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisosxmenu`
--

DROP TABLE IF EXISTS `permisosxmenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permisosxmenu` (
  `idpermisosmenu` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idrol` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `nombremenu` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `tipoobjeto` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `url` varchar(250) DEFAULT NULL COMMENT 'TRIAL',
  `imagen` varchar(250) DEFAULT NULL COMMENT 'TRIAL',
  `orden` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `tooltip` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idpermisosmenu`),
  KEY `fk_permisosxmenu_ref_roles` (`idrol`),
  CONSTRAINT `fk_permisosxmenu_ref_roles` FOREIGN KEY (`idrol`) REFERENCES `roles` (`idrol`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10003 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisosxmenu`
--

LOCK TABLES `permisosxmenu` WRITE;
/*!40000 ALTER TABLE `permisosxmenu` DISABLE KEYS */;
INSERT INTO `permisosxmenu` VALUES (10002,10004,'Administrar',NULL,'#','fa fa-unlock-alt',1,'1',1);
/*!40000 ALTER TABLE `permisosxmenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisosxsubmenu`
--

DROP TABLE IF EXISTS `permisosxsubmenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permisosxsubmenu` (
  `idpermisosxsubmenu` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idpermisosmenu` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `nombresubmenu` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `tipoobjeto` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `url` varchar(250) DEFAULT NULL COMMENT 'TRIAL',
  `imagen` varchar(250) DEFAULT NULL COMMENT 'TRIAL',
  `orden` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `tooltip` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idpermisosxsubmenu`),
  KEY `fk_permisosxmenu_ref_permisosxsubmenu` (`idpermisosmenu`),
  CONSTRAINT `fk_permisosxmenu_ref_permisosxsubmenu` FOREIGN KEY (`idpermisosmenu`) REFERENCES `permisosxmenu` (`idpermisosmenu`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10016 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisosxsubmenu`
--

LOCK TABLES `permisosxsubmenu` WRITE;
/*!40000 ALTER TABLE `permisosxsubmenu` DISABLE KEYS */;
INSERT INTO `permisosxsubmenu` VALUES (10002,10002,'Aplicaciones',NULL,'/Aplicaciones/AplicacionesLista.aspx','fa fa-file-code-o',1,'Aplicaciones',1),(10003,10002,'Roles',NULL,'/Roles/RolesLista.aspx','fa fa-sitemap',2,'Roles',1),(10004,10002,'Usuarios',NULL,'/Usuarios/UserAdmin.aspx','fa fa-users',3,'Usuarios',1),(10005,10002,'Servicios',NULL,'/Administrar/Servicios.aspx','fa fa-wifi',4,'Servivios',0),(10014,10002,'Catalogos',NULL,'/Common/Catalogos.aspx','fa fa-tasks',5,'CATALOGOS',1),(10015,10002,'AppConfig',NULL,'/Common/Configuracion.aspx','fa fa-cog',6,'Configuración',1);
/*!40000 ALTER TABLE `permisosxsubmenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisoxobjetos`
--

DROP TABLE IF EXISTS `permisoxobjetos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permisoxobjetos` (
  `idpermisosobj` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idrol` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `pagina` varchar(500) DEFAULT NULL COMMENT 'TRIAL',
  `nombreobjeto` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `tipoobjeto` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `tooltip` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idpermisosobj`),
  KEY `fk_permisoxobjeto_ref_roles` (`idrol`),
  CONSTRAINT `fk_permisoxobjeto_ref_roles` FOREIGN KEY (`idrol`) REFERENCES `roles` (`idrol`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisoxobjetos`
--

LOCK TABLES `permisoxobjetos` WRITE;
/*!40000 ALTER TABLE `permisoxobjetos` DISABLE KEYS */;
/*!40000 ALTER TABLE `permisoxobjetos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `idrol` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idaplicacion` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `descripcion` varchar(200) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idrol`),
  KEY `fk_roles_ref_aplicacion` (`idaplicacion`),
  CONSTRAINT `fk_roles_ref_aplicacion` FOREIGN KEY (`idaplicacion`) REFERENCES `aplicacion` (`idaplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10005 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (10003,10014,'ADMINISTRADOR',1),(10004,10015,'ADMINISTRADOR',1);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolesxusuario`
--

DROP TABLE IF EXISTS `rolesxusuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rolesxusuario` (
  `idrolxusuario` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idrol` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idusuario` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idestacionxapp` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idrolxusuario`),
  KEY `fk_rolesxperfil_ref_roles` (`idrol`),
  KEY `fk_rolesxus_ref_estacionesapp` (`idestacionxapp`),
  KEY `fk_rolesxusuario_ref_usuarios` (`idusuario`),
  CONSTRAINT `fk_rolesxperfil_ref_roles` FOREIGN KEY (`idrol`) REFERENCES `roles` (`idrol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rolesxus_ref_estacionesapp` FOREIGN KEY (`idestacionxapp`) REFERENCES `estacionesxapp` (`idestacionxapp`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rolesxusuario_ref_usuarios` FOREIGN KEY (`idusuario`) REFERENCES `usuarios` (`idusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10088 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolesxusuario`
--

LOCK TABLES `rolesxusuario` WRITE;
/*!40000 ALTER TABLE `rolesxusuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `rolesxusuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `idusuario` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idsexo` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `idtipopersona` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `idestadocivil` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `idarea` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `idtipousuario` int(11) DEFAULT NULL COMMENT 'TRIAL',
  `idusuarioapp` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `apaterno` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `amaterno` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `nombre` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `fechanacconst` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `usuario` varchar(500) DEFAULT NULL COMMENT 'TRIAL',
  `password` varchar(50) DEFAULT NULL COMMENT 'TRIAL',
  `rutafotoperfil` varchar(150) DEFAULT NULL COMMENT 'TRIAL',
  `fechaalta` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idusuario`),
  KEY `fk_usuarios_ref_cat_area` (`idarea`),
  KEY `fk_usuarios_ref_catedocivil` (`idestadocivil`),
  KEY `fk_usuarios_ref_catsexo` (`idsexo`),
  KEY `fk_usuarios_ref_cattipopersona` (`idtipopersona`),
  KEY `fk_usuarios_ref_cattipousuario` (`idtipousuario`),
  CONSTRAINT `fk_usuarios_ref_cat_area` FOREIGN KEY (`idarea`) REFERENCES `cat_area` (`idarea`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarios_ref_catedocivil` FOREIGN KEY (`idestadocivil`) REFERENCES `cat_estadocivil` (`idestadocivil`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarios_ref_catsexo` FOREIGN KEY (`idsexo`) REFERENCES `cat_sexo` (`idsexo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarios_ref_cattipopersona` FOREIGN KEY (`idtipopersona`) REFERENCES `cat_tipopersona` (`idtipopersona`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarios_ref_cattipousuario` FOREIGN KEY (`idtipousuario`) REFERENCES `cat_tipousuario` (`idtipousuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10074 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (10072,2,1,1,1,1,'jcesarmzamudio@gmail.com','MARTINEZ','ZAMUDIO','JULIO CESAR','1985-04-07 00:00:00.000','jcesarmzamudio@gmail.com','8426D7AD5F1C433DF38F7A9E2C','profile.jpg','2016-01-12 11:43:15.000',1),(10073,1,1,1,1,1,'10072','MARTINEZ','ZAMUDIO','JULIO CESAR','2025-03-11 18:31:09.240','sysmngr','8B539B85236B3245F1837C912AC1','profile.png','2025-03-11 12:45:23.685',1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarioxaplicacion`
--

DROP TABLE IF EXISTS `usuarioxaplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarioxaplicacion` (
  `idusrsxapp` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idaplicacion` bigint(20) NOT NULL COMMENT 'TRIAL',
  `idusuario` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idusrsxapp`),
  KEY `fk_usuarioxapp_ref_aplicacion` (`idaplicacion`),
  KEY `fk_usuarioxapp_ref_usuarios` (`idusuario`),
  CONSTRAINT `fk_usuarioxapp_ref_aplicacion` FOREIGN KEY (`idaplicacion`) REFERENCES `aplicacion` (`idaplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuarioxapp_ref_usuarios` FOREIGN KEY (`idusuario`) REFERENCES `usuarios` (`idusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10099 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarioxaplicacion`
--

LOCK TABLES `usuarioxaplicacion` WRITE;
/*!40000 ALTER TABLE `usuarioxaplicacion` DISABLE KEYS */;
INSERT INTO `usuarioxaplicacion` VALUES (10096,10014,10072,1),(10097,10015,10072,1),(10098,10016,10072,1);
/*!40000 ALTER TABLE `usuarioxaplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vwcattablascatalogos`
--

DROP TABLE IF EXISTS `vwcattablascatalogos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vwcattablascatalogos` (
  `idtable` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `name` varchar(128) NOT NULL COMMENT 'TRIAL'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vwcattablascatalogos`
--

LOCK TABLES `vwcattablascatalogos` WRITE;
/*!40000 ALTER TABLE `vwcattablascatalogos` DISABLE KEYS */;
INSERT INTO `vwcattablascatalogos` VALUES (1,'CAT_GRALS'),(2,'CAT_OPERACIONAUDIT'),(3,'CAT_TIPOPERSONAL');
/*!40000 ALTER TABLE `vwcattablascatalogos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wcfmetodos`
--

DROP TABLE IF EXISTS `wcfmetodos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wcfmetodos` (
  `idmetodos` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idaplicacion` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `idservicios` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `nombremetodo` varchar(100) DEFAULT NULL COMMENT 'TRIAL',
  `recurrente` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idmetodos`),
  KEY `fk_wcfmetodos_ref_aplicacion` (`idaplicacion`),
  KEY `fk_wcfmetodos_ref_wcfservicios` (`idservicios`),
  CONSTRAINT `fk_wcfmetodos_ref_aplicacion` FOREIGN KEY (`idaplicacion`) REFERENCES `aplicacion` (`idaplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_wcfmetodos_ref_wcfservicios` FOREIGN KEY (`idservicios`) REFERENCES `wcfservicios` (`idservicios`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=20130 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wcfmetodos`
--

LOCK TABLES `wcfmetodos` WRITE;
/*!40000 ALTER TABLE `wcfmetodos` DISABLE KEYS */;
INSERT INTO `wcfmetodos` VALUES (20037,10014,4,'addContactoCliente',NULL,1),(20038,10014,4,'SendEmailNOW',NULL,1),(20039,10014,4,'editContactoCliente',NULL,1),(20040,10014,1,'checkPermisoXMethServ',NULL,1),(20041,10014,1,'getObjetosXAppRolPage',NULL,1),(20042,10014,1,'getElementsObjectsXIdObj',NULL,1),(20043,10014,1,'getMenuXAppRol',NULL,1),(20044,10014,1,'getSubMenuXIdMenu',NULL,1),(20045,10014,1,'encryptDesEncrypt',NULL,1),(20046,10014,2,'addUsuario',NULL,1),(20047,10014,2,'getUsuarioFull',NULL,1),(20048,10014,2,'actDeactivateUsuario',NULL,1),(20049,10014,2,'updateUsuario',NULL,1),(20050,10014,2,'getUsuario',NULL,1),(20054,10014,2,'getRolesXApp',NULL,1),(20056,10014,1,'getAplicaciones',NULL,1),(20057,10014,1,'addAplicacion',NULL,1),(20058,10014,1,'updAplicacion',NULL,1),(20109,10014,1,'getMenuxRol',NULL,1),(20115,10014,2,'GetUsuarios',NULL,1),(20119,10014,2,'GetUsuario',NULL,1),(20120,10014,2,'GetRolesVsUser',NULL,1),(20121,10014,2,'getAppXUsuario',NULL,1),(20122,10014,1,'addRolxApp',NULL,1),(20123,10014,1,'addMenuxAppRol',NULL,1),(20124,10014,1,'updMenuxAppRol',NULL,1),(20125,10014,1,'updSubMenuxAppRol',NULL,1),(20126,10014,1,'getMenuxRolAdmin',NULL,1),(20127,10014,1,'addSubMenuxAppRol',NULL,1),(20128,10014,1,'checkMetodoXApp',NULL,1),(20129,10014,1,'addMetodo',NULL,1);
/*!40000 ALTER TABLE `wcfmetodos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wcfrecurrencia`
--

DROP TABLE IF EXISTS `wcfrecurrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wcfrecurrencia` (
  `idrecurrencia` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `idmetodos` bigint(20) DEFAULT NULL COMMENT 'TRIAL',
  `fechaacceso` datetime(3) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idrecurrencia`),
  KEY `fk_wcfrecurrencia_ref_wcfmetodos` (`idmetodos`),
  CONSTRAINT `fk_wcfrecurrencia_ref_wcfmetodos` FOREIGN KEY (`idmetodos`) REFERENCES `wcfmetodos` (`idmetodos`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wcfrecurrencia`
--

LOCK TABLES `wcfrecurrencia` WRITE;
/*!40000 ALTER TABLE `wcfrecurrencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `wcfrecurrencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wcfservicios`
--

DROP TABLE IF EXISTS `wcfservicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wcfservicios` (
  `idservicios` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'TRIAL',
  `descripcion` varchar(80) DEFAULT NULL COMMENT 'TRIAL',
  `activo` tinyint(1) DEFAULT NULL COMMENT 'TRIAL',
  PRIMARY KEY (`idservicios`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='TRIAL';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wcfservicios`
--

LOCK TABLES `wcfservicios` WRITE;
/*!40000 ALTER TABLE `wcfservicios` DISABLE KEYS */;
INSERT INTO `wcfservicios` VALUES (1,'SecurityService',1),(2,'UserSecurityService',1),(4,'CampanaService',1);
/*!40000 ALTER TABLE `wcfservicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'seguridad'
--
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFrontGetCatGenerales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFrontGetCatGenerales`( 

	p_IDCATGENERALES int /* = null */)
BEGIN



SELECT
	IDCATGENERALES
	, NOMBRECATALOGO
	, IDCATALOGO
	,DESCRIPCION
	,FILTRO
	,ACTIVO
FROM CATGENERALES
WHERE 
	IDCATGENERALES LIKE CASE WHEN IFNULL(p_IDCATGENERALES,'') = '' THEN IDCATGENERALES ELSE p_IDCATGENERALES END
	AND ACTIVO = 1;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFrontGetRolesVSUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFrontGetRolesVSUsuario`( 

p_IDUSUARIO nvarchar(10)
,p_IDAPLICACION nvarchar(10))
begin

SELECT 
	RL.IDROL
	,RL.DESCRIPCION
	,RL.IDAPLICACION
	,(SELECT APP.DESCRIPCION from APLICACION APP WHERE APP.IDAPLICACION = RL.IDAPLICACION) APLICACION
	,(SELECT RU.IDROLXUSUARIO from ROLESXUSUARIO RU WHERE RL.IDROL = RU.IDROL AND RU.IDUSUARIO = p_IDUSUARIO) IDROLXUSUARIO
	,CASE WHEN 
		IFNULL((SELECT RU.IDROLXUSUARIO from ROLESXUSUARIO RU WHERE RL.IDROL = RU.IDROL AND RU.IDUSUARIO = p_IDUSUARIO)
		,'') = '' THEN 0 ELSE 1 END AS ROLASIGNADO
FROM 
	ROLES RL
WHERE 
	RL.IDAPLICACION  = p_IDAPLICACION;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFrontGetUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFrontGetUsuario`(IN p_IDUSUARIO NVARCHAR(10))
BEGIN
SELECT
	IDUSUARIO,
	IDSEXO,
	IDTIPOPERSONA,
	IDESTADOCIVIL,
	IDAREA,
	IDTIPOUSUARIO,
	IDUSUARIOAPP,
	APATERNO,
	AMATERNO,
	NOMBRE,
	FECHANACCONST,
	USUARIO,
	PASSWORD,
	RUTAFOTOPERFIL,
	FECHAALTA,
	ACTIVO
FROM USUARIOS
WHERE IDUSUARIO = p_IDUSUARIO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFrontGetUsuarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFrontGetUsuarios`(IN 
p_IdAplicacion int /* = NULL */
,p_Nombre nvarchar(150) /* = '' */ 
,p_AMaterno nvarchar(150) /* = '' */
,p_APaterno nvarchar(150) /* = '' */
,p_Usuario nvarchar (150) /* = '' */)
BEGIN
DECLARE v_SQL LONGTEXT;
BEGIN

IF (p_Nombre <> '')
		THEN
			SET	p_Nombre = Concat('%', p_Nombre , '%');
		END IF;	
	IF (p_AMaterno <> '')
		THEN
			SET	p_AMaterno = Concat('%', p_AMaterno , '%');
		END IF;
	
	IF (p_Usuario <> '')
		THEN
			SET	p_Usuario = Concat('%', p_Usuario , '%');
		END IF;	
		IF (p_IdAplicacion IS NOT NULL OR p_IdAplicacion <> 0)
		THEN
			SET	p_IdAplicacion =  p_IdAplicacion; 
		END IF;		
	
		SELECT USR.IDUSUARIO, (SELECT CA.DESCRIPCION from CAT_AREA CA WHERE CA.IDAREA = USR.IDAREA) As AREA, USR.APATERNO,USR.AMATERNO,USR.NOMBRE,USR.FECHANACCONST,USR.IDUSUARIOAPP as USUARIO,USR.ACTIVO
	    FROM USUARIOS USR , USUARIOXAPLICACION USRXAPP
	    WHERE 1=1 
        AND USR.IDUSUARIO = USRXAPP.IDUSUARIO
        AND USRXAPP.IDAPLICACION = p_IdAplicacion
		AND USR.IDUSUARIOAPP like CASE WHEN IFNULL(p_Usuario,'') = '' THEN USR.IDUSUARIOAPP ELSE  p_Usuario END
	
		AND USR.NOMBRE like CASE WHEN IFNULL(p_Nombre,'') = '' THEN USR.NOMBRE ELSE  p_Nombre END
		AND IFNULL(USR.APATERNO,'') like CASE WHEN IFNULL(p_APaterno,'') = '' THEN IFNULL(USR.APATERNO,'') ELSE  IFNULL(p_APaterno,'') END
		AND IFNULL(USR.AMATERNO,'') like CASE WHEN IFNULL(p_AMaterno,'') = '' THEN IFNULL(USR.AMATERNO,'') ELSE  IFNULL(p_AMaterno,'') END;
	
END;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_actDeactUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_actDeactUsuario`(
	p_TIPOUSUARIOIN		INT,
	p_ACTDEACTIVATE		TINYINT,
	p_USUARIOIN			VARCHAR(150),
	p_IDAPLICACION		BIGINT,
	p_IDUSERMODIFICA		BIGINT /* = NULL */,
	p_IDAPPMODIFICA		BIGINT /* = NULL */
)
BEGIN

	DECLARE v_IDUSERIDENTITY BIGINT;
  DECLARE v_IDSEXO				INT;
  DECLARE v_IDTIPOPERSONA		INT;
  DECLARE v_IDESTADOCIVIL		INT;
  DECLARE v_IDAREA				INT;
  DECLARE v_IDTIPOUSUARIO		INT;
  DECLARE v_IDUSUARIOAPP		VARCHAR(100);
  DECLARE v_APATERNO			VARCHAR(100);
  DECLARE v_AMATERNO			VARCHAR(100);
  DECLARE v_NOMBRE				VARCHAR(150);
  DECLARE v_FECHANACCONST		DATETIME(3);
  DECLARE v_USUARIO			VARCHAR(500);
  DECLARE v_PASSWORD			VARCHAR(50);
  DECLARE v_RUTAFOTOPERFIL		VARCHAR(150);
  DECLARE v_FECHAALTA			DATETIME(3);
  DECLARE v_ACTIVO				TINYINT;
  DECLARE v_ESTADOCIVIL VARCHAR(1500);
  DECLARE v_TIPOPERSONA VARCHAR(150);
  DECLARE v_SEXO VARCHAR(150);
  DECLARE v_AREA VARCHAR(150);
  DECLARE v_TIPOUSUARIO VARCHAR(150);

	IF(p_TIPOUSUARIOIN = 1)
		THEN
			UPDATE `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			SET `ACTIVO` = p_ACTDEACTIVATE
			WHERE A.`IDUSUARIO` = CAST(p_USUARIOIN AS SIGNED INTEGER) 
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;

			SET v_IDUSERIDENTITY = (SELECT A.`IDUSUARIO`
									FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
									WHERE A.`IDUSUARIO` = CAST(p_USUARIOIN AS SIGNED INTEGER) 
									AND	B.`IDAPLICACION` = p_IDAPLICACION
									AND B.`IDUSUARIO` = A.IDUSUARIO);

	ELSEIF (p_TIPOUSUARIOIN = 2)
		THEN
			UPDATE `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			SET `ACTIVO` = p_ACTDEACTIVATE
			WHERE A.`IDUSUARIOAPP` = p_USUARIOIN
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;
			
			SET v_IDUSERIDENTITY = (SELECT A.`IDUSUARIO`
									FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
									WHERE A.`IDUSUARIOAPP` = p_USUARIOIN
									AND	B.`IDAPLICACION` = p_IDAPLICACION
									AND B.`IDUSUARIO` = A.IDUSUARIO);
	ELSEIF (p_TIPOUSUARIOIN = 3)
		THEN
			UPDATE `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			SET `ACTIVO` = p_ACTDEACTIVATE
			WHERE A.`USUARIO` = p_USUARIOIN
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;


			SET v_IDUSERIDENTITY = (SELECT A.`IDUSUARIO`
									FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
									WHERE A.`USUARIO` = p_USUARIOIN
									AND	B.`IDAPLICACION` = p_IDAPLICACION
									AND B.`IDUSUARIO` = A.IDUSUARIO);
	END IF;
		
	-- --A... SQLINES DEMO ***
	
	SELECT -- A.[... SQLINES DEMO ***
 A.`IDSEXO`
		, A.`IDTIPOPERSONA`
		, A.`IDESTADOCIVIL`
		, A.`IDAREA`
		, A.`IDTIPOUSUARIO`
		, A.`IDUSUARIOAPP`
		, A.`APATERNO`
		, A.`AMATERNO`
		, A.`NOMBRE`
		, A.`FECHANACCONST`
		, A.`USUARIO`
		, A.`PASSWORD`
		, A.`RUTAFOTOPERFIL`
		, A.`FECHAALTA`
		, A.`ACTIVO` INTO v_IDSEXO, v_IDTIPOPERSONA, v_IDESTADOCIVIL, v_IDAREA, v_IDTIPOUSUARIO, v_IDUSUARIOAPP, v_APATERNO, v_AMATERNO, v_NOMBRE, v_FECHANACCONST, v_USUARIO, v_PASSWORD, v_RUTAFOTOPERFIL, v_FECHAALTA, v_ACTIVO
	FROM `USUARIOS` AS A
	WHERE A.IDUSUARIO = v_IDUSERIDENTITY;

	SET v_ESTADOCIVIL = (SELECT `DESCRIPCION` FROM `CAT_ESTADOCIVIL` WHERE `IDESTADOCIVIL` = v_IDESTADOCIVIL AND `ACTIVO`=1
LIMIT 1);

	SET v_TIPOPERSONA = (SELECT `DESCRIPCION` FROM `CAT_TIPOPERSONA` WHERE `IDTIPOPERSONA` = v_IDTIPOPERSONA AND `ACTIVO`=1
LIMIT 1);

	SET v_SEXO = (SELECT `DESCRIPCION` FROM `CAT_SEXO` WHERE `IDSEXO` = v_IDSEXO AND `ACTIVO`=1
LIMIT 1);

	SET v_AREA  = (SELECT `DESCRIPCION` FROM `CAT_AREA` WHERE `IDAREA` = v_IDAREA AND `ACTIVO`=1
LIMIT 1);

	SET v_TIPOUSUARIO = (SELECT `DESCRIPCION` FROM `CAT_TIPOUSUARIO` WHERE `IDTIPOUSUARIO` = v_IDTIPOUSUARIO AND `ACTIVO`=1
LIMIT 1);


	IF(p_IDUSERMODIFICA IS NULL)
	THEN
		SET p_IDUSERMODIFICA = v_IDUSERIDENTITY;
	END IF;

	IF(p_IDAPPMODIFICA IS NULL)
		THEN
			SET p_IDAPPMODIFICA = p_IDAPLICACION;
		END IF;


	CALL	`spFront_AuditUser`(p_IDAPLICACION,
			2,
			v_IDUSERIDENTITY		,
			v_SEXO				,
			v_TIPOPERSONA		,
			v_ESTADOCIVIL		,
			v_AREA				,
			v_TIPOUSUARIO		,
			v_IDUSUARIOAPP		,
			v_APATERNO			,
			v_AMATERNO			,
			v_NOMBRE				,
			v_FECHANACCONST		,
			v_USUARIO			,
			v_PASSWORD			,
			v_RUTAFOTOPERFIL		,
			NULL				,
			v_ACTIVO				,
			p_IDUSERMODIFICA		,
			p_IDAPPMODIFICA);


SELECT v_IDUSERIDENTITY;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_addUsuarioXAplicacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_addUsuarioXAplicacion`(
	p_IDUSRSXAPP				nvarchar(10),
	p_IDAPLICACION			nvarchar(10),
	p_IDUSUARIO		nvarchar(10) /* = NULL */,
	p_ACTIVO nvarchar(10) /* = NULL */
)
begin
--  SQLINES DEMO *** P AS BIGINT
--  SQLINES DEMO *** ION AS BIGINT
--  SQLINES DEMO ***  AS BIGINT
--  SQLINES DEMO ***  BIGINT

IF(ifnull(p_IDUSRSXAPP,'') = '')
then
IF NOT EXISTS(SELECT * FROM USUARIOXAPLICACION WHERE IDAPLICACION = p_IDAPLICACION AND IDUSUARIO = p_IDUSUARIO )
THEN
		INSERT INTO USUARIOXAPLICACION (IDAPLICACION, IDUSUARIO, ACTIVO)
			VALUES ( p_IDAPLICACION, p_IDUSUARIO, p_ACTIVO);
			END IF;

 ELSE
UPDATE USUARIOXAPLICACION
	SET ACTIVO = p_ACTIVO
WHERE
	IDUSRSXAPP = p_IDUSRSXAPP;
END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_AuditUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_AuditUser`(
	p_IDAPLICACION		BIGINT,
	p_IDOPERACIONAUDIT	INT,
	p_IDUSUARIO			BIGINT,
	p_IDSEXO				VARCHAR(150) /* = NULL */,
	p_IDTIPOPERSONA		VARCHAR(150) /* = NULL */,
	p_IDESTADOCIVIL		VARCHAR(150) /* = NULL */,
	p_AREA				VARCHAR(150) /* = NULL */,
	p_TIPOUSUARIO		VARCHAR(150) /* = NULL */,
	p_IDUSUARIOAPP		VARCHAR(100) /* = NULL */,
	p_APATERNO			VARCHAR(100) /* = NULL */,
	p_AMATERNO			VARCHAR(100) /* = NULL */,
	p_NOMBRE				VARCHAR(150) /* = NULL */,
	p_FECHANACCONST		DATETIME(3) /* = NULL */,
	p_USUARIO			VARCHAR(500) /* = NULL */,
	p_PASSWORD			VARCHAR(50) /* = NULL */,
	p_RUTAFOTOPERFIL		VARCHAR(150) /* = NULL */,
	p_FECHAALTA			DATETIME(3) /* = NULL */,
	p_ACTIVO				TINYINT /* = NULL */,
	p_IDUSERMODIFICA		BIGINT /* = NULL */,
	p_IDAPPMODIFICA		BIGINT /* = NULL */
)
BEGIN

INSERT INTO `AUDIT_USUARIOS`
           (`IDAPLICACION`
           ,`IDOPERACIONAUDIT`
           ,`IDUSUARIO`
           ,`IDSEXO`
           ,`IDTIPOPERSONA`
           ,`IDESTADOCIVIL`
		   ,`IDAREA`
		   ,`IDTIPOUSUARIO`
           ,`IDUSUARIOAPP`
           ,`APATERNO`
           ,`AMATERNO`
           ,`NOMBRE`
           ,`FECHANACCONST`
           ,`USUARIO`
           ,`PASSWORD`
           ,`RUTAFOTOPERFIL`
           ,`FECHAALTA`
		   ,`ACTIVOUSR`
           ,`IDUSERMODIFICA`
		   ,`IDAPPMODIFICA`
		   ,`FECHATRANSACCION`
           ,`ACTIVO`)
     VALUES
           (p_IDAPLICACION
           ,p_IDOPERACIONAUDIT
           ,p_IDUSUARIO
           ,p_IDSEXO
           ,p_IDTIPOPERSONA
           ,p_IDESTADOCIVIL
		   ,p_AREA
		   ,p_TIPOUSUARIO
           ,p_IDUSUARIOAPP
           ,p_APATERNO
           ,p_AMATERNO
           ,p_NOMBRE
           ,p_FECHANACCONST
           ,p_USUARIO
           ,p_PASSWORD
		   ,p_RUTAFOTOPERFIL
		   ,p_FECHAALTA
		   ,p_ACTIVO
		   ,p_IDUSERMODIFICA
		   ,p_IDAPPMODIFICA
           ,NOW(3)
           ,1);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_checkMenuxAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_checkMenuxAppRol`(
	p_MENU	VARCHAR(200),
	p_IDROL BIGINT
	-- @ID... SQLINES DEMO ***
)
BEGIN
	SELECT -- [ID... SQLINES DEMO ***
	  `IDROL`
      ,`NOMBREMENU`
      ,`ACTIVO`
	FROM PERMISOSXMENU
	WHERE 
    `NOMBREMENU` = p_MENU 
    --  SQLINES DEMO ***  @IDAPLICACION 
    AND IDROL = p_IDROL;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_checkMetodo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_checkMetodo`(
	p_METODO	VARCHAR(200),
	p_IDAPLICACION  BIGINT,
	p_IDSERVICIOS  BIGINT
	
)
BEGIN
	SELECT `IDMETODOS`
      ,`IDAPLICACION`
      ,`IDSERVICIOS`
      ,`NOMBREMETODO`
      ,`RECURRENTE`
      ,`ACTIVO`
	FROM `WCFMETODOS`
	WHERE `NOMBREMETODO` = p_METODO AND `IDAPLICACION` = p_IDAPLICACION AND `IDSERVICIOS` = p_IDSERVICIOS;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_checkRolxApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_checkRolxApp`(
	p_ROL	VARCHAR(200),
	p_IDAPLICACION BIGINT
)
BEGIN
	SELECT `IDAPLICACION`
	  ,`IDROL`
      ,`DESCRIPCION`
      ,`ACTIVO`
	FROM `ROLES`
	WHERE `DESCRIPCION` = p_ROL AND IDAPLICACION = p_IDAPLICACION;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_checkServicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_checkServicio`(
	p_SERVICIO	VARCHAR(200)
)
BEGIN
	SELECT `IDSERVICIOS`
      ,`DESCRIPCION`
      ,`ACTIVO`
	FROM `WCFSERVICIOS`
	WHERE `DESCRIPCION` = p_SERVICIO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_checkSubMenuxAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_checkSubMenuxAppRol`(
	p_SUBMENU	VARCHAR(200),
	p_IDPERMISOSMENU BIGINT
	
)
BEGIN
	SELECT `IDPERMISOSXSUBMENU`
      ,`IDPERMISOSMENU`
      ,`NOMBRESUBMENU`
      ,`TIPOOBJETO`
      ,`URL`
      ,`IMAGEN`
      ,`ORDEN`
      ,`TOOLTIP`
      ,`ACTIVO`
	FROM PERMISOSXSUBMENU
	WHERE `NOMBRESUBMENU` = p_SUBMENU AND `IDPERMISOSMENU` = p_IDPERMISOSMENU;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_checkUsrXApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_checkUsrXApp`(
	p_TIPOBUSQUEDA		INT,
	p_IDAPLICACION		BIGINT,
	p_USUARIO			VARCHAR(150)
)
BEGIN

	IF(p_TIPOBUSQUEDA = 1)
		THEN
			SELECT B.`IDUSRSXAPP`
			  ,B.`IDAPLICACION`
			  ,B.`IDUSUARIO`
			  ,B.`ACTIVO`
			FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			WHERE A.`IDUSUARIO` = CAST(p_USUARIO AS signed integer) 
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;
	ELSEIF (p_TIPOBUSQUEDA = 2)
		THEN
			SELECT B.`IDUSRSXAPP`
			  ,B.`IDAPLICACION`
			  ,B.`IDUSUARIO`
			  ,B.`ACTIVO`
			FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			WHERE A.`IDUSUARIOAPP` = p_USUARIO
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;
	ELSEIF (p_TIPOBUSQUEDA = 3)
		THEN
			SELECT B.`IDUSRSXAPP`
			  ,B.`IDAPLICACION`
			  ,B.`IDUSUARIO`
			  ,B.`ACTIVO`
			FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			WHERE A.`USUARIO` = p_USUARIO
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_checkXApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_checkXApp`(
	p_APLICACION	VARCHAR(200)
)
BEGIN
	SELECT `IDAPLICACION`
      ,`DESCRIPCION`
      ,`PASSWORD`
      ,`ACTIVO`
	FROM `APLICACION`
	WHERE `DESCRIPCION` = p_APLICACION;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_delMenusXAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_delMenusXAppRol`(
	p_IdMenu     BIGINT 
)
BEGIN
	DELETE FROM PERMISOSXMENU
	WHERE IDPERMISOSMENU = p_IdMenu;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_delSubMenusXAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_delSubMenusXAppRol`(
	p_IdSubMenu     BIGINT 
)
BEGIN
	DELETE FROM PERMISOSXSUBMENU
	WHERE IDPERMISOSXSUBMENU = p_IdSubMenu;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getAplicaciones` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getAplicaciones`(
p_IDAPLICACION VARCHAR(50) /* = NULL */,
p_TXTBUSQUEDA NVARCHAR(100) /* = NULL */)
BEGIN
IF p_TXTBUSQUEDA IS NULL OR p_TXTBUSQUEDA = ''
THEN
IF p_IDAPLICACION IS NULL OR p_IDAPLICACION='' 
THEN
	SELECT `IDAPLICACION`
      ,`DESCRIPCION`
      ,`PASSWORD`
      ,`ACTIVO`
	FROM `APLICACION`
	WHERE `ACTIVO` = 1;
ELSE
    SELECT `IDAPLICACION`
      ,`DESCRIPCION`
      ,`PASSWORD`
      ,`ACTIVO`
	FROM `APLICACION`
	WHERE`IDAPLICACION` = p_IDAPLICACION AND `ACTIVO` = 1;
END IF;
ELSE
SELECT `IDAPLICACION`
      ,`DESCRIPCION`
      ,`PASSWORD`
      ,`ACTIVO`
	FROM `APLICACION`
	WHERE DESCRIPCION LIKE Concat('%' , p_TXTBUSQUEDA , '%') AND ACTIVO = 1;
	
END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getAppsXUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getAppsXUsuario`(
	p_TIPOBUSQUEDA		INT,
	p_USUARIO			VARCHAR(150)
)
BEGIN

	IF(p_TIPOBUSQUEDA = 1)
		THEN

			SELECT A.`IDAPLICACION`
				,A.`DESCRIPCION`
				,A.`PASSWORD`
				,A.`URLINICIO`
				,A.`ACTIVO`
				,B.`IDUSRSXAPP`
			FROM `APLICACION` AS A, `USUARIOXAPLICACION` AS B
			WHERE B.`IDUSUARIO` =  CAST(p_USUARIO AS SIGNED INTEGER) 
			AND A.IDAPLICACION = B.IDAPLICACION;

	ELSEIF (p_TIPOBUSQUEDA = 2)
		THEN

			SELECT A.`IDAPLICACION`
				,A.`DESCRIPCION`
				,A.`PASSWORD`
				,A.`URLINICIO`
				,A.`ACTIVO`
				,B.`IDUSRSXAPP`
			FROM `APLICACION` AS A, `USUARIOXAPLICACION` AS B,
			`USUARIOS` AS C
			WHERE C.`IDUSUARIOAPP` =  p_USUARIO
			AND A.IDAPLICACION = B.IDAPLICACION
			AND B.IDUSUARIO = C.IDUSUARIO;

	ELSEIF (p_TIPOBUSQUEDA = 3)
		THEN

			SELECT A.`IDAPLICACION`
				,A.`DESCRIPCION`
				,A.`PASSWORD`
				,A.`URLINICIO`
				,A.`ACTIVO`
				,B.`IDUSRSXAPP`
			FROM `APLICACION` AS A, `USUARIOXAPLICACION` AS B,
			`USUARIOS` AS C
			WHERE C.`USUARIO` =  p_USUARIO
			AND A.IDAPLICACION = B.IDAPLICACION
			AND B.IDUSUARIO = C.IDUSUARIO;

	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getContactos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getContactos`(
	p_IDUSUARIO			BIGINT 
)
BEGIN

	SELECT `IDCONTACTO`
      ,`IDUSUARIO`
      ,`IDTIPOCONTACTO`
	  ,(SELECT TC.DESCRIPCION FROM CAT_TIPOCONTACTO TC WHERE TC.IDTIPOCONTACTO = CONTACTO.IDTIPOCONTACTO) TIPOCONTACTO
      ,`VALOR`
      ,`FECHAALTA`
      ,`ACTIVO`
	FROM `CONTACTO`
	WHERE `IDUSUARIO` = p_IDUSUARIO;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getDomicilios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getDomicilios`(
	p_IDUSUARIO			BIGINT
)
BEGIN

	SELECT `IDDOMICILIO`
      ,`IDUSUARIO`
      ,`CALLE`
      ,`NUMEXT`
      ,`NUMINT`
      ,`IDESTADO`
      ,`ESTADO`
      ,`IDMUN`
      ,`MUNICIPIO`
      ,`IDCOLONIA`
      ,`COLONIA`
      ,`CP`
      ,`FECHAALTA`
      ,`ACTIVO`
	FROM `DOMICILIO`
	WHERE `IDUSUARIO` = p_IDUSUARIO;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getElementsObjectsXIdObj` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getElementsObjectsXIdObj`(
	p_IDELEMENTOSXOBJ	BIGINT
)
BEGIN

	SELECT `IDELEMENTOSXOBJ`
      ,`IDPERMISOSOBJ`
      ,`ELEMENTO`
	  ,`TOOLTIP`
      ,`ACTIVO`
	FROM `PERMISOSXELEMENTOSOBJETO`
	WHERE IDELEMENTOSXOBJ = p_IDELEMENTOSXOBJ
	AND `ACTIVO` = 1;
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getEstacionesXApps` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getEstacionesXApps`(
	p_IDAPLICACION		BIGINT
)
BEGIN

	SELECT `IDESTACIONXAPP`
		,`IDAPLICACION`
		,`IDESTACION`
		,`ACTIVO`
	FROM `ESTACIONESXAPP`
	WHERE `IDAPLICACION` = p_IDAPLICACION
	AND `ACTIVO` = 1;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getMenusXAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getMenusXAppRol`(
	p_IdApp		BIGINT,
	p_IdRol		BIGINT
)
BEGIN

	SELECT A.`IDPERMISOSMENU`
		  ,A.`IDROL`
		  ,A.`NOMBREMENU`
		  ,A.`IMAGEN`
		  ,A.`TIPOOBJETO`
		  ,A.`URL`
		  ,A.`TOOLTIP`
		  ,A.`ACTIVO`
		  ,A.`ORDEN`
	FROM `PERMISOSXMENU`AS A,
	ROLES AS B
	WHERE A.IDROL = B.IDROL
	AND B.IDROL = p_IdRol
	AND B.IDAPLICACION = p_IdApp
	AND A.`ACTIVO` = 1
	ORDER BY `ORDEN`; 
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getMenusXAppRolAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getMenusXAppRolAdmin`(
	p_IdApp		BIGINT,
	p_IdRol		BIGINT
)
BEGIN

	SELECT A.`IDPERMISOSMENU`
		  ,A.`IDROL`
		  ,A.`NOMBREMENU`
		  ,A.`IMAGEN`
		  ,A.`TIPOOBJETO`
		  ,A.`URL`
		  ,A.`TOOLTIP`
		  ,A.`ACTIVO`
		  ,A.`ORDEN`
	FROM `PERMISOSXMENU`AS A,
	ROLES AS B
	WHERE A.IDROL = B.IDROL
	AND B.IDROL = p_IdRol
	AND B.IDAPLICACION = p_IdApp;
	
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getMetodoXApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getMetodoXApp`(
	p_IdApp			BIGINT /* = NULL */,
	p_SERVICENAME	VARCHAR(100) /* = NULL */,
	p_METHODNAME		VARCHAR(100) /* = NULL */
)
BEGIN

	SELECT A.`IDMETODOS`
		,A.`IDAPLICACION`
		,A.`IDSERVICIOS`
		,A.`NOMBREMETODO`
		,A.`RECURRENTE`
		,A.`ACTIVO`
	FROM `WCFMETODOS` AS A,
	`WCFSERVICIOS` AS B
	WHERE A.IDSERVICIOS = B.IDSERVICIOS
	AND A.`IDAPLICACION` LIKE CASE WHEN ifnull(p_IdApp,'') ='' THEN A.IDAPLICACION ELSE p_IdApp END
	AND B.`DESCRIPCION` LIKE CASE WHEN ifnull(p_SERVICENAME,'') = '' THEN B.`DESCRIPCION` ELSE p_SERVICENAME END
	AND A.`NOMBREMETODO` LIKE CASE WHEN ifnull(p_METHODNAME,'') = '' THEN a.NOMBREMETODO ELSE p_METHODNAME END
	AND A.`ACTIVO` = 1;
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getObjetosXAppRolPage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getObjetosXAppRolPage`(
	p_IdApp		BIGINT,
	p_IdRol		BIGINT,
	p_Pagina		VARCHAR(500)
)
BEGIN

	SELECT A.`IDPERMISOSOBJ`
      ,A.`IDROL`
      ,A.`PAGINA`
      ,A.`NOMBREOBJETO`
      ,A.`TIPOOBJETO`
      ,A.`TOOLTIP`
      ,A.`ACTIVO`
	FROM `PERMISOXOBJETOS` AS A,
	ROLES AS B
	WHERE A.IDROL = B.IDROL
	AND B.IDROL = p_IdRol
	AND B.IDAPLICACION = p_IdApp
	AND A.PAGINA = p_Pagina
	AND A.`ACTIVO` = 1;
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getRolesXApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getRolesXApp`(
	p_IDAPLICACION		BIGINT
)
BEGIN

	SELECT `IDROL`
		  ,`IDAPLICACION`
		  ,`DESCRIPCION`
		  ,`ACTIVO`
	FROM `ROLES`
	WHERE `IDAPLICACION` = p_IDAPLICACION;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getRolesXUserApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getRolesXUserApp`(
	p_TIPOBUSQUEDA		INT,
	p_USUARIO			VARCHAR(500),
	p_IDAPLICACION		BIGINT /* = null */
)
BEGIN

	IF(p_TIPOBUSQUEDA = 1)
		THEN
			SELECT A.`IDROLXUSUARIO`
			  ,A.`IDROL`
			  ,(SELECT DESCRIPCION FROM `ROLES` WHERE IDROL = A.`IDROL`
LIMIT 1) AS DESCROL
			  ,A.`IDUSUARIO`
			  ,A.`IDESTACIONXAPP`
			  ,A.`ACTIVO`
			  ,D.IDAPLICACION
			  ,(SELECT Ap.DESCRIPCION FROM APLICACION Ap WHERE Ap.IDAPLICACION = D.IDAPLICACION) AS DescripcionAplicacion
			FROM `ROLESXUSUARIO` AS A, `USUARIOS` AS B,
			USUARIOXAPLICACION AS C, ROLES AS D
			WHERE B.`IDUSUARIO` = CAST(p_USUARIO AS UNSIGNED INTEGER) 
			AND A.`IDUSUARIO` = B.`IDUSUARIO`
			AND B.`IDUSUARIO` = C.`IDUSUARIO`
			AND C.`IDAPLICACION` = D.`IDAPLICACION`
			AND	C.`IDAPLICACION` Like CASE WHEN IFNULL(p_IDAPLICACION,'') = '' THEN C.`IDAPLICACION` ELSE p_IDAPLICACION end	
			AND D.IDAPLICACION LIKE CASE WHEN IFNULL(p_IDAPLICACION,'') = '' THEN D.IDAPLICACION ELSE p_IDAPLICACION END
			AND D.IDROL = A.IDROL
			AND A.ACTIVO = 1
			AND B.ACTIVO=1;
	ELSEIF (p_TIPOBUSQUEDA = 2)
		THEN
			SELECT A.`IDROLXUSUARIO`
			  ,A.`IDROL`
			  ,(SELECT DESCRIPCION FROM `ROLES` WHERE IDROL = A.`IDROL`
LIMIT 1) AS DESCROL
			  ,A.`IDUSUARIO`
			  ,A.`IDESTACIONXAPP`
			  ,A.`ACTIVO`
			  ,D.IDAPLICACION
			  ,(SELECT Ap.DESCRIPCION FROM APLICACION Ap WHERE Ap.IDAPLICACION = D.IDAPLICACION) AS DescripcionAplicacion
			FROM `ROLESXUSUARIO` AS A, `USUARIOS` AS B,
			USUARIOXAPLICACION AS C, ROLES AS D
			WHERE B.`IDUSUARIOAPP` = p_USUARIO 
			AND A.`IDUSUARIO` = B.`IDUSUARIO`
			AND B.`IDUSUARIO` = C.`IDUSUARIO`
			AND C.`IDAPLICACION` = D.`IDAPLICACION`
			AND	C.`IDAPLICACION` = p_IDAPLICACION
			AND D.IDAPLICACION = p_IDAPLICACION
			AND D.IDROL = A.IDROL
			AND A.ACTIVO = 1
			AND B.ACTIVO=1;
	ELSEIF (p_TIPOBUSQUEDA = 3)
		THEN
			SELECT A.`IDROLXUSUARIO`
			  ,A.`IDROL`
			  ,(SELECT DESCRIPCION FROM `ROLES` WHERE IDROL = A.`IDROL`
LIMIT 1) AS DESCROL
			  ,A.`IDUSUARIO`
			  ,A.`IDESTACIONXAPP`
			  ,A.`ACTIVO`
			  ,D.IDAPLICACION
			  ,(SELECT Ap.DESCRIPCION FROM APLICACION Ap WHERE Ap.IDAPLICACION = D.IDAPLICACION) AS DescripcionAplicacion
			FROM `ROLESXUSUARIO` AS A, `USUARIOS` AS B,
			USUARIOXAPLICACION AS C, ROLES AS D
			WHERE B.`USUARIO` = p_USUARIO 
			AND A.`IDUSUARIO` = B.`IDUSUARIO`
			AND B.`IDUSUARIO` = C.`IDUSUARIO`
			AND C.`IDAPLICACION` = D.`IDAPLICACION`
			AND	C.`IDAPLICACION` = p_IDAPLICACION
			AND D.IDAPLICACION = p_IDAPLICACION
			AND D.IDROL = A.IDROL
			AND A.ACTIVO = 1
			AND B.ACTIVO=1;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getSubMenusXIdMenu` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getSubMenusXIdMenu`(
	p_IDPERMISOSMENU	BIGINT
)
BEGIN
	SELECT `IDPERMISOSXSUBMENU`
      ,`IDPERMISOSMENU`
      ,`NOMBRESUBMENU`
	  ,`IMAGEN`
      ,`TIPOOBJETO`
	  ,`URL`
      ,`TOOLTIP`
      ,`ACTIVO`
	  ,`ORDEN`
	FROM `PERMISOSXSUBMENU`
	WHERE IDPERMISOSMENU = p_IDPERMISOSMENU
	AND `ACTIVO` = 1;		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getSubMenusXIdMenuAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getSubMenusXIdMenuAdmin`(
	p_IDPERMISOSMENU	BIGINT
)
BEGIN
	SELECT `IDPERMISOSXSUBMENU`
      ,`IDPERMISOSMENU`
      ,`NOMBRESUBMENU`
	  ,`IMAGEN`
      ,`TIPOOBJETO`
	  ,`URL`
      ,`TOOLTIP`
      ,`ACTIVO`
	  ,`ORDEN`
	FROM `PERMISOSXSUBMENU`
	WHERE IDPERMISOSMENU = p_IDPERMISOSMENU;
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_getUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_getUsuario`(
	p_TIPOBUSQUEDA		INT,
	p_USUARIO			VARCHAR(500),
	p_IDAPLICACION		BIGINT /* = null */
)
BEGIN

	IF(p_TIPOBUSQUEDA = 1)
		THEN
			SELECT A.`IDUSUARIO`
			  ,A.`IDSEXO`
			  ,A.`IDTIPOPERSONA`
			  ,A.`IDESTADOCIVIL`
			  ,A.`IDAREA`
			  ,(SELECT DESCRIPCION FROM `CAT_AREA` WHERE IDAREA = A.`IDAREA`
LIMIT 1) AS DESCAREA
			  ,A.`IDTIPOUSUARIO`
			  ,(SELECT DESCRIPCION FROM `CAT_TIPOUSUARIO` WHERE IDTIPOUSUARIO = A.`IDTIPOUSUARIO`
LIMIT 1) AS DESCIDTIPOUSUARIO
			  ,A.`IDUSUARIOAPP`		
			  ,A.`APATERNO`
			  ,A.`AMATERNO`
			  ,A.`NOMBRE`
			  ,A.`FECHANACCONST`
			  ,A.`USUARIO`
			  ,A.`PASSWORD`
			  ,A.`RUTAFOTOPERFIL`
			  ,A.`FECHAALTA`
			  ,A.`ACTIVO`
			  ,B.`IDAPLICACION`
			FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			WHERE A.`IDUSUARIO` = CAST(p_USUARIO AS signed integer) 
			AND	B.`IDAPLICACION` LIKE CASE WHEN IFNULL(p_IDAPLICACION,'') = '' THEN B.`IDAPLICACION` ELSE p_IDAPLICACION END
			AND B.`IDUSUARIO` LIKE CASE WHEN IFNULL(p_IDAPLICACION,'') = '' THEN B.`IDUSUARIO` else A.IDUSUARIO END;
			-- AND... SQLINES DEMO ***
	ELSEIF (p_TIPOBUSQUEDA = 2)
		THEN
			SELECT A.`IDUSUARIO`
			  ,A.`IDSEXO`
			  ,A.`IDTIPOPERSONA`
			  ,A.`IDESTADOCIVIL`
			  ,A.`IDAREA`
			  ,(SELECT DESCRIPCION FROM `CAT_AREA` WHERE IDAREA = A.`IDAREA`
LIMIT 1) AS DESCAREA
			  ,A.`IDTIPOUSUARIO`
			  ,(SELECT DESCRIPCION FROM `CAT_TIPOUSUARIO` WHERE IDTIPOUSUARIO = A.`IDTIPOUSUARIO`
LIMIT 1) AS DESCIDTIPOUSUARIO
			  ,A.`IDUSUARIOAPP`
			  ,A.`APATERNO`
			  ,A.`AMATERNO`
			  ,A.`NOMBRE`
			  ,A.`FECHANACCONST`
			  ,A.`USUARIO`
			  ,A.`PASSWORD`
			  ,A.`RUTAFOTOPERFIL`
			  ,A.`FECHAALTA`
			  ,A.`ACTIVO`
			  ,B.`IDAPLICACION`
			FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			WHERE A.`IDUSUARIOAPP` = p_USUARIO
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;
			-- AND... SQLINES DEMO ***
	ELSEIF (p_TIPOBUSQUEDA = 3)
		THEN
			SELECT A.`IDUSUARIO`
			  ,A.`IDSEXO`
			  ,A.`IDTIPOPERSONA`
			  ,A.`IDESTADOCIVIL`
			  ,A.`IDAREA`
			  ,(SELECT DESCRIPCION FROM `CAT_AREA` WHERE IDAREA = A.`IDAREA`
LIMIT 1) AS DESCAREA
			  ,A.`IDTIPOUSUARIO`
			  ,(SELECT DESCRIPCION FROM `CAT_TIPOUSUARIO` WHERE IDTIPOUSUARIO = A.`IDTIPOUSUARIO`
LIMIT 1) AS DESCIDTIPOUSUARIO
			  ,A.`IDUSUARIOAPP`
			  ,A.`APATERNO`
			  ,A.`AMATERNO`
			  ,A.`NOMBRE`
			  ,A.`FECHANACCONST`
			  ,A.`USUARIO`
			  ,A.`PASSWORD`
			  ,A.`RUTAFOTOPERFIL`
			  ,A.`FECHAALTA`
			  ,A.`ACTIVO`
			  ,B.`IDAPLICACION`
			FROM `USUARIOS` AS A, `USUARIOXAPLICACION` AS B
			WHERE A.`USUARIO` = p_USUARIO
			AND	B.`IDAPLICACION` = p_IDAPLICACION
			AND B.`IDUSUARIO` = A.IDUSUARIO;
			-- AND... SQLINES DEMO ***
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insAplicacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insAplicacion`(
		p_DESCRIPCION		VARCHAR(200),
		p_PASSWORD			VARCHAR(200),
        p_XAPPID			VARCHAR(200),
        p_URLINICIO			VARCHAR(500),
        p_JWTKEY			VARCHAR(200),
        p_JWTEXPIRATIONTIME	VARCHAR(200),
		p_ACTIVO				TINYINT
)
BEGIN

	INSERT INTO `APLICACION`
           (`DESCRIPCION`
           ,`PASSWORD`
            ,`XAPPID`
             ,`URLINICIO`
              ,`JWTKEY`
               ,`JWTEXPIRATIONTIME`
           ,`ACTIVO`)
           
     VALUES
           (p_DESCRIPCION,
           p_PASSWORD,
            p_XAPPID,
             p_URLINICIO,
              p_JWTKEY,
               p_JWTEXPIRATIONTIME,
           p_ACTIVO);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insContacto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insContacto`(
		p_IDUSUARIO			BIGINT,
		p_IDTIPOCONTACTO		INT,
		p_VALOR				VARCHAR(100) /* = NULL */,
		p_FECHAALTA			DATETIME(3) /* = NULL */,
		p_ACTIVO				TINYINT /* = NULL */,
		p_IDAPLICACION		BIGINT,
		p_IDUSERMODIFICA		BIGINT /* = NULL */,
		p_IDAPPMODIFICA		BIGINT /* = NULL */
)
BEGIN

	
  DECLARE v_IDCONTACTOIDENTITY BIGINT;
  DECLARE v_CONTACTO VARCHAR(100);
  INSERT INTO `CONTACTO`
           (`IDUSUARIO`
           ,`IDTIPOCONTACTO`
           ,`VALOR`
           ,`FECHAALTA`
           ,`ACTIVO`)
     VALUES
           (p_IDUSUARIO,
           p_IDTIPOCONTACTO,
           p_VALOR,
           p_FECHAALTA,
           p_ACTIVO);

	SELECT LAST_INSERT_ID() AS `SCOPE_IDENTITY`;
	SET v_IDCONTACTOIDENTITY = (SELECT LAST_INSERT_ID() AS `@@IDENTITY`);

	SET v_CONTACTO = (SELECT DESCRIPCION FROM CAT_TIPOCONTACTO WHERE IDTIPOCONTACTO = p_IDTIPOCONTACTO
LIMIT 1);

	IF(p_IDUSERMODIFICA IS NULL)
		THEN
			SET p_IDUSERMODIFICA = p_IDUSUARIO;
		END IF;

	IF(p_IDAPPMODIFICA IS NULL)
		THEN
			SET p_IDAPPMODIFICA = p_IDAPLICACION;
		END IF;

	CALL	`spFront_AuditContacto`(1
			,v_IDCONTACTOIDENTITY
			,p_IDUSUARIO
			,v_CONTACTO
			,p_VALOR
			,p_FECHAALTA
			,p_IDUSERMODIFICA
			,p_IDAPPMODIFICA);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insDomicilio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insDomicilio`(
		p_IDUSUARIO			BIGINT,
		p_CALLE				VARCHAR(100) /* = NULL */,
		p_NUMEXT				VARCHAR(20) /* = NULL */,
		p_NUMINT				VARCHAR(20) /* = NULL */,
		p_IDESTADO			INT /* = NULL */,
		p_ESTADO				VARCHAR(50) /* = NULL */,
		p_IDMUN				INT /* = NULL */,
		p_MUNICIPIO			VARCHAR(50) /* = NULL */,
		p_IDCOLONIA			INT /* = NULL */,
		p_COLONIA			VARCHAR(100) /* = NULL */,
		p_CP					VARCHAR(50) /* = NULL */,
		p_FECHAALTA			DATETIME(3) /* = NULL */,
		p_ACTIVO				TINYINT /* = NULL */,
		p_IDAPLICACION		BIGINT,
		p_IDUSERMODIFICA		BIGINT /* = NULL */,
		p_IDAPPMODIFICA		BIGINT /* = NULL */
)
BEGIN

	
  DECLARE v_IDDOMIDENTITY BIGINT;INSERT INTO `DOMICILIO`
           (`IDUSUARIO`
           ,`CALLE`
           ,`NUMEXT`
           ,`NUMINT`
           ,`IDESTADO`
           ,`ESTADO`
           ,`IDMUN`
           ,`MUNICIPIO`
           ,`IDCOLONIA`
           ,`COLONIA`
           ,`CP`
           ,`FECHAALTA`
           ,`ACTIVO`)
     VALUES
           (p_IDUSUARIO,
           p_CALLE,
           p_NUMEXT,
           p_NUMINT,
           p_IDESTADO,
           p_ESTADO,
           p_IDMUN,
           p_MUNICIPIO,
           p_IDCOLONIA,
           p_COLONIA,
           p_CP,
           p_FECHAALTA,
           p_ACTIVO);
	
	SELECT LAST_INSERT_ID() AS `SCOPE_IDENTITY`;
	SET v_IDDOMIDENTITY = (SELECT LAST_INSERT_ID() AS `@@IDENTITY`);

	IF(p_IDUSERMODIFICA IS NULL)
		THEN
			SET p_IDUSERMODIFICA = p_IDUSUARIO;
		END IF;

	IF(p_IDAPPMODIFICA IS NULL)
		THEN
			SET p_IDAPPMODIFICA = p_IDAPLICACION;
		END IF;

	CALL	`spFront_AuditDomicilio`(1,
		v_IDDOMIDENTITY,
		p_IDUSUARIO,
		p_CALLE,
		p_NUMEXT,
		p_NUMINT,
		p_IDESTADO,
		p_ESTADO,
		p_IDMUN,
		p_MUNICIPIO,
		p_IDCOLONIA,
		p_COLONIA,
		p_CP,
		p_FECHAALTA,
		P_IDUSERMODIFICA,
		P_IDAPPMODIFICA);	

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insMenuXAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insMenuXAppRol`(
	p_IDROL		    BIGINT,
	--  SQLINES DEMO *** GINT,
	p_NOMBREMENU		VARCHAR(500),
	p_IMAGEN			VARCHAR(500),
	p_TIPOOBJETO		VARCHAR(200),
	p_URL			VARCHAR(500),	
	p_TOOLTIP		VARCHAR(200),
	p_ORDEN			BIGINT	
)
BEGIN

	INSERT INTO `PERMISOSXMENU` 
	      (`IDROL`
		  -- ,[I... SQLINES DEMO ***
		  ,`NOMBREMENU`
		  ,`IMAGEN`
		  ,`TIPOOBJETO`
		  ,`URL`
		  ,`TOOLTIP`
		  ,`ACTIVO`
		  ,`ORDEN`)
		  VALUES
		  (p_IDROL
		  -- ,@I... SQLINES DEMO ***
		  ,p_NOMBREMENU
		  ,p_IMAGEN
		  ,p_TIPOOBJETO
		  ,p_URL
		  ,p_TOOLTIP
		  ,1
		  ,p_ORDEN);
		  	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insMetodosxApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insMetodosxApp`(
	p_IDMETODOS	BIGINT, 
	p_IDAPLICACION	BIGINT,	
	p_IDSERVICIOS	BIGINT,
	p_NOMBREMETODO	VARCHAR(500),
	p_RECURRENTE		TINYINT,
	p_ACTIVO tinyint
	
)
BEGIN

IF (p_IDMETODOS = 0)
THEN
	INSERT INTO `WCFMETODOS` 
	      (`IDAPLICACION`
		  ,`IDSERVICIOS`
		  ,`NOMBREMETODO`
		  ,`RECURRENTE`
		  ,`ACTIVO`)
		  VALUES
		  (p_IDAPLICACION
		  ,p_IDSERVICIOS
		  ,p_NOMBREMETODO
		  ,p_RECURRENTE
		  ,1);
ELSE
	UPDATE WCFMETODOS
	SET
	    --  SQLINES DEMO *** olumn value is auto-generated
	    WCFMETODOS.IDAPLICACION = p_IDAPLICACION, -- bi... SQLINES DEMO ***
	    WCFMETODOS.IDSERVICIOS = p_IDSERVICIOS, -- bi... SQLINES DEMO ***
	    WCFMETODOS.NOMBREMETODO = p_NOMBREMETODO, -- va... SQLINES DEMO ***
	    WCFMETODOS.RECURRENTE = p_RECURRENTE, -- bi... SQLINES DEMO ***
	    WCFMETODOS.ACTIVO = p_ACTIVO -- bi... SQLINES DEMO ***
		WHERE IDMETODOS = p_IDMETODOS;
END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insPermisosxObjeto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insPermisosxObjeto`(
	p_IDROL    BIGINT,
	p_PAGINA     VARCHAR(200),
	p_NOMBREOBJETO VARCHAR(200),
	p_TIPOOBJETO VARCHAR(100),
	p_TOOLTIP		VARCHAR(500)
)
BEGIN 
	INSERT INTO `PERMISOXOBJETOS` 
	      (`IDROL`
      ,`PAGINA`
      ,`NOMBREOBJETO`
      ,`TIPOOBJETO`
      ,`TOOLTIP`
      ,`ACTIVO`)
		  VALUES
		  (p_IDROL
		  ,p_PAGINA
		  ,p_NOMBREOBJETO
		  ,p_TIPOOBJETO
		  ,p_TIPOOBJETO
		  ,1);
		  	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insRolesXUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insRolesXUsuario`(
	p_IDROL			BIGINT,
	p_IDUSUARIO		BIGINT,
	p_IDESTACIONXAPP		BIGINT /* = NULL */
)
BEGIN

	INSERT INTO `ROLESXUSUARIO`
           (`IDROL`
           ,`IDUSUARIO`
           ,`IDESTACIONXAPP`
           ,`ACTIVO`)
     VALUES
           (p_IDROL
           ,p_IDUSUARIO
           ,p_IDESTACIONXAPP
           ,1);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insRolXApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insRolXApp`(
	p_ROL			VARCHAR(200),
	p_IDAPLICACION	BIGINT
)
BEGIN

	INSERT INTO `ROLES`
           (`IDAPLICACION`
           ,`DESCRIPCION`
           ,`ACTIVO`)
     VALUES
           (p_IDAPLICACION
           ,p_ROL
           ,1);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insRolXUserApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insRolXUserApp`(
	p_IDROL				BIGINT,
	p_IDUSUARIO			BIGINT,
	p_IDESTACIONXAPP		BIGINT /* = NULL */,
	p_IDROLXUSUARIO BIGINT /* = NULL */,
	p_ACTIVO TINYINT /* = NULL */
)
BEGIN

		if ifnull(p_IDROLXUSUARIO,'') = ''
		then
			INSERT INTO `ROLESXUSUARIO`
           (`IDROL`
           ,`IDUSUARIO`
           ,`IDESTACIONXAPP`
           ,`ACTIVO`)
     VALUES
           (p_IDROL
           ,p_IDUSUARIO
           ,p_IDESTACIONXAPP
           ,1);
		ELSE
			UPDATE ROLESXUSUARIO
			SET
				ACTIVO = p_ACTIVO
				,`IDROL` = p_IDROL
			WHERE
				IDROLXUSUARIO = p_IDROLXUSUARIO;
		END IF;
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insServicioWCF` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insServicioWCF`(
	p_DESCRIPCION		VARCHAR(500)
)
BEGIN
	INSERT INTO `WCFSERVICIOS` 
	      (`DESCRIPCION`
		  ,`ACTIVO`)
		  VALUES
		  (p_DESCRIPCION
		  ,1);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insSubMenuXAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insSubMenuXAppRol`(
	p_IDPERMISOSMENU     BIGINT,
	p_NOMBRESUBMENU		VARCHAR(500),
	p_IMAGEN			VARCHAR(500),
	p_TIPOOBJETO		VARCHAR(200),
	p_URL			VARCHAR(500),	
	p_TOOLTIP		VARCHAR(200),
	p_ORDEN			BIGINT	
)
BEGIN

	INSERT INTO `PERMISOSXSUBMENU` 
	      (`IDPERMISOSMENU`
		  ,`NOMBRESUBMENU`
		  ,`IMAGEN`
		  ,`TIPOOBJETO`
		  ,`URL`
		  ,`TOOLTIP`
		  ,`ACTIVO`
		  ,`ORDEN`)
		  VALUES
		  (p_IDPERMISOSMENU
		  ,p_NOMBRESUBMENU
		  ,p_IMAGEN
		  ,p_TIPOOBJETO
		  ,p_URL
		  ,p_TOOLTIP
		  ,1
		  ,p_ORDEN);
		  	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_insUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_insUser`(IN p_IDAPLICACION		BIGINT /* = NULL */,
	p_IDSEXO				INT /* = NULL */,
	p_IDTIPOPERSONA		INT /* = NULL */,
	p_IDESTADOCIVIL		INT /* = NULL */,
	p_IDAREA				INT /* = NULL */,
	p_IDTIPOUSUARIO		INT /* = NULL */,
	p_IDUSUARIOAPP		VARCHAR(100)/* = NULL */,
	p_APATERNO			VARCHAR(100) /* = NULL */,
	p_AMATERNO			VARCHAR(100) /* = NULL */,
	p_NOMBRE				VARCHAR(150) /* = NULL */,
	p_FECHANACCONST		DATETIME(3) /* = NULL */,
	p_USUARIO			VARCHAR(500) /* = NULL */,
	p_PASSWORD			VARCHAR(50) /* = NULL */,
	p_RUTAFOTOPERFIL		VARCHAR(150) /* = NULL */,
	p_FECHAALTA			DATETIME(3) /* = NULL */,
	p_ACTIVO				TINYINT /* = NULL */,
	p_IDUSERMODIFICA		BIGINT /* = NULL */,
	p_IDAPPMODIFICA		BIGINT
)
sp_lbl:

BEGIN

  DECLARE v_IDUSERIDENTITY BIGINT;
  DECLARE v_ESTADOCIVIL VARCHAR(1500);
  DECLARE v_TIPOPERSONA VARCHAR(150);
  DECLARE v_SEXO VARCHAR(150);
  DECLARE v_AREA VARCHAR(150);
  DECLARE v_TIPOUSUARIO VARCHAR(150);

	IF(p_IDUSUARIOAPP IS NOT NULL)
		THEN
			INSERT INTO `USUARIOS`
			   (`IDSEXO`
			   ,`IDTIPOPERSONA`
			   ,`IDESTADOCIVIL`
			   ,`IDAREA`
			   ,`IDTIPOUSUARIO`
			   ,`IDUSUARIOAPP`
			   ,`APATERNO`
			   ,`AMATERNO`
			   ,`NOMBRE`
			   ,`FECHANACCONST`
			   ,`USUARIO`
			   ,`PASSWORD`
			   ,`RUTAFOTOPERFIL`
			   ,`FECHAALTA`
			   ,`ACTIVO`)
			VALUES
			   (p_IDSEXO,
				p_IDTIPOPERSONA,
				p_IDESTADOCIVIL,
				p_IDAREA,
				p_IDTIPOUSUARIO,
				p_IDUSUARIOAPP,
				p_APATERNO,
				p_AMATERNO,
				p_NOMBRE,
				p_FECHANACCONST,
				p_USUARIO,
				p_PASSWORD,
				p_RUTAFOTOPERFIL,
				p_FECHAALTA,
				p_ACTIVO);

			SELECT LAST_INSERT_ID() AS `SCOPE_IDENTITY`;
			SET v_IDUSERIDENTITY = (SELECT LAST_INSERT_ID() AS `@@IDENTITY`);
	ELSE
			INSERT INTO `USUARIOS`
				(`IDSEXO`
				,`IDTIPOPERSONA`
				,`IDESTADOCIVIL`
				,`IDAREA`
				,`IDTIPOUSUARIO`
				,`APATERNO`
				,`AMATERNO`
				,`NOMBRE`
				,`FECHANACCONST`
				,`USUARIO`
				,`PASSWORD`
			    ,`RUTAFOTOPERFIL`
				,`FECHAALTA`
				,`ACTIVO`)
			VALUES
				(p_IDSEXO,
				p_IDTIPOPERSONA,
				p_IDESTADOCIVIL,
				p_IDAREA,
				p_IDTIPOUSUARIO,
				p_APATERNO,
				p_AMATERNO,
				p_NOMBRE,
				p_FECHANACCONST,
				p_USUARIO,
				p_PASSWORD,
				p_RUTAFOTOPERFIL,
				p_FECHAALTA,
				p_ACTIVO);

			SELECT LAST_INSERT_ID() AS `SCOPE_IDENTITY`;
			SET v_IDUSERIDENTITY = (SELECT LAST_INSERT_ID() AS `@@IDENTITY`);

			UPDATE `USUARIOS`
			SET `IDUSUARIOAPP` = v_IDUSERIDENTITY
			WHERE `IDUSUARIO` = v_IDUSERIDENTITY;
		END IF;


	INSERT INTO `USUARIOXAPLICACION`
           (`IDAPLICACION`
           ,`IDUSUARIO`
           ,`ACTIVO`)
     VALUES
           (p_IDAPLICACION
           ,v_IDUSERIDENTITY
           ,1);


	SET v_ESTADOCIVIL = (SELECT `DESCRIPCION` FROM `CAT_ESTADOCIVIL` WHERE `IDESTADOCIVIL` = p_IDESTADOCIVIL AND `ACTIVO`=1
LIMIT 1);

	SET v_TIPOPERSONA = (SELECT `DESCRIPCION` FROM `CAT_TIPOPERSONA` WHERE `IDTIPOPERSONA` = p_IDTIPOPERSONA AND `ACTIVO`=1
LIMIT 1);

	SET v_SEXO = (SELECT `DESCRIPCION` FROM `CAT_SEXO` WHERE `IDSEXO` = p_IDSEXO AND `ACTIVO`=1
LIMIT 1);

	SET v_AREA  = (SELECT `DESCRIPCION` FROM `CAT_AREA` WHERE `IDAREA` = p_IDAREA AND `ACTIVO`=1
LIMIT 1);

	SET v_TIPOUSUARIO = (SELECT `DESCRIPCION` FROM `CAT_TIPOUSUARIO` WHERE `IDTIPOUSUARIO` = p_IDTIPOUSUARIO AND `ACTIVO`=1
LIMIT 1);

	IF(p_IDUSERMODIFICA IS NULL)
		THEN
			SET p_IDUSERMODIFICA = v_IDUSERIDENTITY;
		END IF;


	CALL spFront_AuditUser(p_IDAPLICACION,
			1,
			v_IDUSERIDENTITY		,
			v_SEXO				,
			v_TIPOPERSONA		,
			v_ESTADOCIVIL		,
			v_AREA				,
			v_TIPOUSUARIO		,
			p_IDUSUARIOAPP		,
			p_APATERNO			,
			p_AMATERNO			,
			p_NOMBRE				,
			p_FECHANACCONST		,
			p_USUARIO			,
			p_PASSWORD			,
			p_RUTAFOTOPERFIL		,
			p_FECHAALTA			,
			p_ACTIVO				,
			p_IDUSERMODIFICA		,
			p_IDAPPMODIFICA);

	select v_IDUSERIDENTITY;
	--  SQLINES DEMO *** TITY AS IDUSERIDENTITY


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_updAplicacion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_updAplicacion`(
		p_IDAPLICACION BIGINT,
		p_DESCRIPCION		VARCHAR(200),
		p_PASSWORD			VARCHAR(200),
        p_XAPPID			VARCHAR(200),
        p_URLINICIO			VARCHAR(500),
        p_JWTKEY			VARCHAR(200),
        p_JWTEXPIRATIONTIME	VARCHAR(200),
		p_ACTIVO				TINYINT 
)
BEGIN

	UPDATE `APLICACION`
       SET `DESCRIPCION` = p_DESCRIPCION
           ,`PASSWORD` = p_PASSWORD
           ,`XAPPID` = p_XAPPID
           ,`URLINICIO` = p_URLINICIO
           ,`JWTKEY` = p_JWTKEY
           ,`JWTEXPIRATIONTIME` = p_JWTEXPIRATIONTIME
           ,`ACTIVO` = p_ACTIVO
    WHERE IDAPLICACION = p_IDAPLICACION;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_updContacto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_updContacto`(
		p_IDUSUARIO			BIGINT,
		p_IDCONTACTO			BIGINT,
		p_IDTIPOCONTACTO		INT,
		p_VALOR				VARCHAR(100) /* = NULL */,
		p_ACTIVO				TINYINT /* = NULL */,
		p_IDAPLICACION		BIGINT,
		p_IDUSERMODIFICA		BIGINT /* = NULL */,
		p_IDAPPMODIFICA		BIGINT /* = NULL */
)
BEGIN
DECLARE v_CONTACTO VARCHAR(100); 
	UPDATE `CONTACTO` AS A
	SET `IDTIPOCONTACTO` = p_IDTIPOCONTACTO,
		`VALOR` = p_VALOR,
		`ACTIVO` = p_ACTIVO
	WHERE A.`IDCONTACTO` = p_IDCONTACTO;

	
	SET v_CONTACTO = (SELECT DESCRIPCION FROM CAT_TIPOCONTACTO WHERE IDTIPOCONTACTO = p_IDTIPOCONTACTO
LIMIT 1);

	IF(p_IDUSERMODIFICA IS NULL)
		THEN
			SET p_IDUSERMODIFICA = p_IDUSUARIO;
		END IF;

	IF(p_IDAPPMODIFICA IS NULL)
		THEN
			SET p_IDAPPMODIFICA = p_IDAPLICACION;
		END IF;

	CALL	`spFront_AuditContacto`(2
		,p_IDCONTACTO
		,p_IDUSUARIO
		,v_CONTACTO
		,p_VALOR
		,NULL
		,p_IDUSERMODIFICA
		,p_IDAPPMODIFICA);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_updDomicilio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_updDomicilio`(
		p_IDUSUARIO			BIGINT,
		p_IDDOMICILIO		BIGINT,
		p_CALLE				VARCHAR(100) /* = NULL */,
		p_NUMEXT				VARCHAR(20) /* = NULL */,
		p_NUMINT				VARCHAR(20) /* = NULL */,
		p_IDESTADO			INT /* = NULL */,
		p_ESTADO				VARCHAR(50) /* = NULL */,
		p_IDMUN				INT /* = NULL */,
		p_MUNICIPIO			VARCHAR(50) /* = NULL */,
		p_IDCOLONIA			INT /* = NULL */,
		p_COLONIA			VARCHAR(100) /* = NULL */,
		p_CP					VARCHAR(50) /* = NULL */,
		p_IDAPLICACION		BIGINT,
		p_IDUSERMODIFICA		BIGINT /* = NULL */,
		p_IDAPPMODIFICA		BIGINT /* = NULL */
)
BEGIN

	UPDATE `DOMICILIO` AS A
		SET `CALLE` = p_CALLE
			,`NUMEXT` = p_NUMEXT
			,`NUMINT` = p_NUMINT
			,`IDESTADO` = p_IDESTADO
			,`ESTADO` = p_ESTADO
			,`IDMUN` = p_IDMUN
			,`MUNICIPIO` = p_MUNICIPIO
			,`IDCOLONIA` = p_IDCOLONIA
			,`COLONIA` = p_COLONIA
			,`CP` = p_CP
	WHERE A.IDDOMICILIO = p_IDDOMICILIO;
	
	IF(p_IDUSERMODIFICA IS NULL)
		THEN
			SET p_IDUSERMODIFICA = p_IDUSUARIO;
		END IF;

	IF(p_IDAPPMODIFICA IS NULL)
		THEN
			SET p_IDAPPMODIFICA = p_IDAPLICACION;
		END IF;

	CALL	`spFront_AuditDomicilio`(1,
		p_IDDOMICILIO,
		p_IDUSUARIO,
		p_CALLE,
		p_NUMEXT,
		p_NUMINT,
		p_IDESTADO,
		p_ESTADO,
		p_IDMUN,
		p_MUNICIPIO,
		p_IDCOLONIA,
		p_COLONIA,
		p_CP,
		NULL,
		p_IDUSERMODIFICA,
		p_IDAPPMODIFICA);	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_updMenuXAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_updMenuXAppRol`(
	p_IDPERMISOSMENU BIGINT,
	p_NOMBREMENU		VARCHAR(500),
	p_IMAGEN			VARCHAR(500),
	p_TIPOOBJETO		VARCHAR(200),
	p_URL			VARCHAR(500),	
	p_TOOLTIP		VARCHAR(200),
	p_ORDEN			BIGINT,
	p_ACTIVO			TINYINT
)
BEGIN
	UPDATE `PERMISOSXMENU` SET
	       `NOMBREMENU` = p_NOMBREMENU
		  ,`IMAGEN` = p_IMAGEN
		  ,`TIPOOBJETO` = p_TIPOOBJETO
		  ,`URL` = p_URL
		  ,`TOOLTIP` = p_TOOLTIP
		  ,`ACTIVO` = p_ACTIVO
		  ,`ORDEN` = p_ORDEN
		  WHERE IDPERMISOSMENU = p_IDPERMISOSMENU;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_updRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_updRol`(
	p_IDROLXUSUARIO		BIGINT,
	p_IDROL				BIGINT,
	p_IDESTACIONXAPP		BIGINT /* = NULL */
)
BEGIN
			
	UPDATE `ROLESXUSUARIO`
	SET `IDROL` = p_IDROL
		,`IDESTACIONXAPP` = p_IDESTACIONXAPP
	WHERE IDROLXUSUARIO = p_IDROLXUSUARIO;
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_updSubMenuXAppRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_updSubMenuXAppRol`(
	p_IDPERMISOSMENU BIGINT,
	p_IDPERMISOSSUBMENU BIGINT,
	p_NOMBRESUBMENU		VARCHAR(500),
	p_IMAGEN			VARCHAR(500),
	p_TIPOOBJETO		VARCHAR(200),
	p_URL			VARCHAR(500),	
	p_TOOLTIP		VARCHAR(200),
	p_ORDEN			BIGINT,
	p_ACTIVO			TINYINT
)
BEGIN
	UPDATE `PERMISOSXSUBMENU` SET
	       `NOMBRESUBMENU` = p_NOMBRESUBMENU
		  ,`IMAGEN` = p_IMAGEN
		  ,`TIPOOBJETO` = p_TIPOOBJETO
		  ,`URL` = p_URL
		  ,`TOOLTIP` = p_TOOLTIP
		  ,`ACTIVO` = p_ACTIVO
		  ,`ORDEN` = p_ORDEN
		  WHERE IDPERMISOSXSUBMENU = p_IDPERMISOSSUBMENU
		  AND IDPERMISOSMENU = p_IDPERMISOSMENU;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spFront_updUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spFront_updUsuario`(
	p_IDUSUARIO			BIGINT,
	p_IDAPLICACION		BIGINT /* = NULL */,
	p_IDSEXO				INT /* = NULL */,
	p_IDTIPOPERSONA		INT /* = NULL */,
	p_IDESTADOCIVIL		INT /* = NULL */,
	p_IDAREA				INT /* = 66 */,
	p_IDTIPOUSUARIO		INT /* = NULL */,
	p_IDUSUARIOAPP		VARCHAR(100) /* = NULL */,
	p_APATERNO			VARCHAR(100) /* = NULL */,
	p_AMATERNO			VARCHAR(100) /* = NULL */,
	p_NOMBRE				VARCHAR(150) /* = NULL */,
	p_FECHANACCONST		DATETIME(3) /* = NULL */,
	p_USUARIO			VARCHAR(50) /* = NULL */,
	p_PASSWORD			VARCHAR(50) /* = NULL */,
	p_RUTAFOTOPERFIL		VARCHAR(150) /* = NULL */,
	p_ACTIVO				TINYINT /* = NULL */,
	p_IDUSERMODIFICA		BIGINT /* = NULL */,
	p_IDAPPMODIFICA		BIGINT /* = NULL */
)
BEGIN


  DECLARE v_ESTADOCIVIL VARCHAR(100);
  DECLARE v_TIPOPERSONA VARCHAR(100);
  DECLARE v_SEXO VARCHAR(100);
  DECLARE v_AREA VARCHAR(150);
  DECLARE v_TIPOUSUARIO VARCHAR(150);IF p_IDTIPOUSUARIO = 2
THEN
SET p_RUTAFOTOPERFIL = Concat('http://192.168.10.47/intranet/images/empleados/', CAST((p_IDUSUARIOAPP - 900000) AS NCHAR(1))  ,'.JPG'); 
END IF;

	UPDATE `USUARIOS`
	SET `IDSEXO` = p_IDSEXO
		,`IDTIPOPERSONA` = p_IDTIPOPERSONA
		,`IDESTADOCIVIL` = p_IDESTADOCIVIL
		,`IDAREA` = p_IDAREA
		,`IDTIPOUSUARIO` = p_IDTIPOUSUARIO
		,`IDUSUARIOAPP` = p_IDUSUARIOAPP
		,`APATERNO` = p_APATERNO
		,`AMATERNO` = p_AMATERNO
		,`NOMBRE` = p_NOMBRE
		,`FECHANACCONST` = p_FECHANACCONST
		,`USUARIO` = p_USUARIO
		,`PASSWORD` = p_PASSWORD
		,`RUTAFOTOPERFIL` = p_RUTAFOTOPERFIL
		,`ACTIVO` = p_ACTIVO
	WHERE IDUSUARIO = p_IDUSUARIO;


	--  SQLINES DEMO *** ***		AUDITORIA		**********************************
	SET v_ESTADOCIVIL = (SELECT `DESCRIPCION` FROM `CAT_ESTADOCIVIL` WHERE `IDESTADOCIVIL` = p_IDESTADOCIVIL AND `ACTIVO`=1
LIMIT 1);

	SET v_TIPOPERSONA = (SELECT `DESCRIPCION` FROM `CAT_TIPOPERSONA` WHERE `IDTIPOPERSONA` = p_IDTIPOPERSONA AND `ACTIVO`=1
LIMIT 1);

	SET v_SEXO = (SELECT `DESCRIPCION` FROM `CAT_SEXO` WHERE `IDSEXO` = p_IDSEXO AND `ACTIVO`=1
LIMIT 1);

	SET v_AREA  = (SELECT `DESCRIPCION` FROM `CAT_AREA` WHERE `IDAREA` = p_IDAREA AND `ACTIVO`=1
LIMIT 1);

	SET v_TIPOUSUARIO = (SELECT `DESCRIPCION` FROM `CAT_TIPOUSUARIO` WHERE `IDTIPOUSUARIO` = p_IDTIPOUSUARIO AND `ACTIVO`=1
LIMIT 1);

	IF(p_IDUSERMODIFICA IS NULL)
		THEN
			SET p_IDUSERMODIFICA = p_IDUSUARIO;
		END IF;

	IF(p_IDAPPMODIFICA IS NULL)
		THEN
			SET p_IDAPPMODIFICA = p_IDAPLICACION;
		END IF;

	CALL	`spFront_AuditUser`(p_IDAPLICACION,
			2,
			p_IDUSUARIO			,
			v_SEXO				,
			v_TIPOPERSONA		,
			v_ESTADOCIVIL		,
			v_AREA				,
			v_TIPOUSUARIO		,
			p_IDUSUARIOAPP		,
			p_APATERNO			,
			p_AMATERNO			,
			p_NOMBRE				,
			p_FECHANACCONST		,
			p_USUARIO			,
		p_PASSWORD			,
			p_RUTAFOTOPERFIL		,
			NULL				,
			p_ACTIVO				,
			p_IDUSERMODIFICA		,
			p_IDAPPMODIFICA);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAppInfo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAppInfo`(
	p_xAppId		nvarchar(100))
BEGIN
	
	SELECT 
		IDAPLICACION,
		DESCRIPCION,
		PASSWORD,
		URLINICIO,
		XAPPID,
		JWTKEY,
		JWTEXPIRATIONTIME
	FROM APLICACION 
	where XAPPID = p_xAppId and activo = 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_checkUsr` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_checkUsr`(
	p_TIPOBUSQUEDA		INT,
	p_USUARIO			VARCHAR(150)
)
BEGIN

	IF(p_TIPOBUSQUEDA = 1)
		THEN
			SELECT * FROM `USUARIOS`
			WHERE `IDUSUARIO` = CAST(p_USUARIO AS signed integer);
	ELSEIF (p_TIPOBUSQUEDA = 2)
		THEN
			SELECT * FROM `USUARIOS`
			WHERE `IDUSUARIOAPP` = p_USUARIO;
	ELSEIF (p_TIPOBUSQUEDA = 3)
		THEN
			SELECT * FROM `USUARIOS`
			WHERE `USUARIO` = p_USUARIO;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getEstacionesXApps` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getEstacionesXApps`(
	p_IDAPLICACION		BIGINT
)
BEGIN

	SELECT `IDESTACIONXAPP`
		,`IDAPLICACION`
		,`IDESTACION`
		--  SQLINES DEMO *** ULAR]
		,`ACTIVO`
	FROM `ESTACIONESXAPP`
	WHERE `IDAPLICACION` = p_IDAPLICACION
	AND `ACTIVO` = 1;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getEstacionesXID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getEstacionesXID`(
	p_IDESTACIONXAPP		BIGINT
)
BEGIN

	SELECT A.`IDESTACIONXAPP`
		,A.`IDAPLICACION`
		,A.`IDESTACION`
		,A.`IDESTACIONPARTICULAR`
		,B.DESCRIPCION
		,A.`ACTIVO`
	  FROM `ESTACIONESXAPP` A, CAT_ESTACIONES  B
	WHERE A.`IDESTACIONXAPP` = p_IDESTACIONXAPP
	AND A.IDESTACION = B.IDESTACION
	AND A.`ACTIVO` = 1;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getRolesXUserApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getRolesXUserApp`(
	p_TIPOBUSQUEDA		INT,
	p_USUARIO			VARCHAR(500),
	p_IDAPLICACION		BIGINT
)
BEGIN

	IF(p_TIPOBUSQUEDA = 1)
		THEN
			SELECT A.`IDROLXUSUARIO`
			  ,A.`IDROL`
			  ,(SELECT DESCRIPCION FROM `ROLES` WHERE IDROL = A.`IDROL`
LIMIT 1) AS DESCROL
			  ,A.`IDUSUARIO`
			  ,A.`IDESTACIONXAPP`
			  ,A.`ACTIVO`
			FROM `ROLESXUSUARIO` AS A, `USUARIOS` AS B,
			USUARIOXAPLICACION AS C, ROLES AS D
			WHERE B.`IDUSUARIO` = CAST(p_USUARIO AS SIGNED INTEGER) 
			AND A.`IDUSUARIO` = B.`IDUSUARIO`
			AND B.`IDUSUARIO` = C.`IDUSUARIO`
			AND	C.`IDAPLICACION` Like CASE WHEN IFNULL(p_IDAPLICACION,'') = '' THEN C.`IDAPLICACION` ELSE p_IDAPLICACION end	
			AND D.IDAPLICACION LIKE CASE WHEN IFNULL(p_IDAPLICACION,'') = '' THEN D.IDAPLICACION ELSE p_IDAPLICACION END
			AND D.IDROL = A.IDROL
			AND A.ACTIVO = 1;
	ELSEIF (p_TIPOBUSQUEDA = 2)
		THEN
			SELECT A.`IDROLXUSUARIO`
			  ,A.`IDROL`
			  ,(SELECT DESCRIPCION FROM `ROLES` WHERE IDROL = A.`IDROL`
LIMIT 1) AS DESCROL
			  ,A.`IDUSUARIO`
			  ,A.`IDESTACIONXAPP`
			  ,A.`ACTIVO`
			FROM `ROLESXUSUARIO` AS A, `USUARIOS` AS B,
			USUARIOXAPLICACION AS C, ROLES AS D
			WHERE B.`IDUSUARIOAPP` = p_USUARIO 
			AND A.`IDUSUARIO` = B.`IDUSUARIO`
			AND B.`IDUSUARIO` = C.`IDUSUARIO`
			AND	C.`IDAPLICACION` = p_IDAPLICACION
			AND D.IDAPLICACION = p_IDAPLICACION
			AND D.IDROL = A.IDROL
			AND A.ACTIVO = 1;
	ELSEIF (p_TIPOBUSQUEDA = 3)
		THEN
			SELECT A.`IDROLXUSUARIO`
			  ,A.`IDROL`
			  ,(SELECT DESCRIPCION FROM `ROLES` WHERE IDROL = A.`IDROL`
LIMIT 1) AS DESCROL
			  ,A.`IDUSUARIO`
			  ,A.`IDESTACIONXAPP`
			  ,A.`ACTIVO`
			FROM `ROLESXUSUARIO` AS A, `USUARIOS` AS B,
			USUARIOXAPLICACION AS C, ROLES AS D
			WHERE B.`USUARIO` = p_USUARIO 
			AND A.`IDUSUARIO` = B.`IDUSUARIO`
			AND B.`IDUSUARIO` = C.`IDUSUARIO`
			AND	C.`IDAPLICACION` = p_IDAPLICACION
			AND D.IDAPLICACION = p_IDAPLICACION
			AND D.IDROL = A.IDROL
			AND A.ACTIVO = 1;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getUsuariosXIdRol` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getUsuariosXIdRol`(
	p_IdRol		BIGINT
)
BEGIN

	SELECT A.`IDUSUARIO`
		,A.`IDSEXO`
		,A.`IDTIPOPERSONA`
		,A.`IDESTADOCIVIL`
		,A.`IDAREA`
		,A.`IDTIPOUSUARIO`
		,A.`IDUSUARIOAPP`
		,A.`APATERNO`
		,A.`AMATERNO`
		,A.`NOMBRE`
		,A.`FECHANACCONST`
		,A.`USUARIO`
		,A.`PASSWORD`
		,A.`RUTAFOTOPERFIL`
		,A.`FECHAALTA`
		,A.`ACTIVO`
		,(SELECT C.VALOR FROM CONTACTO C WHERE C.IDUSUARIO = A.IDUSUARIO AND C.IDTIPOCONTACTO = 3 LIMIT 1) AS EMAIL
	  from `USUARIOS` AS A, ROLESXUSUARIO AS B
	WHERE A.IDUSUARIO = B.IDUSUARIO
	AND B.IDROL = p_IdRol
	ORDER BY NOMBRE,APATERNO,AMATERNO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insLogError` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insLogError`(
	p_IdApp			BIGINT,
	p_MENSAJE		VARCHAR(450) /* = NULL */,
	p_HOSTNAME		VARCHAR(150) /* = NULL */,
	p_IP				VARCHAR(40) /* = NULL */,
	p_STACKTRACE		VARCHAR(500) /* = NULL */,
	p_DTFECHAERROR	DATETIME(3) /* = NULL */,
    p_VCHUSUARIO		VARCHAR(1) /* = NULL */
)
BEGIN
-- SET... SQLINES DEMO ***
	INSERT INTO `LOGERROR`
           (`IDAPLICACION`
           ,`VCHMENSAJE`
           ,`VCHHOSTNAME`
           ,`VCHIP`
           ,`VCHSTACKTRACE`
           ,`DTFECHAERROR`
           ,`VCHUSUARIO`
           ,`ACTIVO`)
     VALUES
           (p_IdApp
           ,p_MENSAJE
           ,p_HOSTNAME
           ,p_IP
           ,p_STACKTRACE
           ,p_DTFECHAERROR
           ,p_VCHUSUARIO
           ,1);
		
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_setIdUsrApp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_setIdUsrApp`()
BEGIN

	
SELECT CAST(IFNULL(Max(IDUSUARIOAPP),'900000000') AS SIGNED INTEGER) + 1 AS USUARIO 
FROM USUARIOS
WHERE IDUSUARIOAPP BETWEEN CAST((SELECT CAST(`VCHVALOR` AS CHAR) FROM PARAMETROS WHERE `VCHNOMBRE` = 'LimiteInfUsrs') AS SIGNED INTEGER) AND CAST((SELECT CAST(`VCHVALOR` AS CHAR) FROM PARAMETROS WHERE `VCHNOMBRE` = 'LimiteSupUsrs') AS SIGNED INTEGER);
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

-- Dump completed on 2025-10-21 22:40:35
