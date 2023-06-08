using Business.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SistemaPrestamos.Controllers
{
    public class EquiposController : Controller
    {
        private readonly IEquipoRepository equipoRepository;

        public EquiposController(IEquipoRepository equipoRepository)
        {
            this.equipoRepository = equipoRepository;
        }

        // GET: EntityEquipo
        public async Task<IActionResult> Index()
        {
            var equipos = await equipoRepository.GetAll();
            return View(equipos);
        }

        // GET: EntityEquipo/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var equipo = await equipoRepository.GetById(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // GET: EntityEquipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityEquipo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntityEquipo equipo)
        {
            if (ModelState.IsValid)
            {
                await equipoRepository.Add(equipo);
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: EntityEquipo/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var equipo = await equipoRepository.GetById(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: EntityEquipo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntityEquipo equipo)
        {
            if (id != equipo.IdEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await equipoRepository.Update(equipo);
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: EntityEquipo/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var equipo = await equipoRepository.GetById(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: EntityEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await equipoRepository.GetById(id);
            if (equipo == null)
            {
                return NotFound();
            }

            await equipoRepository.Delete(equipo);
            return RedirectToAction(nameof(Index));
        }
    }
}
