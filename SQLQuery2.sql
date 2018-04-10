


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: "BD-LES"
--

-- --------------------------------------------------------

--
-- Table structure for table "agente_trat"
--

CREATE TABLE "agente_trat" (
  "idAgenTra" int NOT NULL,
  "nomeAgenTra" varchar(45) NOT NULL,
  PRIMARY KEY ("idAgenTra")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "circuito_tanque"
--

CREATE TABLE "circuito_tanque" (
  "idCircuito" int NOT NULL,
  "Projeto_idProjeto" int NOT NULL,
  "codigoCircuito" varchar(15) DEFAULT NULL,
  "dataCriacao" date NOT NULL,
  "dataFinal" date NOT NULL,
  "varControlo" tinyint DEFAULT '0',
  PRIMARY KEY ("idCircuito"),
) ;

CREATE INDEX "fk_Circuito_Tanque_Projeto1_idx" ON "circuito_tanque" ("Projeto_idProjeto");

-- --------------------------------------------------------

--
-- Table structure for table "conselho"
--

CREATE TABLE "conselho" (
  "id" int NOT NULL,
  "nomeConselho" varchar(45) NOT NULL,
  "Distrito_id" int NOT NULL,
  PRIMARY KEY ("id","Distrito_id"),
) ;

  CREATE INDEX "fk_Conselho_Distrito1_idx" ON "conselho" ("Distrito_id");

-- --------------------------------------------------------

--
-- Table structure for table "controlo"
--

CREATE TABLE "controlo" (
  "entry_id" int NOT NULL,
  "table_name" varchar(45) NOT NULL,
  "attribute_name" varchar(45) NOT NULL,
  "lower_bound" float DEFAULT NULL,
  "upper_bound" float DEFAULT NULL,
  PRIMARY KEY ("entry_id","table_name","attribute_name")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "distrito"
--

CREATE TABLE "distrito" (
  "id" int NOT NULL,
  "nomeDistrito" varchar(45) DEFAULT NULL,
  PRIMARY KEY ("id")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "elementoequipa"
--

CREATE TABLE "elementoequipa" (
  "função" char(1) NOT NULL,
  "Projeto_idProjeto" int NOT NULL,
  "Funcionario_idFuncionario" int NOT NULL,
  PRIMARY KEY ("Projeto_idProjeto")
) ;

  CREATE INDEX "fk_equipaProjeto_Funcionario1_idx" on "elementoequipa" ("Funcionario_idFuncionario")

-- --------------------------------------------------------

--
-- Table structure for table "ensaio"
--

CREATE TABLE "ensaio" (
  "idEnsaio" int NOT NULL,
  "dataInicio" date NOT NULL,
  "dataFim" date NOT NULL,
  "descTratamento" varchar(45) NOT NULL,
  "grauSeveridade" int NOT NULL,
  "Projeto_idProjeto" int NOT NULL,
  "Lote_idLote" int NOT NULL,
  "membroEquipa_idEquipa" int NOT NULL,
  PRIMARY KEY ("idEnsaio","Projeto_idProjeto")
) ;

  CREATE INDEX "fk_Ensaio_Projeto1_idx" on "ensaio" ("Projeto_idProjeto");
  CREATE INDEX "fk_Ensaio_Lote1_idx" on "ensaio" ("Lote_idLote");

-- --------------------------------------------------------

--
-- Table structure for table "especie"
--

CREATE TABLE "especie" (
  "idEspecie" int UNIQUE NOT NULL,
  "NomeCient" varchar(45) DEFAULT NULL,
  "NomeVulgar" varchar(45) DEFAULT NULL,
  "Familia_idFamilia" int NOT NULL,
  "Familia_Grupo_idGrupo" int NOT NULL,
  PRIMARY KEY ("idEspecie","Familia_idFamilia","Familia_Grupo_idGrupo")
) ;

  CREATE INDEX "fk_Especie_Familia1_idx" on "especie" ("Familia_idFamilia","Familia_Grupo_idGrupo");

-- --------------------------------------------------------

--
-- Table structure for table "familia"
--

CREATE TABLE "familia" (
  "idFamilia" int NOT NULL,
  "Grupo_idGrupo" int NOT NULL,
  PRIMARY KEY ("idFamilia","Grupo_idGrupo")
) ;

  CREATE INDEX "fk_Familia_Grupo1_idx" on "familia" ("Grupo_idGrupo");

-- --------------------------------------------------------

--
-- Table structure for table "finalidade"
--

CREATE TABLE "finalidade" (
  "idFinalidade" int NOT NULL,
  "T_Finalidade" varchar(45) DEFAULT NULL,
  PRIMARY KEY ("idFinalidade")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "fornecedorcolector"
--

CREATE TABLE "fornecedorcolector" (
  "idFornColect" int NOT NULL,
  "Tipo" char(1) NOT NULL,
  "Nome" varchar(45) DEFAULT NULL,
  "NIF" int DEFAULT NULL,
  "nroLicenca" int DEFAULT NULL,
  "Morada" varchar(45) DEFAULT NULL,
  "telefone" varchar(10) DEFAULT NULL,
  PRIMARY KEY ("idFornColect")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "funcionario"
--

CREATE TABLE "funcionario" (
  "idFuncionario" int NOT NULL,
  "nomeCompleto" varchar(45) NOT NULL,
  "nomeUtilizador" varchar(45) NOT NULL,
  "password" varchar(45) NOT NULL,
  "telefone" varchar(45) DEFAULT NULL,
  PRIMARY KEY ("idFuncionario")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "grupo"
--

CREATE TABLE "grupo" (
  "idGrupo" int NOT NULL,
  "NomeGrupo" varchar(45) DEFAULT NULL,
  PRIMARY KEY ("idGrupo")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "localcaptura"
--

CREATE TABLE "localcaptura" (
  "idLocalCaptura" int NOT NULL,
  "Localidade" varchar(45) DEFAULT NULL,
  "Latitude" float(53) DEFAULT NULL,
  "Longitude" float(53) DEFAULT NULL,
  "Conselho_id" int NOT NULL,
  "Conselho_Distrito_id" int NOT NULL,
  PRIMARY KEY ("idLocalCaptura","Conselho_id","Conselho_Distrito_id")
) ;

  CREATE INDEX "fk_LocalCaptura_Conselho1_idx" on "localcaptura" ("Conselho_id","Conselho_Distrito_id");

-- --------------------------------------------------------

--
-- Table structure for table "lote"
--

CREATE TABLE "lote" (
  "idLote" int NOT NULL,
  "codigoLote" varchar(10) NOT NULL,
  "dataInicio" date NOT NULL,
  "dataFim" date DEFAULT NULL,
  "Observacoes" varchar(45) DEFAULT NULL,
  "Reg_Novos_Animais_idRegAnimal" int NOT NULL,
  "Funcionario_idFuncionario" int NOT NULL,
  "varControlo" tinyint DEFAULT '0',
  PRIMARY KEY ("idLote")
) ;

  CREATE INDEX "fk_Lote_Reg_Novos_Animais1_idx" on "lote" ("Reg_Novos_Animais_idRegAnimal");
  CREATE INDEX "fk_Lote_Funcionario1_idx" on "lote" ("Funcionario_idFuncionario");

-- --------------------------------------------------------

--
-- Table structure for table "lote_sub_lote"
--

CREATE TABLE "lote_sub_lote" (
  "Lote_idLote_prev" int NOT NULL,
  "Lote_idLote_atual" int NOT NULL,
  "codigoSubLote" varchar(15) NOT NULL,
  PRIMARY KEY ("Lote_idLote_prev","Lote_idLote_atual")
) ;

  CREATE INDEX "fk_Sub_Lote_Lote1_idx" on "lote_sub_lote" ("Lote_idLote_prev");
  CREATE INDEX "fk_Sub_Lote_Lote2_idx" on "lote_sub_lote" ("Lote_idLote_atual");

-- --------------------------------------------------------

--
-- Table structure for table "motivo"
--

CREATE TABLE "motivo" (
  "idMotivo" int NOT NULL,
  "tipoMotivo" nchar(1) NOT NULL,
  "nomeMotivo" varchar(45) NOT NULL,
  PRIMARY KEY ("idMotivo")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "origem"
--

CREATE TABLE "origem" (
  "idOrigem" int NOT NULL,
  "TipoOrigem" int DEFAULT NULL,
  PRIMARY KEY ("idOrigem")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "plano_alimentar"
--

CREATE TABLE "plano_alimentar" (
  "idPlanAlim" int NOT NULL,
  "Nome" varchar(45) NOT NULL,
  "MarcaAlim" varchar(45) DEFAULT NULL,
  "Tipo" int NOT NULL,
  "Temperatura" float NOT NULL,
  "Racao" float DEFAULT NULL,
  "RacaoDia" float NOT NULL,
  PRIMARY KEY ("idPlanAlim")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "projeto"
--

CREATE TABLE "projeto" (
  "idProjeto" int NOT NULL,
  "Nome" varchar(45) NOT NULL,
  "dataInicio" date NOT NULL,
  "dataFim" date NOT NULL,
  "AutorizacaoDGVA" varchar(45) DEFAULT NULL,
  "RefORBEA" int DEFAULT NULL,
  "SubmisInsEurop" tinyint DEFAULT NULL,
  "nroAnimaisAutoriz" int DEFAULT NULL,
  "varControlo" tinyint DEFAULT '0',
  PRIMARY KEY ("idProjeto")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "reg_alimentar"
--

CREATE TABLE "reg_alimentar" (
  "idRegAlim" int NOT NULL,
  "data" date NOT NULL,
  "Peso" float NOT NULL,
  "Sobras" float DEFAULT NULL,
  "Plano_Alimentar_idPlanAlim" int NOT NULL,
  "Tanque_idTanque" int NOT NULL,
  PRIMARY KEY ("idRegAlim","Tanque_idTanque")
) ;

  CREATE INDEX "fk_Reg_Alimentar_Plano_Alimentar1_idx" on "reg_alimentar" ("Plano_Alimentar_idPlanAlim");
  CREATE INDEX "fk_Reg_Alimentar_Tanque1_idx" on "reg_alimentar" ("Tanque_idTanque");

-- --------------------------------------------------------

--
-- Table structure for table "reg_amostragens"
--

CREATE TABLE "reg_amostragens" (
  "idRegAmo" int NOT NULL,
  "data" date NOT NULL,
  "pesoMedio" float NOT NULL,
  "nroIndividuos" int NOT NULL,
  "pesoTotal" float NOT NULL,
  "Tanque_idTanque" int NOT NULL,
  PRIMARY KEY ("idRegAmo","Tanque_idTanque")
) ;

  CREATE INDEX "fk_Reg_Amostragens_Tanque1_idx" on "reg_amostragens" ("Tanque_idTanque")

-- --------------------------------------------------------

--
-- Table structure for table "reg_cond_amb"
--

CREATE TABLE "reg_cond_amb" (
  "idRegCondAmb" int NOT NULL,
  "data" date NOT NULL,
  "temperatura" float DEFAULT NULL,
  "volAgua" float DEFAULT NULL,
  "salinidadeAgua" float DEFAULT NULL,
  "nivelO2" float DEFAULT NULL,
  "Circuito_Tanque_idCircuito" int NOT NULL,
  PRIMARY KEY ("idRegCondAmb","Circuito_Tanque_idCircuito")
) ;

  CREATE INDEX "fk_Reg_Cond_Amb_Circuito_Tanque1_idx" on "reg_cond_amb" ("Circuito_Tanque_idCircuito")

-- --------------------------------------------------------

--
-- Table structure for table "reg_manutencao"
--

CREATE TABLE "reg_manutencao" (
  "idRegMan" int NOT NULL,
  "data" date NOT NULL,
  "Tipo_Manuntecao_idT_Manutencao" int NOT NULL,
  "Tanque_idTanque" int NOT NULL,
  PRIMARY KEY ("idRegMan","Tanque_idTanque")
) ;

  CREATE INDEX "fk_Reg_Manutencao_Tipo_Manuntecao1_idx" on "reg_manutencao" ("Tipo_Manuntecao_idT_Manutencao");
  CREATE INDEX "fk_Reg_Manutencao_Tanque1_idx" on "reg_manutencao" ("Tanque_idTanque");

-- --------------------------------------------------------

--
-- Table structure for table "reg_novos_animais"
--

CREATE TABLE "reg_novos_animais" (
  "idRegAnimal" int NOT NULL,
  "nroExemplares" int NOT NULL,
  "nroMachos" int DEFAULT NULL,
  "nroFemeas" int DEFAULT NULL,
  "Imaturos" int DEFAULT NULL,
  "Juvenis" int DEFAULT NULL,
  "Larvas" int DEFAULT NULL,
  "Ovos" int DEFAULT NULL,
  "dataNasc" date DEFAULT NULL,
  "idade" int DEFAULT NULL,
  "pesoMedio" float DEFAULT NULL,
  "compMedio" float DEFAULT NULL,
  "DuracaoViagem" time DEFAULT NULL,
  "tempPartida" int DEFAULT NULL,
  "tempChegada" int DEFAULT NULL,
  "nroContentores" int DEFAULT NULL,
  "tipoContentor" varchar(45) DEFAULT NULL,
  "volContentor" float DEFAULT NULL,
  "volAgua" float DEFAULT NULL,
  "nroCaixasIsoter" int DEFAULT NULL,
  "nroMortosCheg" int DEFAULT NULL,
  "satO2Transp" float DEFAULT NULL,
  "anestesico" float DEFAULT NULL,
  "Gelo" tinyint DEFAULT NULL,
  "Adicao_O2" tinyint DEFAULT NULL,
  "Arejamento" tinyint DEFAULT NULL,
  "refrigeracao" tinyint DEFAULT NULL,
  "sedação" tinyint DEFAULT NULL,
  "respTransporte" varchar(45) DEFAULT NULL,
  "Especie_idEspecie" int NOT NULL,
  "Fornecedor_idFornColect" int NOT NULL,
  "T_Origem_idT_Origem" int NOT NULL,
  "LocalCaptura_idLocalCaptura" int DEFAULT NULL,
  "TipoEstatutoGenetico_idTipoEstatutoGenetico" int NOT NULL,
  "Funcionario_idFuncionario" int NOT NULL,
  "Funcionario_idFuncionario1" int NOT NULL,
  PRIMARY KEY ("idRegAnimal")
) ;

  CREATE INDEX "fk_Reg_Novos_Animais_Especie1_idx" on "reg_novos_animais" ("Especie_idEspecie");
  CREATE INDEX "fk_Reg_Novos_Animais_Fornecedor1_idx" on "reg_novos_animais" ("Fornecedor_idFornColect");
  CREATE INDEX "fk_Reg_Novos_Animais_T_Origem1_idx" on "reg_novos_animais" ("T_Origem_idT_Origem");
  CREATE INDEX "fk_Reg_Novos_Animais_LocalCaptura1_idx" on "reg_novos_animais" ("LocalCaptura_idLocalCaptura");
  CREATE INDEX "fk_Reg_Novos_Animais_TipoEstatutoGenetico1_idx" on "reg_novos_animais" ("TipoEstatutoGenetico_idTipoEstatutoGenetico");
  CREATE INDEX "fk_Reg_Novos_Animais_Funcionario1_idx" on "reg_novos_animais" ("Funcionario_idFuncionario");
  CREATE INDEX "fk_Reg_Novos_Animais_Funcionario2_idx" on "reg_novos_animais" ("Funcionario_idFuncionario1");

-- --------------------------------------------------------

--
-- Table structure for table "reg_remocoes"
--

CREATE TABLE "reg_remocoes" (
  "idRegRemo" int NOT NULL,
  "date" date NOT NULL,
  "nroRemoções" int DEFAULT NULL,
  "Motivo_idMotivo" int NOT NULL,
  "causaMorte" char(1) DEFAULT NULL,
  "Tanque_idTanque" int NOT NULL,
  PRIMARY KEY ("idRegRemo","Tanque_idTanque")
) ;

  CREATE INDEX "fk_Reg_Remocoes_Motivo1_idx" on "reg_remocoes" ("Motivo_idMotivo");
  CREATE INDEX "fk_Reg_Remocoes_Tanque1_idx" on "reg_remocoes" ("Tanque_idTanque");

-- --------------------------------------------------------

--
-- Table structure for table "reg_tratamento"
--

CREATE TABLE "reg_tratamento" (
  "idRegTra" int NOT NULL,
  "date" date NOT NULL,
  "Tempo" time(6) NOT NULL,
  "Concentracao" float NOT NULL,
  "Finalidade_idFinalidade" int NOT NULL,
  "agente_Trat_idAgenTra" int NOT NULL,
  "concAgenTra" int DEFAULT NULL,
  "Tanque_idTanque" int NOT NULL,
  PRIMARY KEY ("idRegTra","Tanque_idTanque")
) ;

  CREATE INDEX "fk_Reg_Tratamento_Finalidade1_idx" on "reg_tratamento" ("Finalidade_idFinalidade");
  CREATE INDEX "fk_Reg_Tratamento_agente_Trat1_idx" on "reg_tratamento" ("agente_Trat_idAgenTra");
  CREATE INDEX "fk_Reg_Tratamento_Tanque1_idx" on "reg_tratamento" ("Tanque_idTanque");

-- --------------------------------------------------------

--
-- Table structure for table "tanque"
--

CREATE TABLE "tanque" (
  "idTanque" int NOT NULL,
  "nroAnimais" int NOT NULL,
  "sala" varchar(15) NOT NULL,
  "observacoes" varchar(45) DEFAULT NULL,
  "Lote_idLote" int NOT NULL,
  "Circuito_Tanque_idCircuito" int NOT NULL,
  "varControlo" tinyint DEFAULT '0',
  PRIMARY KEY ("idTanque")
) ;

  CREATE INDEX "fk_Tanque_Lote1_idx" on "tanque" ("Lote_idLote");
  CREATE INDEX "fk_Tanque_Circuito_Tanque1_idx" on "tanque" ("Circuito_Tanque_idCircuito");

-- --------------------------------------------------------

--
-- Table structure for table "tipoestatutogenetico"
--

CREATE TABLE "tipoestatutogenetico" (
  "idTipoEstatutoGenetico" int NOT NULL,
  "TipoEstatutoGeneticocol" varchar(45) DEFAULT NULL,
  PRIMARY KEY ("idTipoEstatutoGenetico")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "tipo_manuntecao"
--

CREATE TABLE "tipo_manuntecao" (
  "idT_Manutencao" int NOT NULL,
  "T_Manutencao" varchar(45) DEFAULT NULL,
  PRIMARY KEY ("idT_Manutencao")
) ;

-- --------------------------------------------------------

--
-- Table structure for table "t_origem"
--

CREATE TABLE "t_origem" (
  "idT_Origem" int NOT NULL,
  "Descrição" varchar(45) DEFAULT NULL,
  PRIMARY KEY ("idT_Origem")
) ;

--
-- Constraints for dumped tables
--

--
-- Constraints for table "circuito_tanque"
--
ALTER TABLE "circuito_tanque"
  ADD CONSTRAINT "fk_Circuito_Tanque_Projeto1" FOREIGN KEY ("Projeto_idProjeto") REFERENCES "projeto" ("idProjeto") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "conselho"
--
ALTER TABLE "conselho" ADD
  CONSTRAINT "fk_Conselho_Distrito1" FOREIGN KEY ("Distrito_id") REFERENCES "distrito" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "elementoequipa"
--
ALTER TABLE "elementoequipa" ADD
  CONSTRAINT "fk_equipaProjeto_Funcionario1" FOREIGN KEY ("Funcionario_idFuncionario") REFERENCES "funcionario" ("idFuncionario") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_equipaProjeto_Projeto1" FOREIGN KEY ("Projeto_idProjeto") REFERENCES "projeto" ("idProjeto") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "ensaio"
--
ALTER TABLE "ensaio" ADD
  CONSTRAINT "fk_Ensaio_Lote1" FOREIGN KEY ("Lote_idLote") REFERENCES "lote" ("idLote") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Ensaio_Projeto1" FOREIGN KEY ("Projeto_idProjeto") REFERENCES "projeto" ("idProjeto") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "especie"
--
ALTER TABLE "especie"
  ADD CONSTRAINT "fk_Especie_Familia1" FOREIGN KEY ("Familia_idFamilia","Familia_Grupo_idGrupo") REFERENCES "familia" ("idFamilia", "Grupo_idGrupo") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "familia"
--
ALTER TABLE "familia"
  ADD CONSTRAINT "fk_Familia_Grupo1" FOREIGN KEY ("Grupo_idGrupo") REFERENCES "grupo" ("idGrupo") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "localcaptura"
--
ALTER TABLE "localcaptura"
  ADD CONSTRAINT "fk_LocalCaptura_Conselho1" FOREIGN KEY ("Conselho_id","Conselho_Distrito_id") REFERENCES "conselho" ("id", "Distrito_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "lote"
--
ALTER TABLE "lote" ADD
  CONSTRAINT "fk_Lote_Funcionario1" FOREIGN KEY ("Funcionario_idFuncionario") REFERENCES "funcionario" ("idFuncionario") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Lote_Reg_Novos_Animais1" FOREIGN KEY ("Reg_Novos_Animais_idRegAnimal") REFERENCES "reg_novos_animais" ("idRegAnimal") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "lote_sub_lote"
--
ALTER TABLE "lote_sub_lote" ADD
  CONSTRAINT "fk_Sub_Lote_Lote1" FOREIGN KEY ("Lote_idLote_prev") REFERENCES "lote" ("idLote") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Sub_Lote_Lote2" FOREIGN KEY ("Lote_idLote_atual") REFERENCES "lote" ("idLote") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "reg_alimentar"
--
ALTER TABLE "reg_alimentar" ADD
  CONSTRAINT "fk_Reg_Alimentar_Plano_Alimentar1" FOREIGN KEY ("Plano_Alimentar_idPlanAlim") REFERENCES "plano_alimentar" ("idPlanAlim") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Alimentar_Tanque1" FOREIGN KEY ("Tanque_idTanque") REFERENCES "tanque" ("idTanque") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "reg_amostragens"
--
ALTER TABLE "reg_amostragens"
  ADD CONSTRAINT "fk_Reg_Amostragens_Tanque1" FOREIGN KEY ("Tanque_idTanque") REFERENCES "tanque" ("idTanque") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "reg_cond_amb"
--
ALTER TABLE "reg_cond_amb"
  ADD CONSTRAINT "fk_Reg_Cond_Amb_Circuito_Tanque1" FOREIGN KEY ("Circuito_Tanque_idCircuito") REFERENCES "circuito_tanque" ("idCircuito") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "reg_manutencao"
--
ALTER TABLE "reg_manutencao" ADD
  CONSTRAINT "fk_Reg_Manutencao_Tanque1" FOREIGN KEY ("Tanque_idTanque") REFERENCES "tanque" ("idTanque") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Manutencao_Tipo_Manuntecao1" FOREIGN KEY ("Tipo_Manuntecao_idT_Manutencao") REFERENCES "tipo_manuntecao" ("idT_Manutencao") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "reg_novos_animais"
--
ALTER TABLE "reg_novos_animais" ADD
  CONSTRAINT "fk_Reg_Novos_Animais_Especie1" FOREIGN KEY ("Especie_idEspecie") REFERENCES "especie" ("idEspecie") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Novos_Animais_Fornecedor1" FOREIGN KEY ("Fornecedor_idFornColect") REFERENCES "fornecedorcolector" ("idFornColect") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Novos_Animais_Funcionario1" FOREIGN KEY ("Funcionario_idFuncionario") REFERENCES "funcionario" ("idFuncionario") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Novos_Animais_Funcionario2" FOREIGN KEY ("Funcionario_idFuncionario1") REFERENCES "funcionario" ("idFuncionario") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Novos_Animais_T_Origem1" FOREIGN KEY ("T_Origem_idT_Origem") REFERENCES "t_origem" ("idT_Origem") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Novos_Animais_TipoEstatutoGenetico1" FOREIGN KEY ("TipoEstatutoGenetico_idTipoEstatutoGenetico") REFERENCES "tipoestatutogenetico" ("idTipoEstatutoGenetico") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "reg_remocoes"
--
ALTER TABLE "reg_remocoes" ADD
  CONSTRAINT "fk_Reg_Remocoes_Motivo1" FOREIGN KEY ("Motivo_idMotivo") REFERENCES "motivo" ("idMotivo") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Remocoes_Tanque1" FOREIGN KEY ("Tanque_idTanque") REFERENCES "tanque" ("idTanque") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "reg_tratamento"
--
ALTER TABLE "reg_tratamento" ADD
  CONSTRAINT "fk_Reg_Tratamento_Finalidade1" FOREIGN KEY ("Finalidade_idFinalidade") REFERENCES "finalidade" ("idFinalidade") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Tratamento_Tanque1" FOREIGN KEY ("Tanque_idTanque") REFERENCES "tanque" ("idTanque") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Reg_Tratamento_agente_Trat1" FOREIGN KEY ("agente_Trat_idAgenTra") REFERENCES "agente_trat" ("idAgenTra") ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table "tanque"
--
ALTER TABLE "tanque" ADD
  CONSTRAINT "fk_Tanque_Circuito_Tanque1" FOREIGN KEY ("Circuito_Tanque_idCircuito") REFERENCES "circuito_tanque" ("idCircuito") ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT "fk_Tanque_Lote1" FOREIGN KEY ("Lote_idLote") REFERENCES "lote" ("idLote") ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
