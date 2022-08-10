using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class ProducerService : Repository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
