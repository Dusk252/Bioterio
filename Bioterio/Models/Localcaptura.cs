using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Localcaptura
    {
        public Localcaptura()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdLocalCaptura { get; set; }
        public string Localidade { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int ConcelhoId { get; set; }

        public Concelho Concelho { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
