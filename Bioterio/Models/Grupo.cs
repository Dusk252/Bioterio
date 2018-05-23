using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bioterio.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Especie = new HashSet<Especie>();
            Familia = new HashSet<Familia>();
        }

        public int IdGrupo { get; set; }
        [DisplayName("Nome")]
        public string NomeGrupo { get; set; }

        public ICollection<Especie> Especie { get; set; }
        public ICollection<Familia> Familia { get; set; }
    }
}
