using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class CimemasController : Controller
    {
        public AppDbContext _appDbContext { get; }
        public CimemasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var dataProducers = await _appDbContext.Producers.ToListAsync();
            return View();
        }
    }
}
