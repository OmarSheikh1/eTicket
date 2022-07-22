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


        public void Add(Actor actor)
        {
            throw new NotImplementedException();
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

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
