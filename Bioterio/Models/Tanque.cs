using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Tanque
    {
        public Tanque()
        {
            RegAlimentar = new HashSet<RegAlimentar>();
            RegAmostragens = new HashSet<RegAmostragens>();
            RegManutencao = new HashSet<RegManutencao>();
        }

        public int IdTanque { get; set; }
        public int NroAnimais { get; set; }
        public string Sala { get; set; }
        public string Observacoes { get; set; }
        public int LoteIdLote { get; set; }
        public int CircuitoTanqueIdCircuito { get; set; }
        public byte? VarControlo { get; set; }

        public ICollection<RegAlimentar> RegAlimentar { get; set; }
        public ICollection<RegAmostragens> RegAmostragens { get; set; }
        public ICollection<RegManutencao> RegManutencao { get; set; }
    }
}
