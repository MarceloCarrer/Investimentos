using System.Threading.Tasks;
using Investimentos.Domain;

namespace Investimentos.Persistence.Contracts
{
    public interface ITransacaoPersistence
    {
        Task<Transacao[]> GetTransacaosByAtivoIdAsync(int ativoId);
        Task<Transacao> GetTransacaoByIdsAsync(int ativoId, int id);
    }
}