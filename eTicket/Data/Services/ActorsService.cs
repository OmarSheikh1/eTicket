using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Services
{
    public class ActorsService : IActorService
    {
        private AppDbContext _appDbContext { get; }
        public ActorsService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task AddAsync(Actor actor)
        {
           await _appDbContext.Actors.AddAsync(actor);
           await _appDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var data = await _appDbContext.Actors.ToListAsync();
            return data;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var data = await _appDbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return data;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _appDbContext.Update(newActor);
            await _appDbContext.SaveChangesAsync();
            return newActor;
        }
    }
}
