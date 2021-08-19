using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investimentos.Application.Contracts;
using Investimentos.Application.Dtos;
using Investimentos.Domain;
using Investimentos.Persistence.Contracts;

namespace Investimentos.Application
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly ITransacaoPersistence _transacaoPersistence;
        private readonly IMapper _mapper;

        public TransacaoService(IGeralPersistence geralPersistence, ITransacaoPersistence transacaoPersistence, IMapper mapper)
        {
            _mapper = mapper;
            _transacaoPersistence = transacaoPersistence;
            _geralPersistence = geralPersistence;
        }

        public async Task AddTransacao(int ativoId, TransacaoDto model)
        {
            try
            {
                var transacao = _mapper.Map<Transacao>(model);
                transacao.AtivoId = ativoId;

                _geralPersistence.Add<Transacao>(transacao);

                await _geralPersistence.SaveChangesAsync();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransacaoDto[]> SaveTransacao(int ativoId, TransacaoDto[] models)
        {
            try
            {
                var transacoes = await _transacaoPersistence.GetTransacoesByAtivoIdAsync(ativoId);
                if (transacoes == null)
                {
                    return null;
                }

                foreach (var model in models)
                {
                    if (model.Id == 0)
                    {
                        await AddTransacao(ativoId, model);
                    }
                    else
                    {
                        var transacao = transacoes.FirstOrDefault(transacao => transacao.Id == model.Id);
                        model.AtivoId = ativoId;

                        _mapper.Map(model, transacao);

                        _geralPersistence.Update<Transacao>(transacao);
                        
                        await _geralPersistence.SaveChangesAsync();
                    }
                }
               
                var retornoTransacao = await _transacaoPersistence.GetTransacoesByAtivoIdAsync(ativoId);

                return _mapper.Map<TransacaoDto[]>(retornoTransacao);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTransacao(int ativoId, int transacaoId)
        {
            try
            {
                var transacao = await _transacaoPersistence.GetTransacaoByIdsAsync(ativoId, transacaoId);
                if (transacao == null)
                {
                    throw new Exception("Transação para deletar não foi encontrado.");
                }

                _geralPersistence.Delete<Transacao>(transacao);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransacaoDto[]> GetTransacoesByAtivoIdAsync(int ativoId)
        {
            try
            {
                var transacoes = await _transacaoPersistence.GetTransacoesByAtivoIdAsync(ativoId);
                if (transacoes == null)
                {
                    return null;
                }

                var resultado = _mapper.Map<TransacaoDto[]>(transacoes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<TransacaoDto> GetTransacaoByIdsAsync(int ativoId, int transacaoId)
        {
            try
            {
                var transacao = await _transacaoPersistence.GetTransacaoByIdsAsync(ativoId, transacaoId);
                if (transacao == null)
                {
                    return null;
                }

                var resultado = _mapper.Map<TransacaoDto>(transacao);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}