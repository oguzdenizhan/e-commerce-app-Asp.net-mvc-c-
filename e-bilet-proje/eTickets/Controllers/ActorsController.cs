using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _services;

        public ActorsController(IActorsService services)
        {
            _services=services;
            
        }

        public async Task<IActionResult> Index()
        {
            var data = await _services.GetAllAsync();
            return View(data);
        }

        // Actors/create kısmı
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);

            }
            await _services.AddAsync(actor);
            return RedirectToAction(nameof(Index));

        }

        //Actors/details/1 kısmı

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails =  await _services.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }

        //Actors/Edit kısmı
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _services.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //: Actors/Delete kısmı
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _services.DeleteAsync(id);
           
            return RedirectToAction(nameof(Index));
        }
    }
}
