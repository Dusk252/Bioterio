using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation

namespace Bioterio
{
    public partial class RegManutencao
    {
        public int IdRegMan { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "É necessario preencher este campo para Prosseguir")]
        [Display(Name = "Tipo de Manutencao")]
        public int TipoManuntecaoIdTManutencao { get; set; }
        [Display(Name = "Tanque")]
        public int TanqueIdTanque { get; set; }
        [Display(Name = "Tanque")]
        public Tanque TanqueIdTanqueNavigation { get; set; }
        [Display(Name = "Tipo de Manutencao")]
        public TipoManuntecao TipoManuntecaoIdTManutencaoNavigation { get; set; }
        public string data;
        public int isarchived { get; set; }
    }
}
