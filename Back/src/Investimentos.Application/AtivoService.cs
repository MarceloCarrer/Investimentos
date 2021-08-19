using System;
using System.Threading.Tasks;
using AutoMapper;
using Investimentos.Application.Contracts;
using Investimentos.Application.Dtos;
using Investimentos.Domain;
using Investimentos.Persistence.Contracts;

namespace Investimentos.Application
{
    public class AtivoService : IAtivoService
    {
        private readonly IMapper _mapper;
        private readonly IAtivoPersistence _ativoPersistence;
        private readonly IGeralPersistence _geralPersistence;

        public AtivoService(IGeralPersistence geralPersistence, IAtivoPersistence ativoPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _ativoPersistence = ativoPersistence;
            _mapper = mapper;
        }

        public async Task<AtivoDto> AddAtivo(AtivoDto model)
        {
            try
            {
                var ativo = _mapper.Map<Ativo>(model);

                _geralPersistence.Add<Ativo>(ativo);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    var ativoRetorno = await _ativoPersistence.GetAtivoByIdAsync(ativo.Id);
                    return _mapper.Map<AtivoDto>(ativoRetorno);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public async Task<AtivoDto> UpdateAtivo(int ativoId, AtivoDto model)
        {
            try
            {
                var ativo = await _ativoPersistence.GetAtivoByIdAsync(ativoId);
                if (ativo == null)
                {
                    return null;
                }

                model.Id = ativo.Id;

                _mapper.Map(model, ativo);

                _geralPersistence.Update<Ativo>(ativo);
                
                if (await _geralPersistence.SaveChangesAsync())
                {
                    var retornoAtivo = await _ativoPersistence.GetAtivoByIdAsync(ativo.Id);

                    return _mapper.Map<AtivoDto>(retornoAtivo);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAtivo(int ativoId)
        {
            try
            {
                var ativo = await _ativoPersistence.GetAtivoByIdAsync(ativoId);
                if (ativo == null)
                {
                    throw new Exception("Ativo para deletar não foi encontrado.");
                }

                _geralPersistence.Delete<Ativo>(ativo);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtivoDto[]> GetAllAtivosBySiglaAsync(string sigla)
        {
            try
            {
                var ativos = await _ativoPersistence.GetAllAtivosBySiglaAsync(sigla);
                if (ativos == null)
                {
                    return null;
                }
                var resultado = _mapper.Map<AtivoDto[]>(ativos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtivoDto[]> GetAllAtivosAsync()
        {
            try
            {
                var ativos = await _ativoPersistence.GetAllAtivosAsync();
                if (ativos == null)
                {
                    return null;
                }

                var resultado = _mapper.Map<AtivoDto[]>(ativos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task<AtivoDto> GetAtivoByIdAsync(int ativoId)
        {
            try
            {
                var ativo = await _ativoPersistence.GetAtivoByIdAsync(ativoId);
                if (ativo == null)
                {
                    return null;
                }

                var resultado = _mapper.Map<AtivoDto>(ativo);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}