using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Concelho = new HashSet<Concelho>();
            Localcaptura = new HashSet<Localcaptura>();
        }

        public int Id { get; set; }
        [DisplayName("Nome Distrito")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string NomeDistrito { get; set; }

        public ICollection<Concelho> Concelho { get; set; }
        public ICollection<Localcaptura> Localcaptura { get; set; }
    }
}
