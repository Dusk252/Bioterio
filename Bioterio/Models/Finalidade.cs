using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Finalidade
    {
        public Finalidade()
        {
            RegTratamento = new HashSet<RegTratamento>();
        }

        public int IdFinalidade { get; set; }
        public string TFinalidade { get; set; }

        public ICollection<RegTratamento> RegTratamento { get; set; }
    }
}
