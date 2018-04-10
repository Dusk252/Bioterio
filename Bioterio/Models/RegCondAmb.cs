using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class RegCondAmb
    {
        public int IdRegCondAmb { get; set; }
        public DateTime Data { get; set; }
        public double? Temperatura { get; set; }
        public double? VolAgua { get; set; }
        public double? SalinidadeAgua { get; set; }
        public double? NivelO2 { get; set; }
        public int CircuitoTanqueIdCircuito { get; set; }

        public CircuitoTanque CircuitoTanqueIdCircuitoNavigation { get; set; }
    }
}
