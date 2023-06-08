using Business.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Business.Implementations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaPrestamos.Controllers
{
    public class EquiposController : Controller
    {
        private readonly IEquipoRepository equipoRepository;
        private readonly IMarcaRepository marcaRepository;

        public EquiposController(IEquipoRepository equipoRepository, IMarcaRepository marcaRepository)
        {
            this.equipoRepository = equipoRepository;
            this.marcaRepository = marcaRepository;
        }

        // GET: EntityEquipo
        public async Task<IActionResult> Index(string marca, string search)
        {
            var equipos = await equipoRepository.GetAll();
            var marcas = await marcaRepository.GetAll();

            ViewBag.Marcas = marcas;

            if (!string.IsNullOrEmpty(marca))
            {
                equipos = equipos.Where(e => e.Marca.Marca == marca).ToList();
            }

            if (!string.IsNullOrEmpty(search))
            {
                equipos = equipos.Where(e => e.Nombre.Contains(search, StringComparison.OrdinalIgnoreCase)
                                        || e.NumeroSerie.Contains(search, StringComparison.OrdinalIgnoreCase))
                                .ToList();
            }

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

            equipo.Marca = await marcaRepository.GetById(equipo.IdMarca);

            return View(equipo);
        }


        // GET: EntityEquipo/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var marcas = await marcaRepository.GetAll();
            ViewBag.Marcas = new SelectList(marcas, "IdMarca", "Marca");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntityEquipo equipo, int IdMarca)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener la marca seleccionada
                    var marca = await marcaRepository.GetById(IdMarca);
                    if (marca == null)
                    {
                        return NotFound(); // Manejar el caso cuando la marca no existe
                    }

                    // Asignar la marca al equipo
                    equipo.Marca = marca;

                    // Guardar el equipo en la base de datos
                    await equipoRepository.Add(equipo);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    // Manejar cualquier error de guardado
                    // Puedes agregar aquí la lógica de manejo de errores que desees
                    return View(equipo);
                }
            }

            var marcas = await marcaRepository.GetAll();
            ViewBag.Marcas = new SelectList(marcas, "IdMarca", "Marca", equipo.IdMarca);

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
        public async Task<IActionResult> Edit(int id, EntityEquipo equipo)
        {
            var existingEquipo = await equipoRepository.GetById(id);
            if (existingEquipo == null)
            {
                return NotFound();
            }

            // Copiar los valores actualizados al existingEquipo
            existingEquipo.NumeroSerie = equipo.NumeroSerie;
            existingEquipo.Nombre = equipo.Nombre;
            existingEquipo.Descripcion = equipo.Descripcion;
            // ...

            await equipoRepository.Update(existingEquipo);

            return RedirectToAction("Index");
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
        public IActionResult ExportToExcel()
        {
            var equipos = equipoRepository.GetAll().Result;

            // Genera el reporte de Excel utilizando el servicio ExcelService
            var excelService = new ExcelService();
            var excelBytes = excelService.GenerateExcel(equipos);


            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reporte_equipos.xlsx");
        }
    }
}
