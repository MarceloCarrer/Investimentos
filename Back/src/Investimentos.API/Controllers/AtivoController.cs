using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimentos.Application.Contracts;
using Investimentos.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Investimentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly IAtivoService _ativoService;
        public AtivoController(IAtivoService ativoService)
        {
            _ativoService = ativoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ativo = await _ativoService.GetAllAtivosAsync();
                if (ativo == null)
                {
                    return NoContent();
                }

                return Ok(ativo);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar ativos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ativo = await _ativoService.GetAtivoByIdAsync(id);
                if (ativo == null)
                {
                    return NoContent();
                }

                return Ok(ativo);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar ativo. Erro: {ex.Message}");
            }
        }

        [HttpGet("sigla/{sigla}")]
        public async Task<IActionResult> GetBysigla(string sigla)
        {
            try
            {
                var ativo = await _ativoService.GetAllAtivosBySiglaAsync(sigla);
                if (ativo == null)
                {
                    return NoContent();
                }

                return Ok(ativo);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar ativo. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AtivoDto model)
        {
            try
            {
                var ativo = await _ativoService.AddAtivo(model);
                if (ativo == null)
                {
                    return NoContent();
                }

                return Ok(ativo);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar ativo. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AtivoDto model)
        {
            try
            {
                var ativo = await _ativoService.UpdateAtivo(id, model);
                if (ativo == null)
                {
                    return NoContent();
                }

                return Ok(ativo);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar ativo. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ativo = await _ativoService.GetAtivoByIdAsync(id);
                if (ativo == null)
                {
                    return NoContent();
                }

                return await _ativoService.DeleteAtivo(id) ?
                        Ok(new { message = "Ativo Deletado." }) :
                        BadRequest("Erro! Ativo não deletado.");
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar ativo. Erro: {ex.Message}");
            }
        }

    }
}
