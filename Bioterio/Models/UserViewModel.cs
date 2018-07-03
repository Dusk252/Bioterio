using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioterio.Models
{
    public class UserViewModel
    {
        [DisplayName("Funcionário")]
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Nome de Utilizador")]
        [Remote("ValidateUserName", "Funcionarios", AdditionalFields = "IdFuncionario")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Display(Name = "Telefone")]
        [RegularExpression(@"^\+?[\s\d]*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Perfil")]
        public string Permissions { get; set; }
    }
}
