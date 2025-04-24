using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdemServico.Models
{
    public partial class Equipamento
    {
        public Equipamento()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }
        [Key]
        public int IdEquipamento { get; set; }

        [Required(ErrorMessage = "O nome do equipamento é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string? NomeEquipamento { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
