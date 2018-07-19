using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bioterio.Models
{
    public class ApplicationUsers : IdentityUser
    {
        //public ApplicationUsers() : base() { }
        //public ApplicationUsers(string name, int FuncionarioId) : base(name)
        //{
        //    FuncionarioIdFuncionario = FuncionarioId;
        //}

        public int FuncionarioIdFuncionario { get; set; }
        public Funcionario FuncionarioNavigation { get; set; }
        public int IdPerfil { get; set; }
        public Perfil PerfilNavigation { get; set; }
    }
}
