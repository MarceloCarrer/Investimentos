using System.Threading.Tasks;
using Investimentos.Persistence.Context;
using Investimentos.Persistence.Contracts;

namespace Investimentos.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly InvestimentoContext _context;

        public GeralPersistence(InvestimentoContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}