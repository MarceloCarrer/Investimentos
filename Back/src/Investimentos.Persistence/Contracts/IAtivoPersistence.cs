using System.Threading.Tasks;
using Investimentos.Domain;

namespace Investimentos.Persistence.Contracts
{
    public interface IAtivoPersistence
    {
        Task<Ativo[]> GetAllAtivosBySiglaAsync(string sigla);
        Task<Ativo[]> GetAllAtivosAsync();
        Task<Ativo> GetAtivoByIdAsync(int ativoId);
    }
}