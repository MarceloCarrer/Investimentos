using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investimentos.Domain
{
    public class Transacao
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public decimal ValorCompra { get; set; }

        [Required]
        public int QtdCompra { get; set; }

        [Required]
        public DateTime? DataVenda { get; set; }

        [Required]
        public decimal? ValorVenda { get; set; }

        [Required]
        public int? QtdVenda { get; set; }

        public int AtivoId { get; set; }

        public Ativo Ativo { get; set; }
    }
}