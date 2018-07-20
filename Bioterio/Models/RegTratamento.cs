using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
namespace Bioterio.Models
{
    public partial class RegTratamento
    {
        public int IdRegTra { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Tempo")]
        public int Tempo { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Concentracao")]
        public float Concentracao { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Finalidade")]
        public int FinalidadeIdFinalidade { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Agente de Tratamento")]
        public int AgenteTratIdAgenTra { get; set; }
        [Display(Name = "Concentracao Agente Tratamento")]
        public int? ConcAgenTra { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Agente de Tratamento")]
        public AgenteTrat AgenteTratIdAgenTraNavigation { get; set; }
        [Display(Name = "Finalidade")]
        public Finalidade FinalidadeIdFinalidadeNavigation { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
        public string data;
        public int isarchived { get; set; }
    }
}
