using System.Linq.Expressions;

namespace eTicket.Data.Base
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);

        Task Update(int id, T entity);

        Task DeleteAsync(int id);
    }
}
