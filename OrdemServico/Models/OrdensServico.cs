using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdemServico.Models
{
    public enum StatusServicoEnum
    {
        Aberta = 1,
        EmAndamento = 2,
        Concluida = 3,
        Cancelada = 4
    }

    public partial class OrdensServico
    {
        [Key]
        public int IdOrdemServico { get; set; }

        [Required(ErrorMessage = "Data da ordem de serviço é obrigatória")]
        public DateTime DataOrdemServico { get; set; }

        [StringLength(50, ErrorMessage = "Serviço deve ter no máximo 50 caracteres")]
        public string? Servico { get; set; }

        [Required(ErrorMessage = "Valor total é obrigatório")]
        [Range(0, 1000000, ErrorMessage = "Valor total deve ser entre 0 e 1.000.000")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "Status da ordem de serviço é obrigatório")]
        [EnumDataType(typeof(StatusServicoEnum))]
        public StatusServicoEnum StatusServico { get; set; }

        [Required(ErrorMessage = "Equipamento é obrigatório")]
        public int IdEquipamento { get; set; }

        [Required(ErrorMessage = "Cliente é obrigatório")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Defeito é obrigatório")]
        public int IdDefeito { get; set; }

        [Required(ErrorMessage = "Técnico é obrigatório")]
        public int IdTecnico { get; set; }

        [ForeignKey("IdEquipamento")]
        public virtual Equipamento? IdEquipamentoNavigation { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? IdClienteNavigation { get; set; }

        [ForeignKey("IdDefeito")]
        public virtual Defeito? IdDefeitoNavigation { get; set; }

        [ForeignKey("IdTecnico")]
        public virtual Tecnico? IdTecnicoNavigation { get; set; }
    }
}
