CREATE DATABASE  IF NOT EXISTS `bd-les` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `bd-les`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: bd-les
-- ------------------------------------------------------
-- Server version 5.7.21-log

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `agente_trat`
--

DROP TABLE IF EXISTS `agente_trat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agente_trat` (
  `idAgenTra` int(11) NOT NULL AUTO_INCREMENT,
  `nomeAgenTra` varchar(45) NOT NULL,
  PRIMARY KEY (`idAgenTra`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
  `AccessFailedCount` int(11) NOT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(45) NOT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `Discriminator` longtext NOT NULL,
  `IdFuncionario` int(11) DEFAULT NULL,
  `IdPerfil` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `IX_AspNetUsers_IdFuncionario` (`IdFuncionario`),
  KEY `EmailIndex` (`NormalizedEmail`),
  KEY `IX_AspNetUsers_IdPerfil` (`IdPerfil`),
  CONSTRAINT `fk_FuncionarioIdFuncionario` FOREIGN KEY (`IdFuncionario`) REFERENCES `funcionario` (`idFuncionario`) ON DELETE NO ACTION,
  CONSTRAINT `fk_PerfilId` FOREIGN KEY (`IdPerfil`) REFERENCES `perfil` (`IdPerfil`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `circuito_tanque`
--

DROP TABLE IF EXISTS `circuito_tanque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `circuito_tanque` (
  `idCircuito` int(11) NOT NULL AUTO_INCREMENT,
  `Projeto_idProjeto` int(11) NOT NULL,
  `codigoCircuito` varchar(15) NOT NULL,
  `dataCriacao` datetime NOT NULL,
  `dataFinal` datetime NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idCircuito`),
  KEY `fk_Circuito_Tanque_Projeto1_idx` (`Projeto_idProjeto`),
  CONSTRAINT `fk_Circuito_Tanque_Projeto1` FOREIGN KEY (`Projeto_idProjeto`) REFERENCES `projeto` (`idProjeto`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `concelho`
--

DROP TABLE IF EXISTS `concelho`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `concelho` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeConcelho` varchar(45) NOT NULL,
  `Distrito_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Concelho_Distrito1_idx` (`Distrito_id`),
  CONSTRAINT `fk_Concelho_Distrito1` FOREIGN KEY (`Distrito_id`) REFERENCES `distrito` (`id`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `distrito`
--

DROP TABLE IF EXISTS `distrito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `distrito` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeDistrito` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `elementoequipa`
--

DROP TABLE IF EXISTS `elementoequipa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `elementoequipa` (
  `idElementoEquipa` int(11) NOT NULL AUTO_INCREMENT,
  `funcao` varchar(40) NOT NULL,
  `Projeto_idProjeto` int(11) NOT NULL,
  `Funcionario_idFuncionario` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL DEFAULT '',
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idElementoEquipa`),
  KEY `fk_equipaProjeto_Funcionario1` (`Funcionario_idFuncionario`),
  KEY `fk_equipaProjeto_Projeto1` (`Projeto_idProjeto`),
  CONSTRAINT `fk_equipaProjeto_Funcionario1` FOREIGN KEY (`Funcionario_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`) ON DELETE NO ACTION,
  CONSTRAINT `fk_equipaProjeto_Projeto1` FOREIGN KEY (`Projeto_idProjeto`) REFERENCES `projeto` (`idProjeto`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ensaio`
--

DROP TABLE IF EXISTS `ensaio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ensaio` (
  `idEnsaio` int(11) NOT NULL AUTO_INCREMENT,
  `dataInicio` datetime NOT NULL,
  `dataFim` datetime NOT NULL,
  `descTratamento` varchar(45) NOT NULL,
  `grauSeveridade` int(11) NOT NULL,
  `Projeto_idProjeto` int(11) NOT NULL,
  `Lote_idLote` int(11) NOT NULL,
  `nroAnimaisAutoriz` int(11) NOT NULL DEFAULT '0',
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idEnsaio`),
  KEY `fk_Ensaio_Lote1` (`Lote_idLote`),
  KEY `fk_Ensaio_Projeto1` (`Projeto_idProjeto`),
  CONSTRAINT `fk_Ensaio_Lote1` FOREIGN KEY (`Lote_idLote`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Ensaio_Projeto1` FOREIGN KEY (`Projeto_idProjeto`) REFERENCES `projeto` (`idProjeto`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `especie`
--

DROP TABLE IF EXISTS `especie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `especie` (
  `idEspecie` int(11) NOT NULL AUTO_INCREMENT,
  `NomeCient` varchar(45) NOT NULL,
  `NomeVulgar` varchar(45) NOT NULL,
  `Familia_idFamilia` int(11) NOT NULL,
  `Grupo_idGrupo` int(11) NOT NULL,
  PRIMARY KEY (`idEspecie`),
  KEY `fk_Especie_Familia1_idx` (`Familia_idFamilia`),
  KEY `fk_Especie_Grupo1_idx` (`Grupo_idGrupo`),
  CONSTRAINT `fk_Especie_Familia1` FOREIGN KEY (`Familia_idFamilia`) REFERENCES `familia` (`idFamilia`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Especie_Grupo1` FOREIGN KEY (`Grupo_idGrupo`) REFERENCES `grupo` (`idGrupo`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `familia`
--

DROP TABLE IF EXISTS `familia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `familia` (
  `idFamilia` int(11) NOT NULL AUTO_INCREMENT,
  `NomeFamilia` varchar(45) NOT NULL,
  `Grupo_idGrupo` int(11) NOT NULL,
  PRIMARY KEY (`idFamilia`),
  KEY `fk_Familia_Grupo1_idx` (`Grupo_idGrupo`),
  CONSTRAINT `fk_Familia_Grupo1` FOREIGN KEY (`Grupo_idGrupo`) REFERENCES `grupo` (`idGrupo`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `finalidade`
--

DROP TABLE IF EXISTS `finalidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `finalidade` (
  `idFinalidade` int(11) NOT NULL AUTO_INCREMENT,
  `T_Finalidade` varchar(45) NOT NULL,
  PRIMARY KEY (`idFinalidade`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fornecedorcolector`
--

DROP TABLE IF EXISTS `fornecedorcolector`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fornecedorcolector` (
  `idFornColect` int(11) NOT NULL AUTO_INCREMENT,
  `Tipo` char(1) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `NIF` int(10) NOT NULL,
  `nroLicenca` int(11) NOT NULL,
  `Morada` varchar(45) NOT NULL,
  `telefone` varchar(10) NOT NULL,
  PRIMARY KEY (`idFornColect`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `funcionario` (
  `idFuncionario` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCompleto` varchar(45) NOT NULL,
  PRIMARY KEY (`idFuncionario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `grupo`
--

DROP TABLE IF EXISTS `grupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grupo` (
  `idGrupo` int(11) NOT NULL AUTO_INCREMENT,
  `NomeGrupo` varchar(45) NOT NULL,
  PRIMARY KEY (`idGrupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `localcaptura`
--

DROP TABLE IF EXISTS `localcaptura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `localcaptura` (
  `idLocalCaptura` int(11) NOT NULL AUTO_INCREMENT,
  `Localidade` varchar(45) NOT NULL,
  `Latitude` float(10,6) DEFAULT NULL,
  `Longitude` float(10,6) DEFAULT NULL,
  `Concelho_id` int(11) NOT NULL,
  `Distrito_id` int(11) NOT NULL,
  PRIMARY KEY (`idLocalCaptura`),
  KEY `fk_LocalCaptura_Concelho1_idx` (`Concelho_id`),
  KEY `fk_LocalCaptura_Distrito1` (`Distrito_id`),
  CONSTRAINT `fk_LocalCaptura_Concelho1` FOREIGN KEY (`Concelho_id`) REFERENCES `concelho` (`id`) ON DELETE NO ACTION,
  CONSTRAINT `fk_LocalCaptura_Distrito1` FOREIGN KEY (`Distrito_id`) REFERENCES `distrito` (`id`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `lote`
--

DROP TABLE IF EXISTS `lote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lote` (
  `idLote` int(11) NOT NULL AUTO_INCREMENT,
  `codigoLote` varchar(10) NOT NULL,
  `dataInicio` datetime NOT NULL,
  `dataFim` datetime DEFAULT NULL,
  `Observacoes` varchar(45) NOT NULL,
  `Reg_Novos_Animais_idRegAnimal` int(11) NOT NULL,
  `Funcionario_idFuncionario` int(11) NOT NULL,
  PRIMARY KEY (`idLote`),
  KEY `fk_Lote_Funcionario1_idx` (`Funcionario_idFuncionario`),
  KEY `fk_Lote_Reg_Novos_Animais1_idx` (`Reg_Novos_Animais_idRegAnimal`),
  CONSTRAINT `fk_Lote_Funcionario1` FOREIGN KEY (`Funcionario_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Lote_Reg_Novos_Animais1` FOREIGN KEY (`Reg_Novos_Animais_idRegAnimal`) REFERENCES `reg_novos_animais` (`idRegAnimal`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `lote_sub_lote`
--

DROP TABLE IF EXISTS `lote_sub_lote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lote_sub_lote` (
  `Lote_idLote_prev` int(11) NOT NULL,
  `Lote_idLote_atual` int(11) NOT NULL,
  `codigoSubLote` varchar(15) NOT NULL,
  PRIMARY KEY (`Lote_idLote_prev`,`Lote_idLote_atual`),
  KEY `fk_Sub_Lote_Lote2_idx` (`Lote_idLote_atual`),
  KEY `fk_Sub_Lote_Lote1_idx` (`Lote_idLote_prev`),
  CONSTRAINT `fk_Sub_Lote_Lote1` FOREIGN KEY (`Lote_idLote_prev`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Sub_Lote_Lote2` FOREIGN KEY (`Lote_idLote_atual`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `motivo`
--

DROP TABLE IF EXISTS `motivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `motivo` (
  `idMotivo` int(11) NOT NULL AUTO_INCREMENT,
  `tipoMotivo` varchar(45) NOT NULL,
  `nomeMotivo` varchar(45) NOT NULL,
  PRIMARY KEY (`idMotivo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `perfil`
--

DROP TABLE IF EXISTS `perfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `perfil` (
  `IdPerfil` int(11) NOT NULL AUTO_INCREMENT,
  `nomePerfil` varchar(45) NOT NULL,
  `IsDefault` int(1) DEFAULT NULL,
  PRIMARY KEY (`IdPerfil`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `plano_alimentar`
--

DROP TABLE IF EXISTS `plano_alimentar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plano_alimentar` (
  `idPlanAlim` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `MarcaAlim` varchar(45) NOT NULL,
  `Tipo` int(11) NOT NULL,
  `Temperatura` float NOT NULL,
  `Racao` float NOT NULL,
  `RacaoDia` float NOT NULL,
  PRIMARY KEY (`idPlanAlim`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `profilerole`
--

DROP TABLE IF EXISTS `profilerole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `profilerole` (
  `IdPerfil` int(11) NOT NULL,
  `RoleId` varchar(256) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`IdPerfil`,`RoleId`),
  KEY `fk_ProfileRole_Profile_idx` (`IdPerfil`),
  KEY `fk_ProfileRole_Role_idx` (`RoleId`),
  CONSTRAINT `fk_IdPerfil` FOREIGN KEY (`IdPerfil`) REFERENCES `perfil` (`IdPerfil`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `projeto`
--

DROP TABLE IF EXISTS `projeto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `projeto` (
  `idProjeto` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  `dataInicio` datetime NOT NULL,
  `dataFim` datetime NOT NULL,
  `AutorizacaoDGVA` varchar(45) NOT NULL,
  `RefORBEA` int(11) NOT NULL,
  `SubmisInsEurop` tinyint(1) NOT NULL,
  `nroAnimaisAutoriz` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idProjeto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reg_alimentar`
--

DROP TABLE IF EXISTS `reg_alimentar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_alimentar` (
  `idRegAlim` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `Peso` float NOT NULL,
  `Sobras` float NOT NULL,
  `Plano_Alimentar_idPlanAlim` int(11) NOT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idRegAlim`),
  KEY `fk_Reg_Alimentar_Plano_Alimentar1` (`Plano_Alimentar_idPlanAlim`),
  KEY `fk_Reg_Alimentar_Tanque1` (`Tanque_idTanque`),
  CONSTRAINT `fk_Reg_Alimentar_Plano_Alimentar1` FOREIGN KEY (`Plano_Alimentar_idPlanAlim`) REFERENCES `plano_alimentar` (`idPlanAlim`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Alimentar_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reg_amostragens`
--

DROP TABLE IF EXISTS `reg_amostragens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_amostragens` (
  `idRegAmo` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `pesoMedio` float NOT NULL,
  `nroIndividuos` int(11) NOT NULL,
  `pesoTotal` float NOT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idRegAmo`),
  KEY `fk_Reg_Amostragens_Tanque1` (`Tanque_idTanque`),
  CONSTRAINT `fk_Reg_Amostragens_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reg_cond_amb`
--

DROP TABLE IF EXISTS `reg_cond_amb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_cond_amb` (
  `idRegCondAmb` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `temperatura` float NOT NULL,
  `volAgua` float NOT NULL,
  `salinidadeAgua` float NOT NULL,
  `nivelO2` float NOT NULL,
  `Circuito_Tanque_idCircuito` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idRegCondAmb`),
  KEY `fk_Reg_Cond_Amb_Circuito_Tanque1` (`Circuito_Tanque_idCircuito`),
  CONSTRAINT `fk_Reg_Cond_Amb_Circuito_Tanque1` FOREIGN KEY (`Circuito_Tanque_idCircuito`) REFERENCES `circuito_tanque` (`idCircuito`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reg_manutencao`
--

DROP TABLE IF EXISTS `reg_manutencao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_manutencao` (
  `idRegMan` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `Tipo_Manuntecao_idT_Manutencao` int(11) NOT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idRegMan`),
  KEY `fk_Reg_Manutencao_Tanque1` (`Tanque_idTanque`),
  KEY `fk_Reg_Manutencao_Tipo_Manuntecao1` (`Tipo_Manuntecao_idT_Manutencao`),
  CONSTRAINT `fk_Reg_Manutencao_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Manutencao_Tipo_Manuntecao1` FOREIGN KEY (`Tipo_Manuntecao_idT_Manutencao`) REFERENCES `tipo_manuntecao` (`idT_Manutencao`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reg_novos_animais`
--

DROP TABLE IF EXISTS `reg_novos_animais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_novos_animais` (
  `idRegAnimal` int(11) NOT NULL AUTO_INCREMENT,
  `nroExemplares` int(11) NOT NULL,
  `nroMachos` int(11) DEFAULT NULL,
  `nroFemeas` int(11) DEFAULT NULL,
  `Imaturos` int(11) DEFAULT NULL,
  `Juvenis` int(11) DEFAULT NULL,
  `Larvas` int(11) DEFAULT NULL,
  `Ovos` int(11) DEFAULT NULL,
  `dataNasc` datetime DEFAULT NULL,
  `idade` int(11) DEFAULT NULL,
  `pesoMedio` float DEFAULT NULL,
  `compMedio` float DEFAULT NULL,
  `DuracaoViagem` time DEFAULT NULL,
  `tempPartida` int(11) DEFAULT NULL,
  `tempChegada` int(11) DEFAULT NULL,
  `nroContentores` int(11) DEFAULT NULL,
  `tipoContentor` varchar(45) NOT NULL,
  `volContentor` float DEFAULT NULL,
  `volAgua` float DEFAULT NULL,
  `nroCaixasIsoter` int(11) DEFAULT NULL,
  `nroMortosCheg` int(11) DEFAULT NULL,
  `satO2Transp` float DEFAULT NULL,
  `anestesico` float DEFAULT NULL,
  `Gelo` tinyint(1) NOT NULL,
  `Adicao_O2` tinyint(1) NOT NULL,
  `Arejamento` tinyint(1) NOT NULL,
  `refrigeracao` tinyint(1) NOT NULL,
  `sedacao` tinyint(1) NOT NULL,
  `respTransporte` varchar(45) NOT NULL,
  `Especie_idEspecie` int(11) NOT NULL,
  `Fornecedor_idFornColect` int(11) NOT NULL,
  `T_Origem_idT_Origem` int(11) NOT NULL,
  `LocalCaptura_idLocalCaptura` int(11) DEFAULT NULL,
  `TipoEstatutoGenetico_idTipoEstatutoGenetico` int(11) NOT NULL,
  `Funcionario_idFuncionario` int(11) NOT NULL,
  `Funcionario_idFuncionario1` int(11) NOT NULL,
  PRIMARY KEY (`idRegAnimal`),
  KEY `fk_Reg_Novos_Animais_Especie1` (`Especie_idEspecie`),
  KEY `fk_Reg_Novos_Animais_Fornecedor1` (`Fornecedor_idFornColect`),
  KEY `fk_Reg_Novos_Animais_Funcionario1` (`Funcionario_idFuncionario`),
  KEY `fk_Reg_Novos_Animais_Funcionario2` (`Funcionario_idFuncionario1`),
  KEY `fk_Reg_Novos_Animais_LocalCaptura1` (`LocalCaptura_idLocalCaptura`),
  KEY `fk_Reg_Novos_Animais_T_Origem1` (`T_Origem_idT_Origem`),
  KEY `fk_Reg_Novos_Animais_TipoEstatutoGenetico1` (`TipoEstatutoGenetico_idTipoEstatutoGenetico`),
  CONSTRAINT `fk_Reg_Novos_Animais_Especie1` FOREIGN KEY (`Especie_idEspecie`) REFERENCES `especie` (`idEspecie`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Novos_Animais_Fornecedor1` FOREIGN KEY (`Fornecedor_idFornColect`) REFERENCES `fornecedorcolector` (`idFornColect`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Novos_Animais_Funcionario1` FOREIGN KEY (`Funcionario_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Novos_Animais_Funcionario2` FOREIGN KEY (`Funcionario_idFuncionario1`) REFERENCES `funcionario` (`idFuncionario`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Novos_Animais_LocalCaptura1` FOREIGN KEY (`LocalCaptura_idLocalCaptura`) REFERENCES `localcaptura` (`idLocalCaptura`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Novos_Animais_T_Origem1` FOREIGN KEY (`T_Origem_idT_Origem`) REFERENCES `t_origem` (`idT_Origem`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Novos_Animais_TipoEstatutoGenetico1` FOREIGN KEY (`TipoEstatutoGenetico_idTipoEstatutoGenetico`) REFERENCES `tipoestatutogenetico` (`idTipoEstatutoGenetico`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reg_remocoes`
--

DROP TABLE IF EXISTS `reg_remocoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_remocoes` (
  `idRegRemo` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `nroremocoes` int(11) NOT NULL,
  `Motivo_idMotivo` int(11) NOT NULL,
  `causaMorte` char(1) NOT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idRegRemo`),
  KEY `fk_Reg_Remocoes_Motivo1` (`Motivo_idMotivo`),
  KEY `fk_Reg_Remocoes_Tanque1` (`Tanque_idTanque`),
  CONSTRAINT `fk_Reg_Remocoes_Motivo1` FOREIGN KEY (`Motivo_idMotivo`) REFERENCES `motivo` (`idMotivo`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Remocoes_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reg_tratamento`
--

DROP TABLE IF EXISTS `reg_tratamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reg_tratamento` (
  `idRegTra` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `Tempo` int(11) NOT NULL,
  `Concentracao` float NOT NULL,
  `Finalidade_idFinalidade` int(11) NOT NULL,
  `agente_Trat_idAgenTra` int(11) NOT NULL,
  `concAgenTra` int(11) DEFAULT NULL,
  `Tanque_idTanque` int(11) NOT NULL,
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idRegTra`),
  KEY `fk_Reg_Tratamento_agente_Trat1` (`agente_Trat_idAgenTra`),
  KEY `fk_Reg_Tratamento_Finalidade1` (`Finalidade_idFinalidade`),
  KEY `fk_Reg_Tratamento_Tanque1` (`Tanque_idTanque`),
  CONSTRAINT `fk_Reg_Tratamento_Finalidade1` FOREIGN KEY (`Finalidade_idFinalidade`) REFERENCES `finalidade` (`idFinalidade`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Tratamento_Tanque1` FOREIGN KEY (`Tanque_idTanque`) REFERENCES `tanque` (`idTanque`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Reg_Tratamento_agente_Trat1` FOREIGN KEY (`agente_Trat_idAgenTra`) REFERENCES `agente_trat` (`idAgenTra`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `t_origem`
--

DROP TABLE IF EXISTS `t_origem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `t_origem` (
  `idT_Origem` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(45) NOT NULL,
  PRIMARY KEY (`idT_Origem`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tanque`
--

DROP TABLE IF EXISTS `tanque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tanque` (
  `idTanque` int(11) NOT NULL AUTO_INCREMENT,
  `nroAnimais` int(11) NOT NULL,
  `sala` varchar(15) NOT NULL,
  `observacoes` varchar(45) DEFAULT NULL,
  `Lote_idLote` int(11) NOT NULL,
  `Circuito_Tanque_idCircuito` int(11) NOT NULL,
  `codidenttanque` varchar(255) NOT NULL DEFAULT '',
  `isarchived` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idTanque`),
  KEY `fk_Tanque_Circuito_Tanque1_idx` (`Circuito_Tanque_idCircuito`),
  KEY `fk_Tanque_Lote1_idx` (`Lote_idLote`),
  CONSTRAINT `fk_Tanque_Circuito_Tanque1` FOREIGN KEY (`Circuito_Tanque_idCircuito`) REFERENCES `circuito_tanque` (`idCircuito`) ON DELETE NO ACTION,
  CONSTRAINT `fk_Tanque_Lote1` FOREIGN KEY (`Lote_idLote`) REFERENCES `lote` (`idLote`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tipo_manuntecao`
--

DROP TABLE IF EXISTS `tipo_manuntecao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipo_manuntecao` (
  `idT_Manutencao` int(11) NOT NULL AUTO_INCREMENT,
  `T_Manutencao` varchar(45) NOT NULL,
  PRIMARY KEY (`idT_Manutencao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tipoestatutogenetico`
--

DROP TABLE IF EXISTS `tipoestatutogenetico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipoestatutogenetico` (
  `idTipoEstatutoGenetico` int(11) NOT NULL AUTO_INCREMENT,
  `TipoEstatutoGeneticocol` varchar(45) NOT NULL,
  PRIMARY KEY (`idTipoEstatutoGenetico`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-20 11:55:22
