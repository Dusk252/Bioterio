using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class CircuitoTanque
    {
        public CircuitoTanque()
        {
            RegCondAmb = new HashSet<RegCondAmb>();
        }

        public int IdCircuito { get; set; }
        public int ProjetoIdProjeto { get; set; }
        public string CodigoCircuito { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinal { get; set; }
        public byte? VarControlo { get; set; }

        public Projeto ProjetoIdProjetoNavigation { get; set; }
        public ICollection<RegCondAmb> RegCondAmb { get; set; }
    }
}
