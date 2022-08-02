using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
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
            var producer = await _producerService.GetByIdAsync(id);

            if (producer is null) return View("NotFound");

            return View(producer);
        }

        //Get : Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            //if (!ModelState.IsValid) 
            //{
            //    return View(actor);
            //}
            await _producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _producerService.GetByIdAsync(id);

            if (actor is null) return View("NotFound");

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            await _producerService.Update(id, producer);
            return RedirectToAction(nameof(Index));
        }
    }
}
