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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-21  6:43:40
