using Business.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SistemaPrestamos.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly IPrestamoRepository prestamoRepository;

        public PrestamosController(IPrestamoRepository prestamoRepository)
        {
            this.prestamoRepository = prestamoRepository;
        }

        // GET: EntityPrestamo
        public async Task<IActionResult> Index()
        {
            var prestamos = await prestamoRepository.GetAll();
            return View(prestamos);
        }

        // GET: EntityPrestamo/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var prestamo = await prestamoRepository.GetById(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return View(prestamo);
        }

        // GET: EntityPrestamo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityPrestamo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntityPrestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                await prestamoRepository.Add(prestamo);
                return RedirectToAction(nameof(Index));
            }
            return View(prestamo);
        }

        // GET: EntityPrestamo/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var prestamo = await prestamoRepository.GetById(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return View(prestamo);
        }

        // POST: EntityPrestamo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntityPrestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await prestamoRepository.Update(prestamo);
                return RedirectToAction(nameof(Index));
            }
            return View(prestamo);
        }

        // GET: EntityPrestamo/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var prestamo = await prestamoRepository.GetById(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return View(prestamo);
        }

        // POST: EntityPrestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await prestamoRepository.GetById(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            await prestamoRepository.Delete(prestamo);
            return RedirectToAction(nameof(Index));
        }


    }
}
