using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Tipoestatutogenetico
    {
        public Tipoestatutogenetico()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdTipoEstatutoGenetico { get; set; }

        [DisplayName("Tipo de Estatudo Genético")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string TipoEstatutoGeneticocol { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
