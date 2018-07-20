using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;  //needed for DisplayName annotation
using System.Linq;
namespace Bioterio.Models
{
    public partial class TipoManuntecao
    {
        internal object regManutencao;

        public TipoManuntecao()
        {
            RegManutencao = new HashSet<RegManutencao>();
        }

        public int IdTManutencao { get; set; }
        [Required(ErrorMessage = "É necessário preencher este campo para prosseguir.")]
        [Display(Name = "Nome da Manutencao")]
        public string TManutencao { get; set; }
        [Display(Name = "Registo de Manutencao")]
        public ICollection<RegManutencao> RegManutencao { get; set; }
        public Boolean isDeletable;
        public IQueryable<RegTratamento> regManutecao;
    }
}
