using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Projeto
    {
        public Projeto()
        {
            CircuitoTanque = new HashSet<CircuitoTanque>();
            Elementoequipa = new HashSet<Elementoequipa>();
            Ensaio = new HashSet<Ensaio>();
        }

        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string AutorizacaoDgva { get; set; }
        public int? RefOrbea { get; set; }
        public sbyte? SubmisInsEurop { get; set; }
        public int? NroAnimaisAutoriz { get; set; }
        public bool? VarControlo { get; set; }

        public ICollection<CircuitoTanque> CircuitoTanque { get; set; }
        public ICollection<Elementoequipa> Elementoequipa { get; set; }
        public ICollection<Ensaio> Ensaio { get; set; }
    }
}
