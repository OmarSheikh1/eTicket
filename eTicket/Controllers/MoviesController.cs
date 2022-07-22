using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class MoviesController : Controller
    {
        public AppDbContext _appDbContext { get; }
        public MoviesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _appDbContext.Movies.ToListAsync();
            return View(data);
        }
    }
}
