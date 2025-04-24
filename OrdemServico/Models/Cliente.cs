using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdemServico.Models
{
    public partial class Cliente
    {

        public Cliente()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "O nome é obrigatória.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string? NomeCliente { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
