using System;
using System.Collections.Generic;

namespace OrdemServico.Models
{
    public partial class Equipamento
    {
        public Equipamento()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }

        public int IdEquipamento { get; set; }
        public string? NomeEquipamento { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
