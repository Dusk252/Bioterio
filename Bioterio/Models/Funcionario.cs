using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Elementoequipa = new HashSet<Elementoequipa>();
            Lote = new HashSet<Lote>();
            RegNovosAnimaisFuncionarioIdFuncionario1Navigation = new HashSet<RegNovosAnimais>();
            RegNovosAnimaisFuncionarioIdFuncionarioNavigation = new HashSet<RegNovosAnimais>();
            User = new HashSet<ApplicationUsers>();
        }

        [DisplayName("Funcionário")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int IdFuncionario { get; set; }

        [DisplayName("Nome Completo")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string NomeCompleto { get; set; }

        public ICollection<Elementoequipa> Elementoequipa { get; set; }
        public ICollection<Lote> Lote { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimaisFuncionarioIdFuncionario1Navigation { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimaisFuncionarioIdFuncionarioNavigation { get; set; }
        public ICollection<ApplicationUsers> User { get; set; }
    }
}
