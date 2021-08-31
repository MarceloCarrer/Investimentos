using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investimentos.Application.Dtos
{
    public class AtivoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "{0} deve ter 4 dígitos.")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [MinLength(2, ErrorMessage = "{0} deve ter no mínimo 2 letras.")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [MinLength(2, ErrorMessage = "{0} deve ter no mínimo 2 letras.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no máximo 100 letras.")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [MinLength(1, ErrorMessage = "{0} deve ter no mínimo 1 caracter.")]
        [MaxLength(10, ErrorMessage = "{0} deve ter no máximo 10 caracteres.")]
        public string Tipo { get; set; }

        [RegularExpression(@".*\.(jpe?g|png)$", ErrorMessage = "Somente formatos JPG, JPEG ou PNG aceitos.")]
        public string Imagem { get; set; }

        public IEnumerable<TransacaoDto> Transacao { get; set; }
        
    }
}