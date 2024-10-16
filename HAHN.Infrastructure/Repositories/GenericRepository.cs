using HAHN.Domain.Interfaces;
using HAHN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HAHN.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HahnDbContext _context;
        private readonly DbSet<T> _table;
        public GenericRepository(HahnDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var data =  await _table.FindAsync(id);
            if (data is null)
                return null;
            return data;
        }


        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _table.FindAsync(id);
            if (data != null)
            {
                _table.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var data = await _table.FindAsync(id);
            if (data != null)
            {
                _context.Entry(data).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
