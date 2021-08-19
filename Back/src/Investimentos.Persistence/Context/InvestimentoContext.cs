using Investimentos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Investimentos.Persistence.Context
{
    public class InvestimentoContext : DbContext
    {
        public InvestimentoContext(DbContextOptions<InvestimentoContext> options) : base(options){}

        public DbSet<Ativo> Ativo { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
    }
}