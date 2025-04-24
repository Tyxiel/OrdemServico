using System;
using System.Collections.Generic;

namespace OrdemServico.Models
{
    public partial class OrdensServico
    {
        public int IdOrdemServico { get; set; }
        public DateTime? DataOrdemServico { get; set; }
        public string? Servico { get; set; }
        public decimal? ValorTotal { get; set; }
        public string? StatusServico { get; set; }
        public int? IdEquipamento { get; set; }
        public int? IdCliente { get; set; }
        public int? IdDefeito { get; set; }
        public int? IdTecnico { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Defeito? IdDefeitoNavigation { get; set; }
        public virtual Equipamento? IdEquipamentoNavigation { get; set; }
        public virtual Tecnico? IdTecnicoNavigation { get; set; }
    }
}
