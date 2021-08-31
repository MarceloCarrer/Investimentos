using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investimentos.Domain
{
    public class Transacao
    {
        public int Id { get; set; }

        [Required]
        public string DataCompra { get; set; }

        [Required]
        public decimal ValorCompra { get; set; }

        [Required]
        public int QtdCompra { get; set; }
        
        public string DataVenda { get; set; }
        
        public decimal? ValorVenda { get; set; }
        
        public int? QtdVenda { get; set; }

        public decimal? ValorTotalVenda { get; set; }

        public decimal? LucroPorc { get; set; }

        public decimal? Lucro { get; set; }

        public decimal? Imposto { get; set; }

        public decimal? LucroLiquido { get; set; }

        public decimal? RetornoLiquido { get; set; }     
        
        public bool? Vendido { get; set; }   

        public int AtivoId { get; set; }

        public Ativo Ativo { get; set; }
    }
}