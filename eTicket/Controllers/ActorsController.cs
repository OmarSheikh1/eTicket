using eTicket.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class ActorsController : Controller
    {
        public AppDbContext _appDbContext { get; }
        public ActorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {
            var data = _appDbContext.Actors.ToList();
            return View(data);
        }
    }
}
