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
        Task<T?> CreateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T?> UpdateAsync(int id, T entity);
    }
}
