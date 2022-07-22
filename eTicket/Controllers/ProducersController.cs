using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class ProducersController : Controller
    {
        public AppDbContext _appDbContext { get; }
        public ProducersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _appDbContext.Producers.ToListAsync();
            return View(data);
        }
    }
}
