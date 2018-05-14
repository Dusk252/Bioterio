using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Familia
    {
        public Familia()
        {
            Especie = new HashSet<Especie>();
        }

        public int IdFamilia { get; set; }
        public string NomeFamilia { get; set; }
        public int GrupoIdGrupo { get; set; }

        public Grupo GrupoIdGrupoNavigation { get; set; }
        public ICollection<Especie> Especie { get; set; }
    }
}