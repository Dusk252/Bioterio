using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Familia
    {
        public Familia()
        {
            Especie = new HashSet<Especie>();
        }

        public int IdFamilia { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Remote("ValidateFamilyName", "Familias", AdditionalFields = "IdFamilia")]
        public string NomeFamilia { get; set; }

        [DisplayName("Grupo")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int? GrupoIdGrupo { get; set; }

        [DisplayName("Grupo")]
        public Grupo GrupoIdGrupoNavigation { get; set; }

        public ICollection<Especie> Especie { get; set; }
    }
}
