using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Especie
    {
        public Especie()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }
        public int IdEspecie { get; set; }

        [DisplayName("Nome Científico")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Remote("ValidateScientificName", "Especies", AdditionalFields = "IdEspecie")]
        public string NomeCient { get; set; }

        [DisplayName("Nome Vulgar")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string NomeVulgar { get; set; }

        [DisplayName("Familia")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int? FamiliaIdFamilia { get; set; }

        [DisplayName("Grupo")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int? GrupoIdGrupo { get; set; }

        [DisplayName("Familia")]
        public Familia FamiliaIdFamiliaNavigation { get; set; }

        [DisplayName("Grupo")]
        public Grupo GrupoIdGrupoNavigation { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
