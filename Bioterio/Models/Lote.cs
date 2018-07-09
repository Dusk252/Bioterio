using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Lote
    {
        public Lote()
        {
            Ensaio = new HashSet<Ensaio>();
            LoteSubLoteLoteIdLoteAtualNavigation = new HashSet<LoteSubLote>();
            LoteSubLoteLoteIdLotePrevNavigation = new HashSet<LoteSubLote>();
            Tanque = new HashSet<Tanque>();
        }

        public int IdLote { get; set; }

        [DisplayName("Código do Lote")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Remote("ValidateCodigoLote", "Lotes", AdditionalFields = "IdLote")]
        public string CodigoLote { get; set; }

        [DisplayName("Data de Início")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data de Fim")]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        [Remote("ValidateDates", "Lotes", AdditionalFields = "DataInicio")]
        public DateTime? DataFim { get; set; }

        [DisplayName("Observacoes")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string Observacoes { get; set; }

        [DisplayName("Registo Associado")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int RegNovosAnimaisIdRegAnimal { get; set; }

        [DisplayName("Funcionário")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int FuncionarioIdFuncionario { get; set; }

        [DisplayName("Funcionário")]
        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        [DisplayName("Registo Associado")]
        public RegNovosAnimais RegNovosAnimaisIdRegAnimalNavigation { get; set; }
        public ICollection<Ensaio> Ensaio { get; set; }
        public ICollection<LoteSubLote> LoteSubLoteLoteIdLoteAtualNavigation { get; set; }
        public ICollection<LoteSubLote> LoteSubLoteLoteIdLotePrevNavigation { get; set; }
        public ICollection<Tanque> Tanque { get; set; }
    }
}
