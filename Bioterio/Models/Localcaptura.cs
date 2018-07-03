using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Localcaptura
    {
        public Localcaptura()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdLocalCaptura { get; set; }

        [DisplayName("Localidade")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string Localidade { get; set; }

        [DisplayName("Latitude")]
        public float? Latitude { get; set; }

        [DisplayName("Longitude")]
        public float? Longitude { get; set; }

        [DisplayName("Concelho")]
        public int ConcelhoId { get; set; }

        [DisplayName("Distrito")]
        public int DistritoId { get; set; }

        public Concelho Concelho { get; set; }
        public Distrito Distrito { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
