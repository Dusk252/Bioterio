using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class ConfigurationsViewModel
    {

        public ConfigurationsViewModel()
        {
            Especies = new HashSet<Especie>();
        }

        public IEnumerable<Especie> Especies { get; set; }
        public IEnumerable<Familia> Familias { get; set; }
        public IEnumerable<Grupo> Grupos { get; set; } 
    }
}
