using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investimentos.Domain
{
    public class Ativo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(4)]
        public string Sigla { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Setor { get; set; }

        [Required]
        [MaxLength(10)]
        public string Tipo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Imagem { get; set; }

        public IEnumerable<Transacao> Transacao { get; set; }
    }
}