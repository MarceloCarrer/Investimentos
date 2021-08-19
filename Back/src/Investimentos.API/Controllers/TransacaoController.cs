using System;
using System.Threading.Tasks;
using Investimentos.Application.Contracts;
using Investimentos.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Investimentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;
        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpGet("{ativoId}")]
        public async Task<IActionResult> Get(int ativoId)
        {
            try
            {
                var transacao = await _transacaoService.GetTransacoesByAtivoIdAsync(ativoId);
                if (transacao == null)
                {
                    return NoContent();
                }

                return Ok(transacao);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar transações. Erro: {ex.Message}");
            }
        }

        [HttpPut("{ativoId}")]
        public async Task<IActionResult> SaveTransacao(int ativoId, TransacaoDto[] models)
        {
            try
            {
                var transacao = await _transacaoService.SaveTransacao(ativoId, models);
                if (transacao == null)
                {
                    return NoContent();
                }

                return Ok(transacao);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar salvar transação. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{ativoId}/{transacaoId}")]
        public async Task<IActionResult> Delete(int ativoId, int transacaoId)
        {
            try
            {
                var transacao = await _transacaoService.GetTransacaoByIdsAsync(ativoId, transacaoId);
                if (transacao == null)
                {
                    return NoContent();
                }

                return await _transacaoService.DeleteTransacao(transacao.AtivoId, transacao.Id) ?
                        Ok(new { message = "Transação Deletada." }) :
                        BadRequest("Erro! Transação não deletada.");
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar transação. Erro: {ex.Message}");
            }
        }
    }
}
