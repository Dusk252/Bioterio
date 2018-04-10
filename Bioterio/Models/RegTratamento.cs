using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class RegTratamento
    {
        public int IdRegTra { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Tempo { get; set; }
        public double Concentracao { get; set; }
        public int FinalidadeIdFinalidade { get; set; }
        public int AgenteTratIdAgenTra { get; set; }
        public int? ConcAgenTra { get; set; }
        public int TanqueIdTanque { get; set; }
    }
}
