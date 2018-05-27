using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bioterio.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Especie = new HashSet<Especie>();
            Familia = new HashSet<Familia>();
        }

        public int IdGrupo { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Remote("ValidateGroupName", "Grupos", AdditionalFields = "IdGrupo")]
        public string NomeGrupo { get; set; }

        public ICollection<Especie> Especie { get; set; }
        public ICollection<Familia> Familia { get; set; }
    }
}
