using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class CinemasController : Controller
    {
        public AppDbContext _appDbContext { get; }
        public CinemasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _appDbContext.Cinemas.ToListAsync();
            return View(data);
        }
    }
}
