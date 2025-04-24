using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrdemServico.Models
{
    public enum DefeitoEnum
    {
        NaoLiga = 1,
        TelaAzul = 2,
        Superaquecimento = 3,
        SemConexaoComInternet = 4,
        ErroAoInicializarOSistema = 5
    }

    public partial class Defeito
    {
        public Defeito()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }
        [Key]
        public int IdDefeito { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(300, ErrorMessage = "A descrição não pode ter mais que 300 caracteres.")]
        public string? Descricao { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
