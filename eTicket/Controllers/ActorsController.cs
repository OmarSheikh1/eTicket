using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class ActorsController : Controller
    {
        private IActorService _actorService { get; }
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _actorService.GetAllAsync();
            return View(data);
        }

        //Actor/Create
        public IActionResult Create()
        {
            return View();
        }           
    }
}
