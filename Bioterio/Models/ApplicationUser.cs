using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bioterio.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int FuncionarioIdFuncionario { get; set; }
        public Funcionario FuncionarioNavigation { get; set; }
    }
}
