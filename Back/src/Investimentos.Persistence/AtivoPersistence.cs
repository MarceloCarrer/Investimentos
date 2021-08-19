using System.Linq;
using System.Threading.Tasks;
using Investimentos.Domain;
using Investimentos.Persistence.Context;
using Investimentos.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Investimentos.Persistence
{
    public class AtivoPersistence : IAtivoPersistence
    {
        private readonly InvestimentoContext _context;
        public AtivoPersistence(InvestimentoContext context)
        {
            _context = context;
        }

        public async Task<Ativo[]> GetAllAtivosBySiglaAsync(string sigla)
        {
            IQueryable<Ativo> query = _context.Ativo
                .Include(at => at.Transacao);
            
            query = query.AsNoTracking().OrderBy(at => at.Sigla)
                         .Where(at => at.Sigla.ToLower()
                         .Contains(sigla.ToLower()));
            
            return await query.ToArrayAsync();
        }

        public async Task<Ativo[]> GetAllAtivosAsync()
        {
            IQueryable<Ativo> query = _context.Ativo
                .Include(at => at.Transacao);

            query = query.AsNoTracking().OrderBy(at => at.Sigla);

            return await query.ToArrayAsync();
        }

        public async Task<Ativo> GetAtivoByIdAsync(int ativoId)
        {
            IQueryable<Ativo> query = _context.Ativo
                .Include(at => at.Transacao);

            query = query.AsNoTracking().OrderBy(at => at.Sigla)
                         .Where(at => at.Id == ativoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}