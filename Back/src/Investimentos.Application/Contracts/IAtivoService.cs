using System.Threading.Tasks;
using Investimentos.Application.Dtos;

namespace Investimentos.Application.Contracts
{
    public interface IAtivoService
    {
        Task<AtivoDto> AddAtivo(AtivoDto model);
        Task<AtivoDto> UpdateAtivo(int ativoId, AtivoDto model);
        Task<bool> DeleteAtivo(int ativoId);

        Task<AtivoDto[]> GetAllAtivosBySiglaAsync(string sigla);
        Task<AtivoDto[]> GetAllAtivosAsync();
        Task<AtivoDto> GetAtivoByIdAsync(int ativoId);
    }
}