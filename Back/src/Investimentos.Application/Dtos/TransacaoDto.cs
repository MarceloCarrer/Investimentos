using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investimentos.Application.Dtos
{
    public class TransacaoDto
    {
        public int Id { get; set; }

        [Display(Name = "Data Compra")]
        [Required(ErrorMessage = "{0} é obrigatório.")]        
        public string DataCompra { get; set; }

        [Display(Name = "Valor Compra")]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Range(0.01, 999999, ErrorMessage = "{0} está fora do limite.")]
        public decimal ValorCompra { get; set; }
        
        [Display(Name = "Quantidade Ações Compra")]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Range(1, 999999, ErrorMessage = "{0} está fora do limite.")]
        public int QtdCompra { get; set; }
        
        [Display(Name = "Data Venda")]
        public string DataVenda { get; set; }
        
        [Display(Name = "Valor Venda")]
        [Range(0.00, 9999, ErrorMessage = "{0} está fora do limite.")]
        public decimal? ValorVenda { get; set; }
        
        [Display(Name = "Quantidae Venda")]
        [Range(0, 999999999, ErrorMessage = "{0} está fora do limite.")]
        public int? QtdVenda { get; set; }

        [Display(Name = "Valor Total Venda")]
        [Range(0, 999999999, ErrorMessage = "{0} está fora do limite.")]
        public decimal? ValorTotalVenda { get; set; }

        [Display(Name = "Lucro %")]
        public decimal? LucroPorc { get; set; }

        [Display(Name = "Lucro")]
        public decimal? Lucro { get; set; }

        [Display(Name = "Imposto")]
        public decimal? Imposto { get; set; }

        [Display(Name = "Lucro Liquido")]
        public decimal? LucroLiquido { get; set; }

        [Display(Name = "Retorno Liquido")]
        public decimal? RetornoLiquido { get; set; }

        public bool? Vendido { get; set; }
        
        public int AtivoId { get; set; }

        public AtivoDto Ativo { get; set; }
    }
}