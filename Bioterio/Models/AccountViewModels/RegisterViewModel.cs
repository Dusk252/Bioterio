using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioterio.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Nome de Utilizador")]
        [Remote("ValidateUserNameOnCreate", "Funcionarios")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Display(Name = "Telefone")]
        [RegularExpression(@"^\+?[\s\d]*$", ErrorMessageResourceType = typeof(SiteResources), ErrorMessageResourceName = "InvalidField")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} tem de ter pelo menos {2} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A password e o campo de confirmação não são iguais.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Perfil")]
        public int IdPerfil { get; set; }
    }
}
