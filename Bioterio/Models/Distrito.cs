using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Concelho = new HashSet<Concelho>();
        }

        public int Id { get; set; }
        public string NomeDistrito { get; set; }

        public ICollection<Concelho> Concelho { get; set; }
    }
}
