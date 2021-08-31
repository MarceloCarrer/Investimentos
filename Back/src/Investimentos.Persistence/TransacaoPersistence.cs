using System.Linq;
using System.Threading.Tasks;
using Investimentos.Domain;
using Investimentos.Persistence.Context;
using Investimentos.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Investimentos.Persistence
{
    public class TransacaoPersistence : ITransacaoPersistence
    {
        private readonly InvestimentoContext _context;
        public TransacaoPersistence(InvestimentoContext context)
        {
            _context = context;
        }

        public async Task<Transacao> GetTransacaoByIdsAsync(int ativoId, int id)
        {
            IQueryable<Transacao> query = _context.Transacao;

            query = query.AsNoTracking().OrderByDescending(tr => tr.DataCompra)
                         .Where(tr => tr.AtivoId == ativoId
                                       && tr.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Transacao[]> GetTransacoesByAtivoIdAsync(int ativoId)
        {
            IQueryable<Transacao> query = _context.Transacao;

            query = query.AsNoTracking().OrderByDescending(tr => tr.DataCompra)
                         .Where(tr => tr.AtivoId == ativoId);

            return await query.ToArrayAsync();
        }
    }
}