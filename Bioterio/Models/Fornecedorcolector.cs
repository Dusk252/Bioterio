using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Fornecedorcolector
    {
        public Fornecedorcolector()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdFornColect { get; set; }

        [DisplayName("Tipo")]
        [UIHint("CollectorType")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string Tipo { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string Nome { get; set; }

        [DisplayName("NIF")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Remote("ValidateNIF", "Fornecedorcolectors")]
        public int? Nif { get; set; }

        [DisplayName("Nº Licença")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"^\d*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public int? NroLicenca { get; set; }

        [DisplayName("Morada")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string Morada { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"^\+?[\s\d]*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public string Telefone { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
