using Business.Implementations;
using Business.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SistemaPrestamos.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaRepository marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }

        // GET: EntityMarca
        public async Task<IActionResult> Index(string tipo)
        {
            IQueryable<EntityMarca> marcas = (await marcaRepository.GetAll()).AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
            {
                // Aplicar filtro por tipo de marca
                if (Enum.TryParse<TipoHerramienta>(tipo, out var tipoHerramienta))
                {
                    marcas = marcas.Where(m => m.Tipo == tipoHerramienta);
                }
            }

            List<EntityMarca> marcasList = marcas.ToList();

            return View(marcasList);
        }


        // GET: EntityMarca/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var marca = await marcaRepository.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // GET: EntityMarca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntityMarca/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntityMarca marcas)
        {
            if (ModelState.IsValid)
            {
                await marcaRepository.Add(marcas);
                return RedirectToAction(nameof(Index));
            }
            return View(marcas);
        }

        // GET: EntityMarca/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var marca = await marcaRepository.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: EntityMarca/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntityMarca marcas)
        {
            if (id != marcas.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await marcaRepository.Update(marcas);
                return RedirectToAction(nameof(Index));
            }
            return View(marcas);
        }

        // GET: EntityMarca/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var marca = await marcaRepository.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: EntityMarca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await marcaRepository.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }

            await marcaRepository.Delete(marca);
            return RedirectToAction(nameof(Index));
        }
    }
}
