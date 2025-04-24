using System;
using System.Collections.Generic;

namespace OrdemServico.Models
{
    public partial class Defeito
    {
        public Defeito()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }

        public int IdDefeito { get; set; }
        public string? Descricao { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
