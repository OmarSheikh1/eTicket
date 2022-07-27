namespace eTicket.Data.Base
{
    public interface IRepository<T> where T : class,IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task Update(int id, T entity);

        Task DeleteAsync(int id);
    }
}
