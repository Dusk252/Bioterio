using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
using Bioterio.Models;

namespace Bioterio
{
    public partial class Elementoequipa
    {
        public int IdElementoEquipa { get; set; }
        [Required(ErrorMessage = "É necessário preencher este campo para prosseguir.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário preencher este campo para prosseguir.")]
        [Display(Name = "Funcao")]
        public string Funcao { get; set; }
        [Display(Name = "Projeto")]
        public int ProjetoIdProjeto { get; set; }
        [Display(Name = "Funcionário")]
        public int FuncionarioIdFuncionario { get; set; }
        [Display(Name = "Funcionário")]
        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        [Display(Name = "Projeto")]
        public Projeto ProjetoIdProjetoNavigation { get; set; }
        public int isarchived { get; set; }
    }
}
