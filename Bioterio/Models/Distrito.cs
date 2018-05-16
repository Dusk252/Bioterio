using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Concelho = new HashSet<Concelho>();
            Localcaptura = new HashSet<Localcaptura>();
        }

        public int Id { get; set; }
        public string NomeDistrito { get; set; }

        public ICollection<Concelho> Concelho { get; set; }
        public ICollection<Localcaptura> Localcaptura { get; set; }
    }
}
