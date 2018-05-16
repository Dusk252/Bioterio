using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Especie
    {
        public Especie()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdEspecie { get; set; }
        public string NomeCient { get; set; }
        public string NomeVulgar { get; set; }
        public int FamiliaIdFamilia { get; set; }

        public Familia FamiliaIdFamiliaNavigation { get; set; }
        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
