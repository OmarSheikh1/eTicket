using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class OrdersController : Controller
    {
        public IMovieService _movieService { get; }
        public OrdersController(IMovieService movieService )
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }

    public interface IMovieService
    {
    }
}
