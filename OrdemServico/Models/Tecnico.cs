using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdemServico.Models
{
    public partial class Tecnico
    {
        public enum TecnicoEnum
        {
            ArthurDias = 1,
            HelenSilva = 2,
            LeandroAmaral = 3,
            ViniciusBonfim = 4,
            WallaceOliveira = 5
        }

        public Tecnico()
        {
            OrdensServicos = new HashSet<OrdensServico>();
        }
        [Key]
        public int IdTecnico { get; set; }

        [Required(ErrorMessage = "O nome do técnico é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string? NomeTecnico { get; set; }

        public virtual ICollection<OrdensServico> OrdensServicos { get; set; }
    }
}
