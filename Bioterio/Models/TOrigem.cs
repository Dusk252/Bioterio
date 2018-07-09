using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class TOrigem
    {
        public TOrigem()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdTOrigem { get; set; }

        [DisplayName("Tipo de Origem")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string descricao { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
