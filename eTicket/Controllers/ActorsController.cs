using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
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

        //Get : Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid) 
            {
                return View(actor);
            }
           _actorService.Add(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
