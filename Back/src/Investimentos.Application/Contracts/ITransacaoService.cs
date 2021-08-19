using System.Threading.Tasks;
using Investimentos.Application.Dtos;

namespace Investimentos.Application.Contracts
{
    public interface ITransacaoService
    {
        Task<TransacaoDto[]> SaveTransacao(int ativoId, TransacaoDto[] models);
        Task<bool> DeleteTransacao(int ativoId, int transacaoId);

        Task<TransacaoDto[]> GetTransacoesByativoIdAsync(int ativoId);
        Task<TransacaoDto> GetTransacaoByIdsAsync(int ativoId, int id);
    }
}