using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Lote
    {
        public Lote()
        {
            Ensaio = new HashSet<Ensaio>();
            LoteSubLoteLoteIdLoteAtualNavigation = new HashSet<LoteSubLote>();
            LoteSubLoteLoteIdLotePrevNavigation = new HashSet<LoteSubLote>();
        }

        public int IdLote { get; set; }
        public string CodigoLote { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Observacoes { get; set; }
        public int RegNovosAnimaisIdRegAnimal { get; set; }
        public int FuncionarioIdFuncionario { get; set; }
        public byte? VarControlo { get; set; }

        public Funcionario FuncionarioIdFuncionarioNavigation { get; set; }
        public RegNovosAnimais RegNovosAnimaisIdRegAnimalNavigation { get; set; }
        public ICollection<Ensaio> Ensaio { get; set; }
        public ICollection<LoteSubLote> LoteSubLoteLoteIdLoteAtualNavigation { get; set; }
        public ICollection<LoteSubLote> LoteSubLoteLoteIdLotePrevNavigation { get; set; }
    }
}
