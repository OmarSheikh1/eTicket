using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
