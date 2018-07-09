using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Concelho
    {
        public Concelho()
        {
            Localcaptura = new HashSet<Localcaptura>();
        }

        public int IdConcelho { get; set; }

        [DisplayName("Nome Concelho")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Remote("ValidateConcelhoName", "Concelhos", AdditionalFields = "IdConcelho")]
        public string NomeConcelho { get; set; }

        [DisplayName("Distrito")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int DistritoId { get; set; }

        public Distrito Distrito { get; set; }
        public ICollection<Localcaptura> Localcaptura { get; set; }
    }
}
