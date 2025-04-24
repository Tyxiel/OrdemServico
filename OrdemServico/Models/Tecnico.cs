using System;
using System.Collections.Generic;

namespace OrdemServico.Models
{
    public partial class Tecnico
    {
        public Tecnico()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }

        public int IdTecnico { get; set; }
        public string? NomeTecnico { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
