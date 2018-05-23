using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bioterio.Models
{
    public partial class Fornecedorcolector
    {
        public Fornecedorcolector()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdFornColect { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        [DisplayName("NIF")]
        public int? Nif { get; set; }
        [DisplayName("Nº Licença")]
        public int? NroLicenca { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
