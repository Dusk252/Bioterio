using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioterio.Models
{
    public class Perfil
    {
        public Perfil()
        {
            User = new HashSet<ApplicationUsers>();
            Roles = new HashSet<ProfileRole>();
        }

        [DisplayName("Perfil")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int IdPerfil { get; set; }

        [DisplayName("Nome do Perfil")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public string NomePerfil { get; set; }

        [DisplayName("Default")]
        public int? IsDefault { get; set; }

        public ICollection<ApplicationUsers> User { get; set; }
        public ICollection<ProfileRole> Roles { get; set; }
    }
}
