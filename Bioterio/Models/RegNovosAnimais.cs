using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class RegNovosAnimais
    {
        public RegNovosAnimais()
        {
            Lote = new HashSet<Lote>();
        }

        public int IdRegAnimal { get; set; }
        public int NroExemplares { get; set; }
        public int? NroMachos { get; set; }
        public int? NroFemeas { get; set; }
        public int? Imaturos { get; set; }
        public int? Juvenis { get; set; }
        public int? Larvas { get; set; }
        public int? Ovos { get; set; }
        public DateTime? DataNasc { get; set; }
        public int? Idade { get; set; }
        public double? PesoMedio { get; set; }
        public double? CompMedio { get; set; }
        public TimeSpan? DuracaoViagem { get; set; }
        public int? TempPartida { get; set; }
        public int? TempChegada { get; set; }
        public int? NroContentores { get; set; }
        public string TipoContentor { get; set; }
        public double? VolContentor { get; set; }
        public double? VolAgua { get; set; }
        public int? NroCaixasIsoter { get; set; }
        public int? NroMortosCheg { get; set; }
        public double? SatO2transp { get; set; }
        public double? Anestesico { get; set; }
        public byte? Gelo { get; set; }
        public byte? AdicaoO2 { get; set; }
        public byte? Arejamento { get; set; }
        public byte? Refrigeracao { get; set; }
        public byte? Sedação { get; set; }
        public string RespTransporte { get; set; }
        public int EspecieIdEspecie { get; set; }
        public int FornecedorIdFornColect { get; set; }
        public int TOrigemIdTOrigem { get; set; }
        public int? LocalCapturaIdLocalCaptura { get; set; }
        public int TipoEstatutoGeneticoIdTipoEstatutoGenetico { get; set; }
        public int FuncionarioIdFuncionario { get; set; }
        public int FuncionarioIdFuncionario1 { get; set; }

        public ICollection<Lote> Lote { get; set; }
    }
}
