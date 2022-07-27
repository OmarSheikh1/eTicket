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
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            //if (!ModelState.IsValid) 
            //{
            //    return View(actor);
            //}
            await _actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor is null) return View("NotFound");

            return View(actor);
        }

        //Get: Actors/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor is null) return View("NotFound");

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            await _actorService.Update(id,actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor is null) return View("NotFound");

            return View(actor);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}

            var actor = await _actorService.GetByIdAsync(id);

            if (actor is null) return View("NotFound");

            await _actorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
