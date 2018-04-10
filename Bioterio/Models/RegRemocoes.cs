using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class RegRemocoes
    {
        public int IdRegRemo { get; set; }
        public DateTime Date { get; set; }
        public int? NroRemoções { get; set; }
        public int MotivoIdMotivo { get; set; }
        public string CausaMorte { get; set; }
        public int TanqueIdTanque { get; set; }
    }
}
