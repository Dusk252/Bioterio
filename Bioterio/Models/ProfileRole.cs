using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bioterio.Models
{
    public class ProfileRole
    {
        public int IdPerfil { get; set; }
        public string RoleId { get; set; }

        public Perfil Profile { get; set; }
    }
}
