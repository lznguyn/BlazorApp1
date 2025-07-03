using MongoDB.Driver;
using System.Linq.Expressions;

namespace BlazorApp1.Data
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(string id, T entity);
        Task<bool> DeleteAsync(string id);
        Task<long> CountAsync();
        Task<long> CountAsync(Expression<Func<T, bool>> filter);
    }
}
