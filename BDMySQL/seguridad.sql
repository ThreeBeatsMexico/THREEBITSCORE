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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-20 23:57:19
