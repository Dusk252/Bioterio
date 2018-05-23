using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bioterio.Models
{
    public partial class Familia
    {
        public Familia()
        {
            Especie = new HashSet<Especie>();
        }

        public int IdFamilia { get; set; }
        [DisplayName("Nome")]
        public string NomeFamilia { get; set; }
        [DisplayName("Grupo")]
        public int GrupoIdGrupo { get; set; }

        [DisplayName("Grupo")]
        public Grupo GrupoIdGrupoNavigation { get; set; }
        public ICollection<Especie> Especie { get; set; }
    }
}
