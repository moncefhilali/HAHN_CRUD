using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAHN.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T entity);
    }
}
