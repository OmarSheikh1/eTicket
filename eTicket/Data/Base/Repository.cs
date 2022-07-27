using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTicket.Data.Base
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {

        private AppDbContext _appDbContext { get; }
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _appDbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _appDbContext.Set<T>().ToListAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _appDbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return data;
        }

        public async Task Update(int id, T entity)
        {
           EntityEntry entityEntry = _appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
