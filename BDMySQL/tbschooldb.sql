-- MariaDB dump 10.19  Distrib 10.4.28-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: tbschooldb
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
-- Table structure for table `alumnos`
--

DROP TABLE IF EXISTS `alumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alumnos` (
  `IDALUMNO` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `NUMEROMATRICULA` varchar(50) NOT NULL,
  `FECHAREGISTRO` timestamp NOT NULL DEFAULT current_timestamp(),
  `FECHAMATRICULA` datetime NOT NULL,
  `APATERNO` varchar(150) NOT NULL,
  `AMATERNO` varchar(150) NOT NULL,
  `NOMBRES` varchar(150) NOT NULL,
  `FECHANACIMIENTO` datetime NOT NULL,
  `SEXO` varchar(2) NOT NULL,
  `NACIONALIDAD` varchar(50) NOT NULL,
  `GRADO` varchar(50) DEFAULT NULL,
  `GRUPO` varchar(50) DEFAULT NULL,
  `NUMEROLISTA` varchar(50) DEFAULT NULL,
  `ESCUELAPROCEDENCIA` varchar(250) DEFAULT NULL,
  `HERMANOS` int(11) DEFAULT NULL,
  `GRADOHERMANOS` varchar(50) DEFAULT NULL,
  `CALLE` varchar(150) NOT NULL,
  `NUMERO` varchar(50) NOT NULL,
  `COLONIA` varchar(150) NOT NULL,
  `DELEGACION` varchar(150) NOT NULL,
  `ESTADO` varchar(150) NOT NULL,
  `CODIGOPOSTAL` varchar(5) NOT NULL,
  `TELEFONO` varchar(50) NOT NULL,
  `EMAIL` varchar(200) NOT NULL,
  `CURP` varchar(20) NOT NULL,
  `EDADANOS` varchar(50) NOT NULL,
  `EDADMESES` varchar(50) NOT NULL,
  `TUTOR` varchar(250) NOT NULL,
  `USUARIOALTA` varchar(50) NOT NULL,
  `USUARIOMODIFICA` varchar(50) NOT NULL,
  `FECHAALTA` datetime NOT NULL,
  `FECHAMODIFICA` datetime NOT NULL,
  `FOTO` varchar(150) DEFAULT NULL,
  `NIVELACADEMICO` varchar(50) DEFAULT NULL,
  `ESTATUS` varchar(50) DEFAULT NULL,
  `SERVERPATH` varchar(200) DEFAULT NULL,
  `BECA` int(11) DEFAULT NULL,
  `IDCICLO` int(11) DEFAULT NULL,
  `FORMAPAGO` int(11) DEFAULT NULL,
  `IDUSERSEC` int(11) DEFAULT NULL,
  PRIMARY KEY (`IDALUMNO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumnos`
--

LOCK TABLES `alumnos` WRITE;
/*!40000 ALTER TABLE `alumnos` DISABLE KEYS */;
INSERT INTO `alumnos` VALUES (5,1,'P2401','2024-05-22 06:00:00','2024-05-22 00:00:00','MARTINEZ','ZAMUDIO','JULIO CESAR','1982-09-25 00:00:00','M','MEXICANA','6','1','1','JEGV',0,'0','ALDAMA','27','LAS PEÑAS','IZTAPALAPA','CDMX','09750','5541862979','jcesarmzamudio@gmail.com','MAZJ820925HDFRLM03','0','0','JULIO','900650','900650','2024-05-22 00:00:00','2024-05-22 00:00:00','../images/User.png','1','1','../',1,1,1,1);
/*!40000 ALTER TABLE `alumnos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `calificaciones`
--

DROP TABLE IF EXISTS `calificaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `calificaciones` (
  `IDCALIFICACION` int(11) NOT NULL,
  `IDALUMNO` int(11) NOT NULL,
  `IDPERIODO` int(11) NOT NULL,
  `IDMATERIA` int(11) NOT NULL,
  `CALIFICACION` decimal(18,2) DEFAULT NULL,
  `FECHAALTA` datetime DEFAULT NULL,
  `USUARIOALTA` int(11) DEFAULT NULL,
  `FECHAMODIFICA` datetime DEFAULT NULL,
  `USUARIOMODIFICA` int(11) DEFAULT NULL,
  PRIMARY KEY (`IDCALIFICACION`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calificaciones`
--

LOCK TABLES `calificaciones` WRITE;
/*!40000 ALTER TABLE `calificaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `calificaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ciclo`
--

DROP TABLE IF EXISTS `ciclo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ciclo` (
  `ID` int(11) NOT NULL,
  `IDCOLEGIO` int(11) DEFAULT NULL,
  `NOMBRECICLO` varchar(200) DEFAULT NULL,
  `FECHAINICIO` date DEFAULT NULL,
  `FECHAFIN` date DEFAULT NULL,
  `MONTOINSCRIPCION` decimal(16,2) DEFAULT NULL,
  `MONTOCOLEGIATURA` decimal(16,2) DEFAULT NULL,
  `ESTATUS` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ciclo`
--

LOCK TABLES `ciclo` WRITE;
/*!40000 ALTER TABLE `ciclo` DISABLE KEYS */;
/*!40000 ALTER TABLE `ciclo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `colegio`
--

DROP TABLE IF EXISTS `colegio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `colegio` (
  `IDCOLEGIO` int(11) NOT NULL,
  `NOMBRE` varchar(300) DEFAULT NULL,
  `DIRECCION` varchar(300) DEFAULT NULL,
  `TELEFONO` varchar(200) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  `REG_PRIMARIA` varchar(100) DEFAULT NULL,
  `REG_PRESCOLAR` varchar(100) DEFAULT NULL,
  `REG_SECUNDARIA` varchar(100) DEFAULT NULL,
  `LEMA` varchar(500) DEFAULT NULL,
  `LOGO` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `colegio`
--

LOCK TABLES `colegio` WRITE;
/*!40000 ALTER TABLE `colegio` DISABLE KEYS */;
/*!40000 ALTER TABLE `colegio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grado`
--

DROP TABLE IF EXISTS `grado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grado` (
  `ID` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `IDNIVEL` int(11) DEFAULT NULL,
  `IDGRADO` varchar(50) DEFAULT NULL,
  `DESCRIPCIONGRADO` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grado`
--

LOCK TABLES `grado` WRITE;
/*!40000 ALTER TABLE `grado` DISABLE KEYS */;
/*!40000 ALTER TABLE `grado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupo`
--

DROP TABLE IF EXISTS `grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupo` (
  `IDGRUPO` int(11) NOT NULL,
  `IDCOLEGIO` int(11) DEFAULT NULL,
  `IDNIVEL` int(11) DEFAULT NULL,
  `IDGRADO` varchar(50) DEFAULT NULL,
  `IDCICLO` int(11) DEFAULT NULL,
  `NOMBREGRUPO` varchar(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupo`
--

LOCK TABLES `grupo` WRITE;
/*!40000 ALTER TABLE `grupo` DISABLE KEYS */;
/*!40000 ALTER TABLE `grupo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `infoalumnos`
--

DROP TABLE IF EXISTS `infoalumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `infoalumnos` (
  `NUMEROMATRICULA` varchar(50) NOT NULL,
  `IDALUMNO` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `NOMBREPADRETUTOR` varchar(150) DEFAULT NULL,
  `OCUPACIONPADRE` varchar(150) DEFAULT NULL,
  `TELEFONOPADRE` varchar(50) DEFAULT NULL,
  `TELEFONOTRABAJOPADRE` varchar(50) DEFAULT NULL,
  `CELULARPADRE` varchar(50) DEFAULT NULL,
  `FECHANACIMIENTOPADRE` datetime DEFAULT NULL,
  `SUELDOPADRE` varchar(50) DEFAULT NULL,
  `NACIONALIDADPADRE` varchar(150) DEFAULT NULL,
  `NOMBREMADRETUTOR` varchar(150) DEFAULT NULL,
  `OCUPACIONMADRE` varchar(150) DEFAULT NULL,
  `TELEFONOMADRE` varchar(50) DEFAULT NULL,
  `TELEFONOTRABAJOMADRE` varchar(50) DEFAULT NULL,
  `CELULARMADRE` varchar(50) DEFAULT NULL,
  `FECHANACIMIENTOMADRE` datetime DEFAULT NULL,
  `SUELDOMADRE` varchar(50) DEFAULT NULL,
  `NACIONALIDADMADRE` varchar(50) DEFAULT NULL,
  `NOMBREFAMVECINO` varchar(50) DEFAULT NULL,
  `TELEFONOVECINO` varchar(50) DEFAULT NULL,
  `TELEFONOTRABAJOVECINO` varchar(50) DEFAULT NULL,
  `CELULARVECINO` varchar(50) DEFAULT NULL,
  `EDUCACIONFISICA` int(11) DEFAULT NULL,
  `MEDICAMENTO` int(11) DEFAULT NULL,
  `NOMBREMEDICAMENTO` varchar(150) DEFAULT NULL,
  `DOSISMEDICAMENTO` varchar(150) DEFAULT NULL,
  `ALIMENTOPROHIBIDO` varchar(150) DEFAULT NULL,
  `PESO` varchar(50) DEFAULT NULL,
  `TALLA` varchar(50) DEFAULT NULL,
  `TIPOSANGRE` varchar(50) DEFAULT NULL,
  `ENFERMEDADES` int(11) DEFAULT NULL,
  `NOMBREENFERMEDADES` varchar(150) DEFAULT NULL,
  `PROCEDIMIENTOCRISIS` varchar(500) DEFAULT NULL,
  `CERTIFICADO` int(11) DEFAULT NULL,
  `ENFERMEDADCERTIFICADO` int(11) DEFAULT NULL,
  `ALERGIA` int(11) DEFAULT NULL,
  `NOMBREALERGIA` varchar(150) DEFAULT NULL,
  `PROCEDIMINTOCRISISALERGIA` varchar(500) DEFAULT NULL,
  `NOMBREACCIDENTE` varchar(50) DEFAULT NULL,
  `TELEFONOACCIDENTE` varchar(50) DEFAULT NULL,
  `NOMBREHOSPITAL` varchar(150) DEFAULT NULL,
  `MEDICO` int(11) DEFAULT NULL,
  `NOMBREMEDICO` varchar(250) DEFAULT NULL,
  `TELEFONOMEDICO` varchar(150) DEFAULT NULL,
  `CEDULAMEDICO` varchar(150) DEFAULT NULL,
  `AUTORIZATRASLADO` int(11) DEFAULT NULL,
  `PROCEDIMIENTOACCIDENTE` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `infoalumnos`
--

LOCK TABLES `infoalumnos` WRITE;
/*!40000 ALTER TABLE `infoalumnos` DISABLE KEYS */;
/*!40000 ALTER TABLE `infoalumnos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logerror`
--

DROP TABLE IF EXISTS `logerror`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logerror` (
  `IDLOGERROR` bigint(20) NOT NULL,
  `IDCOLEGIO` bigint(20) DEFAULT NULL,
  `VCHMENSAJE` varchar(450) DEFAULT NULL,
  `VCHHOSTNAME` varchar(150) DEFAULT NULL,
  `VCHIP` varchar(40) DEFAULT NULL,
  `VCHSTACKTRACE` varchar(500) DEFAULT NULL,
  `DTFECHAERROR` datetime DEFAULT NULL,
  `VCHUSUARIO` varchar(40) DEFAULT NULL,
  `ACTIVO` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`IDLOGERROR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logerror`
--

LOCK TABLES `logerror` WRITE;
/*!40000 ALTER TABLE `logerror` DISABLE KEYS */;
/*!40000 ALTER TABLE `logerror` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materias`
--

DROP TABLE IF EXISTS `materias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `materias` (
  `IDMATERIA` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `IDGRADO` int(11) NOT NULL,
  `IDGRUPO` int(11) NOT NULL,
  `CVEMATERIA` varchar(50) NOT NULL,
  `NOMBREMATERIA` varchar(150) NOT NULL,
  PRIMARY KEY (`IDMATERIA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materias`
--

LOCK TABLES `materias` WRITE;
/*!40000 ALTER TABLE `materias` DISABLE KEYS */;
/*!40000 ALTER TABLE `materias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `numeracion`
--

DROP TABLE IF EXISTS `numeracion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `numeracion` (
  `ID_NUMERACION` int(11) NOT NULL,
  `IDCOLEGIO` int(11) DEFAULT NULL,
  `ID_DOCTYPE` int(11) NOT NULL,
  `NMBSERIE` varchar(10) DEFAULT NULL,
  `NMBNUMBERFROM` bigint(20) DEFAULT NULL,
  `NMBCURRENTNUMBER` bigint(20) DEFAULT NULL,
  `NMBNUMBERTO` bigint(20) NOT NULL,
  `NMBAUTHNUMBER` varchar(15) DEFAULT NULL,
  `NMBAUTHDATE` int(11) NOT NULL,
  `NMBRFC` varchar(13) NOT NULL,
  PRIMARY KEY (`ID_NUMERACION`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `numeracion`
--

LOCK TABLES `numeracion` WRITE;
/*!40000 ALTER TABLE `numeracion` DISABLE KEYS */;
/*!40000 ALTER TABLE `numeracion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `numeraciones`
--

DROP TABLE IF EXISTS `numeraciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `numeraciones` (
  `CLAVE_PROCESO` char(10) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `TIPO_PROC` char(6) NOT NULL,
  `INICIAL` bigint(20) NOT NULL,
  `FINAL` bigint(20) NOT NULL,
  `ACTUAL` bigint(20) DEFAULT NULL,
  `FECHA_INICIO` datetime DEFAULT NULL,
  `SERIE` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `numeraciones`
--

LOCK TABLES `numeraciones` WRITE;
/*!40000 ALTER TABLE `numeraciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `numeraciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagosalumno`
--

DROP TABLE IF EXISTS `pagosalumno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagosalumno` (
  `ID` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `IDCICLO` int(11) NOT NULL,
  `NUMEROMATRICULA` varchar(50) DEFAULT NULL,
  `IDGRUPO` varchar(50) DEFAULT NULL,
  `IDGRADO` varchar(50) DEFAULT NULL,
  `IDALUMNO` int(11) DEFAULT NULL,
  `CONCEPTO` varchar(500) DEFAULT NULL,
  `MONTOTOTAL` decimal(16,2) DEFAULT NULL,
  `MONTOACTUAL` decimal(16,2) DEFAULT NULL,
  `IDESTATUS` int(11) DEFAULT NULL,
  `FECHAMOVIMIENTO` datetime DEFAULT NULL,
  `FECHAALTA` datetime DEFAULT NULL,
  `USUARIOMODIFICA` varchar(50) DEFAULT NULL,
  `USUARIOALTA` varchar(50) DEFAULT NULL,
  `FECHAMODIFICA` datetime DEFAULT NULL,
  `MEDIOPAGO` int(11) DEFAULT NULL,
  `REFERENCIA` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagosalumno`
--

LOCK TABLES `pagosalumno` WRITE;
/*!40000 ALTER TABLE `pagosalumno` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagosalumno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `periodos`
--

DROP TABLE IF EXISTS `periodos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `periodos` (
  `IDPERIODO` int(11) NOT NULL,
  `IDCICLO` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `DESCRIPCION` varchar(250) DEFAULT NULL,
  `FECHAINCIO` datetime DEFAULT NULL,
  `FECHAFIN` datetime DEFAULT NULL,
  PRIMARY KEY (`IDPERIODO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `periodos`
--

LOCK TABLES `periodos` WRITE;
/*!40000 ALTER TABLE `periodos` DISABLE KEYS */;
/*!40000 ALTER TABLE `periodos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personal`
--

DROP TABLE IF EXISTS `personal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personal` (
  `IDPERSONAL` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `IDAREA` int(11) NOT NULL,
  `IDTIPOPERSONAL` int(11) NOT NULL,
  `CVEPERSONAL` varchar(50) NOT NULL,
  `NOMBRE` varchar(150) DEFAULT NULL,
  `APATERNO` varchar(150) DEFAULT NULL,
  `AMATERNO` varchar(150) DEFAULT NULL,
  `TITULO` varchar(150) DEFAULT NULL,
  `TITULOCORTO` varchar(50) DEFAULT NULL,
  `FECHANACIMIENTO` date DEFAULT NULL,
  `FECHAINGRESO` date DEFAULT NULL,
  `CELULAR` varchar(50) DEFAULT NULL,
  `TELEFONO` varchar(50) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  `DIRECCION` varchar(500) DEFAULT NULL,
  `TIPODOCENTE` varchar(50) DEFAULT NULL,
  `FOTO` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`IDPERSONAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personal`
--

LOCK TABLES `personal` WRITE;
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productos` (
  `ID_PRODUCTO` int(11) NOT NULL,
  `IDCOLEGIO` int(11) DEFAULT NULL,
  `PRODUCTO` int(11) DEFAULT NULL,
  `CLAVEPRODUCTO` varchar(50) DEFAULT NULL,
  `ID_UNIDAD_MEDIDA` smallint(6) DEFAULT NULL,
  `P_COMPRA` double DEFAULT NULL,
  `P_VENTA` double DEFAULT NULL,
  `EXISTENCIA` double DEFAULT NULL,
  PRIMARY KEY (`ID_PRODUCTO`),
  KEY `FK_productos_unidad_medida` (`ID_UNIDAD_MEDIDA`),
  CONSTRAINT `FK_productos_unidad_medida` FOREIGN KEY (`ID_UNIDAD_MEDIDA`) REFERENCES `unidad_medida` (`ID_UNIDAD_MEDIDA`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transacciones`
--

DROP TABLE IF EXISTS `transacciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transacciones` (
  `ID` int(11) NOT NULL,
  `IDCOLEGIO` int(11) DEFAULT NULL,
  `IDALUMNO` int(11) DEFAULT NULL,
  `IDPAGO` int(11) DEFAULT NULL,
  `CONCEPTO` varchar(500) DEFAULT NULL,
  `MONTO` decimal(16,2) DEFAULT NULL,
  `FECHATRANSACCION` datetime DEFAULT NULL,
  `USUARIOTRANSACCION` varchar(50) DEFAULT NULL,
  `FORMAPAGO` varchar(50) DEFAULT NULL,
  `REFERENCIA` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transacciones`
--

LOCK TABLES `transacciones` WRITE;
/*!40000 ALTER TABLE `transacciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `transacciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidad_medida`
--

DROP TABLE IF EXISTS `unidad_medida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidad_medida` (
  `ID_UNIDAD_MEDIDA` smallint(6) NOT NULL,
  `UNIDAD_MEDIDA` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`ID_UNIDAD_MEDIDA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidad_medida`
--

LOCK TABLES `unidad_medida` WRITE;
/*!40000 ALTER TABLE `unidad_medida` DISABLE KEYS */;
/*!40000 ALTER TABLE `unidad_medida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `USER_LOGIN` varchar(50) NOT NULL,
  `USER_PASSWORD` varchar(250) DEFAULT NULL,
  `NOMBRE` varchar(150) DEFAULT NULL,
  `ACTIVO` tinyint(1) NOT NULL,
  `VENTAS` tinyint(1) NOT NULL,
  `REPORTES` tinyint(1) NOT NULL,
  `ADMINISTRAR` tinyint(1) NOT NULL,
  `FECHA_REGISTRO` timestamp NOT NULL DEFAULT current_timestamp(),
  `PRODUCTOS` tinyint(1) NOT NULL,
  `CLIENTES` tinyint(1) NOT NULL,
  `FACTURACION` tinyint(1) NOT NULL,
  `BLOG` tinyint(1) NOT NULL,
  `IMAGEN` varchar(50) NOT NULL,
  `PROY` tinyint(1) NOT NULL,
  `BIBLIO` tinyint(1) NOT NULL,
  `ALUMNOS` tinyint(1) NOT NULL,
  `PROFESORES` tinyint(1) NOT NULL,
  `COBRANZA` tinyint(1) NOT NULL,
  `AYUDA` tinyint(1) NOT NULL,
  `PAGO` tinyint(1) NOT NULL,
  PRIMARY KEY (`USER_LOGIN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venta` (
  `ID_VENTA` int(11) NOT NULL,
  `IDCOLEGIO` int(11) DEFAULT NULL,
  `FECHA_REGISTRO` timestamp NOT NULL DEFAULT current_timestamp(),
  `USER_LOGIN` varchar(50) NOT NULL,
  `DOCSERIE` varchar(50) NOT NULL,
  `DOCNUMBER` bigint(20) NOT NULL,
  `DOCDATE` varchar(50) NOT NULL,
  `TPODOC` varchar(50) NOT NULL,
  `RFCEMISOR` varchar(13) NOT NULL,
  `NMBEMISOR` varchar(60) NOT NULL,
  `RFCRECEP` varchar(13) NOT NULL,
  `NMBRECEP` varchar(60) NOT NULL,
  `MONEDA` varchar(50) NOT NULL,
  `SUBTOTAL` double NOT NULL,
  `IVA` double NOT NULL,
  `TOTAL` double NOT NULL,
  `COMENTARIOS` varchar(300) NOT NULL,
  `VALORPALABRAS` varchar(200) NOT NULL,
  `METODO` varchar(50) NOT NULL,
  `CTAPAGO` varchar(50) NOT NULL,
  `LUGAREXP` varchar(50) NOT NULL,
  `TPOCAMBIO` double NOT NULL,
  PRIMARY KEY (`ID_VENTA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta_detalle`
--

DROP TABLE IF EXISTS `venta_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venta_detalle` (
  `ID_VENTA_DETALLE` int(11) NOT NULL,
  `ID_VENTA` int(11) NOT NULL,
  `ID_PRODUCTO` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `CANTIDAD` double NOT NULL,
  `P_VENTA` double NOT NULL,
  `ADUANA` varchar(50) DEFAULT NULL,
  `PEDIMENTO` varchar(50) DEFAULT NULL,
  `F_PEDIMENTO` varchar(50) DEFAULT NULL,
  `PREDIAL` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID_VENTA_DETALLE`),
  KEY `FK_venta_detalle_venta` (`ID_VENTA`),
  KEY `FK_venta_detalle_productos` (`ID_PRODUCTO`),
  CONSTRAINT `FK_venta_detalle_productos` FOREIGN KEY (`ID_PRODUCTO`) REFERENCES `productos` (`ID_PRODUCTO`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_venta_detalle_venta` FOREIGN KEY (`ID_VENTA`) REFERENCES `venta` (`ID_VENTA`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta_detalle`
--

LOCK TABLES `venta_detalle` WRITE;
/*!40000 ALTER TABLE `venta_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `venta_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta_detalle_tmp`
--

DROP TABLE IF EXISTS `venta_detalle_tmp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venta_detalle_tmp` (
  `ID_VENTA_DETALLE_TMP` int(11) NOT NULL,
  `IDCOLEGIO` int(11) NOT NULL,
  `ID_PRODUCTO` int(11) NOT NULL,
  `CANTIDAD` double NOT NULL,
  `USER_LOGIN` varchar(50) NOT NULL,
  `P_VENTA` double NOT NULL,
  `ADUANA` varchar(50) DEFAULT NULL,
  `PEDIMENTO` varchar(50) DEFAULT NULL,
  `F_PEDIMENTO` varchar(50) DEFAULT NULL,
  `PREDIAL` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID_VENTA_DETALLE_TMP`),
  KEY `FK_venta_detalle_tmp_productos` (`ID_PRODUCTO`),
  CONSTRAINT `FK_venta_detalle_tmp_productos` FOREIGN KEY (`ID_PRODUCTO`) REFERENCES `productos` (`ID_PRODUCTO`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta_detalle_tmp`
--

LOCK TABLES `venta_detalle_tmp` WRITE;
/*!40000 ALTER TABLE `venta_detalle_tmp` DISABLE KEYS */;
/*!40000 ALTER TABLE `venta_detalle_tmp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'tbschooldb'
--
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_ALUMNOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_ALUMNOS`( p_NumeroMatricula	nvarchar(50),
p_IdColegio nvarchar(50),
  p_APaterno	nvarchar(150),
  p_AMaterno	nvarchar(150),
  p_Nombres	nvarchar(150),
  p_FechaNacimiento  nvarchar(20),
  p_Sexo	nvarchar(2),
  p_Nacionalidad	nvarchar(50),
  p_Grado	nvarchar(50),
  p_EscuelaProcedencia	nvarchar(250),
  p_Hermanos	int,
  p_GradoHermanos	nvarchar(50),
  p_Calle	nvarchar(150),
  p_Numero	nvarchar(50),
  p_Colonia	nvarchar(150),
  p_Delegacion	nvarchar(150),
  p_Estado	nvarchar(150),
  p_CodigoPostal	nvarchar(5),
  p_Telefono	nvarchar(50),
  p_Email	nvarchar(200),
  p_Curp	nvarchar(20),
  p_EdadAnos	nvarchar(50),
  p_EdadMeses	nvarchar(50),
  p_Foto	nvarchar(150),
  p_NivelAcademico	nvarchar(50),
  p_NombrePadreTutor	nvarchar(150),
  p_OcupacionPadre	nvarchar(150),
  p_TelefonoPadre	nvarchar(50),
  p_TelefonoTrabajoPadre	nvarchar(50),
  p_CelularPadre	nvarchar(50),
  p_FechaNacimientoPadre	varchar(20),
  p_SueldoPadre	nvarchar(50),
  p_NacionalidadPadre	nvarchar(150),
  p_NombreMadreTutor	nvarchar(150),
  p_OcupacionMadre	nvarchar(150),
  p_TelefonoMadre	nvarchar(50),
  p_TelefonoTrabajoMadre	nvarchar(50),
  p_CelularMadre	nvarchar(50),
  p_FechaNacimientoMadre	varchar(20),
  p_SueldoMadre	nvarchar(50),
  p_NacionalidadMadre	nvarchar(50),
  p_NombreFamVecino	nvarchar(50),
  p_TelefonoVecino	nvarchar(50),
  p_TelefonoTrabajoVecino	nvarchar(50),
  p_CelularVecino	nvarchar(50),
  p_EducacionFisica	int,
  p_Medicamento	int,
  p_NombreMedicamento	nvarchar(150),
  p_DosisMedicamento	nvarchar(150),
  p_Peso	nvarchar(50),
  p_Talla	nvarchar(50),
  p_TipoSangre	nvarchar(50),
  p_Enfermedades	int,
  p_NombreEnfermedades	nvarchar(150),
  p_ProcedimientoCrisis	nvarchar(500),
  p_Certificado	int,
  p_EnfermedadCertificado	int,
  p_Alergia	int,
  p_NombreAlergia	nvarchar(150),
  p_ProcedimintoCrisisAlergia	nvarchar(500),
  p_NombreAccidente	nvarchar(50),
  p_TelefonoAccidente	nvarchar(50),
  p_NombreHospital	nvarchar(150),
  p_Medico	int,
  p_NombreMedico	nvarchar(250),
  p_TelefonoMedico	nvarchar(150),
  p_CedulaMedico	nvarchar(150),
  p_AutorizaTraslado	int,
  p_ProcedimientoAccidente	nvarchar(500),
  p_NombreUsuario nvarchar(50),
  p_Tutor nvarchar(150),
  p_Estatus nvarchar(3),
  p_ServerPath nvarchar(200),
  p_Beca int,
  p_FormaPago int)
sp_lbl:
begin
 DECLARE v_IDAlumno int;
 DECLARE v_SMATRICULA VARCHAR(50);
 DECLARE v_FOLIO INT;
 DECLARE v_NIVEL varchar(5);
 DECLARE v_FOLIOCHAR VARCHAR(4);
 DECLARE v_NombreFoto NVARCHAR(200);
 DECLARE v_RUTAFOTO NVARCHAR(200);
 START TRANSACTION;

 SET v_NIVEL = CASE p_NivelAcademico 
	WHEN '1' THEN 'P'
	WHEN '0' THEN 'K' END;

 IF p_NumeroMatricula IS NULL OR p_NumeroMatricula = ''
		THEN
		CALL proc_GETFOLIOS(p_NivelAcademico,'NUMMAT', v_NIVEL , v_FOLIO);
        SET v_FOLIOCHAR = Right('0000' + v_FOLIO, 4);
			SET v_SMATRICULA = Concat('15' , Right(Concat('0000' , v_FOLIOCHAR), 4) , v_NIVEL);
			SET v_NombreFoto = CONCAT('../Images/Alumnos/' , v_SMATRICULA , '.jpg');
			
	ELSE
			SET v_SMATRICULA = p_NumeroMatricula;
			SET v_NombreFoto = CONCAT('../Images/Alumnos/' , p_NumeroMatricula , '.jpg');
			
		END IF;

		SET v_RUTAFOTO = CONCAT(p_ServerPath , p_NumeroMatricula , '.jpg');


		SELECT v_SMATRICULA AS MATRICULA;
		
 IF NOT EXISTS(SELECT * FROM Alumnos WHERE NumeroMatricula = v_SMATRICULA and IDCOLEGIO = p_IdColegio)
 THEN
 
 INSERT INTO Alumnos
(IDCOLEGIO,NUMEROMATRICULA,FechaRegistro,FechaMatricula,APaterno,AMaterno,Nombres,FechaNacimiento,Sexo,Nacionalidad,Grado,EscuelaProcedencia,Hermanos,GradoHermanos,Calle,Numero,Colonia,Delegacion,Estado,CodigoPostal,Telefono,Email,Curp,EdadAnos,EdadMeses,Tutor,UsuarioAlta,FechaAlta,Foto,NivelAcademico,Estatus,UsuarioModifica,FechaModifica,ServerPath,Beca,FormaPago)
VALUES
(p_IdColegio,v_SMATRICULA,NOW(3),NOW(3),p_APaterno,p_AMaterno,p_Nombres,STR_TO_DATE(p_FechaNacimiento,103),p_Sexo,p_Nacionalidad,p_Grado,p_EscuelaProcedencia,p_Hermanos,p_GradoHermanos,p_Calle,p_Numero,p_Colonia,p_Delegacion,p_Estado,p_CodigoPostal,p_Telefono,p_Email,p_Curp,p_EdadAnos,p_EdadMeses,p_Tutor,p_NombreUsuario,NOW(3),v_NombreFoto,p_NivelAcademico,p_Estatus,p_NombreUsuario,NOW(3),v_RUTAFOTO,p_Beca,p_FormaPago);

SET v_IDAlumno = (SELECT LAST_INSERT_ID());


INSERT INTO InfoAlumnos 
(IDALUMNO,IDCOLEGIO,NumeroMatricula,NombrePadreTutor,OcupacionPadre,TelefonoPadre,TelefonoTrabajoPadre,CelularPadre,FechaNacimientoPadre,SueldoPadre,NacionalidadPadre,NombreMadreTutor,OcupacionMadre,TelefonoMadre,TelefonoTrabajoMadre,CelularMadre,FechaNacimientoMadre,SueldoMadre,NacionalidadMadre,NombreFamVecino,TelefonoVecino,TelefonoTrabajoVecino,CelularVecino,EducacionFisica,
Medicamento,NombreMedicamento,DosisMedicamento,Peso,Talla,TipoSangre,Enfermedades,NombreEnfermedades,ProcedimientoCrisis,Certificado,EnfermedadCertificado,Alergia,NombreAlergia,ProcedimintoCrisisAlergia,NombreAccidente,TelefonoAccidente,NombreHospital,Medico,NombreMedico,TelefonoMedico,CedulaMedico,AutorizaTraslado,ProcedimientoAccidente)
VALUES
(v_IDAlumno,p_IdColegio,v_SMATRICULA,p_NombrePadreTutor,p_OcupacionPadre,p_TelefonoPadre,p_TelefonoTrabajoPadre,p_CelularPadre,STR_TO_DATE(p_FechaNacimientoPadre,103),p_SueldoPadre,p_NacionalidadPadre,p_NombreMadreTutor,p_OcupacionMadre,p_TelefonoMadre,p_TelefonoTrabajoMadre,p_CelularMadre,STR_TO_DATE(p_FechaNacimientoMadre,103),p_SueldoMadre,p_NacionalidadMadre,p_NombreFamVecino,p_TelefonoVecino,p_TelefonoTrabajoVecino,
p_CelularVecino,p_EducacionFisica,p_Medicamento,p_NombreMedicamento,p_DosisMedicamento,p_Peso,p_Talla,p_TipoSangre,p_Enfermedades,p_NombreEnfermedades,p_ProcedimientoCrisis,p_Certificado,p_EnfermedadCertificado,p_Alergia,p_NombreAlergia,p_ProcedimintoCrisisAlergia,p_NombreAccidente,p_TelefonoAccidente,p_NombreHospital,p_Medico,p_NombreMedico,p_TelefonoMedico,p_CedulaMedico,p_AutorizaTraslado,p_ProcedimientoAccidente);


 ELSE
   UPDATE ALUMNOS SET
   APaterno=p_APaterno,AMaterno=p_AMaterno,Nombres=p_Nombres,FechaNacimiento=p_FechaNacimiento,Sexo=p_Sexo,Nacionalidad=p_Nacionalidad,Grado=p_Grado,EscuelaProcedencia=p_EscuelaProcedencia,Hermanos=p_Hermanos,GradoHermanos=p_GradoHermanos,
   Calle=p_Calle,Numero=p_Numero,Colonia=p_Colonia,Delegacion=p_Delegacion,Estado=p_Estado,CodigoPostal=p_CodigoPostal,Telefono=p_Telefono,Email=p_Email,Curp=p_Curp,EdadAnos=p_EdadAnos,EdadMeses=p_EdadMeses,Tutor=p_Tutor,UsuarioModifica=p_NombreUsuario,FechaModifica=NOW(3),Foto=v_NombreFoto,NivelAcademico=p_NivelAcademico,Estatus=p_Estatus,ServerPath = v_RUTAFOTO, Beca=p_Beca, FormaPago = p_FormaPago
   WHERE NumeroMatricula = v_SMATRICULA AND IDCOLEGIO = p_IdColegio;

   UPDATE InfoAlumnos SET
   NombrePadreTutor=p_NombrePadreTutor,OcupacionPadre=p_OcupacionPadre,TelefonoPadre=p_TelefonoPadre,TelefonoTrabajoPadre=p_TelefonoTrabajoPadre,CelularPadre=p_CelularPadre,FechaNacimientoPadre=STR_TO_DATE(p_FechaNacimientoPadre,103),SueldoPadre=p_SueldoPadre,NacionalidadPadre=p_NacionalidadPadre,NombreMadreTutor=p_NombreMadreTutor,OcupacionMadre=p_OcupacionMadre,TelefonoMadre=p_TelefonoMadre,TelefonoTrabajoMadre=p_TelefonoTrabajoMadre,CelularMadre=p_CelularMadre,
   FechaNacimientoMadre=STR_TO_DATE(p_FechaNacimientoMadre,103),SueldoMadre=p_SueldoMadre,NacionalidadMadre=p_NacionalidadMadre,NombreFamVecino=p_NombreFamVecino,TelefonoVecino=p_TelefonoVecino,TelefonoTrabajoVecino=p_TelefonoTrabajoVecino,CelularVecino=p_CelularVecino,EducacionFisica=p_EducacionFisica,Medicamento=p_Medicamento,NombreMedicamento=p_NombreMedicamento,DosisMedicamento=p_DosisMedicamento,Peso=p_Peso,Talla=p_Talla,TipoSangre=p_TipoSangre,
   Enfermedades=p_Enfermedades,NombreEnfermedades=p_NombreEnfermedades,ProcedimientoCrisis=p_ProcedimientoCrisis,Certificado=p_Certificado,EnfermedadCertificado=p_EnfermedadCertificado,Alergia=p_Alergia,NombreAlergia=p_NombreAlergia,ProcedimintoCrisisAlergia=p_ProcedimintoCrisisAlergia,NombreAccidente=p_NombreAccidente,TelefonoAccidente=p_TelefonoAccidente,NombreHospital=p_NombreHospital,Medico=p_Medico,NombreMedico=p_NombreMedico,TelefonoMedico=p_TelefonoMedico,
   CedulaMedico=p_CedulaMedico,AutorizaTraslado=p_AutorizaTraslado,ProcedimientoAccidente=p_ProcedimientoAccidente
  WHERE NumeroMatricula = v_SMATRICULA AND IDCOLEGIO = p_IdColegio;
  END IF;

COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_ASIGNA_ALUMNO_GRUPO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_ASIGNA_ALUMNO_GRUPO`( p_IDALUMNO NVARCHAR(50),
   p_IDGRUPO NVARCHAR(20),
   p_IDCICLO NVARCHAR(20),
   p_USUARIO NVARCHAR(20),
   p_IDCOLEGIO NVARCHAR(20))
begin
DECLARE v_MATRICULA NVARCHAR(50);
  DECLARE v_GRADO NVARCHAR(50);
  DECLARE v_INSCRIPCION DECIMAL(16,2);
  DECLARE v_MENSUALIDAD DECIMAL(16,2);
  DECLARE v_FORMAPAGO INT;

  SET v_FORMAPAGO = (SELECT FormaPago FROM ALUMNOS WHERE IDALUMNO = p_IDALUMNO);
  SET v_MATRICULA = (SELECT NUMEROMATRICULA FROM Alumnos WHERE IDALUMNO=p_IDALUMNO);
  SET v_GRADO = (SELECT GRADO FROM Alumnos WHERE IDALUMNO=p_IDALUMNO);
  SET v_INSCRIPCION = (SELECT MontoInscripcion FROM Ciclo WHERE ID=p_IDCICLO and IDCOLEGIO = p_IDCOLEGIO);
  SET v_MENSUALIDAD = (SELECT MontoColegiatura FROM Ciclo WHERE ID=p_IDCICLO and IDCOLEGIO = p_IDCOLEGIO);



START TRANSACTION;

  UPDATE Alumnos SET GRUPO = p_IDGRUPO, idCiclo=p_IDCICLO WHERE IdAlumno=p_IDALUMNO;
  
  IF v_FORMAPAGO = 1
  THEN

  
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'INSCRIPCION',v_INSCRIPCION,v_INSCRIPCION,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD SEPTIEMBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD OCTUBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD NOVIEMBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD DICIEMBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD ENERO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD FEBRERO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD MARZO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD ABRIL',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD MAYO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD JUNIO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'UNIFORME',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'SEGURO',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'COPIAS',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'LIBROS',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'NATACIÓN',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'TAEKWONDO',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MÚSICA',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'TAREAS',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'FUTBOL',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'BALLET',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'OTRO',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  ELSE

   INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'INSCRIPCION',v_INSCRIPCION,v_INSCRIPCION,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD SEPTIEMBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD OCTUBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD NOVIEMBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD DICIEMBRE',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD ENERO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD FEBRERO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD MARZO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD ABRIL',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD MAYO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD JUNIO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD JULIO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MENSUALIDAD AGOSTO',v_MENSUALIDAD,v_MENSUALIDAD,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'UNIFORME',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'SEGURO',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'COPIAS',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'LIBROS',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'NATACIÓN',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'TAEKWONDO',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'MÚSICA',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'TAREAS',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
   INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'FUTBOL',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'BALLET',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);
  INSERT INTO  PagosAlumno
  (idCiclo,NumeroMatricula,idGrupo,idGrado,idAlumno,Concepto,MontoTotal,MontoActual,idEstatus,FechaModifica,FechaAlta,UsuarioModifica,UsuarioAlta)
    VALUES
  (p_IDCICLO,v_MATRICULA,p_IDGRUPO,v_GRADO,p_IDALUMNO,'OTRO',0.00,0.00,0,NOW(3),NOW(3),p_USUARIO,p_USUARIO);

  END IF;


COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_CATEGORIA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_CATEGORIA`( p_NOMBRE NVARCHAR(200),
   p_IMAGECAT NVARCHAR(200))
begin
START TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM Categoria WHERE Nombre=p_NOMBRE)
 THEN
  INSERT INTO CATEGORIA(NOMBRE,IMAGECAT)
  VALUES(p_NOMBRE,p_IMAGECAT);
 ELSE
  UPDATE CATEGORIA SET
  NOMBRE=p_NOMBRE,
  IMAGECAT=p_IMAGECAT
  WHERE NOMBRE=p_NOMBRE;
 END IF;
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_CICLOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_CICLOS`( p_ID NVARCHAR(50),
p_IDCOLEGIO NVARCHAR(50),
   p_NOMBRECICLO NVARCHAR(50),
   p_FECHAINICIAL NVARCHAR(20),
   p_FECHAFINAL NVARCHAR(20),
   p_MONTOINSCRIPCION NVARCHAR(50),
   p_MONTOCOLEGIATURA NVARCHAR(50),
   p_ESTATUS INT)
begin
START TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM CICLO WHERE ID=p_ID)
 THEN
  INSERT INTO CICLO
  (IdColegio,NombreCiclo,FechaInicio,FechaFin,MontoInscripcion,MontoColegiatura,Estatus)
  VALUES
  (p_IDCOLEGIO,p_NOMBRECICLO,STR_TO_DATE(p_FECHAINICIAL,103),STR_TO_DATE(p_FECHAFINAL,103),p_MONTOINSCRIPCION,p_MONTOCOLEGIATURA,p_ESTATUS);
 ELSE
 UPDATE CICLO SET
  NombreCiclo = p_NOMBRECICLO,
  FechaInicio = STR_TO_DATE(p_FECHAINICIAL,103),
  FechaFin = STR_TO_DATE(p_FECHAFINAL,103),
  MontoInscripcion=CONVERT(p_MONTOINSCRIPCION, DECIMAL(6,2)),
  MontoColegiatura=CONVERT(p_MONTOCOLEGIATURA, DECIMAL(6,2)),
  Estatus=p_ESTATUS
  WHERE Id=p_ID;
 END IF;
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_COLEGIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_COLEGIO`( 
		   p_IDCOLEGIO INT,
           p_NOMBRE varchar(300),
           p_DIRECCION varchar(300),
           p_TELEFONO varchar(200),
           p_EMAIL varchar(100),
           p_REG_PRIMARIA varchar(100),
           p_REG_PRESCOLAR varchar(100),
           p_REG_SECUNDARIA varchar(100),
           p_LEMA varchar(500),
           p_LOGO varchar(100))
BEGIN
 
 START TRANSACTION;


 IF (p_IDCOLEGIO = 0)
 THEN

INSERT INTO `COLEGIO`
           (`NOMBRE`
           ,`DIRECCION`
           ,`TELEFONO`
           ,`EMAIL`
           ,`REG_PRIMARIA`
           ,`REG_PRESCOLAR`
           ,`REG_SECUNDARIA`
           ,`LEMA`
           ,`LOGO`)
     VALUES
           (p_NOMBRE, 
           p_DIRECCION,
           p_TELEFONO,
           p_EMAIL, 
           p_REG_PRIMARIA, 
           p_REG_PRESCOLAR, 
           p_REG_SECUNDARIA,
           p_LEMA,
           p_LOGO);

 ELSE


UPDATE `COLEGIO`
   SET `NOMBRE` = p_NOMBRE, 
      `DIRECCION` = p_DIRECCION, 
      `TELEFONO` = p_TELEFONO, 
      `EMAIL` = p_EMAIL, 
      `REG_PRIMARIA` = p_REG_PRIMARIA, 
      `REG_PRESCOLAR` = p_REG_PRESCOLAR,
      `REG_SECUNDARIA` = p_REG_SECUNDARIA,
      `LEMA` = p_LEMA, 
      `LOGO` = p_LOGO 
 WHERE IDCOLEGIO = p_IDCOLEGIO;







  
  END IF;

COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_FOLIOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_FOLIOS`( p_DOC INT, 
   p_SERIE NVARCHAR(10),
   p_INI BIGINT,
   p_ACT BIGINT, 
   p_FIN BIGINT,
   p_APROBACION VARCHAR(15),
   p_ANO INT,
   p_RFC VARCHAR(13))
begin
START TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM numeracion WHERE nmbSerie=p_SERIE)
 THEN
  INSERT INTO NUMERACION(ID_DOCTYPE,NMBSERIE,NMBNUMBERFROM,NMBCURRENTNUMBER,NMBNUMBERTO,NMBAUTHDATE,NMBAUTHNUMBER,NMBRFC)
  VALUES(p_DOC,p_SERIE,p_INI,p_ACT,p_FIN,p_ANO,p_APROBACION,p_RFC);
 ELSE
  UPDATE NUMERACION SET
  ID_DOCTYPE=p_DOC,
  NMBSERIE=p_SERIE,
  NMBNUMBERFROM=p_INI,
  NMBCURRENTNUMBER=p_ACT,
  NMBNUMBERTO=p_FIN,
  NMBAUTHNUMBER=p_APROBACION,
  NMBAUTHDATE=p_ANO,
  NMBRFC=p_RFC
  WHERE NMBSERIE=p_SERIE;
 END IF;
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GETFOLIOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GETFOLIOS`(p_CveProc VARChar(10), 
  	 p_Tipo varChar(10),
  	 p_Serie varchar(10),
  	 OUT p_Num_Folio numeric(18,0)
  	)
begin
Declare  v_FolIni numeric(18,0);
Declare  v_FolAct numeric(18,0);
Declare  v_Fecha  DateTime(3);

Start Transaction;
	select inicial, Actual, Fecha_Inicio into v_FolIni, v_FolAct, v_Fecha from Numeraciones 
	where rtrim(Clave_Proceso) = rtrim(p_CveProc) and Serie = p_Serie  and
	rtrim(Tipo_Proc) = rtrim(p_Tipo)  and actual < final
	order by inicial
	limit 1;
	if v_FolAct = 0 
	then
		Set v_FolAct = v_FolIni - 1;
		Set v_Fecha = NOW(3);
	end if;

	Update Numeraciones Set Actual = v_FolAct + 1, Fecha_Inicio = v_Fecha 
	where rtrim(Clave_Proceso) = rtrim(p_CveProc) and Serie = p_Serie and
	rtrim(Tipo_Proc) = rtrim(p_Tipo) and inicial = v_FolIni;

	SET p_Num_Folio = v_FolAct + 1;

commit;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GRUPOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GRUPOS`( p_ID NVARCHAR(50),
   p_IDCOLEGIO NVARCHAR(20),
   p_IDNIVEL NVARCHAR(50),
   p_IDGRADO NVARCHAR(20),
   p_IDCICLO NVARCHAR(20),
   p_NOMBREGRUPO NVARCHAR(50))
begin
START TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM GRUPO WHERE IDGRUPO=p_ID)
 THEN
  INSERT INTO GRUPO
  (IDCOLEGIO,IDNIVEL,IDGRADO,IDCICLO,NOMBREGRUPO)
  VALUES
  (p_IDCOLEGIO,p_IDNIVEL,p_IDGRADO,p_IDCICLO,p_NOMBREGRUPO);
 ELSE
 UPDATE GRUPO SET
  IDNIVEL = p_IDNIVEL,
  IDGRADO = p_IDGRADO,
  IDCICLO = p_IDCICLO,
  NOMBREGRUPO = p_NOMBREGRUPO
 
  WHERE IdGRUPO=p_ID;
 END IF;
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_ALUMNOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_ALUMNOS`( 
    p_IdColegio varchar(200),
    p_MATRICULA varchar(200) /* = NULL */,
  	p_Nombres varchar(200)/* = NULL */,
  	p_APaterno varchar(200)/* = NULL */,
  	p_AMaterno varchar(200)/* = NULL */,
  	p_FechaNacimiento varchar(20)/* = NULL */,
  	p_Estatus varchar(20)/* = NULL */)
begin
-- SQLINES DEMO ***  for procedure here

DECLARE v_Seleccion varchar(2000);
DECLARE v_Origen varchar(2000);
DECLARE v_Condiciones varchar(2000);
DECLARE v_Consulta nvarchar(4000);
Set v_Seleccion = CONCAT('SELECT IDALUMNO,NUMEROMATRICULA,NOMBRES,APATERNO,AMATERNO,CONVERT(varchar,FECHANACIMIENTO,103) AS FECHANACIMIENTO, DESCESTATUS = CASE ESTATUS WHEN ''0'' THEN ''NO INSCRITO''
	WHEN ''1'' THEN ''INSCRITO'' END ' , Char(10 Using ascii));
Set v_Origen = CONCAT('FROM Alumnos ' , Char(10 Using ascii));
Set v_Condiciones=CONCAT('WHERE 1=1 AND IDCOLEGIO=' , p_IdColegio , Char(10 Using ascii));
--  SQLINES DEMO *** WHERE 1=1 '
IF p_MATRICULA IS NULL OR p_MATRICULA = ''
THEN
 SET v_Condiciones = v_Condiciones;
ELSE 
 SET v_Condiciones = CONCAT(v_Condiciones , ' AND NumeroMatricula = ' , Quotename(p_MATRICULA,'''') , '');
END IF;
IF p_Nombres IS NULL OR p_Nombres = ''
THEN
 SET v_Condiciones = v_Condiciones;
ELSE 
SET v_Condiciones = CONCAT(v_Condiciones , ' AND Nombres LIKE ''%' , p_Nombres , '%''');      
END IF;
IF p_APaterno IS NULL OR p_APaterno = ''
THEN
 SET v_Condiciones = v_Condiciones;
ELSE 
--  SQLINES DEMO ***  @Condiciones + ' AND APATERNO = ' + Quotename(@APaterno,'''') + ''
SET v_Condiciones = CONCAT(v_Condiciones , ' AND APATERNO LIKE ''%' , p_APaterno , '%''');
END IF;

IF p_AMaterno IS NULL OR p_AMaterno = ''
THEN
 SET v_Condiciones = v_Condiciones;
ELSE 
SET v_Condiciones = CONCAT(v_Condiciones , ' AND AMATERNO LIKE ''%' , p_AMaterno , '%''');
END IF;

IF p_FechaNacimiento IS NULL OR p_FechaNacimiento = ''
THEN
 SET v_Condiciones = v_Condiciones;
ELSE 
SET v_Condiciones = CONCAT(v_Condiciones , ' AND FECHANACIMIENTO = ' , Quotename(p_FechaNacimiento,'''') , '');
END IF;

IF p_Estatus IS NULL or p_Estatus = '-1' or  p_Estatus = ''
THEN
 SET v_Condiciones = v_Condiciones;
ELSE 
SET v_Condiciones = CONCAT(v_Condiciones , ' AND ESTATUS = ' , Quotename(p_Estatus,'''') , '');
END IF;


SET v_Consulta = CONCAT(v_Seleccion , v_Origen , v_Condiciones);
/* PRINT v_Consulta */

CALL sp_executesql(v_Consulta, N'@Matricula AS varchar(200),@Nombres varchar(200),@APaterno varchar(200),@AMaterno varchar(200),@FechaNacimiento varchar(20),@Estatus varchar(200)',p_MATRICULA,p_Nombres,p_APaterno,p_AMaterno,p_FechaNacimiento,p_Estatus);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_ALUMNOS_GRUPO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_ALUMNOS_GRUPO`( 
p_IDCOLEGIO varchar(50),
p_IDGRADO varchar(50),
  	p_IDGRUPO varchar(50))
begin
-- SQLINES DEMO ***  for procedure here

SELECT * FROM Alumnos WHERE Grado = p_IDGRADO AND Grupo=p_IDGRUPO AND IDCOLEGIO = p_IDCOLEGIO order by APaterno, AMaterno;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_ALUMNOS_GRUPO_ADD` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_ALUMNOS_GRUPO_ADD`( p_IDGRADO varchar(50),
p_IDCOLEGIO varchar(50))
begin
-- SQLINES DEMO ***  for procedure here

SELECT * FROM Alumnos WHERE Grado = p_IDGRADO AND GRUPO IS NULL and IDCOLEGIO = p_IDCOLEGIO order by APaterno, AMaterno;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_DETALLES` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_DETALLES`( p_ID_VENTA int)
begin
SELECT T.id_venta_detalle,P.id_producto, 
P.producto, T.cantidad,  T.p_venta,
(T.cantidad * T.p_venta) AS TOTAL,T.aduana,T.pedimento,T.f_pedimento,T.predial,(SELECT unidad_medida FROM UNIDAD_MEDIDA WHERE id_unidad_medida=P.id_unidad_medida) AS UM
FROM productos P JOIN venta_detalle T ON P.id_producto=T.id_producto
JOIN unidad_medida M ON P.id_unidad_medida=M.id_unidad_medida
WHERE T.id_venta=p_ID_VENTA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_DEUDORES` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_DEUDORES`( 
p_IDCOLEGIO nvarchar(20))
begin
-- SQLINES DEMO ***  for procedure here

SELECT A.IDALUMNO, A.APaterno, A.AMaterno, A.Nombres, GR.NombreGrupo, G.DescripcionGrado ,PA.ID,PA.CONCEPTO, PA.MontoActual
FROM ALUMNOS A, PAGOSALUMNO PA , GRUPO GR, GRADO G
WHERE A.GRADO = G.IDGrado
AND A.Grupo = GR.IDGrupo AND PA.idEstatus IN (0,2)
and A.IDCOLEGIO = p_IDCOLEGIO
ORDER BY DescripcionGrado,NombreGrupo;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_GRADO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_GRADO`( p_NIVEL varchar(2),
p_IDCOLEGIO varchar(50))
BEGIN
SELECT IDGRADO, DESCRIPCIONGRADO FROM GRADO WHERE IDNIVEL = p_NIVEL AND IDCOLEGIO = p_IDCOLEGIO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_PAGOS_ALUMNO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_PAGOS_ALUMNO`( p_IDALUMNO VARCHAR (50))
begin
-- SQLINES DEMO ***  for procedure here

SELECT A.IDALUMNO,PA.ID,PA.CONCEPTO, PA.MontoActual , 
 CASE PA.IDESTATUS 
WHEN 0 THEN 'SIN PAGAR'
WHEN 1 THEN 'PAGADO'
WHEN 2 THEN 'ABONADO'
END AS ESTATUS, PA.FechaMovimiento
FROM ALUMNOS A,PAGOSALUMNO PA
WHERE A.IDALUMNO = p_IDALUMNO AND A.IDALUMNO = PA.IDALUMNO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_PAGOS_ALUMNO_MATRICULA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_PAGOS_ALUMNO_MATRICULA`( p_MATRICULA VARCHAR (50), p_IDCOLEGIO VARCHAR(50))
begin
-- SQLINES DEMO ***  for procedure here

SELECT A.IDALUMNO,PA.ID,PA.CONCEPTO, PA.MontoActual , 
 CASE PA.IDESTATUS 
WHEN 0 THEN 'SIN PAGAR'
WHEN 1 THEN 'PAGADO'
WHEN 2 THEN 'ABONADO'
END AS ESTATUS, PA.FechaMovimiento
FROM ALUMNOS A,PAGOSALUMNO PA
WHERE A.NumeroMatricula = p_MATRICULA 
AND A.IDCOLEGIO = p_IDCOLEGIO
AND A.IDALUMNO = PA.IDALUMNO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_PAGOS_TRANSACCIONES` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_PAGOS_TRANSACCIONES`( p_IDPAGO VARCHAR (50),
  	p_IDALUMNO VARCHAR (50))
begin
-- SQLINES DEMO ***  for procedure here

SELECT *, CASE  FormaPago
WHEN 1 THEN 'EFECTIVO'
WHEN 2 THEN 'CHEQUE'
WHEN 0 THEN 'TRANSFERENCIA'
WHEN 1 THEN 'DEPOSITO'
WHEN 2 THEN 'OTRO'
END AS DESCFORMAPAGO 
FROM Transacciones
WHERE idPago = p_IDPAGO AND IDALUMNO = p_IDALUMNO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_LISTA_TEMP_VENTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_LISTA_TEMP_VENTAS`( p_USER_LOGIN NVARCHAR(50))
begin
SELECT T.id_venta_detalle_tmp,P.id_producto, 
P.producto, T.cantidad,  T.p_venta,
(T.cantidad * T.p_venta) AS TOTAL,T.aduana,T.pedimento,T.f_pedimento,T.predial,(SELECT unidad_medida FROM UNIDAD_MEDIDA WHERE id_unidad_medida=P.id_unidad_medida) AS UM
FROM productos P JOIN venta_detalle_tmp T ON P.id_producto=T.id_producto
JOIN unidad_medida M ON P.id_unidad_medida=M.id_unidad_medida
WHERE T.user_login=p_USER_LOGIN;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_MATERIAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_MATERIAS`( 
			p_IDMATERIA int,
		    p_IDCOLEGIO int,
            p_IDGRADO int,
            p_IDGRUPO int,
            p_CVEMATERIA varchar(50),
            p_NOMBREMATERIA varchar(150))
BEGIN
 
 START TRANSACTION;


 IF (p_IDMATERIA = 0)
 THEN
 
INSERT INTO `MATERIAS`
           (`IDCOLEGIO`
           ,`IDGRADO`
           ,`IDGRUPO`
           ,`CVEMATERIA`
           ,`NOMBREMATERIA`)
     VALUES
           (p_IDCOLEGIO,
            p_IDGRADO,
            p_IDGRUPO,
            p_CVEMATERIA,
            p_NOMBREMATERIA);




 ELSE
UPDATE `MATERIAS`
   SET `IDCOLEGIO` = p_IDCOLEGIO, 
       `IDGRADO` = p_IDGRADO, 
       `IDGRUPO` = p_IDGRUPO, 
       `CVEMATERIA` = p_CVEMATERIA,
       `NOMBREMATERIA` = p_NOMBREMATERIA
 WHERE IDMATERIA = p_IDMATERIA;

  END IF;

COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_OBTIENE_PAGO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_OBTIENE_PAGO`( p_IDPAGO VARCHAR (50))
begin
-- SQLINES DEMO ***  for procedure here

SELECT A.IDALUMNO,PA.ID,PA.CONCEPTO, PA.MontoActual , 
 CASE PA.IDESTATUS 
WHEN 0 THEN 'SIN PAGAR'
WHEN 1 THEN 'PAGADO'
WHEN 2 THEN 'ABONADO'
END AS ESTATUS, PA.FechaMovimiento
FROM ALUMNOS A,PAGOSALUMNO PA
WHERE PA.id = p_IDPAGO AND A.IDALUMNO = PA.IDALUMNO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_PERIODOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_PERIODOS`( 
             p_IDPERIODO int,
			 p_IDCICLO int,
             p_IDCOLEGIO int,
             p_DESCRIPCION varchar(250),
             p_FECHAINCIO date,
             p_FECHAFIN date)
BEGIN
 
 START TRANSACTION;


 IF (p_IDPERIODO = 0)
 THEN

INSERT INTO `PERIODOS`
           (`IDCICLO`
           ,`IDCOLEGIO`
           ,`DESCRIPCION`
           ,`FECHAINCIO`
           ,`FECHAFIN`)
     VALUES
           (p_IDCICLO,
           p_IDCOLEGIO,
           p_DESCRIPCION,
           p_FECHAINCIO,
           p_FECHAFIN);

 ELSE
UPDATE `PERIODOS`
   SET `IDCICLO` = p_IDCICLO,
      `IDCOLEGIO` = p_IDCOLEGIO,
      `DESCRIPCION` = p_DESCRIPCION,
      `FECHAINCIO` = p_FECHAINCIO,
      `FECHAFIN` = p_FECHAFIN
 WHERE IDPERIODO = p_IDPERIODO;
  END IF;

COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_PERSONAL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_PERSONAL`( 
           p_IDPERSONAL int,
		   p_IDCOLEGIO int,
           p_IDAREA int,
           p_IDTIPOPERSONAL int,
           p_CVEPERSONAL nvarchar(50),
           p_NOMBRE varchar(150),
           p_APATERNO varchar(150),
           p_AMATERNO varchar(150),
           p_TITULO varchar(150),
           p_TITULOCORTO varchar(50),
           p_FECHANACIMIENTO date,
           p_FECHAINGRESO date,
           p_CELULAR varchar(50),
           p_TELEFONO varchar(50),
           p_EMAIL varchar(100),
           p_DIRECCION varchar(500),
           p_TIPODOCENTE varchar(50),
           p_FOTO varchar(250))
BEGIN
 DECLARE v_IDAlumno int;
 DECLARE v_SMATRICULA VARCHAR(50);
 DECLARE v_FOLIO INT;
 DECLARE v_NIVEL varchar(5);
 DECLARE v_FOLIOCHAR VARCHAR(4);
 DECLARE v_NombreFoto NVARCHAR(200);
 DECLARE v_RUTAFOTO NVARCHAR(200);
 DECLARE v_FechaY Varchar(1);
 START TRANSACTION ;

 set v_FechaY = (Select Right(Cast(Year(now(3)) As Char(4)),2));

 IF p_CVEPERSONAL IS NULL OR p_CVEPERSONAL = ''
		THEN
		CALL proc_GETFOLIOS('5','NUMPER', 'D' , v_FOLIO);
        SET v_FOLIOCHAR = Right('0000' + v_FOLIO, 4);
			SET v_SMATRICULA = CONCAT(v_FechaY , Right(Concat('0000' , v_FOLIOCHAR), 4) , v_NIVEL);
			SET v_NombreFoto = CONCAT('/Images/Personal/' , v_SMATRICULA , '.jpg');
			
	ELSE
			SET v_SMATRICULA = p_CVEPERSONAL;
			SET v_NombreFoto = CONCAT('/Images/Personal/' , p_CVEPERSONAL , '.jpg');
			
		END IF;

		


		SELECT v_SMATRICULA AS MATRICULA;
		
 IF (p_IDPERSONAL = 0)
 THEN
 
 
INSERT INTO `PERSONAL`
           (`IDCOLEGIO`
           ,`IDAREA`
           ,`IDTIPOPERSONAL`
           ,`CVEPERSONAL`
           ,`NOMBRE`
           ,`APATERNO`
           ,`AMATERNO`
           ,`TITULO`
           ,`TITULOCORTO`
           ,`FECHANACIMIENTO`
           ,`FECHAINGRESO`
           ,`CELULAR`
           ,`TELEFONO`
           ,`EMAIL`
           ,`DIRECCION`
           ,`TIPODOCENTE`
           ,`FOTO`)
     VALUES
           (p_IDCOLEGIO,
           p_IDAREA, 
           p_IDTIPOPERSONAL,
           v_SMATRICULA, 
           p_NOMBRE, 
           p_APATERNO,
           p_AMATERNO, 
           p_TITULO, 
           p_TITULOCORTO, 
           p_FECHANACIMIENTO, 
           p_FECHAINGRESO, 
           p_CELULAR, 
           p_TELEFONO, 
           p_EMAIL, 
           p_DIRECCION, 
           p_TIPODOCENTE, 
           p_FOTO);

 ELSE


UPDATE `PERSONAL`
   SET `IDAREA` = p_IDAREA, 
      `IDTIPOPERSONAL` = p_IDTIPOPERSONAL,
      `CVEPERSONAL` = p_CVEPERSONAL,
      `NOMBRE` = p_NOMBRE,
      `APATERNO` = p_APATERNO,
      `AMATERNO` = p_AMATERNO,
      `TITULO` = p_TITULO,
      `TITULOCORTO` = p_TITULOCORTO, 
      `FECHANACIMIENTO` = p_FECHANACIMIENTO,
      `FECHAINGRESO` = p_FECHAINGRESO,
      `CELULAR` = p_CELULAR, 
      `TELEFONO` = p_TELEFONO, 
      `EMAIL` = p_EMAIL, 
      `DIRECCION` = p_DIRECCION, 
      `TIPODOCENTE` = p_TIPODOCENTE, 
      `FOTO` = p_FOTO
 WHERE IDPERSONAL = p_IDPERSONAL;




  
  END IF;

COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_PRODS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_PRODS`( p_ID_PRODUCTO NVARCHAR(50),
   p_PRODUCTO NVARCHAR(250),
   p_ID_UNIDAD_MEDIDA SMALLINT,
   p_COMPRA DOUBLE,
   p_VENTA DOUBLE,
   p_EXISTENCIA DOUBLE)
begin
START TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM productos WHERE id_producto=p_ID_PRODUCTO)
 THEN
  INSERT INTO PRODUCTOS(ID_PRODUCTO,PRODUCTO,ID_UNIDAD_MEDIDA,P_COMPRA,P_VENTA,EXISTENCIA)
  VALUES(p_ID_PRODUCTO,p_PRODUCTO,p_ID_UNIDAD_MEDIDA,p_COMPRA,p_VENTA,p_EXISTENCIA);
 ELSE
  UPDATE PRODUCTOS SET
  PRODUCTO=p_PRODUCTO,
  ID_UNIDAD_MEDIDA=p_ID_UNIDAD_MEDIDA,
  P_COMPRA=p_COMPRA,
  P_VENTA=p_VENTA,
  EXISTENCIA=p_EXISTENCIA
  WHERE ID_PRODUCTO=p_ID_PRODUCTO;
 END IF;
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_REGISTRA_PAGO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_REGISTRA_PAGO`( p_IDPAGO VARCHAR (50),
  	p_IDALUMNO VARCHAR (50),
  	p_MONTO VARCHAR (50),
  	p_REFERENCIA VARCHAR(500),
  	p_MEDIOPAGO VARCHAR(50),
  	p_ESTATUS VARCHAR(50))
begin
DECLARE v_MONTOACTUAL DECIMAL(16,2);
DECLARE v_NUEVOMONTO DECIMAL(16,2);
DECLARE v_CONCEPTO VARCHAR(500);
SET v_MONTOACTUAL = (SELECT MONTOACTUAL FROM PagosAlumno WHERE ID = p_IDPAGO);
SET v_NUEVOMONTO = (v_MONTOACTUAL - (CONVERT(p_MONTO, DECIMAL(16,2))));
SET v_CONCEPTO = (SELECT CONCEPTO FROM PagosAlumno WHERE ID = p_IDPAGO);
IF p_ESTATUS = 1
THEN
SET v_CONCEPTO = CONCAT('PAGO FINAL DE ' , v_CONCEPTO);
END IF;

IF p_ESTATUS = 2
THEN
SET v_CONCEPTO = CONCAT('PAGO A CUENTA DE ' , v_CONCEPTO);
END IF;
-- SQLINES DEMO ***  for procedure here
UPDATE PagosAlumno SET MontoActual = v_NUEVOMONTO, idEstatus = p_ESTATUS, FechaMovimiento=NOW(3),MEDIOPAGO = p_MEDIOPAGO, REFERENCIA = p_REFERENCIA
WHERE ID = p_IDPAGO AND IDALUMNO=p_IDALUMNO;

INSERT INTO TRANSACCIONES 
(idAlumno,idPago,Concepto,Monto,FechaTransaccion,UsuarioTransaccion,FormaPago,Referencia)
VALUES
(p_IDALUMNO,p_IDPAGO,v_CONCEPTO,CONVERT(p_MONTO, DECIMAL(16,2)),NOW(3),'ADMIN',p_MEDIOPAGO,p_REFERENCIA);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_RPT_ALUMNO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_RPT_ALUMNO`( p_MATRICULA NVARCHAR(50),
p_IDCOLEGIO NVARCHAR(50))
begin
SELECT A.*, B.*, GR.NombreGrupo, G.DescripcionGrado, C.NombreCiclo
FROM
Alumnos A, InfoAlumnos B, Grupo GR, Grado G, CICLO C
WHERE A.NumeroMatricula = p_MATRICULA AND A.NumeroMatricula = B.NumeroMatricula
AND A.IDCOLEGIO = p_IDCOLEGIO
AND A.Grupo = GR.IDGrupo
AND A.Grado = G.IDGrado
AND A.idCiclo = C.id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_RPT_CREDENCIAL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_RPT_CREDENCIAL`( p_MATRICULA NVARCHAR(300),p_IDCOLEGIO NVARCHAR(20),p_IDCICLO NVARCHAR(20))
SELECT A.*, B.*, GR.NombreGrupo, G.DescripcionGrado, C.NombreCiclo
			FROM Alumnos A, InfoAlumnos B, Grupo GR, Grado G, CICLO C 
			WHERE A.NumeroMatricula in (p_MATRICULA)
			AND A.IdColegio = p_IDCOLEGIO
            AND A.idCiclo = p_IDCICLO
			AND A.NumeroMatricula = B.NumeroMatricula
			AND A.Grupo = GR.IDGrupo
			AND A.Grado = G.IDGrado ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_RPT_PAGOS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_RPT_PAGOS`( p_FECHA_INI VARCHAR(10),
      p_FECHA_FIN VARCHAR(10),
	  p_IDCOLEGIO VARCHAR(20))
begin
select A.IdAlumno, A.NumeroMatricula, A.Apaterno, A.AMaterno, A.Nombres,GR.NombreGrupo, G.DescripcionGrado, T.Concepto, T.Monto, T.FechaTransaccion, p_FECHA_INI AS FINI, p_FECHA_FIN AS FFIN,
case T.FormaPago when 1 then 'EFECTIVO'
WHEN 2 THEN 'CHEQUE'
WHEN 3 THEN 'TRANSFERENCIA'
WHEN 4 THEN 'DEPOSITO'
WHEN 5 THEN 'OTRO' 
ELSE 'NO IDENTIFICADO' END AS FPAGO, T.REFERENCIA
 from Transacciones T, Alumnos A, Grupo GR, Grado G
 where T.FechaTransaccion >= str_to_date(p_FECHA_INI,103) and T.FechaTransaccion <= str_to_date(p_FECHA_FIN,103)
 AND A.IDCOLEGIO = p_IDCOLEGIO
AND T.idAlumno = A.IdAlumno
AND A.Grupo = GR.IDGrupo
AND A.Grado = G.IDGrado ORDER BY FechaTransaccion;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_RPT_RECIBO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_RPT_RECIBO`( p_IDALUMNO VARCHAR(20))
begin
select Concepto, Monto, FechaTransaccion,
case FormaPago when 1 then 'EFECTIVO'
WHEN 2 THEN 'CHEQUE'
WHEN 3 THEN 'TRANSFERENCIA'
WHEN 4 THEN 'DEPOSITO'
WHEN 5 THEN 'OTRO' 
ELSE 'NO IDENTIFICADO' END AS FPAGO, REFERENCIA 
 from Transacciones where DATE_FORMAT(FechaTransaccion,'%d/%m/%Y') = date_format(now(3),'%d/%m/%Y')
AND IdAlumno = p_IDALUMNO;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_RPT_RECIBO_ALUMNO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_RPT_RECIBO_ALUMNO`( p_IDALUMNO NVARCHAR(20))
begin
SELECT A.IdAlumno, A.APaterno, A.AMaterno, A.Nombres, GR.NombreGrupo, G.DescripcionGrado, C.NombreCiclo
FROM
Alumnos A, Grupo GR, Grado G, CICLO C
WHERE A.IdAlumno = p_IDALUMNO
AND A.Grupo = GR.IDGrupo
AND A.Grado = G.IDGrado
AND A.idCiclo = C.id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_RPT_VENTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_RPT_VENTAS`( p_FECHA_INI DATETIME(3),
      p_FECHA_FIN DATETIME(3))
begin
SELECT V.id_venta,V.fecha_registro, P.id_producto,P.producto,
D.cantidad,D.p_venta, D.cantidad*D.p_venta AS TOTAL
FROM
venta V JOIN venta_detalle D ON V.id_venta=V.id_venta
JOIN productos P ON D.id_producto=P.id_producto
WHERE V.fecha_registro BETWEEN p_FECHA_INI AND p_FECHA_FIN;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_TEMP_VENTAS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_TEMP_VENTAS`( p_USER_LOGIN NVARCHAR(50),  
      p_ID_PRODUCTO NVARCHAR(50), 
      p_CANTIDAD DOUBLE,
      p_ADUANA NVARCHAR(50), 
  	p_PEDIMENTO NVARCHAR(50), 
  	p_FECHAPEDIMENTO NVARCHAR(50), 
  	p_PREDIAL NVARCHAR(50))
begin
    
     DECLARE v_PRECIO DOUBLE; DECLARE v_IVA DOUBLE; DECLARE v_EXISTENCIA DOUBLE; DECLARE v_CANT DOUBLE; DECLARE v_PORC_DESC DOUBLE;
START TRANSACTION;
   
    SELECT EXISTENCIA INTO v_EXISTENCIA FROM productos WHERE ID_PRODUCTO=p_ID_PRODUCTO;
    SET v_PORC_DESC=0;
    SELECT p_venta,ID_PRODUCTO INTO v_PRECIO, p_ID_PRODUCTO FROM productos 
    WHERE ID_PRODUCTO=p_ID_PRODUCTO
    LIMIT 1;
    
    IF EXISTS(SELECT ID_PRODUCTO FROM venta_detalle_tmp 
    WHERE ID_PRODUCTO=p_ID_PRODUCTO AND user_login=p_USER_LOGIN)
    THEN
        -- EDI... SQLINES DEMO ***
        SELECT CANTIDAD INTO v_CANT FROM venta_detalle_tmp 
        WHERE ID_PRODUCTO=p_ID_PRODUCTO AND user_login=p_USER_LOGIN;
        IF(p_CANTIDAD<=(v_EXISTENCIA-v_CANT))
        THEN
            UPDATE venta_detalle_tmp 
            SET CANTIDAD = CANTIDAD + p_CANTIDAD
            WHERE user_login = p_USER_LOGIN
            AND ID_PRODUCTO=p_ID_PRODUCTO AND user_login=p_USER_LOGIN;
         END IF;
    ELSE
        -- INS... SQLINES DEMO ***
        IF(p_CANTIDAD<=v_EXISTENCIA)
        THEN
            INSERT  INTO venta_detalle_tmp(user_login,ID_PRODUCTO,CANTIDAD,p_venta,aduana,pedimento,f_pedimento,predial)
            VALUES(p_USER_LOGIN,p_ID_PRODUCTO,p_CANTIDAD,v_PRECIO,p_ADUANA,p_PEDIMENTO,p_FECHAPEDIMENTO,p_PREDIAL);
          END IF;
    END IF;
    
   
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_UM` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_UM`( p_UMEDIDA NVARCHAR(50))
begin
START TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM unidad_medida WHERE unidad_medida=p_UMEDIDA)
 THEN
  INSERT INTO UNIDAD_MEDIDA(UNIDAD_MEDIDA)
  VALUES(p_UMEDIDA);
 ELSE
  UPDATE UNIDAD_MEDIDA SET
  UNIDAD_MEDIDA=p_UMEDIDA
  WHERE UNIDAD_MEDIDA=p_UMEDIDA;
 END IF;
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_USERS` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_USERS`( p_USER_LOGIN NVARCHAR(50),
   p_USER_PASSWORD VARCHAR(8000),
   p_NOMBRE NVARCHAR(50),
   p_ACTIVO TINYINT,
   p_ADMINISTRACION TINYINT,
   p_ALUMNOS TINYINT,
   p_PROFESORES TINYINT, 
   p_COBRANZA TINYINT,
   p_BLOG TINYINT, 
   p_AYUDA TINYINT,
   p_IMAGEN NVARCHAR(50))
begin
START TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM users WHERE user_login=p_USER_LOGIN)
 THEN
  INSERT INTO USERS

(USEr_LOGIN,USER_PASSWORD,NOMBRE,activo,administrar,alumnos,profesores,cobranza,blog,ayuda,imagen)
  VALUES

(p_USER_LOGIN,p_USER_PASSWORD,p_NOMBRE,p_ACTIVO,p_ADMINISTRACION,p_ALUMNOS,p_PROFESORES,p_COBRANZA,p_BLOG,p_AYUDA,p_IMAGEN);
 ELSE
 UPDATE USERS SET
  NOMBRE=p_NOMBRE,
  activo=p_ACTIVO,
  ADMINISTRAR=p_ADMINISTRACION,
  alumnos=p_ALUMNOS,
  profesores=p_PROFESORES,
  cobranza = p_COBRANZA,
  blog=p_BLOG,
  ayuda=p_AYUDA,
  imagen=p_IMAGEN
  WHERE user_login=p_USER_LOGIN;
 END IF;
COMMIT;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_USERS_PERMISOS_MOSTRAR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_USERS_PERMISOS_MOSTRAR`( p_USER_LOGIN NVARCHAR(50))
begin
SELECT U.* FROM USERS U WHERE U.`USER_LOGIN`=p_USER_LOGIN;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ZERO_IN_DATE,NO_ZERO_DATE,NO_ENGINE_SUBSTITUTION' */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_VENTA` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_VENTA`( p_USER_LOGIN NVARCHAR(50),
  p_SERIE VARCHAR(50),
  p_NUMERO BIGINT,
  p_DATE NVARCHAR(50),
  p_TPODOC NVARCHAR(50),
  p_RFCE NVARCHAR(13),
  p_NMBE NVARCHAR(60),
  p_RFCR NVARCHAR(13),
  p_NMBR NVARCHAR(60),
  p_MONEDA NVARCHAR(50),
  p_SUBTOTAL DOUBLE,
  p_IVA DOUBLE,
  p_TOTAL DOUBLE,
  p_COMENT NVARCHAR(300),
  p_PALABRAS NVARCHAR(200),
  p_METODO NVARCHAR(50),
  p_CTAPAGO NVARCHAR(50),
  p_LUGAREXP NVARCHAR(50),
  p_TPOCAMBIO DOUBLE)
begin
  
  DECLARE v_FOLIO_VENTA INT;
START TRANSACTION;
    
   
    -- GRA... SQLINES DEMO ***
    --  SQLINES DEMO *** oat prmNUMERO,string prmDATE,string prmTPODOC,string prmRFCE,string prmNMBE,string prmRFCR,string prmNMBR,string prmMONEDA,float prmSUBTOTAL,float prmIVA,float prmTOTAL
    INSERT INTO VENTA(user_login,fecha_registro,docSerie,docNumber,docDate,tpoDoc,rfcEmisor,nmbEmisor,rfcRecep,nmbRecep,moneda,subtotal,iva,total,comentarios,valorPalabras,metodo,ctaPago,lugarExp,tpoCambio) 
    VALUES(p_USER_LOGIN,NOW(3),p_SERIE,p_NUMERO,p_DATE,p_TPODOC,p_RFCE,p_NMBE,p_RFCR,p_NMBR,p_MONEDA,p_SUBTOTAL,p_IVA,p_TOTAL,p_COMENT,p_PALABRAS,p_METODO,p_CTAPAGO,p_LUGAREXP,p_TPOCAMBIO);
    --  SQLINES DEMO ***  DE LA VENTA
    SET v_FOLIO_VENTA=LAST_INSERT_ID();
    --  SQLINES DEMO *** MERACION RESPECTO A LA SERIE
	UPDATE numeracion 
    SET numeracion.NMBCURRENTNUMBER = p_NUMERO + 1
    WHERE nmbSerie = p_SERIE AND nmbRFC = p_RFCE;
    --  SQLINES DEMO *** LLE DE LA VENTA
    INSERT INTO VENTA_DETALLE(id_venta,ID_PRODUCTO,CANTIDAD,P_VENTA,ADUANA,PEDIMENTO,F_PEDIMENTO,PREDIAL)
    SELECT v_FOLIO_VENTA,ID_PRODUCTO,CANTIDAD,P_VENTA,ADUANA,PEDIMENTO,F_PEDIMENTO,PREDIAL 
    FROM venta_detalle_tmp WHERE user_login=p_USER_LOGIN; 
    --  SQLINES DEMO *** XISTENCIAS GENERALES
    UPDATE venta_detalle_tmp 
    SET productos.EXISTENCIA = 
     productos.EXISTENCIA-venta_detalle_tmp.`CANTIDAD`
     WHERE productos.ID_PRODUCTO = 
     venta_detalle_tmp.ID_PRODUCTO 
     AND venta_detalle_tmp.user_login= p_USER_LOGIN;
    --  SQLINES DEMO *** TEMPORAL
    DELETE FROM venta_detalle_tmp  WHERE user_login = p_USER_LOGIN;
   
    SELECT v_FOLIO_VENTA
    
COMMIT; 
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

-- Dump completed on 2025-10-21 22:40:59
