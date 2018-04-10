using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Localcaptura
    {
        public int IdLocalCaptura { get; set; }
        public string Localidade { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int ConselhoId { get; set; }
        public int ConselhoDistritoId { get; set; }

        public Conselho Conselho { get; set; }
    }
}
