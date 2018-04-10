using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class PlanoAlimentar
    {
        public PlanoAlimentar()
        {
            RegAlimentar = new HashSet<RegAlimentar>();
        }

        public int IdPlanAlim { get; set; }
        public string Nome { get; set; }
        public string MarcaAlim { get; set; }
        public int Tipo { get; set; }
        public double Temperatura { get; set; }
        public double? Racao { get; set; }
        public double RacaoDia { get; set; }

        public ICollection<RegAlimentar> RegAlimentar { get; set; }
    }
}
