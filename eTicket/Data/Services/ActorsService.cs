using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Services
{
    public class ActorsService : Repository<Actor>, IActorService
    {
        public ActorsService(AppDbContext appDbContext) : base(appDbContext) { }
             
    }
}
