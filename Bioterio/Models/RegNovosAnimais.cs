﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class RegNovosAnimais
    {
        public RegNovosAnimais()
        {
            Lote = new HashSet<Lote>();
        }

        public int IdRegAnimal { get; set; }

        [DisplayName("Nº Exemplares")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? NroExemplares { get; set; }

        [DisplayName("Nº de Machos")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? NroMachos { get; set; }

        [DisplayName("Nº de Fêmeas")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? NroFemeas { get; set; }

        [DisplayName("Nº de Imaturos")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? Imaturos { get; set; }

        [DisplayName("Nº de Juvenis")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? Juvenis { get; set; }

        [DisplayName("Nº de Larvas")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? Larvas { get; set; }

        [DisplayName("Nº de Ovos")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? Ovos { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public DateTime? DataNasc { get; set; }

        [DisplayName("Idade")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? Idade { get; set; }

        [DisplayName("Peso Médio")]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public float? PesoMedio { get; set; }

        [DisplayName("Comprimento Médio")]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public float? CompMedio { get; set; }

        [DisplayName("Duracao do Transporte")]
        [DataType(DataType.Duration, ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public TimeSpan? DuracaoViagem { get; set; }

        [DisplayName("Temperatura de Partida")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? TempPartida { get; set; }

        [DisplayName("Temperatura de Chegada")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? TempChegada { get; set; }

        [DisplayName("Idade")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? NroContentores { get; set; }

        [DisplayName("Tipo de Contentor")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string TipoContentor { get; set; }

        [DisplayName("Volume do Contentor")]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public float? VolContentor { get; set; }

        [DisplayName("Volume da Água")]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public float? VolAgua { get; set; }

        [DisplayName("Nº de Caixas Isotérmicas")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? NroCaixasIsoter { get; set; }

        [DisplayName("Nº de Mortos à Chegada")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? NroMortosCheg { get; set; }

        [DisplayName("Saturacao de O2")]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public float? SatO2transp { get; set; }

        [DisplayName("Anestésico")]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public float? Anestesico { get; set; }

        [DisplayName("Gelo")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public sbyte? Gelo { get; set; }

        [DisplayName("Adicao de O2")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public sbyte? AdicaoO2 { get; set; }

        [DisplayName("Arejamento")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public sbyte? Arejamento { get; set; }

        [DisplayName("Refrigeracao")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public sbyte? Refrigeracao { get; set; }

        [DisplayName("sedacao")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public sbyte? sedacao { get; set; }

        [DisplayName("Responsável pelo Transporte")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string RespTransporte { get; set; }

        [DisplayName("Espécie")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int? EspecieIdEspecie { get; set; }

        [DisplayName("Fornecedor / Colector")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int? FornecedorIdFornColect { get; set; }

        [DisplayName("Tipo de Origem")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int? TOrigemIdTOrigem { get; set; }

        [DisplayName("Local de Captura")]
        public int? LocalCapturaIdLocalCaptura { get; set; }

        [DisplayName("Tipo de Estatuto Genético")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int? TipoEstatutoGeneticoIdTipoEstatutoGenetico { get; set; }

        [DisplayName("Funcionário (recepcao)")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int FuncionarioIdFuncionario { get; set; }

        [DisplayName("Funcionário (registo)")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int FuncionarioIdFuncionario1 { get; set; }

        [DisplayName("Espécie")]
        public Especie EspecieIdEspecieNavigation { get; set; }
        [DisplayName("Fornecedor / Colector")]
        public Fornecedorcolector FornecedorIdFornColectNavigation { get; set; }
        [DisplayName("Funcionário (recepcao)")]
        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        [DisplayName("Funcionário (registo)")]
        public Funcionario FuncionarioIdFuncionario1Navigation { get; set; }
        [DisplayName("Local de captura")]
        public Localcaptura LocalCapturaIdLocalCapturaNavigation { get; set; }
        [DisplayName("Tipo de Origem")]
        public TOrigem TOrigemIdTOrigemNavigation { get; set; }
        [DisplayName("Tipo de Estatuto Genético")]
        public Tipoestatutogenetico TipoEstatutoGeneticoIdTipoEstatutoGeneticoNavigation { get; set; }
        public ICollection<Lote> Lote { get; set; }
    }
}
