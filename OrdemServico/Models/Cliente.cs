using System;
using System.Collections.Generic;

namespace OrdemServico.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }

        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
