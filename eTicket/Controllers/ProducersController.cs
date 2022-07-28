using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    public class ProducersController : Controller
    {
        public IProducerService _producerService { get; }

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _producerService.GetAllAsync();
            return View(data);
        }


        //Get producers/details/1

        public async Task<IActionResult> Details(int id)
        {
            var actor = await _producerService.GetByIdAsync(id);

            if (actor is null) return View("NotFound");

            return View(actor);
        }
    }
}
