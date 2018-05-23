using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bioterio.Models
{
    public partial class Especie
    {
        public Especie()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdEspecie { get; set; }
        [DisplayName("Nome Científico")]
        public string NomeCient { get; set; }
        [DisplayName("Nome Vulgar")]
        public string NomeVulgar { get; set; }
        [DisplayName("Familia")]
        public int FamiliaIdFamilia { get; set; }
        [DisplayName("Grupo")]
        public int GrupoIdGrupo { get; set; }

        [DisplayName("Familia")]
        public Familia FamiliaIdFamiliaNavigation { get; set; }
        [DisplayName("Grupo")]
        public Grupo GrupoIdGrupoNavigation { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
