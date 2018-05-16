using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Concelho
    {
        public Concelho()
        {
            Localcaptura = new HashSet<Localcaptura>();
        }

        public int Id { get; set; }
        public string NomeConcelho { get; set; }
        public int DistritoId { get; set; }

        public Distrito Distrito { get; set; }
        public ICollection<Localcaptura> Localcaptura { get; set; }
    }
}
