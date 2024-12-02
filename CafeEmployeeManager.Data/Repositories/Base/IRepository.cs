using CafeEmployeeManager.Core.Base;
using System.Linq.Expressions;

namespace CafeEmployeeManager.Data.Repositories.Base
{
    public interface IRepository<T> where T : CoreDbEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
